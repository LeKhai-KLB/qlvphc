﻿using IdentityService.Application.Common.Interfaces;
using IdentityService.Application.Common.Models;
using IdentityService.Application.Common.Models.AuthModels;
using IdentityService.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static Shared.Common.Constants.Permissions;

namespace IdentityService.API.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _config;
        private UserManager<User> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private IMailService _mailService;

        public AuthService(IConfiguration config,
                            UserManager<User> userManager,
                            IMailService mailService,
                            RoleManager<IdentityRole> roleManager)
        {
            _config = config;
            _userManager = userManager;
            _roleManager = roleManager;
            _mailService = mailService;
        }

        //Login User
        public async Task<ResponseManager> LoginUser(AuthUser model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);

            if (user == null || user.UserName != model.UserName)
            {
                return new ResponseManager
                {
                    Message = "Tên đăng nhập không chính xác!",
                    IsSuccess = false
                };
            }
            else
            {
                var result = await _userManager.CheckPasswordAsync(user, model.Password);
                if (!result)
                    return new ResponseManager
                    {
                        Message = "Mật khẩu không chính xác!",
                        IsSuccess = false
                    };


                var userRole = new List<string>(await _userManager.GetRolesAsync(user));
                //Generate Token JWT
                var Token = await GenerateToken(user);

                return new ResponseManager
                {
                    Message = Token,
                    Data = user.Id,
                    IsSuccess = true
                };
            }
        }

        //ConfirmEmail
        public async Task<ResponseManager> ConfirmEmail(string userId, string token)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return new ResponseManager
                {
                    IsSuccess = false,
                    Message = "User not found"
                };
            }

            var decodedToken = WebEncoders.Base64UrlDecode(token);
            var normalToken = Encoding.UTF8.GetString(decodedToken);

            var result = await _userManager.ConfirmEmailAsync(user, normalToken);

            if (result.Succeeded)
            {
                user.EmailConfirmed = true;
                await _userManager.UpdateAsync(user);

                return new ResponseManager
                {
                    Message = "Email confirmed successfully!",
                    IsSuccess = true,
                };
            }

            return new ResponseManager
            {
                IsSuccess = false,
                Message = "Email did not confirm",
                Errors = result.Errors.ToArray()
            };
        }

        //Forget Password
        public async Task<ResponseManager> ForgetPassword(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                return new ResponseManager
                {
                    IsSuccess = false,
                    Message = "No user associated with email",
                };

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var encodedToken = Encoding.UTF8.GetBytes(token);
            var validToken = WebEncoders.Base64UrlEncode(encodedToken);
            string pass = "Tester@123";
            string url = $"{_config["AppUrl"]}/api/Auth/ResetPassword?Email={email}&Token={validToken}&NewPassword={pass}&ConfirmPassword={pass}";

            var mailContent = new MailRequest
            {
                ToEmail = email,
                Subject = "Reset Password",
                Body = "<h1>Follow the instructions to reset your password</h1>" +
                $"<p>To reset your password, <br><br> 1. Copy the Link :  <a href='{url}'>{url}</a><br><br> 2. Navigate to API Testing Tools(Postman)<br><br> 3. Set the Method to 'POST' <br><br> 4. Make a Request <br><br> or Use SWAGGER <br><br> <strong>Reset Token : {validToken}</strong></p>"
            };

            await _mailService.SendEmailAsync(mailContent);

            return new ResponseManager
            {
                IsSuccess = true,
                Message = "Reset password URL has been sent to the email successfully!"
            };
        }

        //Reset Password
        public async Task<ResponseManager> ResetPassword(ResetPasswordModel model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user == null)
                return new ResponseManager
                {
                    IsSuccess = false,
                    Message = "Tài khoản không tồn tại hoặc có lỗi xảy ra!",
                };

            if (!await _userManager.CheckPasswordAsync(user, model.OldPassword))
                return new ResponseManager
                {
                    IsSuccess = false,
                    Message = "Mật khẩu cũ không chính xác!",
                };

            if (model.NewPassword != model.ConfirmPassword)
                return new ResponseManager
                {
                    IsSuccess = false,
                    Message = "Mật khẩu xác nhận mới chưa chính xác!",
                };

            //var decodedToken = WebEncoders.Base64UrlDecode(model.Token);
            //string normalToken = Encoding.UTF8.GetString(decodedToken);

            //var result = await _userManager.ResetPasswordAsync(user, normalToken, model.NewPassword);

            var result = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);

            if (result.Succeeded)
                return new ResponseManager
                {
                    Message = "Đổi mật khẩu thành công!",
                    IsSuccess = true,
                };

            return new ResponseManager
            {
                Message = "Có lỗi xảy ra. Vui lòng thử lại hoặc liên hệ với quản trị viên.",
                IsSuccess = false,
                Errors = result.Errors.Select(e => e.Description),
            };
        }

        //Token Genereator
        private async Task<string> GenerateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var roles = await _userManager.GetRolesAsync(user).ConfigureAwait(false);

            var userRoles = roles.Select(r => new Claim(ClaimTypes.Role, r)).ToArray();

            var userClaims = await _userManager.GetClaimsAsync(user).ConfigureAwait(false);

            var roleClaims = new List<Claim>();

            foreach (var roleName in userRoles)
            {
                var role = await _roleManager.FindByNameAsync(roleName.Value);

                if (role != null)
                {
                    var tempClaims = await _roleManager.GetClaimsAsync(role);
                    roleClaims.AddRange(tempClaims);
                }
            }

            // Include role and permission claims in the token
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.UserName),
            }.Union(userClaims).Union(roleClaims).Union(userRoles);

            var tokenClaims = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenClaims);
            return tokenString;
        }
    }
}
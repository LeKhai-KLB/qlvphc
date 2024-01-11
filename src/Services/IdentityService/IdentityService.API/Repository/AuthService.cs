using IdentityService.API.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using IdentityService.API.Models;
using IdentityService.API.Models.AuthModels;
using IdentityService.API.Models.UserModels;

namespace IdentityService.API.Repository
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _config;
        private UserManager<IdentityUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private IMailService _mailService;
        private readonly IUserService _useService;

        public AuthService(IConfiguration config,
                            UserManager<IdentityUser> userManager,
                            IMailService mailService,
                            IUserService userService,
                            RoleManager<IdentityRole> roleManager)
        {
            _config = config;
            _userManager = userManager;
            _roleManager = roleManager;
            _mailService = mailService;
            _useService = userService;
        }

        //Register User
        public async Task<ResponseManager> RegisterUser(RegisterUser model)
        {
            //user creation
            var createdUser = await _useService.CreateUser(model);

            if (createdUser.IsSuccess != false)
            {
                return new ResponseManager
                {
                    IsSuccess = true,
                    Message = "User created successfully! Please confirm the your Email!",
                };
            }

            return new ResponseManager
            {
                IsSuccess = false,
                Message = "User Already Registered, Try Login"
            };
        }

        //Login User
        public async Task<ResponseManager> LoginUser(AuthUser model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);

            if (user.UserName != model.UserName)
            {
                return new ResponseManager
                {
                    Message = "There is no user with that Username! ",
                    IsSuccess = false,
                };
            }
            else
            {
                var result = await _userManager.CheckPasswordAsync(user, model.Password);
                if (!result)
                    return new ResponseManager
                    {
                        Message = "Invalid password",
                        IsSuccess = false,
                    };


                var userRole = new List<string>(await _userManager.GetRolesAsync(user));
                //Generate Token JWT
                var Token = await GenerateToken(user);

                return new ResponseManager
                {
                    Message = Token,
                    IsSuccess = true,
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
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
                return new ResponseManager
                {
                    IsSuccess = false,
                    Message = "No user associated with email",
                };

            if (model.NewPassword != model.ConfirmPassword)
                return new ResponseManager
                {
                    IsSuccess = false,
                    Message = "Password doesn't match its confirmation",
                };

            var decodedToken = WebEncoders.Base64UrlDecode(model.Token);
            string normalToken = Encoding.UTF8.GetString(decodedToken);

            var result = await _userManager.ResetPasswordAsync(user, normalToken, model.NewPassword);

            if (result.Succeeded)
                return new ResponseManager
                {
                    Message = "Password has been reset successfully!",
                    IsSuccess = true,
                };

            return new ResponseManager
            {
                Message = "Something went wrong",
                IsSuccess = false,
                Errors = result.Errors.Select(e => e.Description),
            };
        }

        //Token Genereator
        private async Task<string> GenerateToken(IdentityUser user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var roles = await _userManager.GetRolesAsync(user);

            var userRoles = roles.Select(r => new Claim(ClaimTypes.Role, r)).ToArray();

            var userClaims = await _userManager.GetClaimsAsync(user).ConfigureAwait(false);

            var roleClaims = await _userManager.GetClaimsAsync(user).ConfigureAwait(false);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.UserName)

            }.Union(userClaims).Union(roleClaims).Union(userRoles);

            var tokenClaims = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials);

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenClaims);
            return tokenString;
        }
    }
}
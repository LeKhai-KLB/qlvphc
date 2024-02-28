using AutoMapper;
using IdentityService.Application.Common.Interfaces;
using IdentityService.Application.Common.Models.AuthModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdentityService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _auth;
        private readonly IMapper _mapper;
        private readonly IMailService _mailService;
        private readonly IConfiguration _config;

        public AuthController(IAuthService AuthService, IMapper mapper, IMailService mailService, IConfiguration configuration)
        {
            _auth = AuthService;
            _mapper = mapper;
            _mailService = mailService;
            _config = configuration;
        }

        // api/auth/Authenticate
        [HttpPost("Authenticate")]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate([FromBody] AuthUser model)
        {
            if (ModelState.IsValid)
            {
                var result = await _auth.LoginUser(model);

                if (result.IsSuccess)
                {
                    return Ok(result);
                }

                return BadRequest(result);
            }

            return BadRequest("Some properties are not valid");
        }

        // api/auth/ForgetPassword
        [HttpPost("ForgetPassword")]
        public async Task<IActionResult> ForgetPassword(string email)
        {
            if (string.IsNullOrEmpty(email))
                return NotFound();

            var result = await _auth.ForgetPassword(email);

            if (result.IsSuccess)
                return Ok(result); // 200

            return BadRequest(result); // 400
        }

        // api/auth/ResetPassword
        [HttpPost("ResetPassword")]
        //[Description("This Method will not work in Swagger, Check your Registered Mail to get the Request link, Make a request using PostMan or any API Testing Tools with the Request Link")]
        public async Task<IActionResult> ResetPassword([FromQuery] ResetPasswordModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _auth.ResetPassword(model);

                if (result.IsSuccess)
                    return Ok(result);

                return BadRequest(result);
            }

            return BadRequest("Some properties are not valid");
        }
    }
}
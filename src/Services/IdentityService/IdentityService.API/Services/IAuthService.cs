using IdentityService.API.Models;
using IdentityService.API.Models.AuthModels;
using IdentityService.API.Models.UserModels;

namespace IdentityService.API.Services
{
    public interface IAuthService
    {
        Task<ResponseManager> RegisterUser(RegisterUser model);

        Task<ResponseManager> LoginUser(AuthUser model);

        Task<ResponseManager> ConfirmEmail(string userId, string token);

        Task<ResponseManager> ForgetPassword(string email);

        Task<ResponseManager> ResetPassword(ResetPasswordModel model);
    }
}
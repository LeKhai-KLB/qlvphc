using IdentityService.Application.Common.Models;
using IdentityService.Application.Common.Models.AuthModels;

namespace IdentityService.Application.Common.Interfaces
{
    public interface IAuthService
    {
        Task<ResponseManager> LoginUser(AuthUser model);

        Task<ResponseManager> ConfirmEmail(string userId, string token);

        Task<ResponseManager> ForgetPassword(string email);

        Task<ResponseManager> ResetPassword(ResetPasswordModel model);
    }
}
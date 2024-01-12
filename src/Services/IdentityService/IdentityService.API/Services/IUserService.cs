using IdentityService.API.Models;
using IdentityService.API.Models.UserModels;

namespace IdentityService.API.Services
{
    public interface IUserService
    {
        Task<ResponseManager> GetUsers();

        Task<ResponseManager> GetUserbyId(string id);

        Task<ResponseManager> CreateUser(RegisterUser model);

        Task<ResponseManager> UpdateUser(string id, UpdateUser user);

        Task<ResponseManager> DeleteUser(string id);

        public bool IsExist(string id);
    }
}
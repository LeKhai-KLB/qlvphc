using IdentityService.Application.Parameters.Users;
using IdentityService.Domain.Entities;
using Shared.SeedWord;

namespace IdentityService.Application.Common.Interfaces;

public interface IUserRepository
{
    Task<User> GetByIdAsync(object id);

    Task<PageList<User>> GetPagedAsync(UserParameter parameter, List<string> propertiesToCheck);

    Task<bool> UpdateAsync(User entity);

    void Detach(User entity);
}
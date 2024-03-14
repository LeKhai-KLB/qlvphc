using CatalogService.Application.Common.Models.Users;

namespace CatalogService.Application.Common.Interfaces;

public interface IUserServiceClient
{
    Task<UserDto> GetUserAsync(Guid userId);
}
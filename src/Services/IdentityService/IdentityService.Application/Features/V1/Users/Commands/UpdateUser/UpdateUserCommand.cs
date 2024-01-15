using MediatR;
using Microsoft.AspNetCore.Identity;
using Shared.SeedWord;

namespace IdentityService.Application.Features.V1.Users.Commands.UpdateUser;

public class UpdateUserCommand : IRequest<ApiResult<IdentityUser>>
{
    public string Id { get; private set; }

    public string? Username { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public void SetId(string id)
    {
        Id = id;
    }
}
using MediatR;
using Microsoft.AspNetCore.Identity;
using Shared.SeedWord;

namespace IdentityService.Application.Features.V1.Users.Commands.CreateUser;

public class CreateUserCommand : IRequest<ApiResult<IdentityUser>>
{
    public string Username { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public string ConfirmPassword { get; set; }

    public string PhoneNumber { get; set; }

    public string Role { get; set; }
}
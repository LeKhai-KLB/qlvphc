using MediatR;
using Shared.SeedWord;

namespace IdentityService.Application.Features.V1.Users.Commands.DeleteUser;

public class DeleteUserCommand : IRequest<ApiResult<bool>>
{
    public string Id { get; private set; }

    public DeleteUserCommand(string id)
    {
        Id = id;
    }
}
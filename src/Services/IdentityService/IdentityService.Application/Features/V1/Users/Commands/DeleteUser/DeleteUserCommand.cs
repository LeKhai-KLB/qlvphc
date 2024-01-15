using MediatR;

namespace IdentityService.Application.Features.V1.Users.Commands.DeleteUser;

public class DeleteUserCommand : IRequest<bool>
{
    public string Id { get; private set; }

    public DeleteUserCommand(string id)
    {
        Id = id;
    }
}
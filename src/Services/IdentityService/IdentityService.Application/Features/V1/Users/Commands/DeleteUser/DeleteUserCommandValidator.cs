using IdentityService.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Serilog;

namespace IdentityService.Application.Features.V1.Users.Commands.DeleteUser;

public class DeleteUserCommandValidator : IRequestHandler<DeleteUserCommand, bool>
{
    private readonly ILogger _logger;
    private readonly UserManager<User> _userManager;
    private const string MethodName = "DeleteUserCommandValidator";

    public DeleteUserCommandValidator(UserManager<User> userManager, ILogger logger)
    {
        _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var user = await _userManager.FindByIdAsync(request.Id);
        try
        {
            await _userManager.DeleteAsync(user);

            _logger.Information($"END: {MethodName}");

            return true;
        }
        catch
        {
            return false;
        }
    }
}
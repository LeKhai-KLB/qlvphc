using IdentityService.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Serilog;
using Shared.SeedWord;

namespace IdentityService.Application.Features.V1.Users.Commands.DeleteUser;

public class DeleteUserCommandValidator : IRequestHandler<DeleteUserCommand, ApiResult<bool>>
{
    private readonly ILogger _logger;
    private readonly UserManager<User> _userManager;
    private const string MethodName = "DeleteUserCommandValidator";

    public DeleteUserCommandValidator(UserManager<User> userManager, ILogger logger)
    {
        _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<ApiResult<bool>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var user = await _userManager.FindByIdAsync(request.Id);
        try
        {
            await _userManager.DeleteAsync(user);

            _logger.Information($"END: {MethodName}");

            return new ApiSuccessResult<bool>(true, "Xóa cán bộ thành công.");
        }
        catch
        {
            return new ApiErrorResult<bool>("Xóa cán bộ không thành công. Vui lòng thử lại hoặc liên hệ với quản trị viên!");
        }
    }
}
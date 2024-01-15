using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Serilog;
using Shared.SeedWord;

namespace IdentityService.Application.Features.V1.Users.Commands.UpdateUser;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, ApiResult<IdentityUser>>
{
    private readonly IMapper _mapper;
    private readonly ILogger _logger;
    private readonly UserManager<IdentityUser> _userManager;
    private const string MethodName = "UpdateUserCommandHandler";

    public UpdateUserCommandHandler(IMapper mapper, UserManager<IdentityUser> userManager, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<ApiResult<IdentityUser>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        if (request == null)
        {
            var findUser = await _userManager.FindByIdAsync(request.Id);
            if (findUser != null)
            {
                try
                {
                    findUser.UserName = request.Username;
                    findUser.Email = request.Email;
                    findUser.PhoneNumber = request.PhoneNumber;
                    var up = _userManager.UpdateAsync(findUser);

                    if (up.Result.Succeeded)
                    {
                        var updatedUser = await _userManager.FindByIdAsync(findUser.Id);
                        var updatedUserResponse = new IdentityUser
                        {
                            Id = request.Id,
                            UserName = updatedUser.UserName,
                            NormalizedUserName = updatedUser.Email,
                            Email = updatedUser.Email,
                            NormalizedEmail = updatedUser.Email,
                            PhoneNumber = updatedUser.PhoneNumber
                        };

                        return new ApiSuccessResult<IdentityUser>(updatedUserResponse);
                    }
                    else
                    {
                        _logger.Error("Update user not successful");
                        return new ApiErrorResult<IdentityUser>("Update user not successful");
                    }
                }
                catch (Exception ex)
                {
                    _logger.Error(ex.Message);
                    return new ApiErrorResult<IdentityUser>(ex.Message);
                }
            }

            _logger.Error("User not found.");
            return new ApiErrorResult<IdentityUser>("User not found..");
        }

        _logger.Information($"END: {MethodName}");

        //- User Exist
        _logger.Error("Updating property should not null.");
        return new ApiErrorResult<IdentityUser>("Updating property should not null.");
    }
}
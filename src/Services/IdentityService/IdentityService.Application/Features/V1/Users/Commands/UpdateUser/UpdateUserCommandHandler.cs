using AutoMapper;
using IdentityService.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Serilog;
using Shared.SeedWord;

namespace IdentityService.Application.Features.V1.Users.Commands.UpdateUser;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, ApiResult<User>>
{
    private readonly IMapper _mapper;
    private readonly ILogger _logger;
    private readonly UserManager<User> _userManager;
    private const string MethodName = "UpdateUserCommandHandler";

    public UpdateUserCommandHandler(IMapper mapper, UserManager<User> userManager, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<ApiResult<User>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var findUser = await _userManager.FindByIdAsync(request.Id);
        if (findUser != null)
        {
            try
            {
                findUser.UserName = request.Username;
                findUser.Email = request.Email;
                findUser.PhoneNumber = request.PhoneNumber;
                findUser.HoTen = request.HoTen;
                findUser.NgaySinh = request.NgaySinh;
                findUser.CCCD = request.CCCD;
                findUser.GioiTinh = request.GioiTinh;
                findUser.DiaChi = request.DiaChi;
                findUser.GhiChu = request.GhiChu;
                var up = _userManager.UpdateAsync(findUser);

                if (up.Result.Succeeded)
                {
                    var updatedUser = await _userManager.FindByIdAsync(findUser.Id);
                    var updatedUserResponse = new User
                    {
                        Id = request.Id,
                        UserName = updatedUser.UserName,
                        NormalizedUserName = updatedUser.Email,
                        Email = updatedUser.Email,
                        NormalizedEmail = updatedUser.Email,
                        PhoneNumber = updatedUser.PhoneNumber,
                        HoTen = request.HoTen,
                        NgaySinh = request.NgaySinh,
                        CCCD = request.CCCD,
                        GioiTinh = request.GioiTinh,
                        DiaChi = request.DiaChi,
                        GhiChu = request.GhiChu
                    };

                    return new ApiSuccessResult<User>(updatedUserResponse);
                }
                else
                {
                    _logger.Error("Update user not successful");
                    return new ApiErrorResult<User>("Update user not successful");
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return new ApiErrorResult<User>(ex.Message);
            }
        }

        _logger.Error("User not found.");

        _logger.Information($"END: {MethodName}");

        return new ApiErrorResult<User>("User not found..");
    }
}
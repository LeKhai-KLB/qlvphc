using AutoMapper;
using IdentityService.Application.Common.Models.UserModels;
using IdentityService.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Serilog;
using Shared.SeedWord;
using static Shared.Common.Constants.Permissions;

namespace IdentityService.Application.Features.V1.Users.Commands.UpdateUser;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, ApiResult<UserDto>>
{
    private readonly IMapper _mapper;
    private readonly ILogger _logger;
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private const string MethodName = "UpdateUserCommandHandler";

    public UpdateUserCommandHandler(IMapper mapper, UserManager<User> userManager, RoleManager<IdentityRole> roleManager, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        _roleManager = roleManager ?? throw new ArgumentNullException(nameof(roleManager));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<ApiResult<UserDto>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var findUser = await _userManager.FindByIdAsync(request.Id.ToString());
        if (findUser != null)
        {
            try
            {
                if (request.Role != null)
                {
                    var roleCheck = await _roleManager.RoleExistsAsync(request.Role);
                    if (roleCheck)
                    {
                        _mapper.Map(request, findUser);
                        var result = await _userManager.UpdateAsync(findUser);
                        if (result.Succeeded)
                        {
                            var updatedUser = await _userManager.FindByIdAsync(findUser.Id);
                            var userDto = _mapper.Map<UserDto>(updatedUser);

                            try
                            {
                                var currentRoles = await _userManager.GetRolesAsync(updatedUser);

                                result = await _userManager.RemoveFromRolesAsync(updatedUser, currentRoles);
                                if (result.Succeeded)
                                {
                                    await _userManager.AddToRoleAsync(updatedUser, request.Role);
                                    userDto.Role = request.Role;

                                    return new ApiSuccessResult<UserDto>(userDto, "Cập nhật thông tin cán bộ thành công!");
                                }
                                else
                                {
                                    _logger.Error($"Cập nhật thông tin cán bộ không thành công: {string.Join(" | ", result.Errors.Select(x => x.Description))}. Vui lòng thử lại hoặc liên hệ với quản trị viên");
                                    return new ApiErrorResult<UserDto>($"Cập nhật thông tin cán bộ không thành công: {string.Join(" | ", result.Errors.Select(x => x.Description))}. Vui lòng thử lại hoặc liên hệ với quản trị viên");
                                }
                            }
                            catch (Exception addToRoleException)
                            {
                                _logger.Error($"Có lỗi xảy ra trong quá trình cập nhật chức vụ cho cán bộ: {addToRoleException.Message}");
                                return new ApiErrorResult<UserDto>($"Có lỗi xảy ra trong quá trình cập nhật chức vụ cho cán bộ: {addToRoleException.Message}. Vui lòng thử lại hoặc liên hệ với quản trị viên");
                            }
                        }
                        else
                        {
                            _logger.Error($"Cập nhật thông tin cán bộ không thành công: {string.Join(" | ", result.Errors.Select(x => x.Description))}. Vui lòng thử lại hoặc liên hệ với quản trị viên");
                            return new ApiErrorResult<UserDto>($"Cập nhật thông tin cán bộ không thành công: {string.Join(" | ", result.Errors.Select(x => x.Description))}. Vui lòng thử lại hoặc liên hệ với quản trị viên");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return new ApiErrorResult<UserDto>($"Có lỗi xảy ra trong quá trình cập nhật thông tin cán bộ: { ex.Message }. Vui lòng thử lại hoặc liên hệ với quản trị viên");
            }
        }

        _logger.Error("Cán bộ này không tồn tại.");

        _logger.Information($"END: {MethodName}");

        return new ApiErrorResult<UserDto>("Cán bộ này không tồn tại.");
    }
}
using System.Data;
using AutoMapper;
using IdentityService.Application.Common.Models.UserModels;
using IdentityService.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Serilog;
using Shared.SeedWord;

namespace IdentityService.Application.Features.V1.Users.Commands.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, ApiResult<UserDto>>
{
    private readonly IMapper _mapper;
    private readonly ILogger _logger;
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private const string MethodName = "CreateUserCommandHandler";

    public CreateUserCommandHandler(IMapper mapper, UserManager<User> userManager, RoleManager<IdentityRole> roleManager, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        _roleManager = roleManager ?? throw new ArgumentNullException(nameof(roleManager));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<ApiResult<UserDto>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        if (request == null)
        {
            _logger.Error("Lỗi xảy ra. Bạn cần nhập đầy đủ những thông tin yêu cầu.");
            return new ApiErrorResult<UserDto>("Lỗi xảy ra. Bạn cần nhập đầy đủ những thông tin yêu cầu.");
        }

        if (request.Password != request.ConfirmPassword)
        {
            _logger.Error("Mật khẩu và mật khẩu xác nhận không trùng khớp.");
            return new ApiErrorResult<UserDto>("Mật khẩu và mật khẩu xác nhận không trùng khớp.");
        }

        //Is User Exist
        var userFound = await _userManager.FindByEmailAsync(request.Email);

        //-Not Exists
        if (userFound == null)
        {
            var identityUser = _mapper.Map<User>(request);

            try
            {
                if (request.Role != null)
                {
                    var roleCheck = await _roleManager.RoleExistsAsync(request.Role);
                    if (roleCheck)
                    {
                        var result = await _userManager.CreateAsync(identityUser, request.Password);
                        if (result.Succeeded)
                        {
                            try
                            {
                                await _userManager.AddToRoleAsync(identityUser, request.Role);

                                var userDto = _mapper.Map<UserDto>(identityUser);
                                userDto.Role = request.Role;

                                return new ApiSuccessResult<UserDto>(userDto, "Tạo cán bộ thành công!");
                            }
                            catch (Exception addToRoleException)
                            {
                                await _userManager.DeleteAsync(identityUser);

                                _logger.Error($"Có lỗi xảy ra trong quá trình thêm chức vụ cho cán bộ: {addToRoleException.Message}");
                                return new ApiErrorResult<UserDto>($"Có lỗi xảy ra trong quá trình thêm chức vụ cho cán bộ: {addToRoleException.Message}. Vui lòng thử lại hoặc liên hệ với quản trị viên");
                            }
                        }
                        else
                        {
                            _logger.Error("Có lỗi xảy ra trong quá trình tạo cán bộ.");
                            return new ApiErrorResult<UserDto>($"Có lỗi xảy ra trong quá trình tạo cán bộ: { string.Join(" | ", result.Errors.Select(x => x.Description)) }. Vui lòng thử lại hoặc liên hệ với quản trị viên");
                        }
                    }
                    else
                    {
                        _logger.Error("Chức vụ này không tồn tại. Vui lòng thử lại hoặc liên hệ với quản trị viên");
                        return new ApiErrorResult<UserDto>("Chức vụ này không tồn tại. Vui lòng thử lại hoặc liên hệ với quản trị viên");
                    }
                }
            }
            catch (DBConcurrencyException ex)
            {
                await _userManager.DeleteAsync(identityUser);

                _logger.Error(ex.Message);
                return new ApiErrorResult<UserDto>($"Có lỗi xảy ra trong quá trình tạo cán bộ: { ex.Message }. Vui lòng thử lại hoặc liên hệ với quản trị viên");
            }
        }

        _logger.Information($"END: {MethodName}");

        //- User Exist
        _logger.Error("Cán bộ đã tồn tại.");
        return new ApiErrorResult<UserDto>("Cán bộ đã tồn tại.");
    }
}
using System.Data;
using AutoMapper;
using IdentityService.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Serilog;
using Shared.SeedWord;

namespace IdentityService.Application.Features.V1.Users.Commands.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, ApiResult<User>>
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

    public async Task<ApiResult<User>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        if (request == null)
        {
            _logger.Error("Data provided is NULL.");
            return new ApiErrorResult<User>("Data provided is NULL.");
        }

        if (request.Password != request.ConfirmPassword)
        {
            _logger.Error("Confirm password doesn't match the password.");
            return new ApiErrorResult<User>("Confirm password doesn't match the password.");
        }

        //Is User Exist
        var userFound = await _userManager.FindByEmailAsync(request.Email);

        //-Not Exists
        if (userFound == null)
        {
            var identityUser = new User
            {
                Email = request.Email,
                UserName = request.Username,
                NormalizedUserName = request.Username.Normalize(),
                NormalizedEmail = request.Email.Normalize(),
                PhoneNumber = request.PhoneNumber,
                HoTen = request.HoTen,
                NgaySinh = request.NgaySinh,
                CCCD = request.CCCD,
                GioiTinh = request.GioiTinh,
                DiaChi = request.DiaChi,
                GhiChu = request.GhiChu
            };

            try
            {
                var result = await _userManager.CreateAsync(identityUser, request.Password);

                if (result.Succeeded)
                {
                    //Setting Roles
                    if (request.Role != null)
                    {
                        var roleCheck = await _roleManager.RoleExistsAsync(request.Role);
                        if (roleCheck != true)
                        {
                            await _userManager.AddToRoleAsync(identityUser, Convert.ToString("Guest"));
                        }
                        else
                        {
                            await _userManager.AddToRoleAsync(identityUser, Convert.ToString(request.Role));
                        }
                    }
                    else
                    {
                        await _userManager.AddToRoleAsync(identityUser, Convert.ToString("Guest"));
                    }

                    return new ApiSuccessResult<User>(identityUser);
                }
                else
                {
                    _logger.Error("Error when creating user.");
                    return new ApiErrorResult<User>($"Error when creating user: { string.Join(" | ", result.Errors.Select(x => x.Description)) }");
                }
            }
            catch (DBConcurrencyException ex)
            {
                _logger.Error(ex.Message);
                return new ApiErrorResult<User>(ex.Message);
            }
        }

        _logger.Information($"END: {MethodName}");

        //- User Exist
        _logger.Error("User existed.");
        return new ApiErrorResult<User>("User existed.");
    }
}
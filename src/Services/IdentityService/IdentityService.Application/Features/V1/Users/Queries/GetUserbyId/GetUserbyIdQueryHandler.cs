using AutoMapper;
using IdentityService.Application.Common.Models.UserModels;
using IdentityService.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Serilog;
using Shared.SeedWord;

namespace IdentityService.Application.Features.V1.Users.Queries.GetUserbyId;

public class GetUserbyIdQueryHandler : IRequestHandler<GetUserbyIdQuery, ApiResult<UserDto>>
{
    private readonly IMapper _mapper;
    private readonly ILogger _logger;
    private readonly UserManager<User> _userManager;
    private const string MethodName = "GetUsersQueryHandler";

    public GetUserbyIdQueryHandler(IMapper mapper, UserManager<User> userManager, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<ApiResult<UserDto>> Handle(GetUserbyIdQuery request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var user = await _userManager.FindByIdAsync(request.Id);

        _logger.Information($"END: {MethodName}");

        if (user == null)
        {
            _logger.Error("User not found.");
            return new ApiErrorResult<UserDto>("Cán bộ này không tồn tại.");
        }

        var roles = await _userManager.GetRolesAsync(user);
        var userDto = _mapper.Map<UserDto>(user);

        if (roles.Any()) userDto.Role = roles.OrderByDescending(x => x).First();

        return new ApiSuccessResult<UserDto>(userDto);
    }
}
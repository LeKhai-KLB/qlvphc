using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Serilog;
using Shared.SeedWord;

namespace IdentityService.Application.Features.V1.Users.Queries.GetUserbyId;

public class GetUserbyIdQueryHandler : IRequestHandler<GetUserbyIdQuery, ApiResult<IdentityUser>>
{
    private readonly IMapper _mapper;
    private readonly ILogger _logger;
    private readonly UserManager<IdentityUser> _userManager;
    private const string MethodName = "GetUsersQueryHandler";

    public GetUserbyIdQueryHandler(IMapper mapper, UserManager<IdentityUser> userManager, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<ApiResult<IdentityUser>> Handle(GetUserbyIdQuery request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var user = await _userManager.FindByIdAsync(request.Id);

        _logger.Information($"END: {MethodName}");

        if (user == null)
        {
            _logger.Error("User not found.");
            return new ApiErrorResult<IdentityUser>("User not found..");
        }

        return new ApiSuccessResult<IdentityUser>(user);
    }
}
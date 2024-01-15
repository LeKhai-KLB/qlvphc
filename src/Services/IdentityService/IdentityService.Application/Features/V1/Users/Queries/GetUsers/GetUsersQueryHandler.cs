using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Shared.SeedWord;

namespace IdentityService.Application.Features.V1.Users.Queries.GetUsers;

public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, ApiResult<List<IdentityUser>>>
{
    private readonly IMapper _mapper;
    private readonly ILogger _logger;
    private readonly UserManager<IdentityUser> _userManager;
    private const string MethodName = "GetUsersQueryHandler";

    public GetUsersQueryHandler(IMapper mapper, UserManager<IdentityUser> userManager, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _userManager = userManager;
        _logger = logger;
    }

    public async Task<ApiResult<List<IdentityUser>>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var allUsers = await _userManager.Users.ToListAsync();

        _logger.Information($"END: {MethodName}");

        return new ApiSuccessResult<List<IdentityUser>>(allUsers);
    }
}
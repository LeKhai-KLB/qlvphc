using AutoMapper;
using IdentityService.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Shared.SeedWord;

namespace IdentityService.Application.Features.V1.Users.Queries.GetUsers;

public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, ApiResult<List<User>>>
{
    private readonly IMapper _mapper;
    private readonly ILogger _logger;
    private readonly UserManager<User> _userManager;
    private const string MethodName = "GetUsersQueryHandler";

    public GetUsersQueryHandler(IMapper mapper, UserManager<User> userManager, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _userManager = userManager;
        _logger = logger;
    }

    public async Task<ApiResult<List<User>>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var allUsers = await _userManager.Users.ToListAsync();

        _logger.Information($"END: {MethodName}");

        return new ApiSuccessResult<List<User>>(allUsers);
    }
}
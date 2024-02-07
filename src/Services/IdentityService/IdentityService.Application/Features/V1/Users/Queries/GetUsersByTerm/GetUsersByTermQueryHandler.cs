using AutoMapper;
using IdentityService.Application.Common.Interfaces;
using IdentityService.Application.Common.Models.UserModels;
using IdentityService.Application.Parameters.Users;
using IdentityService.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Serilog;
using Shared.SeedWord;

namespace IdentityService.Application.Features.V1.Users.Queries.GetUsersByTerm;

public class GetUsersByTermQueryHandler : IRequestHandler<GetUsersByTermQuery, ApiResult<List<UserDto>>>
{
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;
    private readonly IEntityRepository<User, UserParameter> _userRepository;
    private readonly ILogger _logger;
    private const string MethodName = "GetUsersByTermQueryHandler";

    public GetUsersByTermQueryHandler(IMapper mapper, UserManager<User> userManager, IEntityRepository<User, UserParameter> userRepository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        _logger = logger;
    }

    public async Task<ApiResult<List<UserDto>>> Handle(GetUsersByTermQuery request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var users = await _userRepository.GetByTerm(request.Term);

        var userDtos = new List<UserDto>();

        foreach (var item in users)
        {
            var roles = await _userManager.GetRolesAsync(item);
            var userDto = _mapper.Map<UserDto>(item);

            if (roles.Any()) userDto.Role = roles.OrderByDescending(x => x).First();

            userDtos.Add(userDto);
        }

        _logger.Information($"END: {MethodName}");
        return new ApiSuccessResult<List<UserDto>>(userDtos);
    }
}
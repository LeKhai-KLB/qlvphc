using AutoMapper;
using IdentityService.Application.Common.Interfaces;
using IdentityService.Application.Common.Models.UserModels;
using IdentityService.Application.Parameters.Users;
using IdentityService.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Serilog;
using Shared.SeedWord;

namespace IdentityService.Application.Features.V1.Users.Queries.GetUsers;

public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, PagedResponse<IEnumerable<UserDto>>>
{
    private readonly IMapper _mapper;
    private readonly ILogger _logger;
    private readonly UserManager<User> _userManager;
    private readonly IEntityRepository<User, UserParameter> _userRepository;
    private const string MethodName = "GetUsersQueryHandler";

    public GetUsersQueryHandler(IMapper mapper, UserManager<User> userManager, IEntityRepository<User, UserParameter> userRepository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        _logger = logger;
    }

    public async Task<PagedResponse<IEnumerable<UserDto>>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var validFilter = _mapper.Map<UserParameter>(request);
        var users = await _userRepository.GetPagedAsync(validFilter);
        var metaData = users.GetMetaData();

        var userDtos = new List<UserDto>();

        foreach(var item in users)
        {
            var roles = await _userManager.GetRolesAsync(item);
            var userDto = _mapper.Map<UserDto>(item);

            if (roles.Any()) userDto.Role = roles.First();

            userDtos.Add(userDto);
        }

        _logger.Information($"END: {MethodName}");

        return new PagedResponse<IEnumerable<UserDto>>(userDtos, metaData.CurrentPage, metaData.TotalPages, metaData.PageSize, metaData.TotalItems);
    }
}
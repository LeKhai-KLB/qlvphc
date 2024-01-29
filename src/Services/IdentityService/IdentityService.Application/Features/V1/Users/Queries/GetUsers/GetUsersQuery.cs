using IdentityService.Domain.Entities;
using MediatR;
using Shared.SeedWord;

namespace IdentityService.Application.Features.V1.Users.Queries.GetUsers;

public class GetUsersQuery : IRequest<ApiResult<List<User>>>
{
    public GetUsersQuery()
    {
    }
}
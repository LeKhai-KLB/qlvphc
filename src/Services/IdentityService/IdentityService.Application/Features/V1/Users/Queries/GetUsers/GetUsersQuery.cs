using MediatR;
using Microsoft.AspNetCore.Identity;
using Shared.SeedWord;

namespace IdentityService.Application.Features.V1.Users.Queries.GetUsers;

public class GetUsersQuery : IRequest<ApiResult<List<IdentityUser>>>
{
    public GetUsersQuery()
    {
    }
}
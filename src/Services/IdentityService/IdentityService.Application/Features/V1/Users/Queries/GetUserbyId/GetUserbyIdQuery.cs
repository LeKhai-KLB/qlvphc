using MediatR;
using Microsoft.AspNetCore.Identity;
using Shared.SeedWord;

namespace IdentityService.Application.Features.V1.Users.Queries.GetUserbyId;

public class GetUserbyIdQuery : IRequest<ApiResult<IdentityUser>>
{
    public string Id { get; set; }

    public GetUserbyIdQuery(string id)
    {
        Id = id;
    }
}
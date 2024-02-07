using IdentityService.Application.Common.Models.UserModels;
using MediatR;
using Shared.SeedWord;

namespace IdentityService.Application.Features.V1.Users.Queries.GetUsersByTerm;

public class GetUsersByTermQuery : IRequest<ApiResult<List<UserDto>>>
{
    public string? Term { get; set; }

    public GetUsersByTermQuery(string? term)
    {
        Term = term;
    }
}
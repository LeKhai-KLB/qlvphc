using CatalogService.Application.Common.Models.CoQuans;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.CoQuans.Queries.GetAllCoQuans;

public class GetAllCoQuansQuery : IRequest<ApiResult<IEnumerable<CoQuanDto>>>
{
    public GetAllCoQuansQuery()
    {
    }
}
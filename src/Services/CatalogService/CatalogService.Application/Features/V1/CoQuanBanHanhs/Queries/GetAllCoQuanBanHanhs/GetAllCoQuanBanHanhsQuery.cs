using CatalogService.Application.Common.Models.CoQuanBanHanhs;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.CoQuanBanHanhs.Queries.GetAllCoQuanBanHanhs;

public class GetAllCoQuanBanHanhsQuery : IRequest<ApiResult<IEnumerable<CoQuanBanHanhDto>>>
{
    public GetAllCoQuanBanHanhsQuery()
    {
    }
}
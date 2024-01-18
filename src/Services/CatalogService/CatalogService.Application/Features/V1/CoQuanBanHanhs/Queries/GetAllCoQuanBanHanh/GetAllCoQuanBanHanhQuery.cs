using CatalogService.Application.Common.Models.CoQuanBanHanhs;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.CoQuanBanHanhs.Queries.GetAllCoQuanBanHanh;

public class GetAllCoQuanBanHanhQuery : IRequest<ApiResult<IEnumerable<CoQuanBanHanhDto>>>
{
    public GetAllCoQuanBanHanhQuery()
    {
    }
}
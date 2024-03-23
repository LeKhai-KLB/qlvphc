using CatalogService.Application.Common.Models.KetQuaXuPhatTruyCuuHSs;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.KetQuaXuPhatTruyCuuHSs.Queries.GetAllKetQuaXuPhatTruyCuuHSs;

public class GetAllKetQuaXuPhatTruyCuuHSsQuery : IRequest<ApiResult<IEnumerable<KetQuaXuPhatTruyCuuHSDto>>>
{
    public GetAllKetQuaXuPhatTruyCuuHSsQuery()
    {
    }
}
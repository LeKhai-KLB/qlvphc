using CatalogService.Application.Common.Models.VanBanGiaiQuyets;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.VanBanGiaiQuyets.Queries.GetAllVanBanGiaiQuyet;

public class GetAllVanBanGiaiQuyetQuery : IRequest<ApiResult<IEnumerable<VanBanGiaiQuyetDto>>>
{
    public GetAllVanBanGiaiQuyetQuery()
    {
    }
}
using CatalogService.Application.Common.Models.LoaiVanBans;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.LoaiVanBans.Queries.GetAllLoaiVanBan;

public class GetAllLoaiVanBanQuery : IRequest<ApiResult<IEnumerable<LoaiVanBanDto>>>
{
    public GetAllLoaiVanBanQuery()
    {
    }
}
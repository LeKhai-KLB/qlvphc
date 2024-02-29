using CatalogService.Application.Common.Models.LoaiVanBans;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.LoaiVanBans.Queries.GetAllLoaiVanBans;

public class GetAllLoaiVanBansQuery : IRequest<ApiResult<IEnumerable<LoaiVanBanDto>>>
{
    public GetAllLoaiVanBansQuery()
    {
    }
}
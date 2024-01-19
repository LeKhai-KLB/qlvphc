using CatalogService.Application.Common.Models.LoaiVanBans;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.LoaiVanBans.Queries.GetLoaiVanBanById;

public class GetLoaiVanBanByIdQuery : IRequest<ApiResult<LoaiVanBanDto>>
{
    public int Id { get; set; }

    public GetLoaiVanBanByIdQuery(int id)
    {
        Id = id;
    }
}
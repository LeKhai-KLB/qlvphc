using CatalogService.Application.Common.Models.VanBanLienQuans;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.VanBanLienQuans.Queries.GetVanBanLienQuanById;

public class GetVanBanLienQuanByIdQuery : IRequest<ApiResult<VanBanLienQuanDto>>
{
    public int Id { get; set; }

    public GetVanBanLienQuanByIdQuery(int id)
    {
        Id = id;
    }
}
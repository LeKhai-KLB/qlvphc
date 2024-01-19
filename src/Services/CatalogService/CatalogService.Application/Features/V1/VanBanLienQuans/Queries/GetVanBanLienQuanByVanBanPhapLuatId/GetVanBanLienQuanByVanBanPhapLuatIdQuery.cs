using CatalogService.Application.Common.Models.VanBanLienQuans;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.VanBanLienQuans.Queries.GetVanBanLienQuanByVanBanPhapLuatId;

public class GetVanBanLienQuanByVanBanPhapLuatIdQuery : IRequest<ApiResult<IEnumerable<VanBanLienQuanDto>>>
{
    public int VanBanPhapLuatId { get; set; }

    public GetVanBanLienQuanByVanBanPhapLuatIdQuery(int vanBanPhapLuatId)
    {
        VanBanPhapLuatId = vanBanPhapLuatId;
    }
}
using CatalogService.Application.Common.Models.HoSoXuLyViPhams;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.HSVPVanBanGiaiQuyet.Queries.GetHSVPVanBanById;

public class GetHSVPVanBanByIdQuery : IRequest<ApiResult<HSVPVanBanGiaiQuyetDto>>
{
    public int HoSoXuLyViPhamId { get; set; }

    public int VanBanGiaiQuyetId { get; set; }

    public GetHSVPVanBanByIdQuery(int hsId, int vbId)
    {
        HoSoXuLyViPhamId = hsId;
        VanBanGiaiQuyetId = vbId;
    }
}
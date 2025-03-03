using CatalogService.Application.Common.Models.HoSoXuLyViPhams;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.HSVPVanBanGiaiQuyet.Queries.GetHSVPVanBanById;

public class GetHoSoXuLyViPham_VanBanGiaiQuyetByIdQuery : IRequest<ApiResult<HoSoXuLyViPham_VanBanGiaiQuyetDto>>
{
    public int HoSoXuLyViPhamId { get; set; }

    public int VanBanGiaiQuyetId { get; set; }

    public GetHoSoXuLyViPham_VanBanGiaiQuyetByIdQuery(int hoSoXuLyViPhamId, int vanBanGiaiQuyetId)
    {
        HoSoXuLyViPhamId = hoSoXuLyViPhamId;
        VanBanGiaiQuyetId = vanBanGiaiQuyetId;
    }
}
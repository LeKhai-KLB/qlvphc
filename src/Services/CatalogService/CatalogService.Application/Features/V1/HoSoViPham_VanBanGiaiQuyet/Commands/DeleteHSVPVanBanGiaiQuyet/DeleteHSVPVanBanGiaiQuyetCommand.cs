using MediatR;

namespace CatalogService.Application.Features.V1.HSVPVanBanGiaiQuyet.Commands.DeleteHSVPVanBanGiaiQuyet;

public class DeleteHoSoXuLyViPham_VanBanGiaiQuyetCommand : IRequest<bool>
{
    public int HoSoXuLyViPhamId { get; set; }

    public int VanBanGiaiQuyetId { get; set; }

    public DeleteHoSoXuLyViPham_VanBanGiaiQuyetCommand(int hoSoXuLyViPhamId, int vanBanGiaiQuyetId)
    {
        HoSoXuLyViPhamId = hoSoXuLyViPhamId;
        VanBanGiaiQuyetId = vanBanGiaiQuyetId;
    }
}
using MediatR;

namespace CatalogService.Application.Features.V1.HSVPVanBanGiaiQuyet.Commands.DeleteHSVPVanBanGiaiQuyet;

public class DeleteHSVPVanBanGiaiQuyetCommand : IRequest<bool>
{
    public int HoSoXuLyViPhamId { get; set; }

    public int VanBanGiaiQuyetId { get; set; }

    public DeleteHSVPVanBanGiaiQuyetCommand(int hsId, int vbId)
    {
        HoSoXuLyViPhamId = hsId;
        VanBanGiaiQuyetId = vbId;
    }
}
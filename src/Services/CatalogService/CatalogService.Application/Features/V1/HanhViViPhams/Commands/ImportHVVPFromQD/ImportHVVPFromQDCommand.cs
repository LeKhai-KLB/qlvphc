using MediatR;

namespace CatalogService.Application.Features.V1.HanhViViPhams.Commands.ImportHVVPFromQD;

public class ImportHVVPFromQDCommand : IRequest<bool>
{
    public int HoSoXuLyViPhamId { get; set; }

    public ImportHVVPFromQDCommand(int hoSoXuLyViPhamId)
    {
        HoSoXuLyViPhamId = hoSoXuLyViPhamId;
    }
}
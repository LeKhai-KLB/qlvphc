using MediatR;

namespace CatalogService.Application.Features.V1.HoSoXuLyViPhams.Commands.DeleteHoSoXuLyViPham;

public class DeleteHoSoXuLyViPhamCommand : IRequest<bool>
{
    public int Id { get; private set; }

    public DeleteHoSoXuLyViPhamCommand(int id)
    {
        Id = id;
    }
}
using MediatR;

namespace CatalogService.Application.Features.V1.ChiTietLinhVucXuPhats.Commands.DeleteChiTietLinhVucXuPhat;

public class DeleteChiTietLinhVucXuPhatCommand : IRequest<bool>
{
    public int Id { get; private set; }

    public DeleteChiTietLinhVucXuPhatCommand(int id)
    {
        Id = id;
    }
}
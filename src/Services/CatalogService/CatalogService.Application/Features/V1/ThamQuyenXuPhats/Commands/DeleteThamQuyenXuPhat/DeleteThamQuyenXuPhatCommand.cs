using MediatR;

namespace CatalogService.Application.Features.V1.ThamQuyenXuPhats.Commands.DeleteThamQuyenXuPhat;

public class DeleteThamQuyenXuPhatCommand : IRequest<bool>
{
    public int Id { get; private set; }

    public DeleteThamQuyenXuPhatCommand(int id)
    {
        Id = id;
    }
}
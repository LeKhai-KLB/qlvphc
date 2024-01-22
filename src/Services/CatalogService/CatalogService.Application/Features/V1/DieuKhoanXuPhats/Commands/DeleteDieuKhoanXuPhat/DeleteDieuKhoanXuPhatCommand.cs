using MediatR;

namespace CatalogService.Application.Features.V1.DieuKhoanXuPhats.Commands.DeleteDieuKhoanXuPhat;

public class DeleteDieuKhoanXuPhatCommand : IRequest<bool>
{
    public int Id { get; private set; }

    public DeleteDieuKhoanXuPhatCommand(int id)
    {
        Id = id;
    }
}
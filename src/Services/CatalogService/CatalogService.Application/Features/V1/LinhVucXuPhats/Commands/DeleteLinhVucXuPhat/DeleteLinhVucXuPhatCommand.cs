using MediatR;

namespace CatalogService.Application.Features.V1.LinhVucXuPhats.Commands.DeleteLinhVucXuPhat;

public class DeleteLinhVucXuPhatCommand : IRequest<bool>
{
    public int Id { get; private set; }

    public DeleteLinhVucXuPhatCommand(int id)
    {
        Id = id;
    }
}
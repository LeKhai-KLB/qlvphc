using MediatR;

namespace CatalogService.Application.Features.V1.HanhViViPhams.Commands.DeleteHanhViViPham;

public class DeleteHanhViViPhamCommand : IRequest<bool>
{
    public int Id { get; private set; }

    public DeleteHanhViViPhamCommand(int id)
    {
        Id = id;
    }
}
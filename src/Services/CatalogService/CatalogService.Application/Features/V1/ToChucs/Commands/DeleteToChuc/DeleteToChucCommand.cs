using MediatR;

namespace CatalogService.Application.Features.V1.ToChucs.Commands.DeleteToChuc;

public class DeleteToChucCommand : IRequest<bool>
{
    public int Id { get; private set; }

    public DeleteToChucCommand(int id)
    {
        Id = id;
    }
}
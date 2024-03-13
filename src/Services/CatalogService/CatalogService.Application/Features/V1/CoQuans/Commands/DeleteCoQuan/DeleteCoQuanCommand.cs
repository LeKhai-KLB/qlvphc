using MediatR;

namespace CatalogService.Application.Features.V1.CoQuans.Commands.DeleteCoQuan;

public class DeleteCoQuanCommand : IRequest<bool>
{
    public int Id { get; private set; }

    public DeleteCoQuanCommand(int id)
    {
        Id = id;
    }
}
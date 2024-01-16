using MediatR;

namespace CatalogService.Application.Features.V1.XaPhuongs.Commands.DeleteXaPhuong;

public class DeleteXaPhuongCommand : IRequest<bool>
{
    public int Id { get; private set; }
    public DeleteXaPhuongCommand(int id)
    {
        Id = id;
    }
}

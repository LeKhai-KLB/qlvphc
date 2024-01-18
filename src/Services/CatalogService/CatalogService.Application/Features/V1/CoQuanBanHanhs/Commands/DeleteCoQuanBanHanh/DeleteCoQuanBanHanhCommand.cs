using MediatR;

namespace CatalogService.Application.Features.V1.CoQuanBanHanhs.Commands.DeleteCoQuanBanHanh;

public class DeleteCoQuanBanHanhCommand : IRequest<bool>
{
    public int Id { get; private set; }

    public DeleteCoQuanBanHanhCommand(int id)
    {
        Id = id;
    }
}
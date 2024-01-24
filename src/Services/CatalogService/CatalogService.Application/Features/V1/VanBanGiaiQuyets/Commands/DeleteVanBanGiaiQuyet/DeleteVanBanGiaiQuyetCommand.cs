using MediatR;

namespace CatalogService.Application.Features.V1.VanBanGiaiQuyets.Commands.DeleteVanBanGiaiQuyet;

public class DeleteVanBanGiaiQuyetCommand : IRequest<bool>
{
    public int Id { get; private set; }

    public DeleteVanBanGiaiQuyetCommand(int id)
    {
        Id = id;
    }
}
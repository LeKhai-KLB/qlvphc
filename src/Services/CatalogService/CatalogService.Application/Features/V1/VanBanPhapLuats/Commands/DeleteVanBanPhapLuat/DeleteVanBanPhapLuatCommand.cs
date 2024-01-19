using MediatR;

namespace CatalogService.Application.Features.V1.VanBanPhapLuats.Commands.DeleteVanBanPhapLuat;

public class DeleteVanBanPhapLuatCommand : IRequest<bool>
{
    public int Id { get; private set; }

    public DeleteVanBanPhapLuatCommand(int id)
    {
        Id = id;
    }
}
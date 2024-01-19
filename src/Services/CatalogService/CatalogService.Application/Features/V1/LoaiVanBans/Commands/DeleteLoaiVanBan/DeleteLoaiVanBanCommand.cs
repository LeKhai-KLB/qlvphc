using MediatR;

namespace CatalogService.Application.Features.V1.LoaiVanBans.Commands.DeleteLoaiVanBan;

public class DeleteLoaiVanBanCommand : IRequest<bool>
{
    public int Id { get; private set; }

    public DeleteLoaiVanBanCommand(int id)
    {
        Id = id;
    }
}
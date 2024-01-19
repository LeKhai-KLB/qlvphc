using MediatR;

namespace CatalogService.Application.Features.V1.VanBanLienQuans.Commands.DeleteVanBanLienQuan;

public class DeleteVanBanLienQuanCommand : IRequest<bool>
{
    public int Id { get; private set; }

    public DeleteVanBanLienQuanCommand(int id)
    {
        Id = id;
    }
}
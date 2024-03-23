using MediatR;

namespace CatalogService.Application.Features.V1.KetQuaXuPhatTruyCuuHSs.Commands.DeleteKetQuaXuPhatTruyCuuHS;

public class DeleteKetQuaXuPhatTruyCuuHSCommand : IRequest<bool>
{
    public int Id { get; private set; }

    public DeleteKetQuaXuPhatTruyCuuHSCommand(int id)
    {
        Id = id;
    }
}
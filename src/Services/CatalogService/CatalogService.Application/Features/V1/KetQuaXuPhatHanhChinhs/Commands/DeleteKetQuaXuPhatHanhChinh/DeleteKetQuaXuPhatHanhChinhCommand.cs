using MediatR;

namespace CatalogService.Application.Features.V1.KetQuaXuPhatHanhChinhs.Commands.DeleteKetQuaXuPhatHanhChinh;

public class DeleteKetQuaXuPhatHanhChinhCommand : IRequest<bool>
{
    public int Id { get; private set; }

    public DeleteKetQuaXuPhatHanhChinhCommand(int id)
    {
        Id = id;
    }
}
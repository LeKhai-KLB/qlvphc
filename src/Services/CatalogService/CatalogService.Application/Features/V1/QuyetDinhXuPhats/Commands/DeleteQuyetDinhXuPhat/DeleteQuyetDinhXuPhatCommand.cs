using MediatR;

namespace CatalogService.Application.Features.V1.QuyetDinhXuPhats.Commands.DeleteQuyetDinhXuPhat;

public class DeleteQuyetDinhXuPhatCommand : IRequest<bool>
{
    public int Id { get; private set; }
    public DeleteQuyetDinhXuPhatCommand(int id)
    {
        Id = id;
    }
}

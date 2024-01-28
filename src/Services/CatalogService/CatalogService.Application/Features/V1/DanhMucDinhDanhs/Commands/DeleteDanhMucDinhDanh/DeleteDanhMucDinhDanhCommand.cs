using MediatR;

namespace CatalogService.Application.Features.V1.DanhMucDinhDanhs.Commands.DeleteDanhMucDinhDanh;

public class DeleteDanhMucDinhDanhCommand : IRequest<bool>
{
    public int Id { get; private set; }
    public DeleteDanhMucDinhDanhCommand(int id)
    {
        Id = id;
    }
}

using MediatR;

namespace CatalogService.Application.Features.V1.DieuKhoanBoSungKhacPhucs.Commands.DeleteDieuKhoanBoSungKhacPhuc;

public class DeleteDieuKhoanBoSungKhacPhucCommand : IRequest<bool>
{
    public int Id { get; private set; }

    public DeleteDieuKhoanBoSungKhacPhucCommand(int id)
    {
        Id = id;
    }
}
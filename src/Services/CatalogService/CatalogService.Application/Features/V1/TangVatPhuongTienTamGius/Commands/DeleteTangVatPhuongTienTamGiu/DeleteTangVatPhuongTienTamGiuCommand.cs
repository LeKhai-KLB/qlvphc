using MediatR;

namespace CatalogService.Application.Features.V1.TangVatPhuongTienTamGius.Commands.DeleteTangVatPhuongTienTamGiu;

public class DeleteTangVatPhuongTienTamGiuCommand : IRequest<bool>
{
    public int Id { get; private set; }
    public DeleteTangVatPhuongTienTamGiuCommand(int id)
    {
        Id = id;
    }
}

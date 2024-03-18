using MediatR;

namespace CatalogService.Application.Features.V1.ChiTietHSXLVPVVBGQs.Commands.DeleteChiTietHSXLVPVVBGQ;

public class DeleteChiTietHSXLVPVVBGQCommand : IRequest<bool>
{
    public int Id { get; private set; }

    public DeleteChiTietHSXLVPVVBGQCommand(int id)
    {
        Id = id;
    }
}
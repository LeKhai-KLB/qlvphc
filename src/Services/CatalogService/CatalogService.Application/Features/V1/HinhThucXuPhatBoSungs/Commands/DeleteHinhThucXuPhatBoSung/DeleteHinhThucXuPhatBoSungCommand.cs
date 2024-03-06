using MediatR;

namespace CatalogService.Application.Features.V1.HinhThucXuPhatBoSungs.Commands.DeleteHinhThucXuPhatBoSung;

public class DeleteHinhThucXuPhatBoSungCommand : IRequest<bool>
{
    public int Id { get; private set; }
    public DeleteHinhThucXuPhatBoSungCommand(int id)
    {
        Id = id;
    }
}

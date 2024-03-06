using MediatR;

namespace CatalogService.Application.Features.V1.HinhThucXuPhatChinhs.Commands.DeleteHinhThucXuPhatChinh;

public class DeleteHinhThucXuPhatChinhCommand : IRequest<bool>
{
    public int Id { get; private set; }
    public DeleteHinhThucXuPhatChinhCommand(int id)
    {
        Id = id;
    }
}

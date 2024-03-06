using MediatR;

namespace CatalogService.Application.Features.V1.GiayPhepTamGius.Commands.DeleteGiayPhepTamGiu;

public class DeleteGiayPhepTamGiuCommand : IRequest<bool>
{
    public int Id { get; private set; }
    public DeleteGiayPhepTamGiuCommand(int id)
    {
        Id = id;
    }
}

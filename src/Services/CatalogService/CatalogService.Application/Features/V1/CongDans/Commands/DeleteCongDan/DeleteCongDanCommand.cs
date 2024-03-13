using MediatR;

namespace CatalogService.Application.Features.V1.CongDans.Commands.DeleteCongDan;

public class DeleteCongDanCommand : IRequest<bool>
{
    public int Id { get; private set; }

    public DeleteCongDanCommand(int id)
    {
        Id = id;
    }
}
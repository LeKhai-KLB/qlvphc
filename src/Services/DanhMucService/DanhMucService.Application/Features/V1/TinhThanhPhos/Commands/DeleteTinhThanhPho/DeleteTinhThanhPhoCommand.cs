using MediatR;

namespace DanhMucService.Application.Features.V1.TinhThanhPhos.Commands.DeleteTinhThanhPho;

public class DeleteTinhThanhPhoCommand : IRequest<bool>
{
    public int Id { get; private set; }
    public DeleteTinhThanhPhoCommand(int id)
    {
        Id = id;
    }
}

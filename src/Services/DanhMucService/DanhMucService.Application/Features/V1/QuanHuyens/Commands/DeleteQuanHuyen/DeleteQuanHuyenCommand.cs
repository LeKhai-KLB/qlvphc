using MediatR;

namespace DanhMucService.Application.Features.V1.QuanHuyens.Commands.DeleteQuanHuyen;

public class DeleteQuanHuyenCommand : IRequest<bool>
{
    public int Id { get; private set; }
    public DeleteQuanHuyenCommand(int id)
    {
        Id = id;
    }
}

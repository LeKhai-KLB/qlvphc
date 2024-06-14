using CatalogService.Application.Common.Exceptions;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Domain.Entities;
using MediatR;
using Serilog;

namespace CatalogService.Application.Features.V1.HSVPVanBanGiaiQuyet.Commands.DeleteHSVPVanBanGiaiQuyet;

public class DeleteHSVPVanBanGiaiQuyetCommandHandler : IRequestHandler<DeleteHSVPVanBanGiaiQuyetCommand, bool>
{
    private readonly IHoSoXuLyViPham_VanBanGiaiQuyetRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "DeleteHSVPVanBanGiaiQuyetCommandHandler";

    public DeleteHSVPVanBanGiaiQuyetCommandHandler(IHoSoXuLyViPham_VanBanGiaiQuyetRepository repository, ILogger logger)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<bool> Handle(DeleteHSVPVanBanGiaiQuyetCommand request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var dkxp = await _repository.GetHSVPVanBanById(request.HoSoXuLyViPhamId, request.VanBanGiaiQuyetId);

        if (dkxp == null) throw new NotFoundException(nameof(HoSoXuLyViPham_VanBanGiaiQuyet), new { request.HoSoXuLyViPhamId, request.VanBanGiaiQuyetId });

        await _repository.DeleteHSVPVanBan(dkxp);

        _logger.Information($"END: {MethodName}");

        return true;
    }
}
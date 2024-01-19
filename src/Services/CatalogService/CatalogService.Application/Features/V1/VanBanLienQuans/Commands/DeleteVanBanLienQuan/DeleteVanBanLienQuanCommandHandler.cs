using CatalogService.Application.Common.Exceptions;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Domain.Entities;
using MediatR;
using Serilog;

namespace CatalogService.Application.Features.V1.VanBanLienQuans.Commands.DeleteVanBanLienQuan;

public class DeleteVanBanLienQuanCommandHandler : IRequestHandler<DeleteVanBanLienQuanCommand, bool>
{
    private readonly IVanBanLienQuanRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "DeleteVanBanLienQuanCommandHandler";

    public DeleteVanBanLienQuanCommandHandler(IVanBanLienQuanRepository repository, ILogger logger)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<bool> Handle(DeleteVanBanLienQuanCommand request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var vblq = await _repository.GetByIdAsync(request.Id);

        if (vblq == null) throw new NotFoundException(nameof(VanBanLienQuan), request.Id);

        await _repository.DeleteVanBanLienQuan(vblq);

        _logger.Information($"END: {MethodName}");

        return true;
    }
}
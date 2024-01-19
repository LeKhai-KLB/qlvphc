using CatalogService.Application.Common.Exceptions;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Domain.Entities;
using MediatR;
using Serilog;

namespace CatalogService.Application.Features.V1.VanBanPhapLuats.Commands.DeleteVanBanPhapLuat;

public class DeleteVanBanPhapLuatCommandHandler : IRequestHandler<DeleteVanBanPhapLuatCommand, bool>
{
    private readonly IVanBanPhapLuatRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "DeleteVanBanPhapLuatCommandHandler";

    public DeleteVanBanPhapLuatCommandHandler(IVanBanPhapLuatRepository repository, ILogger logger)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<bool> Handle(DeleteVanBanPhapLuatCommand request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var vbpl = await _repository.GetByIdAsync(request.Id);

        if (vbpl == null) throw new NotFoundException(nameof(VanBanPhapLuat), request.Id);

        await _repository.DeleteVanBanPhapLuat(vbpl);

        _logger.Information($"END: {MethodName}");

        return true;
    }
}
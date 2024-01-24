using CatalogService.Application.Common.Exceptions;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Domain.Entities;
using MediatR;
using Serilog;

namespace CatalogService.Application.Features.V1.VanBanGiaiQuyets.Commands.DeleteVanBanGiaiQuyet;

public class DeleteVanBanGiaiQuyetCommandHandler : IRequestHandler<DeleteVanBanGiaiQuyetCommand, bool>
{
    private readonly IVanBanGiaiQuyetRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "DeleteVanBanGiaiQuyetCommandHandler";

    public DeleteVanBanGiaiQuyetCommandHandler(IVanBanGiaiQuyetRepository repository, ILogger logger)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<bool> Handle(DeleteVanBanGiaiQuyetCommand request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var vbgq = await _repository.GetByIdAsync(request.Id);

        if (vbgq == null) throw new NotFoundException(nameof(VanBanGiaiQuyet), request.Id);

        await _repository.DeleteVanBanGiaiQuyet(vbgq);

        _logger.Information($"END: {MethodName}");

        return true;
    }
}
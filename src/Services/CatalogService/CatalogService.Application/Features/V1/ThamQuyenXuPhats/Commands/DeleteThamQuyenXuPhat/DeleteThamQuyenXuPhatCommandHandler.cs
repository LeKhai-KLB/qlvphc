using CatalogService.Application.Common.Exceptions;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Domain.Entities;
using MediatR;
using Serilog;

namespace CatalogService.Application.Features.V1.ThamQuyenXuPhats.Commands.DeleteThamQuyenXuPhat;

public class DeleteThamQuyenXuPhatCommandHandler : IRequestHandler<DeleteThamQuyenXuPhatCommand, bool>
{
    private readonly IThamQuyenXuPhatRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "DeleteThamQuyenXuPhatCommandHandler";

    public DeleteThamQuyenXuPhatCommandHandler(IThamQuyenXuPhatRepository repository, ILogger logger)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<bool> Handle(DeleteThamQuyenXuPhatCommand request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var tqxp = await _repository.GetByIdAsync(request.Id);

        if (tqxp == null) throw new NotFoundException(nameof(ThamQuyenXuPhat), request.Id);

        await _repository.DeleteThamQuyenXuPhat(tqxp);

        _logger.Information($"END: {MethodName}");

        return true;
    }
}
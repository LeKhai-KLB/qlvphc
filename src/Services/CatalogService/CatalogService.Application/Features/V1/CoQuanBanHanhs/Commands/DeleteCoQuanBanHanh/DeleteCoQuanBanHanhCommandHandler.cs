using CatalogService.Application.Common.Exceptions;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Domain.Entities;
using MediatR;
using Serilog;

namespace CatalogService.Application.Features.V1.CoQuanBanHanhs.Commands.DeleteCoQuanBanHanh;

public class DeleteCoQuanBanHanhCommandHandler : IRequestHandler<DeleteCoQuanBanHanhCommand, bool>
{
    private readonly ICoQuanBanHanhRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "DeleteCoQuanBanHanhCommandHandler";

    public DeleteCoQuanBanHanhCommandHandler(ICoQuanBanHanhRepository repository, ILogger logger)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<bool> Handle(DeleteCoQuanBanHanhCommand request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var cqbh = await _repository.GetByIdAsync(request.Id);

        if (cqbh == null) throw new NotFoundException(nameof(CoQuanBanHanh), request.Id);

        await _repository.DeleteCoQuanBanHanh(cqbh);

        _logger.Information($"END: {MethodName}");

        return true;
    }
}
using CatalogService.Application.Common.Exceptions;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Domain.Entities;
using MediatR;
using Serilog;

namespace CatalogService.Application.Features.V1.CoQuans.Commands.DeleteCoQuan;

public class DeleteCoQuanCommandHandler : IRequestHandler<DeleteCoQuanCommand, bool>
{
    private readonly ICoQuanRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "DeleteCoQuanCommandHandler";

    public DeleteCoQuanCommandHandler(ICoQuanRepository repository, ILogger logger)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<bool> Handle(DeleteCoQuanCommand request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var cqbh = await _repository.GetByIdAsync(request.Id);

        if (cqbh == null) throw new NotFoundException(nameof(CoQuan), request.Id);

        await _repository.DeleteCoQuan(cqbh);

        _logger.Information($"END: {MethodName}");

        return true;
    }
}
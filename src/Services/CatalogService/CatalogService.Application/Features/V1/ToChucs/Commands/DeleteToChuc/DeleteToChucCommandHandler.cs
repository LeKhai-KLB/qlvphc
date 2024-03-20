using CatalogService.Application.Common.Exceptions;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Domain.Entities;
using MediatR;
using Serilog;

namespace CatalogService.Application.Features.V1.ToChucs.Commands.DeleteToChuc;

public class DeleteToChucCommandHandler : IRequestHandler<DeleteToChucCommand, bool>
{
    private readonly IToChucRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "DeleteToChucCommandHandler";

    public DeleteToChucCommandHandler(IToChucRepository repository, ILogger logger)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<bool> Handle(DeleteToChucCommand request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var cqbh = await _repository.GetByIdAsync(request.Id);

        if (cqbh == null) throw new NotFoundException(nameof(ToChuc), request.Id);

        await _repository.DeleteToChuc(cqbh);

        _logger.Information($"END: {MethodName}");

        return true;
    }
}
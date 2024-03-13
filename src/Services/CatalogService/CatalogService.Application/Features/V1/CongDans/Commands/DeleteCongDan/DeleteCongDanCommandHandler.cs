using CatalogService.Application.Common.Exceptions;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Domain.Entities;
using MediatR;
using Serilog;

namespace CatalogService.Application.Features.V1.CongDans.Commands.DeleteCongDan;

public class DeleteCongDanCommandHandler : IRequestHandler<DeleteCongDanCommand, bool>
{
    private readonly ICongDanRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "DeleteCongDanCommandHandler";

    public DeleteCongDanCommandHandler(ICongDanRepository repository, ILogger logger)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<bool> Handle(DeleteCongDanCommand request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var cqbh = await _repository.GetByIdAsync(request.Id);

        if (cqbh == null) throw new NotFoundException(nameof(CongDan), request.Id);

        await _repository.DeleteCongDan(cqbh);

        _logger.Information($"END: {MethodName}");

        return true;
    }
}
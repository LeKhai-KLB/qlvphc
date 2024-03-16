using CatalogService.Application.Common.Exceptions;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Domain.Entities;
using MediatR;
using Serilog;

namespace CatalogService.Application.Features.V1.HanhViViPhams.Commands.DeleteHanhViViPham;

public class DeleteHanhViViPhamCommandHandler : IRequestHandler<DeleteHanhViViPhamCommand, bool>
{
    private readonly IHanhViViPhamRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "DeleteHanhViViPhamCommandHandler";

    public DeleteHanhViViPhamCommandHandler(IHanhViViPhamRepository repository, ILogger logger)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<bool> Handle(DeleteHanhViViPhamCommand request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var dkxp = await _repository.GetByIdAsync(request.Id);

        if (dkxp == null) throw new NotFoundException(nameof(HanhViViPham), request.Id);

        await _repository.DeleteHanhViViPham(dkxp);

        _logger.Information($"END: {MethodName}");

        return true;
    }
}
using CatalogService.Application.Common.Exceptions;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Domain.Entities;
using MediatR;
using Serilog;

namespace CatalogService.Application.Features.V1.KetQuaXuPhatHanhChinhs.Commands.DeleteKetQuaXuPhatHanhChinh;

public class DeleteKetQuaXuPhatHanhChinhCommandHandler : IRequestHandler<DeleteKetQuaXuPhatHanhChinhCommand, bool>
{
    private readonly IKetQuaXuPhatHanhChinhRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "DeleteKetQuaXuPhatHanhChinhCommandHandler";

    public DeleteKetQuaXuPhatHanhChinhCommandHandler(IKetQuaXuPhatHanhChinhRepository repository, ILogger logger)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<bool> Handle(DeleteKetQuaXuPhatHanhChinhCommand request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var cqbh = await _repository.GetByIdAsync(request.Id);

        if (cqbh == null) throw new NotFoundException(nameof(KetQuaXuPhatHanhChinh), request.Id);

        await _repository.DeleteKetQuaXuPhatHanhChinh(cqbh);

        _logger.Information($"END: {MethodName}");

        return true;
    }
}
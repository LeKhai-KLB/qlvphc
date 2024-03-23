using CatalogService.Application.Common.Exceptions;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Domain.Entities;
using MediatR;
using Serilog;

namespace CatalogService.Application.Features.V1.KetQuaXuPhatTruyCuuHSs.Commands.DeleteKetQuaXuPhatTruyCuuHS;

public class DeleteKetQuaXuPhatTruyCuuHSCommandHandler : IRequestHandler<DeleteKetQuaXuPhatTruyCuuHSCommand, bool>
{
    private readonly IKetQuaXuPhatTruyCuuHSRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "DeleteKetQuaXuPhatTruyCuuHSCommandHandler";

    public DeleteKetQuaXuPhatTruyCuuHSCommandHandler(IKetQuaXuPhatTruyCuuHSRepository repository, ILogger logger)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<bool> Handle(DeleteKetQuaXuPhatTruyCuuHSCommand request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var cqbh = await _repository.GetByIdAsync(request.Id);

        if (cqbh == null) throw new NotFoundException(nameof(KetQuaXuPhatTruyCuuHS), request.Id);

        await _repository.DeleteKetQuaXuPhatTruyCuuHS(cqbh);

        _logger.Information($"END: {MethodName}");

        return true;
    }
}
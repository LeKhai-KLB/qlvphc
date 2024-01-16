using CatalogService.Application.Common.Exceptions;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Domain.Entities;
using MediatR;
using Serilog;

namespace CatalogService.Application.Features.V1.LinhVucXuPhats.Commands.DeleteLinhVucXuPhat;

public class DeleteLinhVucXuPhatCommandHandler : IRequestHandler<DeleteLinhVucXuPhatCommand, bool>
{
    private readonly ILinhVucXuPhatRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "DeleteLinhVucXuPhatCommandHandler";

    public DeleteLinhVucXuPhatCommandHandler(ILinhVucXuPhatRepository repository, ILogger logger)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<bool> Handle(DeleteLinhVucXuPhatCommand request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var lvxp = await _repository.GetByIdAsync(request.Id);

        if (lvxp == null) throw new NotFoundException(nameof(LinhVucXuPhat), request.Id);

        await _repository.DeleteLinhVucXuPhat(lvxp);

        _logger.Information($"END: {MethodName}");

        return true;
    }
}
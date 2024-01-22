using CatalogService.Application.Common.Exceptions;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Domain.Entities;
using MediatR;
using Serilog;

namespace CatalogService.Application.Features.V1.DieuKhoanXuPhats.Commands.DeleteDieuKhoanXuPhat;

public class DeleteDieuKhoanXuPhatCommandHandler : IRequestHandler<DeleteDieuKhoanXuPhatCommand, bool>
{
    private readonly IDieuKhoanXuPhatRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "DeleteDieuKhoanXuPhatCommandHandler";

    public DeleteDieuKhoanXuPhatCommandHandler(IDieuKhoanXuPhatRepository repository, ILogger logger)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<bool> Handle(DeleteDieuKhoanXuPhatCommand request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var dkxp = await _repository.GetByIdAsync(request.Id);

        if (dkxp == null) throw new NotFoundException(nameof(DieuKhoanXuPhat), request.Id);

        await _repository.DeleteDieuKhoanXuPhat(dkxp);

        _logger.Information($"END: {MethodName}");

        return true;
    }
}
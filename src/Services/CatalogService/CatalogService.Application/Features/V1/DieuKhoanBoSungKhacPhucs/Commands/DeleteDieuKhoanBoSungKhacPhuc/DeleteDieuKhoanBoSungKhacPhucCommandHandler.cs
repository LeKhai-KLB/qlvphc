using CatalogService.Application.Common.Exceptions;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Domain.Entities;
using MediatR;
using Serilog;

namespace CatalogService.Application.Features.V1.DieuKhoanBoSungKhacPhucs.Commands.DeleteDieuKhoanBoSungKhacPhuc;

public class DeleteDieuKhoanBoSungKhacPhucCommandHandler : IRequestHandler<DeleteDieuKhoanBoSungKhacPhucCommand, bool>
{
    private readonly IDieuKhoanBoSungKhacPhucRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "DeleteDieuKhoanBoSungKhacPhucCommandHandler";

    public DeleteDieuKhoanBoSungKhacPhucCommandHandler(IDieuKhoanBoSungKhacPhucRepository repository, ILogger logger)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<bool> Handle(DeleteDieuKhoanBoSungKhacPhucCommand request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var dkxp = await _repository.GetByIdAsync(request.Id);

        if (dkxp == null) throw new NotFoundException(nameof(DieuKhoanBoSungKhacPhuc), request.Id);

        await _repository.DeleteDieuKhoanBoSungKhacPhuc(dkxp);

        _logger.Information($"END: {MethodName}");

        return true;
    }
}
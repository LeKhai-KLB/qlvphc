using CatalogService.Application.Common.Exceptions;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Domain.Entities;
using MediatR;
using Serilog;

namespace CatalogService.Application.Features.V1.ChiTietHSXLVPVVBGQs.Commands.DeleteChiTietHSXLVPVVBGQ;

public class DeleteChiTietHSXLVPVVBGQCommandHandler : IRequestHandler<DeleteChiTietHSXLVPVVBGQCommand, bool>
{
    private readonly IChiTietHSXLVPVVBGQRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "DeleteChiTietHSXLVPVVBGQCommandHandler";

    public DeleteChiTietHSXLVPVVBGQCommandHandler(IChiTietHSXLVPVVBGQRepository repository, ILogger logger)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<bool> Handle(DeleteChiTietHSXLVPVVBGQCommand request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var cqbh = await _repository.GetByIdAsync(request.Id);

        if (cqbh == null) throw new NotFoundException(nameof(ChiTietHSXLVPVVBGQ), request.Id);

        await _repository.DeleteChiTietHSXLVPVVBGQ(cqbh);

        _logger.Information($"END: {MethodName}");

        return true;
    }
}
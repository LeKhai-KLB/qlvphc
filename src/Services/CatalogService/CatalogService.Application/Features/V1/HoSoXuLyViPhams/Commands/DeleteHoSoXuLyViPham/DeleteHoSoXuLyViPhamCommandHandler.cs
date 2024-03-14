using CatalogService.Application.Common.Exceptions;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Domain.Entities;
using MediatR;
using Serilog;

namespace CatalogService.Application.Features.V1.HoSoXuLyViPhams.Commands.DeleteHoSoXuLyViPham;

public class DeleteHoSoXuLyViPhamCommandHandler : IRequestHandler<DeleteHoSoXuLyViPhamCommand, bool>
{
    private readonly IHoSoXuLyViPhamRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "DeleteHoSoXuLyViPhamCommandHandler";

    public DeleteHoSoXuLyViPhamCommandHandler(IHoSoXuLyViPhamRepository repository, ILogger logger)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<bool> Handle(DeleteHoSoXuLyViPhamCommand request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var dkxp = await _repository.GetByIdAsync(request.Id);

        if (dkxp == null) throw new NotFoundException(nameof(HoSoXuLyViPham), request.Id);

        await _repository.DeleteHoSoXuLyViPham(dkxp);

        _logger.Information($"END: {MethodName}");

        return true;
    }
}
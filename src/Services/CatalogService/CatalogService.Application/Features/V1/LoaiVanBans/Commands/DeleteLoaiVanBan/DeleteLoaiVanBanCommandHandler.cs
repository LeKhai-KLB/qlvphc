using CatalogService.Application.Common.Exceptions;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Domain.Entities;
using MediatR;
using Serilog;

namespace CatalogService.Application.Features.V1.LoaiVanBans.Commands.DeleteLoaiVanBan;

public class DeleteLoaiVanBanCommandHandler : IRequestHandler<DeleteLoaiVanBanCommand, bool>
{
    private readonly ILoaiVanBanRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "DeleteLoaiVanBanCommandHandler";

    public DeleteLoaiVanBanCommandHandler(ILoaiVanBanRepository repository, ILogger logger)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<bool> Handle(DeleteLoaiVanBanCommand request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var lvb = await _repository.GetByIdAsync(request.Id);

        if (lvb == null) throw new NotFoundException(nameof(LoaiVanBan), request.Id);

        await _repository.DeleteLoaiVanBan(lvb);

        _logger.Information($"END: {MethodName}");

        return true;
    }
}
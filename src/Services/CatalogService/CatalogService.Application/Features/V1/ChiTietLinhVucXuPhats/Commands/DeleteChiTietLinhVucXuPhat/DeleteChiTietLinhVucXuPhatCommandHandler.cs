using CatalogService.Application.Common.Exceptions;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Domain.Entities;
using MediatR;
using Serilog;

namespace CatalogService.Application.Features.V1.ChiTietLinhVucXuPhats.Commands.DeleteChiTietLinhVucXuPhat;

public class DeleteChiTietLinhVucXuPhatCommandHandler : IRequestHandler<DeleteChiTietLinhVucXuPhatCommand, bool>
{
    private readonly IChiTietLinhVucXuPhatRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "DeleteChiTietLinhVucXuPhatCommandHandler";

    public DeleteChiTietLinhVucXuPhatCommandHandler(IChiTietLinhVucXuPhatRepository repository, ILogger logger)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<bool> Handle(DeleteChiTietLinhVucXuPhatCommand request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var chiTietLvxp = await _repository.GetByIdAsync(request.Id);

        if (chiTietLvxp == null) throw new NotFoundException(nameof(ChiTietLinhVucXuPhat), request.Id);

        await _repository.DeleteChiTietLinhVucXuPhat(chiTietLvxp);

        _logger.Information($"END: {MethodName}");

        return true;
    }
}
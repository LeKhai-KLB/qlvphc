using CatalogService.Application.Common.Exceptions;
using CatalogService.Application.Common.Interfaces;
using MediatR;
using Serilog;

namespace CatalogService.Application.Features.V1.TinhThanhPhos.Commands.DeleteTinhThanhPho
{
    public class DeleteTinhThanhPhoHandler : IRequestHandler<DeleteTinhThanhPhoCommand, bool>
    {
        private readonly ITinhThanhPhoRepository _repository;
        private readonly ILogger _logger;
        private const string MethodName = "DeleteTinhThanhPhoHandler";

        public DeleteTinhThanhPhoHandler(ITinhThanhPhoRepository repository, ILogger logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<bool> Handle(DeleteTinhThanhPhoCommand request, CancellationToken cancellationToken)
        {
            _logger.Information($"BEGIN: {MethodName}");

            var tinhThanhPho = await _repository.GetByIdAsync(request.Id);

            if (tinhThanhPho == null) throw new NotFoundException(nameof(tinhThanhPho), request.Id);
            await _repository.DeleteTinhThanhPho(tinhThanhPho);

            _logger.Information($"END: {MethodName}");

            return true;
        }
    }
}
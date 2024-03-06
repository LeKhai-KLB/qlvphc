using CatalogService.Application.Common.Exceptions;
using CatalogService.Application.Common.Interfaces;
using MediatR;
using Serilog;

namespace CatalogService.Application.Features.V1.QuyetDinhXuPhats.Commands.DeleteQuyetDinhXuPhat
{
    public class DeleteQuyetDinhXuPhatHandler : IRequestHandler<DeleteQuyetDinhXuPhatCommand, bool>
    {
        private readonly IQuyetDinhXuPhatRepository _repository;
        private readonly ILogger _logger;
        private const string MethodName = "DeleteQuyetDinhXuPhatHandler";

        public DeleteQuyetDinhXuPhatHandler(IQuyetDinhXuPhatRepository repository, ILogger logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<bool> Handle(DeleteQuyetDinhXuPhatCommand request, CancellationToken cancellationToken)
        {
            _logger.Information($"BEGIN: {MethodName}");

            var quyetDinhXuPhat = await _repository.GetByIdAsync(request.Id);

            if (quyetDinhXuPhat == null) throw new NotFoundException(nameof(quyetDinhXuPhat), request.Id);
            await _repository.DeleteQuyetDinhXuPhat(quyetDinhXuPhat);

            _logger.Information($"END: {MethodName}");

            return true;
        }
    }
}
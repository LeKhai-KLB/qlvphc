using CatalogService.Application.Common.Exceptions;
using CatalogService.Application.Common.Interfaces;
using MediatR;
using Serilog;

namespace CatalogService.Application.Features.V1.DanhMucDinhDanhs.Commands.DeleteDanhMucDinhDanh
{
    public class DeleteDanhMucDinhDanhHandler : IRequestHandler<DeleteDanhMucDinhDanhCommand, bool>
    {
        private readonly IDanhMucDinhDanhRepository _repository;
        private readonly ILogger _logger;
        private const string MethodName = "DeleteDanhMucDinhDanhHandler";

        public DeleteDanhMucDinhDanhHandler(IDanhMucDinhDanhRepository repository, ILogger logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<bool> Handle(DeleteDanhMucDinhDanhCommand request, CancellationToken cancellationToken)
        {
            _logger.Information($"BEGIN: {MethodName}");

            var danhMucDinhDanh = await _repository.GetByIdAsync(request.Id);

            if (danhMucDinhDanh == null) throw new NotFoundException(nameof(danhMucDinhDanh), request.Id);
            await _repository.DeleteDanhMucDinhDanh(danhMucDinhDanh);

            _logger.Information($"END: {MethodName}");

            return true;
        }
    }
}
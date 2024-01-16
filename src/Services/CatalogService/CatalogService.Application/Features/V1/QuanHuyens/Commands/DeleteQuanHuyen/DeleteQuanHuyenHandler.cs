using CatalogService.Application.Common.Exceptions;
using CatalogService.Application.Common.Interfaces;
using MediatR;
using Serilog;

namespace CatalogService.Application.Features.V1.QuanHuyens.Commands.DeleteQuanHuyen
{
    public class DeleteQuanHuyenHandler : IRequestHandler<DeleteQuanHuyenCommand, bool>
    {
        private readonly IQuanHuyenRepository _repository;
        private readonly ILogger _logger;
        private const string MethodName = "DeleteQuanHuyenHandler";

        public DeleteQuanHuyenHandler(IQuanHuyenRepository repository, ILogger logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<bool> Handle(DeleteQuanHuyenCommand request, CancellationToken cancellationToken)
        {
            _logger.Information($"BEGIN: {MethodName}");

            var QuanHuyen = await _repository.GetByIdAsync(request.Id);

            if (QuanHuyen == null) throw new NotFoundException(nameof(QuanHuyen), request.Id);
            await _repository.DeleteQuanHuyen(QuanHuyen);

            _logger.Information($"END: {MethodName}");

            return true;
        }
    }
}
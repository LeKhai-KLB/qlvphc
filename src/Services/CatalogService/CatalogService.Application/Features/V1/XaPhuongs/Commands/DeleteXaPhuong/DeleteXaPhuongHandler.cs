using CatalogService.Application.Common.Exceptions;
using CatalogService.Application.Common.Interfaces;
using MediatR;
using Serilog;

namespace CatalogService.Application.Features.V1.XaPhuongs.Commands.DeleteXaPhuong
{
    public class DeleteXaPhuongHandler : IRequestHandler<DeleteXaPhuongCommand, bool>
    {
        private readonly IXaPhuongRepository _repository;
        private readonly ILogger _logger;
        private const string MethodName = "DeleteXaPhuongHandler";

        public DeleteXaPhuongHandler(IXaPhuongRepository repository, ILogger logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<bool> Handle(DeleteXaPhuongCommand request, CancellationToken cancellationToken)
        {
            _logger.Information($"BEGIN: {MethodName}");

            var XaPhuong = await _repository.GetByIdAsync(request.Id);

            if (XaPhuong == null) throw new NotFoundException(nameof(XaPhuong), request.Id);
            await _repository.DeleteXaPhuong(XaPhuong);

            _logger.Information($"END: {MethodName}");

            return true;
        }
    }
}
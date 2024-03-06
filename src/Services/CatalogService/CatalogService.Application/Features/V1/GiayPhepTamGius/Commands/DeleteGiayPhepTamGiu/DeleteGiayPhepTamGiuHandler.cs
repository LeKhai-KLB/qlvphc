using CatalogService.Application.Common.Exceptions;
using CatalogService.Application.Common.Interfaces;
using MediatR;
using Serilog;

namespace CatalogService.Application.Features.V1.GiayPhepTamGius.Commands.DeleteGiayPhepTamGiu
{
    public class DeleteGiayPhepTamGiuHandler : IRequestHandler<DeleteGiayPhepTamGiuCommand, bool>
    {
        private readonly IGiayPhepTamGiuRepository _repository;
        private readonly ILogger _logger;
        private const string MethodName = "DeleteGiayPhepTamGiuHandler";

        public DeleteGiayPhepTamGiuHandler(IGiayPhepTamGiuRepository repository, ILogger logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<bool> Handle(DeleteGiayPhepTamGiuCommand request, CancellationToken cancellationToken)
        {
            _logger.Information($"BEGIN: {MethodName}");

            var giayPhepTamGiu = await _repository.GetByIdAsync(request.Id);

            if (giayPhepTamGiu == null) throw new NotFoundException(nameof(giayPhepTamGiu), request.Id);
            await _repository.DeleteGiayPhepTamGiu(giayPhepTamGiu);

            _logger.Information($"END: {MethodName}");

            return true;
        }
    }
}
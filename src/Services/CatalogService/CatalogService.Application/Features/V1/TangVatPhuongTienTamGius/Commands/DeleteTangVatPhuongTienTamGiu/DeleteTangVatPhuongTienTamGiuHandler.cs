using CatalogService.Application.Common.Exceptions;
using CatalogService.Application.Common.Interfaces;
using MediatR;
using Serilog;

namespace CatalogService.Application.Features.V1.TangVatPhuongTienTamGius.Commands.DeleteTangVatPhuongTienTamGiu
{
    public class DeleteTangVatPhuongTienTamGiuHandler : IRequestHandler<DeleteTangVatPhuongTienTamGiuCommand, bool>
    {
        private readonly ITangVatPhuongTienTamGiuRepository _repository;
        private readonly ILogger _logger;
        private const string MethodName = "DeleteTangVatPhuongTienTamGiuHandler";

        public DeleteTangVatPhuongTienTamGiuHandler(ITangVatPhuongTienTamGiuRepository repository, ILogger logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<bool> Handle(DeleteTangVatPhuongTienTamGiuCommand request, CancellationToken cancellationToken)
        {
            _logger.Information($"BEGIN: {MethodName}");

            var tangVatPhuongTienTamGiu = await _repository.GetByIdAsync(request.Id);

            if (tangVatPhuongTienTamGiu == null) throw new NotFoundException(nameof(tangVatPhuongTienTamGiu), request.Id);
            await _repository.DeleteTangVatPhuongTienTamGiu(tangVatPhuongTienTamGiu);

            _logger.Information($"END: {MethodName}");

            return true;
        }
    }
}
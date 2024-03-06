using CatalogService.Application.Common.Exceptions;
using CatalogService.Application.Common.Interfaces;
using MediatR;
using Serilog;

namespace CatalogService.Application.Features.V1.HinhThucXuPhatBoSungs.Commands.DeleteHinhThucXuPhatBoSung
{
    public class DeleteHinhThucXuPhatBoSungHandler : IRequestHandler<DeleteHinhThucXuPhatBoSungCommand, bool>
    {
        private readonly IHinhThucXuPhatBoSungRepository _repository;
        private readonly ILogger _logger;
        private const string MethodName = "DeleteHinhThucXuPhatBoSungHandler";

        public DeleteHinhThucXuPhatBoSungHandler(IHinhThucXuPhatBoSungRepository repository, ILogger logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<bool> Handle(DeleteHinhThucXuPhatBoSungCommand request, CancellationToken cancellationToken)
        {
            _logger.Information($"BEGIN: {MethodName}");

            var hinhThucXuPhatBoSung = await _repository.GetByIdAsync(request.Id);

            if (hinhThucXuPhatBoSung == null) throw new NotFoundException(nameof(hinhThucXuPhatBoSung), request.Id);
            await _repository.DeleteHinhThucXuPhatBoSung(hinhThucXuPhatBoSung);

            _logger.Information($"END: {MethodName}");

            return true;
        }
    }
}
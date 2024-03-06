using CatalogService.Application.Common.Exceptions;
using CatalogService.Application.Common.Interfaces;
using MediatR;
using Serilog;

namespace CatalogService.Application.Features.V1.HinhThucXuPhatChinhs.Commands.DeleteHinhThucXuPhatChinh
{
    public class DeleteHinhThucXuPhatChinhHandler : IRequestHandler<DeleteHinhThucXuPhatChinhCommand, bool>
    {
        private readonly IHinhThucXuPhatChinhRepository _repository;
        private readonly ILogger _logger;
        private const string MethodName = "DeleteHinhThucXuPhatChinhHandler";

        public DeleteHinhThucXuPhatChinhHandler(IHinhThucXuPhatChinhRepository repository, ILogger logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<bool> Handle(DeleteHinhThucXuPhatChinhCommand request, CancellationToken cancellationToken)
        {
            _logger.Information($"BEGIN: {MethodName}");

            var hinhThucXuPhatChinh = await _repository.GetByIdAsync(request.Id);

            if (hinhThucXuPhatChinh == null) throw new NotFoundException(nameof(hinhThucXuPhatChinh), request.Id);
            await _repository.DeleteHinhThucXuPhatChinh(hinhThucXuPhatChinh);

            _logger.Information($"END: {MethodName}");

            return true;
        }
    }
}
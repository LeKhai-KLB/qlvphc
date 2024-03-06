using AutoMapper;
using CatalogService.Application.Common.Exceptions;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.HinhThucXuPhatChinhs;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.HinhThucXuPhatChinhs.Commands.UpdateHinhThucXuPhatChinh
{
    public class UpdateHinhThucXuPhatChinhHandler : IRequestHandler<UpdateHinhThucXuPhatChinhCommand, ApiResult<HinhThucXuPhatChinhDto>>
    {
        private readonly IMapper _mapper;
        private readonly IHinhThucXuPhatChinhRepository _repository;
        private readonly ILogger _logger;
        private const string MethodName = "UpdateHinhThucXuPhatChinhHandler";

        public UpdateHinhThucXuPhatChinhHandler(IMapper mapper, IHinhThucXuPhatChinhRepository repository, ILogger logger)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<ApiResult<HinhThucXuPhatChinhDto>> Handle(UpdateHinhThucXuPhatChinhCommand request, CancellationToken cancellationToken)
        {
            _logger.Information($"BEGIN: {MethodName}");

            var updateHinhThucXuPhatChinh = await _repository.GetByIdAsync(request.Id);
            if (updateHinhThucXuPhatChinh == null)
            {
                throw new NotFoundException("Hinh Thuc Xu Phat Chinh not found");
            }

            updateHinhThucXuPhatChinh.Ten = request.Ten;

            await _repository.UpdateHinhThucXuPhatChinh(updateHinhThucXuPhatChinh);

            _logger.Information($"END: {MethodName}");

            return new ApiSuccessResult<HinhThucXuPhatChinhDto>(_mapper.Map<HinhThucXuPhatChinhDto>(updateHinhThucXuPhatChinh));
        }
    }
}
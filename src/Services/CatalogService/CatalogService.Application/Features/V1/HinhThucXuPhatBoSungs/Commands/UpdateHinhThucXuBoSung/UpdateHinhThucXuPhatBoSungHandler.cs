using AutoMapper;
using CatalogService.Application.Common.Exceptions;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.HinhThucXuPhatBoSungs;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.HinhThucXuPhatBoSungs.Commands.UpdateHinhThucXuPhatBoSung
{
    public class UpdateHinhThucXuPhatBoSungHandler : IRequestHandler<UpdateHinhThucXuPhatBoSungCommand, ApiResult<HinhThucXuPhatBoSungDto>>
    {
        private readonly IMapper _mapper;
        private readonly IHinhThucXuPhatBoSungRepository _repository;
        private readonly ILogger _logger;
        private const string MethodName = "UpdateHinhThucXuPhatBoSungHandler";

        public UpdateHinhThucXuPhatBoSungHandler(IMapper mapper, IHinhThucXuPhatBoSungRepository repository, ILogger logger)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<ApiResult<HinhThucXuPhatBoSungDto>> Handle(UpdateHinhThucXuPhatBoSungCommand request, CancellationToken cancellationToken)
        {
            _logger.Information($"BEGIN: {MethodName}");

            var updateHinhThucXuPhatBoSung = await _repository.GetByIdAsync(request.Id);
            if (updateHinhThucXuPhatBoSung == null)
            {
                throw new NotFoundException("Hinh Thuc Xu Phat Bo Sung not found");
            }

            updateHinhThucXuPhatBoSung.Ten = request.Ten;

            await _repository.UpdateHinhThucXuPhatBoSung(updateHinhThucXuPhatBoSung);

            _logger.Information($"END: {MethodName}");

            return new ApiSuccessResult<HinhThucXuPhatBoSungDto>(_mapper.Map<HinhThucXuPhatBoSungDto>(updateHinhThucXuPhatBoSung));
        }
    }
}
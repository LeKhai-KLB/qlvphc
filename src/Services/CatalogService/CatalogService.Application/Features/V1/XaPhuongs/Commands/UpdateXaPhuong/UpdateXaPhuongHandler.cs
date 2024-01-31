using AutoMapper;
using CatalogService.Application.Common.Exceptions;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.XaPhuongs;
using CatalogService.Domain.Entities;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.XaPhuongs.Commands.UpdateXaPhuong
{
    public class UpdateXaPhuongHandler : IRequestHandler<UpdateXaPhuongCommand, ApiResult<XaPhuongDto>>
    {
        private readonly IMapper _mapper;
        private readonly IXaPhuongRepository _repository;
        private readonly IQuanHuyenRepository _quanHuyenRepository;
        private readonly ILogger _logger;
        private const string MethodName = "UpdateXaPhuongHandler";

        public UpdateXaPhuongHandler(IMapper mapper, IXaPhuongRepository repository, ILogger logger, IQuanHuyenRepository quanHuyenRepository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _quanHuyenRepository = quanHuyenRepository;
        }

        public async Task<ApiResult<XaPhuongDto>> Handle(UpdateXaPhuongCommand request, CancellationToken cancellationToken)
        {
            _logger.Information($"BEGIN: {MethodName}");

            var updateXaPhuong = await _repository.GetByIdAsync(request.Id);
            if (updateXaPhuong == null)
            {
                throw new NotFoundException("Quan Huyen not found");
            }

            if (updateXaPhuong.MaDinhDanh != request.MaDinhDanh)
            {
                var existMaDinhDanh = await _repository.CheckExistMaDinhDanhXaPhuong(request.MaDinhDanh);
                if (existMaDinhDanh)
                {
                    return new ApiErrorResult<XaPhuongDto>("Ma Dinh Danh exists.");
                }
            }

            var quanHuyen = await _quanHuyenRepository.GetByIdAsync(request.QuanHuyenId);
            if (quanHuyen == null)
            {
                throw new NotFoundException("Quan Huyen not found");
            }

            updateXaPhuong.QuanHuyenId = request.QuanHuyenId;
            updateXaPhuong.MaDinhDanh = request.MaDinhDanh;
            updateXaPhuong.Ten = request.Ten;

            await _repository.UpdateXaPhuong(updateXaPhuong);

            _logger.Information($"END: {MethodName}");

            return new ApiSuccessResult<XaPhuongDto>(_mapper.Map<XaPhuongDto>(updateXaPhuong));
        }
    }
}
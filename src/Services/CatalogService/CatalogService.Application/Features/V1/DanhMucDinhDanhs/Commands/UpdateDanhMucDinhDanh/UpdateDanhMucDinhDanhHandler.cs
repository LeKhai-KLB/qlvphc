using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.DanhMucDinhDanhs;
using CatalogService.Domain.Entities;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.DanhMucDinhDanhs.Commands.UpdateDanhMucDinhDanh
{
    public class UpdateDanhMucDinhDanhHandler : IRequestHandler<UpdateDanhMucDinhDanhCommand, ApiResult<DanhMucDinhDanhDto>>
    {
        private readonly IMapper _mapper;
        private readonly IDanhMucDinhDanhRepository _repository;
        private readonly ILogger _logger;
        private const string MethodName = "UpdateDanhMucDinhDanhHandler";

        public UpdateDanhMucDinhDanhHandler(IMapper mapper, IDanhMucDinhDanhRepository repository, ILogger logger)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<ApiResult<DanhMucDinhDanhDto>> Handle(UpdateDanhMucDinhDanhCommand request, CancellationToken cancellationToken)
        {
            _logger.Information($"BEGIN: {MethodName}");

            var danhMucDinhDanh = _mapper.Map<DanhMucDinhDanh>(request);
            var existMaDinhDanh = await _repository.CheckExistMaDinhDanhDanhMucDinhDanh(request.MaDinhDanh);
            if (existMaDinhDanh)
            {
                return new ApiErrorResult<DanhMucDinhDanhDto>("Ma Dinh Danh exists.");
            }
            await _repository.UpdateDanhMucDinhDanh(danhMucDinhDanh);

            _logger.Information($"END: {MethodName}");

            return new ApiSuccessResult<DanhMucDinhDanhDto>(_mapper.Map<DanhMucDinhDanhDto>(danhMucDinhDanh));
        }
    }
}
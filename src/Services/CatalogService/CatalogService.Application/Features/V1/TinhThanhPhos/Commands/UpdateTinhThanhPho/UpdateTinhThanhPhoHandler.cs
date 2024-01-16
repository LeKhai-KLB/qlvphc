using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.TinhThanhPhos;
using CatalogService.Domain.Entities;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.TinhThanhPhos.Commands.UpdateTinhThanhPho
{
    public class UpdateTinhThanhPhoHandler : IRequestHandler<UpdateTinhThanhPhoCommand, ApiResult<TinhThanhPhoDto>>
    {
        private readonly IMapper _mapper;
        private readonly ITinhThanhPhoRepository _repository;
        private readonly ILogger _logger;
        private const string MethodName = "UpdateTinhThanhPhoHandler";

        public UpdateTinhThanhPhoHandler(IMapper mapper, ITinhThanhPhoRepository repository, ILogger logger)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<ApiResult<TinhThanhPhoDto>> Handle(UpdateTinhThanhPhoCommand request, CancellationToken cancellationToken)
        {
            _logger.Information($"BEGIN: {MethodName}");

            var tinhThanhPho = _mapper.Map<TinhThanhPho>(request);
            var existMaDinhDanh = await _repository.CheckExistMaDinhDanhTinhThanhPho(request.MaDinhDanh);
            if (existMaDinhDanh)
            {
                return new ApiErrorResult<TinhThanhPhoDto>("Ma Dinh Danh exists.");
            }
            await _repository.UpdateTinhThanhPho(tinhThanhPho);

            _logger.Information($"END: {MethodName}");

            return new ApiSuccessResult<TinhThanhPhoDto>(_mapper.Map<TinhThanhPhoDto>(tinhThanhPho));
        }
    }
}
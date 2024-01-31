using AutoMapper;
using CatalogService.Application.Common.Exceptions;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.QuanHuyens;
using CatalogService.Domain.Entities;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.QuanHuyens.Commands.UpdateQuanHuyen
{
    public class UpdateQuanHuyenHandler : IRequestHandler<UpdateQuanHuyenCommand, ApiResult<QuanHuyenDto>>
    {
        private readonly IMapper _mapper;
        private readonly IQuanHuyenRepository _repository;
        private readonly ITinhThanhPhoRepository _tinhThanhPhoRepository;
        private readonly ILogger _logger;
        private const string MethodName = "UpdateQuanHuyenHandler";

        public UpdateQuanHuyenHandler(IMapper mapper, IQuanHuyenRepository repository, ILogger logger, ITinhThanhPhoRepository tinhThanhPhoRepository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _tinhThanhPhoRepository = tinhThanhPhoRepository;
        }

        public async Task<ApiResult<QuanHuyenDto>> Handle(UpdateQuanHuyenCommand request, CancellationToken cancellationToken)
        {
            _logger.Information($"BEGIN: {MethodName}");

            var updateQuanHuyen = await _repository.GetByIdAsync(request.Id);
            if (updateQuanHuyen == null)
            {
                throw new NotFoundException("Quan Huyen not found");
            }

            if (updateQuanHuyen.MaDinhDanh != request.MaDinhDanh)
            {
                var existMaDinhDanh = await _repository.CheckExistMaDinhDanhQuanHuyen(request.MaDinhDanh);
                if (existMaDinhDanh)
                {
                    return new ApiErrorResult<QuanHuyenDto>("Ma Dinh Danh exists.");
                }
            }

            var tinhThanhPho = await _tinhThanhPhoRepository.GetByIdAsync(request.TinhThanhPhoId);
            if (tinhThanhPho == null)
            {
                throw new NotFoundException("Tinh Thanh Pho not found");
            }

            updateQuanHuyen.TinhThanhPhoId = request.TinhThanhPhoId;
            updateQuanHuyen.MaDinhDanh = request.MaDinhDanh;
            updateQuanHuyen.Ten = request.Ten;

            await _repository.UpdateQuanHuyen(updateQuanHuyen);

            _logger.Information($"END: {MethodName}");

            return new ApiSuccessResult<QuanHuyenDto>(_mapper.Map<QuanHuyenDto>(updateQuanHuyen));
        }
    }
}
﻿using AutoMapper;
using DanhMucService.Application.Common.Interfaces;
using DanhMucService.Application.Common.Models.QuanHuyens;
using DanhMucService.Domain.Entities;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace DanhMucService.Application.Features.V1.QuanHuyens.Commands.UpdateQuanHuyen
{
    public class UpdateQuanHuyenHandler : IRequestHandler<UpdateQuanHuyenCommand, ApiResult<QuanHuyenDto>>
    {
        private readonly IMapper _mapper;
        private readonly IQuanHuyenRepository _repository;
        private readonly ILogger _logger;
        private const string MethodName = "UpdateQuanHuyenHandler";

        public UpdateQuanHuyenHandler(IMapper mapper, IQuanHuyenRepository repository, ILogger logger)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<ApiResult<QuanHuyenDto>> Handle(UpdateQuanHuyenCommand request, CancellationToken cancellationToken)
        {
            _logger.Information($"BEGIN: {MethodName}");

            var QuanHuyen = _mapper.Map<QuanHuyen>(request);
            var existMaDinhDanh = await _repository.CheckExistMaDinhDanhQuanHuyen(request.MaDinhDanh);
            if (existMaDinhDanh)
            {
                return new ApiErrorResult<QuanHuyenDto>("Ma Dinh Danh exists.");
            }
            await _repository.UpdateQuanHuyen(QuanHuyen);

            _logger.Information($"END: {MethodName}");

            return new ApiSuccessResult<QuanHuyenDto>(_mapper.Map<QuanHuyenDto>(QuanHuyen));
        }
    }
}
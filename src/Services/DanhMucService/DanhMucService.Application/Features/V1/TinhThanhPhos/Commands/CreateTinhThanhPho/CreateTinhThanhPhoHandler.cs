using AutoMapper;
using DanhMucService.Application.Common.Interfaces;
using DanhMucService.Application.Common.Models.TinhThanhPhos;
using DanhMucService.Domain.Entities;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace DanhMucService.Application.Features.V1.TinhThanhPhos.Commands.CreateTinhThanhPho;

public class CreateTinhThanhPhoHandler : IRequestHandler<CreateTinhThanhPhoCommand, ApiResult<TinhThanhPhoDto>>
{
    private readonly IMapper _mapper;
    private readonly ITinhThanhPhoRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "CreateTinhThanhPhoHandler";

    public CreateTinhThanhPhoHandler(IMapper mapper, ITinhThanhPhoRepository repository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<ApiResult<TinhThanhPhoDto>> Handle(CreateTinhThanhPhoCommand request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var tinhThanhPho = _mapper.Map<TinhThanhPho>(request);

        var existMaDinhDanh = await _repository.CheckExistMaDinhDanhTinhThanhPho(request.MaDinhDanh);
        if (existMaDinhDanh)
        {
            return new ApiErrorResult<TinhThanhPhoDto>("Ma Dinh Danh exists.");
        }

        await _repository.CreateTinhThanhPho(tinhThanhPho);

        _logger.Information($"END: {MethodName}");

        return new ApiSuccessResult<TinhThanhPhoDto>(_mapper.Map<TinhThanhPhoDto>(tinhThanhPho));
    }
}
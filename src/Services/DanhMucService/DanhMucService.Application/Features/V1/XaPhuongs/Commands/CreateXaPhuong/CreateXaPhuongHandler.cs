using AutoMapper;
using DanhMucService.Application.Common.Interfaces;
using DanhMucService.Application.Common.Models.XaPhuongs;
using DanhMucService.Domain.Entities;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace DanhMucService.Application.Features.V1.XaPhuongs.Commands.CreateXaPhuong;

public class CreateXaPhuongHandler : IRequestHandler<CreateXaPhuongCommand, ApiResult<XaPhuongDto>>
{
    private readonly IMapper _mapper;
    private readonly IXaPhuongRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "CreateXaPhuongHandler";

    public CreateXaPhuongHandler(IMapper mapper, IXaPhuongRepository repository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<ApiResult<XaPhuongDto>> Handle(CreateXaPhuongCommand request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var xaPhuong = _mapper.Map<XaPhuong>(request);

        var existMaDinhDanh = await _repository.CheckExistMaDinhDanhXaPhuong(request.MaDinhDanh);
        if (existMaDinhDanh)
        {
            return new ApiErrorResult<XaPhuongDto>("Ma Dinh Danh exists.");
        }

        await _repository.CreateXaPhuong(xaPhuong);

        _logger.Information($"END: {MethodName}");

        return new ApiSuccessResult<XaPhuongDto>(_mapper.Map<XaPhuongDto>(xaPhuong));
    }
}
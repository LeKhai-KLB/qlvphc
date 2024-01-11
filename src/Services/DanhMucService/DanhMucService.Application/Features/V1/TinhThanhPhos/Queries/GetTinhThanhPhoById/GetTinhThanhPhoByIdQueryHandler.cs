using AutoMapper;
using DanhMucService.Application.Common.Interfaces;
using DanhMucService.Application.Common.Models.TinhThanhPhos;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace DanhMucService.Application.Features.V1.TinhThanhPhos.Queries.GetTinhThanhPhoById;

public class GetTinhThanhPhoByIdQueryHandler : IRequestHandler<GetTinhThanhPhoByIdQuery, ApiResult<TinhThanhPhoDto>>
{
    private readonly IMapper _mapper;
    private readonly ITinhThanhPhoRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "GetTinhThanhPhoByIdQueryHandler";

    public GetTinhThanhPhoByIdQueryHandler(IMapper mapper, ITinhThanhPhoRepository repository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger;
    }

    public async Task<ApiResult<TinhThanhPhoDto>> Handle(GetTinhThanhPhoByIdQuery request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var tinhThanhPho = await _repository.GetByIdAsync(request.Id);
        var tinhThanhPhoDto = _mapper.Map<TinhThanhPhoDto>(tinhThanhPho);

        _logger.Information($"END: {MethodName}");

        return new ApiSuccessResult<TinhThanhPhoDto>(tinhThanhPhoDto);
    }
}
using AutoMapper;
using DanhMucService.Application.Common.Interfaces;
using DanhMucService.Application.Common.Models.QuanHuyens;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace DanhMucService.Application.Features.V1.QuanHuyens.Queries.GetQuanHuyenByTinhThanhPhoId;

public class GetQuanHuyenByTinhThanhPhoIdQueryHandler : IRequestHandler<GetQuanHuyenByTinhThanhPhoIdQuery, ApiResult<IEnumerable<QuanHuyenDto>>>
{
    private readonly IMapper _mapper;
    private readonly IQuanHuyenRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "GetTinhThanhPhoByIdQueryHandler";

    public GetQuanHuyenByTinhThanhPhoIdQueryHandler(IMapper mapper, IQuanHuyenRepository repository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger;
    }

    public async Task<ApiResult<IEnumerable<QuanHuyenDto>>> Handle(GetQuanHuyenByTinhThanhPhoIdQuery request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var quanHuyenEntities = await _repository.GetQuanHuyenByTinhThanhPhoId(request.Id);
        var quanHuyenDtos = _mapper.Map<IEnumerable<QuanHuyenDto>>(quanHuyenEntities);

        _logger.Information($"END: {MethodName}");

        return new ApiSuccessResult<IEnumerable<QuanHuyenDto>>(quanHuyenDtos);
    }
}
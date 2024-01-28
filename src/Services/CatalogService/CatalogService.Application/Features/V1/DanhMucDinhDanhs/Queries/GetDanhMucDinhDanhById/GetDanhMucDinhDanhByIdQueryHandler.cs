using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.DanhMucDinhDanhs;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.DanhMucDinhDanhs.Queries.GetDanhMucDinhDanhById;

public class GetDanhMucDinhDanhByIdQueryHandler : IRequestHandler<GetDanhMucDinhDanhByIdQuery, ApiResult<DanhMucDinhDanhDto>>
{
    private readonly IMapper _mapper;
    private readonly IDanhMucDinhDanhRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "GetDanhMucDinhDanhByIdQueryHandler";

    public GetDanhMucDinhDanhByIdQueryHandler(IMapper mapper, IDanhMucDinhDanhRepository repository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger;
    }

    public async Task<ApiResult<DanhMucDinhDanhDto>> Handle(GetDanhMucDinhDanhByIdQuery request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var danhMucDinhDanh = await _repository.GetByIdAsync(request.Id);
        var danhMucDinhDanhDto = _mapper.Map<DanhMucDinhDanhDto>(danhMucDinhDanh);

        _logger.Information($"END: {MethodName}");

        return new ApiSuccessResult<DanhMucDinhDanhDto>(danhMucDinhDanhDto);
    }
}
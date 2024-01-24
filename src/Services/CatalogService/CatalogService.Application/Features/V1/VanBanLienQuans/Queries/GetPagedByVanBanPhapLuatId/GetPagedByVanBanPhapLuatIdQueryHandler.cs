using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.VanBanLienQuans;
using CatalogService.Application.Parameters.VanBanLienQuans;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.VanBanLienQuans.Queries.GetPagedByVanBanPhapLuatId;

public class GetPagedByVanBanPhapLuatIdQueryQueryHandler : IRequestHandler<GetPagedByVanBanPhapLuatIdQuery, ApiResult<IEnumerable<VanBanLienQuanDto>>>
{
    private readonly IMapper _mapper;
    private readonly IVanBanLienQuanRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "GetPagedByVanBanPhapLuatIdQueryQueryHandler";

    public GetPagedByVanBanPhapLuatIdQueryQueryHandler(IMapper mapper, IVanBanLienQuanRepository repository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger;
    }

    public async Task<ApiResult<IEnumerable<VanBanLienQuanDto>>> Handle(GetPagedByVanBanPhapLuatIdQuery request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var validFilter = _mapper.Map<VanBanLienQuanParameter>(request);
        var vblqs = await _repository.GetPagedByVanBanPhapLuatId(validFilter);
        var metaData = vblqs.GetMetaData();

        _logger.Information($"END: {MethodName}");

        return new PagedResponse<IEnumerable<VanBanLienQuanDto>>(_mapper.Map<List<VanBanLienQuanDto>>(vblqs), metaData.CurrentPage, metaData.TotalPages, metaData.PageSize, metaData.TotalItems);
    }
}
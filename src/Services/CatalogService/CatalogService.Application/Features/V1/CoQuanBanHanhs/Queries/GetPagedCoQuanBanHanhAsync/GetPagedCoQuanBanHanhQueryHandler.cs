using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.CoQuanBanHanhs;
using CatalogService.Application.Parameters.CoQuanBanHanhs;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.CoQuanBanHanhs.Queries.GetPagedCoQuanBanHanhAsync;

public class GetPagedCoQuanBanHanhQueryHandler : IRequestHandler<GetPagedCoQuanBanHanhQuery, PagedResponse<IEnumerable<CoQuanBanHanhDto>>>
{
    private readonly IMapper _mapper;
    private readonly ICoQuanBanHanhRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "GetPagedCoQuanBanHanhQueryHandler";

    public GetPagedCoQuanBanHanhQueryHandler(IMapper mapper, ICoQuanBanHanhRepository repository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger;
    }

    public async Task<PagedResponse<IEnumerable<CoQuanBanHanhDto>>> Handle(GetPagedCoQuanBanHanhQuery request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var validFilter = _mapper.Map<CoQuanBanHanhParameter>(request);
        var cqbhs = await _repository.GetPagedCoQuanBanHanhAsync(validFilter);
        var metaData = cqbhs.GetMetaData();

        _logger.Information($"END: {MethodName}");

        return new PagedResponse<IEnumerable<CoQuanBanHanhDto>>(_mapper.Map<List<CoQuanBanHanhDto>>(cqbhs), metaData.CurrentPage, metaData.TotalPages, metaData.PageSize, metaData.TotalItems);
    }
}
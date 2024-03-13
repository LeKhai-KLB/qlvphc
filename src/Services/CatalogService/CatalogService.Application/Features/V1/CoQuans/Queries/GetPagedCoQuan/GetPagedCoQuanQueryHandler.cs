using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.CoQuans;
using CatalogService.Application.Parameters.CoQuans;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.CoQuans.Queries.GetPagedCoQuan;

public class GetPagedCoQuanQueryHandler : IRequestHandler<GetPagedCoQuanQuery, PagedResponse<IEnumerable<CoQuanDto>>>
{
    private readonly IMapper _mapper;
    private readonly ICoQuanRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "GetPagedCoQuanQueryHandler";

    public GetPagedCoQuanQueryHandler(IMapper mapper, ICoQuanRepository repository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger;
    }

    public async Task<PagedResponse<IEnumerable<CoQuanDto>>> Handle(GetPagedCoQuanQuery request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var validFilter = _mapper.Map<CoQuanParameter>(request);
        var cqbhs = await _repository.GetPagedCoQuanAsync(validFilter);
        var metaData = cqbhs.GetMetaData();

        _logger.Information($"END: {MethodName}");

        return new PagedResponse<IEnumerable<CoQuanDto>>(_mapper.Map<List<CoQuanDto>>(cqbhs), metaData.CurrentPage, metaData.TotalPages, metaData.PageSize, metaData.TotalItems);
    }
}
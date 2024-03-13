using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.CongDans;
using CatalogService.Application.Parameters.CongDans;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.CongDans.Queries.GetPagedCongDan;

public class GetPagedCongDanQueryHandler : IRequestHandler<GetPagedCongDanQuery, PagedResponse<IEnumerable<CongDanDto>>>
{
    private readonly IMapper _mapper;
    private readonly ICongDanRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "GetPagedCongDanQueryHandler";

    public GetPagedCongDanQueryHandler(IMapper mapper, ICongDanRepository repository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger;
    }

    public async Task<PagedResponse<IEnumerable<CongDanDto>>> Handle(GetPagedCongDanQuery request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var validFilter = _mapper.Map<CongDanParameter>(request);
        var cqbhs = await _repository.GetPagedCongDanAsync(validFilter);
        var metaData = cqbhs.GetMetaData();

        _logger.Information($"END: {MethodName}");

        return new PagedResponse<IEnumerable<CongDanDto>>(_mapper.Map<List<CongDanDto>>(cqbhs), metaData.CurrentPage, metaData.TotalPages, metaData.PageSize, metaData.TotalItems);
    }
}
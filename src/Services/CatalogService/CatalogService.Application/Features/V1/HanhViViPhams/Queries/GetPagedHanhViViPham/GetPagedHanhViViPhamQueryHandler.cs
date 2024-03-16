using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.HanhViViPhams;
using CatalogService.Application.Parameters.HanhViViPhams;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.HanhViViPhams.Queries.GetPagedHanhViViPham;

public class GetPagedHanhViViPhamQueryHandler : IRequestHandler<GetPagedHanhViViPhamQuery, PagedResponse<IEnumerable<HanhViViPhamDto>>>
{
    private readonly IMapper _mapper;
    private readonly IHanhViViPhamRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "GetPagedHanhViViPhamQueryHandler";

    public GetPagedHanhViViPhamQueryHandler(IMapper mapper, IHanhViViPhamRepository repository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger;
    }

    public async Task<PagedResponse<IEnumerable<HanhViViPhamDto>>> Handle(GetPagedHanhViViPhamQuery request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var validFilter = _mapper.Map<HanhViViPhamParameter>(request);
        var cqbhs = await _repository.GetPagedHanhViViPham(validFilter);
        var metaData = cqbhs.GetMetaData();

        _logger.Information($"END: {MethodName}");

        return new PagedResponse<IEnumerable<HanhViViPhamDto>>(_mapper.Map<List<HanhViViPhamDto>>(cqbhs), metaData.CurrentPage, metaData.TotalPages, metaData.PageSize, metaData.TotalItems);
    }
}
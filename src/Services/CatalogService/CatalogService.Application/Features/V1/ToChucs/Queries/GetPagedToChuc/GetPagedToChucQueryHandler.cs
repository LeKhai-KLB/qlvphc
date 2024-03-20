using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.ToChucs;
using CatalogService.Application.Parameters.ToChucs;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.ToChucs.Queries.GetPagedToChuc;

public class GetPagedToChucQueryHandler : IRequestHandler<GetPagedToChucQuery, PagedResponse<IEnumerable<ToChucDto>>>
{
    private readonly IMapper _mapper;
    private readonly IToChucRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "GetPagedToChucQueryHandler";

    public GetPagedToChucQueryHandler(IMapper mapper, IToChucRepository repository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger;
    }

    public async Task<PagedResponse<IEnumerable<ToChucDto>>> Handle(GetPagedToChucQuery request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var validFilter = _mapper.Map<ToChucParameter>(request);
        var cqbhs = await _repository.GetPagedToChucAsync(validFilter);
        var metaData = cqbhs.GetMetaData();

        _logger.Information($"END: {MethodName}");

        return new PagedResponse<IEnumerable<ToChucDto>>(_mapper.Map<List<ToChucDto>>(cqbhs), metaData.CurrentPage, metaData.TotalPages, metaData.PageSize, metaData.TotalItems);
    }
}
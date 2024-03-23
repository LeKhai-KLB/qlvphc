using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.KhoBacs;
using CatalogService.Application.Parameters.KhoBacs;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.KhoBacs.Queries.GetPagedKhoBac;

public class GetPagedKhoBacQueryHandler : IRequestHandler<GetPagedKhoBacQuery, PagedResponse<IEnumerable<KhoBacDto>>>
{
    private readonly IMapper _mapper;
    private readonly IKhoBacRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "GetPagedKhoBacQueryHandler";

    public GetPagedKhoBacQueryHandler(IMapper mapper, IKhoBacRepository repository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger;
    }

    public async Task<PagedResponse<IEnumerable<KhoBacDto>>> Handle(GetPagedKhoBacQuery request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var validFilter = _mapper.Map<KhoBacParameter>(request);
        var cqbhs = await _repository.GetPagedKhoBacAsync(validFilter);
        var metaData = cqbhs.GetMetaData();

        _logger.Information($"END: {MethodName}");

        return new PagedResponse<IEnumerable<KhoBacDto>>(_mapper.Map<List<KhoBacDto>>(cqbhs), metaData.CurrentPage, metaData.TotalPages, metaData.PageSize, metaData.TotalItems);
    }
}
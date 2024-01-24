using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.LinhVucXuPhats;
using CatalogService.Application.Parameters.LinhVucXuPhats;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.LinhVucXuPhats.Queries.GetPagedLinhVucXuPhatAsync;

public class GetPagedLinhVucXuPhatQueryHandler : IRequestHandler<GetPagedLinhVucXuPhatQuery, PagedResponse<IEnumerable<LinhVucXuPhatDto>>>
{
    private readonly IMapper _mapper;
    private readonly ILinhVucXuPhatRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "GetPagedLinhVucXuPhatQueryHandler";

    public GetPagedLinhVucXuPhatQueryHandler(IMapper mapper, ILinhVucXuPhatRepository repository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger;
    }

    public async Task<PagedResponse<IEnumerable<LinhVucXuPhatDto>>> Handle(GetPagedLinhVucXuPhatQuery request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var validFilter = _mapper.Map<LinhVucXuPhatParameter>(request);
        var lvxps = await _repository.GetPagedLinhVucXuPhatAsync(validFilter);
        var metaData = lvxps.GetMetaData();

        _logger.Information($"END: {MethodName}");

        return new PagedResponse<IEnumerable<LinhVucXuPhatDto>>(_mapper.Map<List<LinhVucXuPhatDto>>(lvxps), metaData.CurrentPage, metaData.TotalPages, metaData.PageSize, metaData.TotalItems);
    }
}
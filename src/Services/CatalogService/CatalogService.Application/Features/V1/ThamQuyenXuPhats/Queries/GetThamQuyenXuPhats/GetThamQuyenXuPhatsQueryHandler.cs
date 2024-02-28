using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.ThamQuyenXuPhats;
using CatalogService.Application.Parameters.ThamQuyenXuPhats;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.ThamQuyenXuPhats.Queries.GetThamQuyenXuPhats;

public class GetThamQuyenXuPhatsQueryHandler : IRequestHandler<GetThamQuyenXuPhatsQuery, PagedResponse<IEnumerable<ThamQuyenXuPhatDto>>>
{
    private readonly IMapper _mapper;
    private readonly IThamQuyenXuPhatRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "GetAllThamQuyenXuPhatQueryHandler";

    public GetThamQuyenXuPhatsQueryHandler(IMapper mapper, IThamQuyenXuPhatRepository repository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger;
    }

    public async Task<PagedResponse<IEnumerable<ThamQuyenXuPhatDto>>> Handle(GetThamQuyenXuPhatsQuery request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var validFilter = _mapper.Map<ThamQuyenXuPhatParameter>(request);
        var dkxps = await _repository.GetPagedThamQuyenXuPhatAsync(validFilter);
        var metaData = dkxps.GetMetaData();

        _logger.Information($"END: {MethodName}");

        return new PagedResponse<IEnumerable<ThamQuyenXuPhatDto>>(_mapper.Map<List<ThamQuyenXuPhatDto>>(dkxps), metaData.CurrentPage, metaData.TotalPages, metaData.PageSize, metaData.TotalItems);
    }
}
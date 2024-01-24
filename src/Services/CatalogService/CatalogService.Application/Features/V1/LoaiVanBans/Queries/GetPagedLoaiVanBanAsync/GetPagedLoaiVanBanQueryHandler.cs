using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.LoaiVanBans;
using CatalogService.Application.Parameters.LoaiVanBans;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.LoaiVanBans.Queries.GetPagedLoaiVanBanAsync;

public class GetPagedLoaiVanBanQueryHandler : IRequestHandler<GetPagedLoaiVanBanQuery, PagedResponse<IEnumerable<LoaiVanBanDto>>>
{
    private readonly IMapper _mapper;
    private readonly ILoaiVanBanRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "GetPagedLoaiVanBanQueryHandler";

    public GetPagedLoaiVanBanQueryHandler(IMapper mapper, ILoaiVanBanRepository repository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger;
    }

    public async Task<PagedResponse<IEnumerable<LoaiVanBanDto>>> Handle(GetPagedLoaiVanBanQuery request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var validFilter = _mapper.Map<LoaiVanBanParameter>(request);
        var lvbs = await _repository.GetPagedLoaiVanBanAsync(validFilter);
        var metaData = lvbs.GetMetaData();

        _logger.Information($"END: {MethodName}");

        return new PagedResponse<IEnumerable<LoaiVanBanDto>>(_mapper.Map<List<LoaiVanBanDto>>(lvbs), metaData.CurrentPage, metaData.TotalPages, metaData.PageSize, metaData.TotalItems);
    }
}
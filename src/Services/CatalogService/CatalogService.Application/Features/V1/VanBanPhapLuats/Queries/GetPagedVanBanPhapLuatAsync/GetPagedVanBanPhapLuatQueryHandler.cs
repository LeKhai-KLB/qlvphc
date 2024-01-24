using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.VanBanPhapLuats;
using CatalogService.Application.Parameters.VanBanPhapLuats;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.VanBanPhapLuats.Queries.GetPagedVanBanPhapLuatAsync;

public class GetPagedVanBanPhapLuatQueryHandler : IRequestHandler<GetPagedVanBanPhapLuatQuery, PagedResponse<IEnumerable<VanBanPhapLuatDto>>>
{
    private readonly IMapper _mapper;
    private readonly IVanBanPhapLuatRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "GetPagedVanBanPhapLuatQueryHandler";

    public GetPagedVanBanPhapLuatQueryHandler(IMapper mapper, IVanBanPhapLuatRepository repository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger;
    }

    public async Task<PagedResponse<IEnumerable<VanBanPhapLuatDto>>> Handle(GetPagedVanBanPhapLuatQuery request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var validFilter = _mapper.Map<VanBanPhapLuatParameter>(request);
        var vbpls = await _repository.GetPagedVanBanPhapLuatAsync(validFilter);
        var metaData = vbpls.GetMetaData();

        _logger.Information($"END: {MethodName}");

        return new PagedResponse<IEnumerable<VanBanPhapLuatDto>>(_mapper.Map<List<VanBanPhapLuatDto>>(vbpls), metaData.CurrentPage, metaData.TotalPages, metaData.PageSize, metaData.TotalItems);
    }
}
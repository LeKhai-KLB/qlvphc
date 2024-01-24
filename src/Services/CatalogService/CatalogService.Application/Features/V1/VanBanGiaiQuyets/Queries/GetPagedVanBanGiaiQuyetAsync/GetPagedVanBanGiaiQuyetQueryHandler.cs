using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.VanBanGiaiQuyets;
using CatalogService.Application.Parameters.VanBanGiaiQuyets;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.VanBanGiaiQuyets.Queries.GetPagedVanBanGiaiQuyetAsync;

public class GetPagedVanBanGiaiQuyetQueryHandler : IRequestHandler<GetPagedVanBanGiaiQuyetQuery, PagedResponse<IEnumerable<VanBanGiaiQuyetDto>>>
{
    private readonly IMapper _mapper;
    private readonly IVanBanGiaiQuyetRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "GetPagedVanBanGiaiQuyetQueryHandler";

    public GetPagedVanBanGiaiQuyetQueryHandler(IMapper mapper, IVanBanGiaiQuyetRepository repository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger;
    }

    public async Task<PagedResponse<IEnumerable<VanBanGiaiQuyetDto>>> Handle(GetPagedVanBanGiaiQuyetQuery request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var validFilter = _mapper.Map<VanBanGiaiQuyetParameter>(request);
        var vbgqs = await _repository.GetPagedVanBanGiaiQuyetAsync(validFilter);
        var metaData = vbgqs.GetMetaData();

        _logger.Information($"END: {MethodName}");

        return new PagedResponse<IEnumerable<VanBanGiaiQuyetDto>>(_mapper.Map<List<VanBanGiaiQuyetDto>>(vbgqs), metaData.CurrentPage, metaData.TotalPages, metaData.PageSize, metaData.TotalItems);
    }
}
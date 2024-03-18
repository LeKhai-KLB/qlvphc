using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.ChiTietHSXLVPVVBGQs;
using CatalogService.Application.Parameters.ChiTietHSXLVPVVBGQs;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.ChiTietHSXLVPVVBGQs.Queries.GetPagedChiTietHSXLVPVVBGQ;

public class GetPagedChiTietHSXLVPVVBGQQueryHandler : IRequestHandler<GetPagedChiTietHSXLVPVVBGQQuery, PagedResponse<IEnumerable<ChiTietHSXLVPVVBGQDto>>>
{
    private readonly IMapper _mapper;
    private readonly IChiTietHSXLVPVVBGQRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "GetPagedChiTietHSXLVPVVBGQQueryHandler";

    public GetPagedChiTietHSXLVPVVBGQQueryHandler(IMapper mapper, IChiTietHSXLVPVVBGQRepository repository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger;
    }

    public async Task<PagedResponse<IEnumerable<ChiTietHSXLVPVVBGQDto>>> Handle(GetPagedChiTietHSXLVPVVBGQQuery request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var validFilter = _mapper.Map<ChiTietHSXLVPVVBGQParameter>(request);
        var cqbhs = await _repository.GetPagedChiTietHSXLVPVVBGQAsync(validFilter);
        var metaData = cqbhs.GetMetaData();

        _logger.Information($"END: {MethodName}");

        return new PagedResponse<IEnumerable<ChiTietHSXLVPVVBGQDto>>(_mapper.Map<List<ChiTietHSXLVPVVBGQDto>>(cqbhs), metaData.CurrentPage, metaData.TotalPages, metaData.PageSize, metaData.TotalItems);
    }
}
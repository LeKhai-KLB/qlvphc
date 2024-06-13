using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.HoSoXuLyViPhams;
using CatalogService.Application.Parameters.HoSoXuLyViPhams;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.HSVPVanBanGiaiQuyet.Queries.GetPagedVanBanByHSVPId;

public class GetPagedVanBanByHSVPIdQueryHandler : IRequestHandler<GetPagedVanBanByHSVPIdQuery, PagedResponse<IEnumerable<HSVPVanBanGiaiQuyetDto>>>
{
    private readonly IMapper _mapper;
    private readonly IHoSoXuLyViPham_VanBanGiaiQuyetRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "GetPagedVanBanByHSVPIdQueryHandler";

    public GetPagedVanBanByHSVPIdQueryHandler(IMapper mapper, IHoSoXuLyViPham_VanBanGiaiQuyetRepository repository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger;
    }

    public async Task<PagedResponse<IEnumerable<HSVPVanBanGiaiQuyetDto>>> Handle(GetPagedVanBanByHSVPIdQuery request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var validFilter = _mapper.Map<HSVPVanBanGiaiQuyetParameter>(request);
        var lvxps = await _repository.GetPagedVanBanByHSVPId(validFilter);
        var metaData = lvxps.GetMetaData();

        _logger.Information($"END: {MethodName}");

        return new PagedResponse<IEnumerable<HSVPVanBanGiaiQuyetDto>>(_mapper.Map<List<HSVPVanBanGiaiQuyetDto>>(lvxps), metaData.CurrentPage, metaData.TotalPages, metaData.PageSize, metaData.TotalItems);
    }
}
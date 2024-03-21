using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.HoSoXuLyViPhams;
using CatalogService.Application.Parameters.HoSoXuLyViPhams;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.HoSoXuLyViPhams.Queries.GetPagedHoSoXuLyViPham;

public class GetPagedHoSoXuLyViPhamQueryHandler : IRequestHandler<GetPagedHoSoXuLyViPhamQuery, PagedResponse<IEnumerable<HoSoXuLyViPhamDto>>>
{
    private readonly IMapper _mapper;
    private readonly IHoSoXuLyViPhamRepository _repository;
    private readonly IHanhViViPhamRepository _hvvpRepository;
    private readonly ILogger _logger;
    private const string MethodName = "GetPagedHoSoXuLyViPhamQueryHandler";

    public GetPagedHoSoXuLyViPhamQueryHandler(IMapper mapper, IHoSoXuLyViPhamRepository repository, IHanhViViPhamRepository hvvpRepository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _hvvpRepository = hvvpRepository ?? throw new ArgumentNullException(nameof(hvvpRepository));
        _logger = logger;
    }

    public async Task<PagedResponse<IEnumerable<HoSoXuLyViPhamDto>>> Handle(GetPagedHoSoXuLyViPhamQuery request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var validFilter = _mapper.Map<HoSoXuLyViPhamParameter>(request);
        var lvxps = await _repository.GetPagedHoSoXuLyViPhamAsync(validFilter);
        var metaData = lvxps.GetMetaData();

        var hsvpDto = _mapper.Map<List<HoSoXuLyViPhamDto>>(lvxps);
        if (hsvpDto.Any())
        {
            foreach(var hs in hsvpDto)
            {
                var hvvps = await _hvvpRepository.GetQDHVVPByHoSoXuLyViPhamId(hs.Id);
                hs.HanhViViPhams = hvvps.Where(x => !string.IsNullOrEmpty(x)).ToList();
            }
        }

        _logger.Information($"END: {MethodName}");

        return new PagedResponse<IEnumerable<HoSoXuLyViPhamDto>>(hsvpDto, metaData.CurrentPage, metaData.TotalPages, metaData.PageSize, metaData.TotalItems);
    }
}
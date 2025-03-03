using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.HoSoXuLyViPhams;
using CatalogService.Application.Parameters.HoSoXuLyViPhams;
using MediatR;
using Newtonsoft.Json;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.HoSoXuLyViPhams.Queries.GetPagedHoSoXuLyViPham;

public class GetPagedHoSoXuLyViPhamQueryHandler : IRequestHandler<GetPagedHoSoXuLyViPhamQuery, PagedResponse<IEnumerable<HoSoXuLyViPhamDto>>>
{
    private readonly IMapper _mapper;
    private readonly IHoSoXuLyViPhamRepository _hsxlvpRepository;
    private readonly IHanhViViPhamRepository _hvvpRepository;
    private readonly IHoSoXuLyViPham_VanBanGiaiQuyetRepository _hSXLVP_VBGQRepository;
    private readonly ILogger _logger;
    private const string MethodName = "GetPagedHoSoXuLyViPhamQueryHandler";

    public GetPagedHoSoXuLyViPhamQueryHandler(IMapper mapper, IHoSoXuLyViPhamRepository hsxlvpRepository, IHanhViViPhamRepository hvvpRepository, ILogger logger, IHoSoXuLyViPham_VanBanGiaiQuyetRepository hSXLVP_VBGQRepository)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _hsxlvpRepository = hsxlvpRepository ?? throw new ArgumentNullException(nameof(hsxlvpRepository));
        _hvvpRepository = hvvpRepository ?? throw new ArgumentNullException(nameof(hvvpRepository));
        _logger = logger;
        _hSXLVP_VBGQRepository = hSXLVP_VBGQRepository;
    }

    public async Task<PagedResponse<IEnumerable<HoSoXuLyViPhamDto>>> Handle(GetPagedHoSoXuLyViPhamQuery request, CancellationToken cancellationToken)
    {
        // TODO : change to use include
        _logger.Information($"BEGIN: {MethodName}");

        var validFilter = _mapper.Map<HoSoXuLyViPhamParameter>(request);
        var hsxlvp = await _hsxlvpRepository.GetPagedHoSoXuLyViPhamAsync(validFilter);
        var metaData = hsxlvp.GetMetaData();

        var hsxlvpDto = _mapper.Map<List<HoSoXuLyViPhamDto>>(hsxlvp);

        if (hsxlvpDto.Any())
        {
            foreach (var hs in hsxlvpDto)
            {
                var hinhAnhViPham = hsxlvp?.FirstOrDefault(h => h.Id == hs.Id)?.HinhAnhViPham;
                hs.HinhAnhViPhams = !string.IsNullOrEmpty(hinhAnhViPham) ? JsonConvert.DeserializeObject<List<string>>(hinhAnhViPham) : null;

                var hvvps = await _hvvpRepository.GetQDHVVPByHoSoXuLyViPhamId(hs.Id);
                hs.HanhViViPhams = hvvps.Where(x => !string.IsNullOrEmpty(x)).ToList();

                var hsxlvp_vbgps = await _hSXLVP_VBGQRepository.GetHoSoXuLyViPham_VanBanGiaiQuyetsByHoSoXuLyViPhamId(hs.Id);
                hs.VanBanGiaiQuyetIds = hsxlvp_vbgps.Select(x => x.VanBanGiaiQuyetId).ToList();
            }
        }

        _logger.Information($"END: {MethodName}");

        return new PagedResponse<IEnumerable<HoSoXuLyViPhamDto>>(hsxlvpDto, metaData.CurrentPage, metaData.TotalPages, metaData.PageSize, metaData.TotalItems);
    }
}
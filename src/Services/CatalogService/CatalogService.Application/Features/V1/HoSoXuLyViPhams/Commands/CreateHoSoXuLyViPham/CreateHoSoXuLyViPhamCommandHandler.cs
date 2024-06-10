using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.HoSoXuLyViPhams;
using CatalogService.Domain.Entities;
using MediatR;
using Newtonsoft.Json;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.HoSoXuLyViPhams.Commands.CreateHoSoXuLyViPham;

public class CreateHoSoXuLyViPhamCommandHandler : IRequestHandler<CreateHoSoXuLyViPhamCommand, ApiResult<HoSoXuLyViPhamDto>>
{
    private readonly IMapper _mapper;
    private readonly IHoSoXuLyViPhamRepository _repository;
    private readonly IHSVPVanBanGiaiQuyetRepository _hSVPVBGQrepository;
    private readonly ILogger _logger;
    private const string MethodName = "CreateHoSoXuLyViPhamCommandHandler";

    public CreateHoSoXuLyViPhamCommandHandler(IMapper mapper, IHoSoXuLyViPhamRepository repository, IHSVPVanBanGiaiQuyetRepository hSVPVBGQrepository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _hSVPVBGQrepository = hSVPVBGQrepository ?? throw new ArgumentNullException(nameof(hSVPVBGQrepository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<ApiResult<HoSoXuLyViPhamDto>> Handle(CreateHoSoXuLyViPhamCommand request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var hoso = _mapper.Map<HoSoXuLyViPham>(request);
        hoso.HinhAnhViPham = JsonConvert.SerializeObject(request.HinhAnhViPhams);
        var hosoId = await _repository.CreateHoSoXuLyViPham(hoso);
        if (hosoId != 0 && request.VanBanGiaiQuyetIds != null && request.VanBanGiaiQuyetIds.Any())
        {
            foreach(var vbId in request.VanBanGiaiQuyetIds)
            {
                await _hSVPVBGQrepository.CreateHSVPVanBan(new HSXLVP_VanBanGiaiQuyet
                {
                    HoSoXuLyViPhamId = hosoId,
                    VanBanGiaiQuyetId = vbId,
                    NgayNhap = DateTime.Now
                });
            }
        }

        _logger.Information($"END: {MethodName}");

        return new ApiSuccessResult<HoSoXuLyViPhamDto>(_mapper.Map<HoSoXuLyViPhamDto>(hoso));
    }
}
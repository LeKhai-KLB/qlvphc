using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.HoSoXuLyViPhams;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.HSVPVanBanGiaiQuyet.Queries.GetHSVPVanBanById;

public class GetHSVPVanBanByIdQueryHandler : IRequestHandler<GetHoSoXuLyViPham_VanBanGiaiQuyetByIdQuery, ApiResult<HoSoXuLyViPham_VanBanGiaiQuyetDto>>
{
    private readonly IMapper _mapper;
    private readonly IHoSoXuLyViPham_VanBanGiaiQuyetRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "GetHSVPVanBanByIdQueryHandler";

    public GetHSVPVanBanByIdQueryHandler(IMapper mapper, IHoSoXuLyViPham_VanBanGiaiQuyetRepository repository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger;
    }

    public async Task<ApiResult<HoSoXuLyViPham_VanBanGiaiQuyetDto>> Handle(GetHoSoXuLyViPham_VanBanGiaiQuyetByIdQuery request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var lvxpEntity = await _repository.GetHoSoXuLyViPham_VanBanQiaiQuyetById(request.HoSoXuLyViPhamId, request.VanBanGiaiQuyetId);
        var lvxpDto = _mapper.Map<HoSoXuLyViPham_VanBanGiaiQuyetDto>(lvxpEntity);

        _logger.Information($"END: {MethodName}");

        return new ApiSuccessResult<HoSoXuLyViPham_VanBanGiaiQuyetDto>(lvxpDto);
    }
}
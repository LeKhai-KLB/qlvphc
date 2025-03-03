using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.HoSoXuLyViPhams;
using CatalogService.Domain.Entities;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.HSVPVanBanGiaiQuyet.Commands.UpdateHSVPVanBanGiaiQuyet;

public class UpdateHSVPVanBanGiaiQuyetCommandHandler : IRequestHandler<UpdateHoSoXuLyViPham_VanBanGiaiQuyetCommand, ApiResult<HoSoXuLyViPham_VanBanGiaiQuyetDto>>
{
    private readonly IMapper _mapper;
    private readonly IHoSoXuLyViPham_VanBanGiaiQuyetRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "UpdateHoSoXuLyViPham_VanBanGiaiQuyetCommandHandler";

    public UpdateHSVPVanBanGiaiQuyetCommandHandler(IMapper mapper, IHoSoXuLyViPham_VanBanGiaiQuyetRepository repository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<ApiResult<HoSoXuLyViPham_VanBanGiaiQuyetDto>> Handle(UpdateHoSoXuLyViPham_VanBanGiaiQuyetCommand request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var hsxlvpDb = await _repository.GetHoSoXuLyViPham_VanBanQiaiQuyetById(request.HoSoXuLyViPhamId, request.VanBanGiaiQuyetId);
        if (hsxlvpDb == null)
        {
            return new ApiErrorResult<HoSoXuLyViPham_VanBanGiaiQuyetDto>("Ho so xu ly vi pham va van ban giai quyet khong ton tai.");
        }

        hsxlvpDb.SoQuyetDinh = request.SoQuyetDinh;
        hsxlvpDb.NgayNhap = request.NgayNhap;
        await _repository.UpdateHoSoXuLyViPham_VanBanGiaiQuyet(hsxlvpDb);

        _logger.Information($"END: {MethodName}");

        return new ApiSuccessResult<HoSoXuLyViPham_VanBanGiaiQuyetDto>(_mapper.Map<HoSoXuLyViPham_VanBanGiaiQuyetDto>(hsxlvpDb));
    }
}
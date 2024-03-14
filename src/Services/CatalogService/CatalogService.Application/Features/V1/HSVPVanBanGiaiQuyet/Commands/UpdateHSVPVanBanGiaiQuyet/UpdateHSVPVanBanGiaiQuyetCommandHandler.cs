using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.HoSoXuLyViPhams;
using CatalogService.Domain.Entities;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.HSVPVanBanGiaiQuyet.Commands.UpdateHSVPVanBanGiaiQuyet;

public class UpdateHSVPVanBanGiaiQuyetCommandHandler : IRequestHandler<UpdateHSVPVanBanGiaiQuyetCommand, ApiResult<HSVPVanBanGiaiQuyetDto>>
{
    private readonly IMapper _mapper;
    private readonly IHSVPVanBanGiaiQuyetRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "UpdateHSVPVanBanGiaiQuyetCommandHandler";

    public UpdateHSVPVanBanGiaiQuyetCommandHandler(IMapper mapper, IHSVPVanBanGiaiQuyetRepository repository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<ApiResult<HSVPVanBanGiaiQuyetDto>> Handle(UpdateHSVPVanBanGiaiQuyetCommand request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var dkxp = _mapper.Map<HSXLVP_VanBanGiaiQuyet>(request);
        var dkxpDb = await _repository.GetHSVPVanBanById(request.HoSoXuLyViPhamId, request.VanBanGiaiQuyetId);
        if (dkxpDb == null)
        {
            return new ApiErrorResult<HSVPVanBanGiaiQuyetDto>("Ho so xu ly vi pham & van ban giai quyet not exists.");
        }

        await _repository.UpdateHSVPVanBan(dkxp);

        _logger.Information($"END: {MethodName}");

        return new ApiSuccessResult<HSVPVanBanGiaiQuyetDto>(_mapper.Map<HSVPVanBanGiaiQuyetDto>(dkxp));
    }
}
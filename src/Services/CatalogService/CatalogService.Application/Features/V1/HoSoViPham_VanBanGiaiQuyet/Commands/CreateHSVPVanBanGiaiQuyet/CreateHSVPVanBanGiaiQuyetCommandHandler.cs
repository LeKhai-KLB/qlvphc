using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.HoSoXuLyViPhams;
using CatalogService.Domain.Entities;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.HSVPVanBanGiaiQuyet.Commands.CreateHSVPVanBanGiaiQuyet;

public class CreateHSVPVanBanGiaiQuyetCommandHandler : IRequestHandler<CreateHoSoXuLyViPham_VanBanGiaiQuyetCommand, ApiResult<HoSoXuLyViPham_VanBanGiaiQuyetDto>>
{
    private readonly IMapper _mapper;
    private readonly IHoSoXuLyViPham_VanBanGiaiQuyetRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "CreateHSVPVanBanGiaiQuyetCommandHandler";

    public CreateHSVPVanBanGiaiQuyetCommandHandler(IMapper mapper, IHoSoXuLyViPham_VanBanGiaiQuyetRepository repository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<ApiResult<HoSoXuLyViPham_VanBanGiaiQuyetDto>> Handle(CreateHoSoXuLyViPham_VanBanGiaiQuyetCommand request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var dkxp = _mapper.Map<HoSoXuLyViPham_VanBanGiaiQuyet>(request);

        await _repository.CreateHSVPVanBan(dkxp);

        _logger.Information($"END: {MethodName}");

        return new ApiSuccessResult<HoSoXuLyViPham_VanBanGiaiQuyetDto>(_mapper.Map<HoSoXuLyViPham_VanBanGiaiQuyetDto>(dkxp));
    }
}
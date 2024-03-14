using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.HoSoXuLyViPhams;
using CatalogService.Domain.Entities;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.HSVPVanBanGiaiQuyet.Commands.CreateHSVPVanBanGiaiQuyet;

public class CreateHSVPVanBanGiaiQuyetCommandHandler : IRequestHandler<CreateHSVPVanBanGiaiQuyetCommand, ApiResult<HSVPVanBanGiaiQuyetDto>>
{
    private readonly IMapper _mapper;
    private readonly IHSVPVanBanGiaiQuyetRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "CreateHSVPVanBanGiaiQuyetCommandHandler";

    public CreateHSVPVanBanGiaiQuyetCommandHandler(IMapper mapper, IHSVPVanBanGiaiQuyetRepository repository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<ApiResult<HSVPVanBanGiaiQuyetDto>> Handle(CreateHSVPVanBanGiaiQuyetCommand request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var dkxp = _mapper.Map<HSXLVP_VanBanGiaiQuyet>(request);

        await _repository.CreateHSVPVanBan(dkxp);

        _logger.Information($"END: {MethodName}");

        return new ApiSuccessResult<HSVPVanBanGiaiQuyetDto>(_mapper.Map<HSVPVanBanGiaiQuyetDto>(dkxp));
    }
}
using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.VanBanPhapLuats;
using CatalogService.Domain.Entities;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.VanBanPhapLuats.Commands.UpdateVanBanPhapLuat;

public class UpdateVanBanPhapLuatCommandHandler : IRequestHandler<UpdateVanBanPhapLuatCommand, ApiResult<VanBanPhapLuatDto>>
{
    private readonly IMapper _mapper;
    private readonly IVanBanPhapLuatRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "UpdateVanBanPhapLuatCommandHandler";

    public UpdateVanBanPhapLuatCommandHandler(IMapper mapper, IVanBanPhapLuatRepository repository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<ApiResult<VanBanPhapLuatDto>> Handle(UpdateVanBanPhapLuatCommand request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var vbpl = _mapper.Map<VanBanPhapLuat>(request);
        var existVBPL = await _repository.CheckExistVanBanPhapLuat(request.SoHieu);
        if (!existVBPL)
        {
            return new ApiErrorResult<VanBanPhapLuatDto>("Van ban phap luat not exists.");
        }
        await _repository.UpdateVanBanPhapLuat(vbpl);

        _logger.Information($"END: {MethodName}");

        return new ApiSuccessResult<VanBanPhapLuatDto>(_mapper.Map<VanBanPhapLuatDto>(vbpl));
    }
}
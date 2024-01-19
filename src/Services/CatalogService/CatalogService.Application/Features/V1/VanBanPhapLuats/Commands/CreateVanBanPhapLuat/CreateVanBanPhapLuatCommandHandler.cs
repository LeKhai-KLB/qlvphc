using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.VanBanPhapLuats;
using CatalogService.Domain.Entities;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.VanBanPhapLuats.Commands.CreateVanBanPhapLuat;

public class CreateVanBanPhapLuatCommandHandler : IRequestHandler<CreateVanBanPhapLuatCommand, ApiResult<VanBanPhapLuatDto>>
{
    private readonly IMapper _mapper;
    private readonly IVanBanPhapLuatRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "CreateVanBanPhapLuatCommandHandler";

    public CreateVanBanPhapLuatCommandHandler(IMapper mapper, IVanBanPhapLuatRepository repository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<ApiResult<VanBanPhapLuatDto>> Handle(CreateVanBanPhapLuatCommand request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var vbpl = _mapper.Map<VanBanPhapLuat>(request);
        await _repository.CreateVanBanPhapLuat(vbpl);

        _logger.Information($"END: {MethodName}");

        return new ApiSuccessResult<VanBanPhapLuatDto>(_mapper.Map<VanBanPhapLuatDto>(vbpl));
    }
}
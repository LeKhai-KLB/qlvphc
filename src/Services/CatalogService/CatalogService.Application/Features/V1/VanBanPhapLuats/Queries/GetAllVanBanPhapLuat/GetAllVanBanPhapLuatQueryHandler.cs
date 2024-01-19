using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.VanBanPhapLuats;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.VanBanPhapLuats.Queries.GetAllVanBanPhapLuat;

public class GetAllVanBanPhapLuatQueryHandler : IRequestHandler<GetAllVanBanPhapLuatQuery, ApiResult<IEnumerable<VanBanPhapLuatDto>>>
{
    private readonly IMapper _mapper;
    private readonly IVanBanPhapLuatRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "GetAllVanBanPhapLuatQueryHandler";

    public GetAllVanBanPhapLuatQueryHandler(IMapper mapper, IVanBanPhapLuatRepository repository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger;
    }

    public async Task<ApiResult<IEnumerable<VanBanPhapLuatDto>>> Handle(GetAllVanBanPhapLuatQuery request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var vbplEntities = await _repository.GetAllVanBanPhapLuat();
        var vbplDto = _mapper.Map<IEnumerable<VanBanPhapLuatDto>>(vbplEntities);

        _logger.Information($"END: {MethodName}");

        return new ApiSuccessResult<IEnumerable<VanBanPhapLuatDto>>(vbplDto);
    }
}
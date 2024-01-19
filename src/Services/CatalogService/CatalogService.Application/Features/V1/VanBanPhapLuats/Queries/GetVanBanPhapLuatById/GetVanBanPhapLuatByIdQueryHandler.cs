using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.VanBanPhapLuats;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.VanBanPhapLuats.Queries.GetVanBanPhapLuatById;

public class GetVanBanPhapLuatByIdQueryHandler : IRequestHandler<GetVanBanPhapLuatByIdQuery, ApiResult<VanBanPhapLuatDto>>
{
    private readonly IMapper _mapper;
    private readonly IVanBanPhapLuatRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "GetVanBanPhapLuatByIdQueryHandler";

    public GetVanBanPhapLuatByIdQueryHandler(IMapper mapper, IVanBanPhapLuatRepository repository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger;
    }

    public async Task<ApiResult<VanBanPhapLuatDto>> Handle(GetVanBanPhapLuatByIdQuery request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var vbplEntity = await _repository.GetVanBanPhapLuatById(request.Id);
        var vbplDto = _mapper.Map<VanBanPhapLuatDto>(vbplEntity);

        _logger.Information($"END: {MethodName}");

        return new ApiSuccessResult<VanBanPhapLuatDto>(vbplDto);
    }
}
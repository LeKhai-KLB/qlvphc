using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.VanBanGiaiQuyets;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.VanBanGiaiQuyets.Queries.GetAllVanBanGiaiQuyet;

public class GetAllVanBanGiaiQuyetQueryHandler : IRequestHandler<GetAllVanBanGiaiQuyetQuery, ApiResult<IEnumerable<VanBanGiaiQuyetDto>>>
{
    private readonly IMapper _mapper;
    private readonly IVanBanGiaiQuyetRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "GetAllVanBanGiaiQuyetQueryHandler";

    public GetAllVanBanGiaiQuyetQueryHandler(IMapper mapper, IVanBanGiaiQuyetRepository repository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger;
    }

    public async Task<ApiResult<IEnumerable<VanBanGiaiQuyetDto>>> Handle(GetAllVanBanGiaiQuyetQuery request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var vbgqEntities = await _repository.GetAllVanBanGiaiQuyet();
        var vbgqDto = _mapper.Map<IEnumerable<VanBanGiaiQuyetDto>>(vbgqEntities);

        _logger.Information($"END: {MethodName}");

        return new ApiSuccessResult<IEnumerable<VanBanGiaiQuyetDto>>(vbgqDto);
    }
}
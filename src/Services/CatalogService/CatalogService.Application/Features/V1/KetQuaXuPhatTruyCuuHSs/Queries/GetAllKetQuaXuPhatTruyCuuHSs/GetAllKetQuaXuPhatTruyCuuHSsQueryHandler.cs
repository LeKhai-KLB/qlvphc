using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.KetQuaXuPhatTruyCuuHSs;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.KetQuaXuPhatTruyCuuHSs.Queries.GetAllKetQuaXuPhatTruyCuuHSs;

public class GetAllKetQuaXuPhatTruyCuuHSsQueryHandler : IRequestHandler<GetAllKetQuaXuPhatTruyCuuHSsQuery, ApiResult<IEnumerable<KetQuaXuPhatTruyCuuHSDto>>>
{
    private readonly IMapper _mapper;
    private readonly IKetQuaXuPhatTruyCuuHSRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "GetAllKetQuaXuPhatTruyCuuHSQueryHandler";

    public GetAllKetQuaXuPhatTruyCuuHSsQueryHandler(IMapper mapper, IKetQuaXuPhatTruyCuuHSRepository repository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger;
    }

    public async Task<ApiResult<IEnumerable<KetQuaXuPhatTruyCuuHSDto>>> Handle(GetAllKetQuaXuPhatTruyCuuHSsQuery request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var cqbhEntities = await _repository.GetAllKetQuaXuPhatTruyCuuHSs();
        var cqbhDto = _mapper.Map<IEnumerable<KetQuaXuPhatTruyCuuHSDto>>(cqbhEntities);

        _logger.Information($"END: {MethodName}");

        return new ApiSuccessResult<IEnumerable<KetQuaXuPhatTruyCuuHSDto>>(cqbhDto);
    }
}
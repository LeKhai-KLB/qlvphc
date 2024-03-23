using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.KetQuaXuPhatHanhChinhs;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.KetQuaXuPhatHanhChinhs.Queries.GetAllKetQuaXuPhatHanhChinhs;

public class GetAllKetQuaXuPhatHanhChinhsQueryHandler : IRequestHandler<GetAllKetQuaXuPhatHanhChinhsQuery, ApiResult<IEnumerable<KetQuaXuPhatHanhChinhDto>>>
{
    private readonly IMapper _mapper;
    private readonly IKetQuaXuPhatHanhChinhRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "GetAllKetQuaXuPhatHanhChinhQueryHandler";

    public GetAllKetQuaXuPhatHanhChinhsQueryHandler(IMapper mapper, IKetQuaXuPhatHanhChinhRepository repository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger;
    }

    public async Task<ApiResult<IEnumerable<KetQuaXuPhatHanhChinhDto>>> Handle(GetAllKetQuaXuPhatHanhChinhsQuery request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var cqbhEntities = await _repository.GetAllKetQuaXuPhatHanhChinhs();
        var cqbhDto = _mapper.Map<IEnumerable<KetQuaXuPhatHanhChinhDto>>(cqbhEntities);

        _logger.Information($"END: {MethodName}");

        return new ApiSuccessResult<IEnumerable<KetQuaXuPhatHanhChinhDto>>(cqbhDto);
    }
}
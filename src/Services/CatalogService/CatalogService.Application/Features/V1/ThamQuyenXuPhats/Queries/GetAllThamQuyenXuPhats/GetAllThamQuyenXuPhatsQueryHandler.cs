using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.ThamQuyenXuPhats;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.ThamQuyenXuPhats.Queries.GetAllThamQuyenXuPhats;

public class GetAllThamQuyenXuPhatsQueryHandler : IRequestHandler<GetAllThamQuyenXuPhatsQuery, ApiResult<IEnumerable<ThamQuyenXuPhatDto>>>
{
    private readonly IMapper _mapper;
    private readonly IThamQuyenXuPhatRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "GetAllThamQuyenXuPhatQueryHandler";

    public GetAllThamQuyenXuPhatsQueryHandler(IMapper mapper, IThamQuyenXuPhatRepository repository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger;
    }

    public async Task<ApiResult<IEnumerable<ThamQuyenXuPhatDto>>> Handle(GetAllThamQuyenXuPhatsQuery request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var cqbhEntities = await _repository.GetAllThamQuyenXuPhats();
        var cqbhDto = _mapper.Map<IEnumerable<ThamQuyenXuPhatDto>>(cqbhEntities);

        _logger.Information($"END: {MethodName}");

        return new ApiSuccessResult<IEnumerable<ThamQuyenXuPhatDto>>(cqbhDto);
    }
}
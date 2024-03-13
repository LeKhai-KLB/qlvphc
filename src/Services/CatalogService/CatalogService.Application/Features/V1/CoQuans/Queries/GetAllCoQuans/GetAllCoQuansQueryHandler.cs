using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.CoQuans;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.CoQuans.Queries.GetAllCoQuans;

public class GetAllCoQuansQueryHandler : IRequestHandler<GetAllCoQuansQuery, ApiResult<IEnumerable<CoQuanDto>>>
{
    private readonly IMapper _mapper;
    private readonly ICoQuanRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "GetAllCoQuanQueryHandler";

    public GetAllCoQuansQueryHandler(IMapper mapper, ICoQuanRepository repository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger;
    }

    public async Task<ApiResult<IEnumerable<CoQuanDto>>> Handle(GetAllCoQuansQuery request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var cqbhEntities = await _repository.GetAllCoQuans();
        var cqbhDto = _mapper.Map<IEnumerable<CoQuanDto>>(cqbhEntities);

        _logger.Information($"END: {MethodName}");

        return new ApiSuccessResult<IEnumerable<CoQuanDto>>(cqbhDto);
    }
}
using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.CoQuanBanHanhs;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.CoQuanBanHanhs.Queries.GetCoQuanBanHanhsByTerm;

public class GetCoQuanBanHanhsByTermQueryHandler : IRequestHandler<GetCoQuanBanHanhsByTermQuery, ApiResult<IEnumerable<CoQuanBanHanhDto>>>
{
    private readonly IMapper _mapper;
    private readonly ICoQuanBanHanhRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "GetAllCoQuanBanHanhQueryHandler";

    public GetCoQuanBanHanhsByTermQueryHandler(IMapper mapper, ICoQuanBanHanhRepository repository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger;
    }

    public async Task<ApiResult<IEnumerable<CoQuanBanHanhDto>>> Handle(GetCoQuanBanHanhsByTermQuery request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var cqbhEntities = await _repository.GetCoQuanBanHanhsByTerm(request.Term);
        var cqbhDto = _mapper.Map<IEnumerable<CoQuanBanHanhDto>>(cqbhEntities);

        _logger.Information($"END: {MethodName}");

        return new ApiSuccessResult<IEnumerable<CoQuanBanHanhDto>>(cqbhDto);
    }
}
using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.CoQuans;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.CoQuans.Queries.GetCoQuanById;

public class GetCoQuanByIdQueryHandler : IRequestHandler<GetCoQuanByIdQuery, ApiResult<CoQuanDto>>
{
    private readonly IMapper _mapper;
    private readonly ICoQuanRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "GetCoQuanByIdQueryHandler";

    public GetCoQuanByIdQueryHandler(IMapper mapper, ICoQuanRepository repository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger;
    }

    public async Task<ApiResult<CoQuanDto>> Handle(GetCoQuanByIdQuery request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var cqbhEntity = await _repository.GetCoQuanById(request.Id);
        var cqbhDto = _mapper.Map<CoQuanDto>(cqbhEntity);

        _logger.Information($"END: {MethodName}");

        return new ApiSuccessResult<CoQuanDto>(cqbhDto);
    }
}
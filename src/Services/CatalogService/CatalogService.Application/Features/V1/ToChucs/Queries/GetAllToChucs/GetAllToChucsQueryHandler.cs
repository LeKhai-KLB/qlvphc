using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.ToChucs;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.ToChucs.Queries.GetAllToChucs;

public class GetAllToChucsQueryHandler : IRequestHandler<GetAllToChucsQuery, ApiResult<IEnumerable<ToChucDropdownDto>>>
{
    private readonly IMapper _mapper;
    private readonly IToChucRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "GetAllToChucQueryHandler";

    public GetAllToChucsQueryHandler(IMapper mapper, IToChucRepository repository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger;
    }

    public async Task<ApiResult<IEnumerable<ToChucDropdownDto>>> Handle(GetAllToChucsQuery request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var cqbhEntities = await _repository.GetAllToChucs();
        var cqbhDto = _mapper.Map<IEnumerable<ToChucDropdownDto>>(cqbhEntities);

        _logger.Information($"END: {MethodName}");

        return new ApiSuccessResult<IEnumerable<ToChucDropdownDto>>(cqbhDto);
    }
}
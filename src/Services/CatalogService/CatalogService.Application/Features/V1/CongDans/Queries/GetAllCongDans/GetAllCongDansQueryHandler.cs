using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.CongDans;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.CongDans.Queries.GetAllCongDans;

public class GetAllCongDansQueryHandler : IRequestHandler<GetAllCongDansQuery, ApiResult<IEnumerable<CongDanDropDownDto>>>
{
    private readonly IMapper _mapper;
    private readonly ICongDanRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "GetAllCongDanQueryHandler";

    public GetAllCongDansQueryHandler(IMapper mapper, ICongDanRepository repository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger;
    }

    public async Task<ApiResult<IEnumerable<CongDanDropDownDto>>> Handle(GetAllCongDansQuery request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var cqbhEntities = await _repository.GetAllCongDans();
        var cqbhDto = _mapper.Map<IEnumerable<CongDanDropDownDto>>(cqbhEntities);

        _logger.Information($"END: {MethodName}");

        return new ApiSuccessResult<IEnumerable<CongDanDropDownDto>>(cqbhDto);
    }
}
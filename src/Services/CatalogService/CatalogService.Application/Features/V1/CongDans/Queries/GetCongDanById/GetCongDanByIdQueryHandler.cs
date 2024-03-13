using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.CongDans;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.CongDans.Queries.GetCongDanById;

public class GetCongDanByIdQueryHandler : IRequestHandler<GetCongDanByIdQuery, ApiResult<CongDanDto>>
{
    private readonly IMapper _mapper;
    private readonly ICongDanRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "GetCongDanByIdQueryHandler";

    public GetCongDanByIdQueryHandler(IMapper mapper, ICongDanRepository repository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger;
    }

    public async Task<ApiResult<CongDanDto>> Handle(GetCongDanByIdQuery request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var cqbhEntity = await _repository.GetCongDanById(request.Id);
        var cqbhDto = _mapper.Map<CongDanDto>(cqbhEntity);

        _logger.Information($"END: {MethodName}");

        return new ApiSuccessResult<CongDanDto>(cqbhDto);
    }
}
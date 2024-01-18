using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.CoQuanBanHanhs;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.CoQuanBanHanhs.Queries.GetCoQuanBanHanhById;

public class GetCoQuanBanHanhByIdQueryHandler : IRequestHandler<GetCoQuanBanHanhByIdQuery, ApiResult<CoQuanBanHanhDto>>
{
    private readonly IMapper _mapper;
    private readonly ICoQuanBanHanhRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "GetCoQuanBanHanhByIdQueryHandler";

    public GetCoQuanBanHanhByIdQueryHandler(IMapper mapper, ICoQuanBanHanhRepository repository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger;
    }

    public async Task<ApiResult<CoQuanBanHanhDto>> Handle(GetCoQuanBanHanhByIdQuery request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var cqbhEntity = await _repository.GetCoQuanBanHanhById(request.Id);
        var cqbhDto = _mapper.Map<CoQuanBanHanhDto>(cqbhEntity);

        _logger.Information($"END: {MethodName}");

        return new ApiSuccessResult<CoQuanBanHanhDto>(cqbhDto);
    }
}
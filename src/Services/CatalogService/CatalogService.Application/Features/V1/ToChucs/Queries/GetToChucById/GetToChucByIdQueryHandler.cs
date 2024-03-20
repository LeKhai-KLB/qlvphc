using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.ToChucs;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.ToChucs.Queries.GetToChucById;

public class GetToChucByIdQueryHandler : IRequestHandler<GetToChucByIdQuery, ApiResult<ToChucDto>>
{
    private readonly IMapper _mapper;
    private readonly IToChucRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "GetToChucByIdQueryHandler";

    public GetToChucByIdQueryHandler(IMapper mapper, IToChucRepository repository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger;
    }

    public async Task<ApiResult<ToChucDto>> Handle(GetToChucByIdQuery request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var cqbhEntity = await _repository.GetToChucById(request.Id);
        var cqbhDto = _mapper.Map<ToChucDto>(cqbhEntity);

        _logger.Information($"END: {MethodName}");

        return new ApiSuccessResult<ToChucDto>(cqbhDto);
    }
}
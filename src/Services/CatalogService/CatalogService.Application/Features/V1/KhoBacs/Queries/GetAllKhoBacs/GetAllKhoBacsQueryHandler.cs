using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.KhoBacs;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.KhoBacs.Queries.GetAllKhoBacs;

public class GetAllKhoBacsQueryHandler : IRequestHandler<GetAllKhoBacsQuery, ApiResult<IEnumerable<KhoBacDto>>>
{
    private readonly IMapper _mapper;
    private readonly IKhoBacRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "GetAllKhoBacsQueryHandler";

    public GetAllKhoBacsQueryHandler(IMapper mapper, IKhoBacRepository repository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger;
    }

    public async Task<ApiResult<IEnumerable<KhoBacDto>>> Handle(GetAllKhoBacsQuery request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var cqbhEntities = await _repository.GetAllKhoBacs();
        var cqbhDto = _mapper.Map<IEnumerable<KhoBacDto>>(cqbhEntities);

        _logger.Information($"END: {MethodName}");

        return new ApiSuccessResult<IEnumerable<KhoBacDto>>(cqbhDto);
    }
}
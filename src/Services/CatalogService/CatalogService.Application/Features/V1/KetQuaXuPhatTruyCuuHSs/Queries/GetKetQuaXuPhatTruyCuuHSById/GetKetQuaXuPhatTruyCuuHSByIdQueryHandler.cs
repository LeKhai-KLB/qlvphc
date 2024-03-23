using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.KetQuaXuPhatTruyCuuHSs;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.KetQuaXuPhatTruyCuuHSs.Queries.GetKetQuaXuPhatTruyCuuHSById;

public class GetKetQuaXuPhatTruyCuuHSByIdQueryHandler : IRequestHandler<GetKetQuaXuPhatTruyCuuHSByIdQuery, ApiResult<KetQuaXuPhatTruyCuuHSDto>>
{
    private readonly IMapper _mapper;
    private readonly IKetQuaXuPhatTruyCuuHSRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "GetKetQuaXuPhatTruyCuuHSByIdQueryHandler";

    public GetKetQuaXuPhatTruyCuuHSByIdQueryHandler(IMapper mapper, IKetQuaXuPhatTruyCuuHSRepository repository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger;
    }

    public async Task<ApiResult<KetQuaXuPhatTruyCuuHSDto>> Handle(GetKetQuaXuPhatTruyCuuHSByIdQuery request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var cqbhEntity = await _repository.GetKetQuaXuPhatTruyCuuHSById(request.Id);
        var cqbhDto = _mapper.Map<KetQuaXuPhatTruyCuuHSDto>(cqbhEntity);

        _logger.Information($"END: {MethodName}");

        return new ApiSuccessResult<KetQuaXuPhatTruyCuuHSDto>(cqbhDto);
    }
}
using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.KetQuaXuPhatHanhChinhs;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.KetQuaXuPhatHanhChinhs.Queries.GetKetQuaXuPhatHanhChinhById;

public class GetKetQuaXuPhatHanhChinhByIdQueryHandler : IRequestHandler<GetKetQuaXuPhatHanhChinhByIdQuery, ApiResult<KetQuaXuPhatHanhChinhDto>>
{
    private readonly IMapper _mapper;
    private readonly IKetQuaXuPhatHanhChinhRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "GetKetQuaXuPhatHanhChinhByIdQueryHandler";

    public GetKetQuaXuPhatHanhChinhByIdQueryHandler(IMapper mapper, IKetQuaXuPhatHanhChinhRepository repository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger;
    }

    public async Task<ApiResult<KetQuaXuPhatHanhChinhDto>> Handle(GetKetQuaXuPhatHanhChinhByIdQuery request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var cqbhEntity = await _repository.GetKetQuaXuPhatHanhChinhById(request.Id);
        var cqbhDto = _mapper.Map<KetQuaXuPhatHanhChinhDto>(cqbhEntity);

        _logger.Information($"END: {MethodName}");

        return new ApiSuccessResult<KetQuaXuPhatHanhChinhDto>(cqbhDto);
    }
}
using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.ThamQuyenXuPhats;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.ThamQuyenXuPhats.Queries.GetThamQuyenXuPhatById;

public class GetThamQuyenXuPhatByIdQueryHandler : IRequestHandler<GetThamQuyenXuPhatByIdQuery, ApiResult<ThamQuyenXuPhatDto>>
{
    private readonly IMapper _mapper;
    private readonly IThamQuyenXuPhatRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "GetThamQuyenXuPhatByIdQueryHandler";

    public GetThamQuyenXuPhatByIdQueryHandler(IMapper mapper, IThamQuyenXuPhatRepository repository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger;
    }

    public async Task<ApiResult<ThamQuyenXuPhatDto>> Handle(GetThamQuyenXuPhatByIdQuery request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var tqxpEntity = await _repository.GetThamQuyenXuPhatById(request.Id);
        var tqxpDto = _mapper.Map<ThamQuyenXuPhatDto>(tqxpEntity);

        _logger.Information($"END: {MethodName}");

        return new ApiSuccessResult<ThamQuyenXuPhatDto>(tqxpDto);
    }
}
using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.ThamQuyenXuPhats;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.ThamQuyenXuPhats.Queries.GetThamQuyenXuPhatsByTerm;

public class GetThamQuyenXuPhatsByTermQueryHandler : IRequestHandler<GetThamQuyenXuPhatsByTermQuery, ApiResult<List<ThamQuyenXuPhatDto>>>
{
    private readonly IMapper _mapper;
    private readonly IThamQuyenXuPhatRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "GetThamQuyenXuPhatQueryHandler";

    public GetThamQuyenXuPhatsByTermQueryHandler(IMapper mapper, IThamQuyenXuPhatRepository repository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger;
    }

    public async Task<ApiResult<List<ThamQuyenXuPhatDto>>> Handle(GetThamQuyenXuPhatsByTermQuery request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var tqxpEntities = await _repository.GetThamQuyenXuPhatsByTerm(request.Term);
        var tqxpDto = _mapper.Map<List<ThamQuyenXuPhatDto>>(tqxpEntities);

        _logger.Information($"END: {MethodName}");
        return new ApiSuccessResult<List<ThamQuyenXuPhatDto>>(tqxpDto);
    }
}
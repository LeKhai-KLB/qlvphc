using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.ChiTietLinhVucXuPhats;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.ChiTietLinhVucXuPhats.Queries.GetChiTietLinhVucXuPhatsByTerm;

public class GetChiTietLinhVucXuPhatsByTermQueryHandler : IRequestHandler<GetChiTietLinhVucXuPhatsByTermQuery, ApiResult<IEnumerable<ChiTietLinhVucXuPhatDto>>>
{
    private readonly IMapper _mapper;
    private readonly IChiTietLinhVucXuPhatRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "GetChiTietLinhVucXuPhatsByTermQueryHandler";

    public GetChiTietLinhVucXuPhatsByTermQueryHandler(IMapper mapper, IChiTietLinhVucXuPhatRepository repository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger;
    }

    public async Task<ApiResult<IEnumerable<ChiTietLinhVucXuPhatDto>>> Handle(GetChiTietLinhVucXuPhatsByTermQuery request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var ctlvxpEntities = await _repository.GetChiTietLinhVucXuPhatsByTerm(request.LinhVucXuPhatId, request.Term);
        var ctlvxpDto = _mapper.Map<IEnumerable<ChiTietLinhVucXuPhatDto>>(ctlvxpEntities);

        _logger.Information($"END: {MethodName}");

        return new ApiSuccessResult<IEnumerable<ChiTietLinhVucXuPhatDto>>(ctlvxpDto);
    }
}
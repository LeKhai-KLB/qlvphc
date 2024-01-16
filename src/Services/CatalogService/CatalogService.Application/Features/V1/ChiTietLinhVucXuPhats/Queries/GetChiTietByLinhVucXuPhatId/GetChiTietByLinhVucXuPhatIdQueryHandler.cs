using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.ChiTietLinhVucXuPhats;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.ChiTietLinhVucXuPhats.Queries.GetChiTietByLinhVucXuPhatId;

public class GetChiTietByLinhVucXuPhatIdQueryHandler : IRequestHandler<GetChiTietByLinhVucXuPhatIdQuery, ApiResult<IEnumerable<ChiTietLinhVucXuPhatDto>>>
{
    private readonly IMapper _mapper;
    private readonly IChiTietLinhVucXuPhatRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "GetChiTietByLinhVucXuPhatIdQueryHandler";

    public GetChiTietByLinhVucXuPhatIdQueryHandler(IMapper mapper, IChiTietLinhVucXuPhatRepository repository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger;
    }

    public async Task<ApiResult<IEnumerable<ChiTietLinhVucXuPhatDto>>> Handle(GetChiTietByLinhVucXuPhatIdQuery request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var lvxpEntities = await _repository.GetChiTietByLinhVucXuPhatId(request.LinhVucXuPhatId);
        var lvxpDto = _mapper.Map<IEnumerable<ChiTietLinhVucXuPhatDto>>(lvxpEntities);

        _logger.Information($"END: {MethodName}");

        return new ApiSuccessResult<IEnumerable<ChiTietLinhVucXuPhatDto>>(lvxpDto);
    }
}
using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.LinhVucXuPhats;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.LinhVucXuPhats.Queries.GetAllLinhVucXuPhats;

public class GetAllLinhVucXuPhatsQueryHandler : IRequestHandler<GetAllLinhVucXuPhatsQuery, ApiResult<IEnumerable<LinhVucXuPhatDto>>>
{
    private readonly IMapper _mapper;
    private readonly ILinhVucXuPhatRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "GetAllLinhVucXuPhatQueryHandler";

    public GetAllLinhVucXuPhatsQueryHandler(IMapper mapper, ILinhVucXuPhatRepository repository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger;
    }

    public async Task<ApiResult<IEnumerable<LinhVucXuPhatDto>>> Handle(GetAllLinhVucXuPhatsQuery request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var lvxpEntities = await _repository.GetAllLinhVucXuPhats();
        var lvxpDto = _mapper.Map<IEnumerable<LinhVucXuPhatDto>>(lvxpEntities);

        _logger.Information($"END: {MethodName}");

        return new ApiSuccessResult<IEnumerable<LinhVucXuPhatDto>>(lvxpDto);
    }
}
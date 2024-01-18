using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.LinhVucXuPhats;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.LinhVucXuPhats.Queries.GetAllLinhVucXuPhat;

public class GetAllLinhVucXuPhatQueryHanlder : IRequestHandler<GetAllLinhVucXuPhatQuery, ApiResult<IEnumerable<LinhVucXuPhatDto>>>
{
    private readonly IMapper _mapper;
    private readonly ILinhVucXuPhatRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "GetAllLinhVucXuPhatQueryHanlder";

    public GetAllLinhVucXuPhatQueryHanlder(IMapper mapper, ILinhVucXuPhatRepository repository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger;
    }

    public async Task<ApiResult<IEnumerable<LinhVucXuPhatDto>>> Handle(GetAllLinhVucXuPhatQuery request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var lvxpEntity = await _repository.GetAllLinhVucXuPhat();
        var lvxpDto = _mapper.Map<IEnumerable<LinhVucXuPhatDto>>(lvxpEntity);

        _logger.Information($"END: {MethodName}");

        return new ApiSuccessResult<IEnumerable<LinhVucXuPhatDto>>(lvxpDto);
    }
}
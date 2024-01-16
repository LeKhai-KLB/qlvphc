using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.LinhVucXuPhats;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.LinhVucXuPhats.Queries.GetLinhVucXuPhatById;

public class GetLinhVucXuPhatByIdQueryHandler : IRequestHandler<GetLinhVucXuPhatByIdQuery, ApiResult<LinhVucXuPhatDto>>
{
    private readonly IMapper _mapper;
    private readonly ILinhVucXuPhatRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "GetLinhVucXuPhatByIdQueryHandler";

    public GetLinhVucXuPhatByIdQueryHandler(IMapper mapper, ILinhVucXuPhatRepository repository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger;
    }

    public async Task<ApiResult<LinhVucXuPhatDto>> Handle(GetLinhVucXuPhatByIdQuery request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var lvxpEntity = await _repository.GetLinhVucXuPhatById(request.Id);
        var lvxpDto = _mapper.Map<LinhVucXuPhatDto>(lvxpEntity);

        _logger.Information($"END: {MethodName}");

        return new ApiSuccessResult<LinhVucXuPhatDto>(lvxpDto);
    }
}
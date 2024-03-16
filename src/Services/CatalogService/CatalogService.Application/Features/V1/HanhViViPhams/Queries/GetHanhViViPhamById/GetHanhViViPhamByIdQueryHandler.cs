using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.HanhViViPhams;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.HanhViViPhams.Queries.GetHanhViViPhamById;

public class GetHanhViViPhamByIdQueryHandler : IRequestHandler<GetHanhViViPhamByIdQuery, ApiResult<HanhViViPhamDto>>
{
    private readonly IMapper _mapper;
    private readonly IHanhViViPhamRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "GetHanhViViPhamByIdQueryHandler";

    public GetHanhViViPhamByIdQueryHandler(IMapper mapper, IHanhViViPhamRepository repository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger;
    }

    public async Task<ApiResult<HanhViViPhamDto>> Handle(GetHanhViViPhamByIdQuery request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var lvxpEntity = await _repository.GetHanhViViPhamById(request.Id);
        var lvxpDto = _mapper.Map<HanhViViPhamDto>(lvxpEntity);

        _logger.Information($"END: {MethodName}");

        return new ApiSuccessResult<HanhViViPhamDto>(lvxpDto);
    }
}
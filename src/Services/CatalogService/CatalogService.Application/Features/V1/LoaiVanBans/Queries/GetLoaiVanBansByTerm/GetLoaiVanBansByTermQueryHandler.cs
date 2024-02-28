using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.LoaiVanBans;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.LoaiVanBans.Queries.GetLoaiVanBansByTerm;

public class GetLoaiVanBansByTermQueryHandler : IRequestHandler<GetLoaiVanBansByTermQuery, ApiResult<IEnumerable<LoaiVanBanDto>>>
{
    private readonly IMapper _mapper;
    private readonly ILoaiVanBanRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "GetAllLoaiVanBanQueryHandler";

    public GetLoaiVanBansByTermQueryHandler(IMapper mapper, ILoaiVanBanRepository repository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger;
    }

    public async Task<ApiResult<IEnumerable<LoaiVanBanDto>>> Handle(GetLoaiVanBansByTermQuery request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var lvbEntities = await _repository.GetLoaiVanBansByTerm(request.Term);
        var lvbDto = _mapper.Map<IEnumerable<LoaiVanBanDto>>(lvbEntities);

        _logger.Information($"END: {MethodName}");

        return new ApiSuccessResult<IEnumerable<LoaiVanBanDto>>(lvbDto);
    }
}
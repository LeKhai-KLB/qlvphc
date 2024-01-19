using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.LoaiVanBans;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.LoaiVanBans.Queries.GetLoaiVanBanById;

public class GetLoaiVanBanByIdQueryHandler : IRequestHandler<GetLoaiVanBanByIdQuery, ApiResult<LoaiVanBanDto>>
{
    private readonly IMapper _mapper;
    private readonly ILoaiVanBanRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "GetLoaiVanBanByIdQueryHandler";

    public GetLoaiVanBanByIdQueryHandler(IMapper mapper, ILoaiVanBanRepository repository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger;
    }

    public async Task<ApiResult<LoaiVanBanDto>> Handle(GetLoaiVanBanByIdQuery request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var lvbEntity = await _repository.GetLoaiVanBanById(request.Id);
        var lvbDto = _mapper.Map<LoaiVanBanDto>(lvbEntity);

        _logger.Information($"END: {MethodName}");

        return new ApiSuccessResult<LoaiVanBanDto>(lvbDto);
    }
}
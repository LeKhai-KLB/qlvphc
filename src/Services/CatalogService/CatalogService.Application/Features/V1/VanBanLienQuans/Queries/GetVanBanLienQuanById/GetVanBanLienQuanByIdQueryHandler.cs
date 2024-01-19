using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.VanBanLienQuans;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.VanBanLienQuans.Queries.GetVanBanLienQuanById;

public class GetVanBanLienQuanByIdQueryHandler : IRequestHandler<GetVanBanLienQuanByIdQuery, ApiResult<VanBanLienQuanDto>>
{
    private readonly IMapper _mapper;
    private readonly IVanBanLienQuanRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "GetVanBanLienQuanByIdQueryHandler";

    public GetVanBanLienQuanByIdQueryHandler(IMapper mapper, IVanBanLienQuanRepository repository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger;
    }

    public async Task<ApiResult<VanBanLienQuanDto>> Handle(GetVanBanLienQuanByIdQuery request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var vblqEntity = await _repository.GetVanBanLienQuanById(request.Id);
        var vblqDto = _mapper.Map<VanBanLienQuanDto>(vblqEntity);

        _logger.Information($"END: {MethodName}");

        return new ApiSuccessResult<VanBanLienQuanDto>(vblqDto);
    }
}
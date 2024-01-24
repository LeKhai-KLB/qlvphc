using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.VanBanGiaiQuyets;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.VanBanGiaiQuyets.Queries.GetVanBanGiaiQuyetById;

public class GetVanBanGiaiQuyetByIdQueryHandler : IRequestHandler<GetVanBanGiaiQuyetByIdQuery, ApiResult<VanBanGiaiQuyetDto>>
{
    private readonly IMapper _mapper;
    private readonly IVanBanGiaiQuyetRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "GetVanBanGiaiQuyetByIdQueryHandler";

    public GetVanBanGiaiQuyetByIdQueryHandler(IMapper mapper, IVanBanGiaiQuyetRepository repository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger;
    }

    public async Task<ApiResult<VanBanGiaiQuyetDto>> Handle(GetVanBanGiaiQuyetByIdQuery request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var vbgqEntity = await _repository.GetVanBanGiaiQuyetById(request.Id);
        var vbgqDto = _mapper.Map<VanBanGiaiQuyetDto>(vbgqEntity);

        _logger.Information($"END: {MethodName}");

        return new ApiSuccessResult<VanBanGiaiQuyetDto>(vbgqDto);
    }
}
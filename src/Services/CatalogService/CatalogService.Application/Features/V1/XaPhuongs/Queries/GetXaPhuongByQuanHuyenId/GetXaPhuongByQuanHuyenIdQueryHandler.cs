using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.XaPhuongs;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.XaPhuongs.Queries.GetXaPhuongByQuanHuyenId;

public class GetXaPhuongByQuanHuyenIdQueryHandler : IRequestHandler<GetXaPhuongByQuanHuyenIdQuery, ApiResult<IEnumerable<XaPhuongDto>>>
{
    private readonly IMapper _mapper;
    private readonly IXaPhuongRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "GetTinhThanhPhoByIdQueryHandler";

    public GetXaPhuongByQuanHuyenIdQueryHandler(IMapper mapper, IXaPhuongRepository repository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger;
    }

    public async Task<ApiResult<IEnumerable<XaPhuongDto>>> Handle(GetXaPhuongByQuanHuyenIdQuery request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var xaPhuongEntities = await _repository.GetXaPhuongByQuanHuyenId(request.Id);
        var xaPhuongDtos = _mapper.Map<IEnumerable<XaPhuongDto>>(xaPhuongEntities);

        _logger.Information($"END: {MethodName}");

        return new ApiSuccessResult<IEnumerable<XaPhuongDto>>(xaPhuongDtos);
    }
}
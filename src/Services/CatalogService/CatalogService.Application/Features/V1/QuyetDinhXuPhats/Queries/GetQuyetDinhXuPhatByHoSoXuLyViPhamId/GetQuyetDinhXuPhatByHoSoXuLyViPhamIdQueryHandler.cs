using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.QuyetDinhXuPhats;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.QuyetDinhXuPhats.Queries.GetQuyetDinhXuPhatByHoSoXuLyViPhamId;

public class GetQuyetDinhXuPhatByHoSoXuLyViPhamIdQueryHandler : IRequestHandler<GetQuyetDinhXuPhatByHoSoXuLyViPhamIdQuery, ApiResult<IEnumerable<QuyetDinhXuPhatDto>>>
{
    private readonly IMapper _mapper;
    private readonly IQuyetDinhXuPhatRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "GetQuyetDinhXuPhatByHoSoXuLyViPhamIdQueryHandler";

    public GetQuyetDinhXuPhatByHoSoXuLyViPhamIdQueryHandler(IMapper mapper, IQuyetDinhXuPhatRepository repository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger;
    }

    public async Task<ApiResult<IEnumerable<QuyetDinhXuPhatDto>>> Handle(GetQuyetDinhXuPhatByHoSoXuLyViPhamIdQuery request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var quyetDinhXuPhatEntities = await _repository.GetQuyetDinhXuPhatByHoSoXuLyViPhamId(request.Id);
        var quyetDinhXuPhatDtos = _mapper.Map<IEnumerable<QuyetDinhXuPhatDto>>(quyetDinhXuPhatEntities);

        _logger.Information($"END: {MethodName}");

        return new ApiSuccessResult<IEnumerable<QuyetDinhXuPhatDto>>(quyetDinhXuPhatDtos);
    }
}
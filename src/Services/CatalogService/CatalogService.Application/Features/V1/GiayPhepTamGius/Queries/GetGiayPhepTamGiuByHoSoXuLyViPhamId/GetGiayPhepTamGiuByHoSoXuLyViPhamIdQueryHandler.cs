using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.GiayPhepTamGius;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.GiayPhepTamGius.Queries.GetGiayPhepTamGiuByHoSoXuLyViPhamId;

public class GetGiayPhepTamGiuByHoSoXuLyViPhamIdQueryHandler : IRequestHandler<GetGiayPhepTamGiuByHoSoXuLyViPhamIdQuery, ApiResult<IEnumerable<GiayPhepTamGiuDto>>>
{
    private readonly IMapper _mapper;
    private readonly IGiayPhepTamGiuRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "GetGiayPhepTamGiuByHoSoXuLyViPhamIdQueryHandler";

    public GetGiayPhepTamGiuByHoSoXuLyViPhamIdQueryHandler(IMapper mapper, IGiayPhepTamGiuRepository repository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger;
    }

    public async Task<ApiResult<IEnumerable<GiayPhepTamGiuDto>>> Handle(GetGiayPhepTamGiuByHoSoXuLyViPhamIdQuery request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var giayPhepTamGiuEntities = await _repository.GetGiayPhepTamGiuByHoSoXuLyViPhamId(request.Id);
        var giayPhepTamGiuDtos = _mapper.Map<IEnumerable<GiayPhepTamGiuDto>>(giayPhepTamGiuEntities);

        _logger.Information($"END: {MethodName}");

        return new ApiSuccessResult<IEnumerable<GiayPhepTamGiuDto>>(giayPhepTamGiuDtos);
    }
}
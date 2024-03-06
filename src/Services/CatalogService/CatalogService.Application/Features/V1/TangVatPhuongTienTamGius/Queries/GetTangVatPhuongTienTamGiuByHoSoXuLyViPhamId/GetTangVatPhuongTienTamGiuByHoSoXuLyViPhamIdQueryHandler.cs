using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.TangVatPhuongTienTamGius;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.TangVatPhuongTienTamGius.Queries.GetTangVatPhuongTienTamGiuByHoSoXuLyViPhamId;

public class GetTangVatPhuongTienTamGiuByHoSoXuLyViPhamIdQueryHandler : IRequestHandler<GetTangVatPhuongTienTamGiuByHoSoXuLyViPhamIdQuery, ApiResult<IEnumerable<TangVatPhuongTienTamGiuDto>>>
{
    private readonly IMapper _mapper;
    private readonly ITangVatPhuongTienTamGiuRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "GetTangVatPhuongTienTamGiuByHoSoXuLyViPhamIdQueryHandler";

    public GetTangVatPhuongTienTamGiuByHoSoXuLyViPhamIdQueryHandler(IMapper mapper, ITangVatPhuongTienTamGiuRepository repository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger;
    }

    public async Task<ApiResult<IEnumerable<TangVatPhuongTienTamGiuDto>>> Handle(GetTangVatPhuongTienTamGiuByHoSoXuLyViPhamIdQuery request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var tangVatPhuongTienTamGiuEntities = await _repository.GetTangVatPhuongTienTamGiuByHoSoXuLyViPhamId(request.Id);
        var tangVatPhuongTienTamGiuDtos = _mapper.Map<IEnumerable<TangVatPhuongTienTamGiuDto>>(tangVatPhuongTienTamGiuEntities);

        _logger.Information($"END: {MethodName}");

        return new ApiSuccessResult<IEnumerable<TangVatPhuongTienTamGiuDto>>(tangVatPhuongTienTamGiuDtos);
    }
}
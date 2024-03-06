using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.HinhThucXuPhatBoSungs;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.HinhThucXuPhatBoSungs.Queries.GetHinhThucXuPhatBoSungById;

public class GetHinhThucXuPhatBoSungByIdQueryHandler : IRequestHandler<GetHinhThucXuPhatBoSungByIdQuery, ApiResult<HinhThucXuPhatBoSungDto>>
{
    private readonly IMapper _mapper;
    private readonly IHinhThucXuPhatBoSungRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "GetHinhThucXuPhatBoSungByIdQueryHandler";

    public GetHinhThucXuPhatBoSungByIdQueryHandler(IMapper mapper, IHinhThucXuPhatBoSungRepository repository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger;
    }

    public async Task<ApiResult<HinhThucXuPhatBoSungDto>> Handle(GetHinhThucXuPhatBoSungByIdQuery request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var hinhThucXuPhatBoSung = await _repository.GetByIdAsync(request.Id);
        var hinhThucXuPhatBoSungDto = _mapper.Map<HinhThucXuPhatBoSungDto>(hinhThucXuPhatBoSung);

        _logger.Information($"END: {MethodName}");

        return new ApiSuccessResult<HinhThucXuPhatBoSungDto>(hinhThucXuPhatBoSungDto);
    }
}
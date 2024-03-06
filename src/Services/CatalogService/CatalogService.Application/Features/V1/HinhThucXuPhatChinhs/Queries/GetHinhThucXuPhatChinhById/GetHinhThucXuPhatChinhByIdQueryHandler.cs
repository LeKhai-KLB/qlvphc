using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.HinhThucXuPhatChinhs;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.HinhThucXuPhatChinhs.Queries.GetHinhThucXuPhatChinhById;

public class GetHinhThucXuPhatChinhByIdQueryHandler : IRequestHandler<GetHinhThucXuPhatChinhByIdQuery, ApiResult<HinhThucXuPhatChinhDto>>
{
    private readonly IMapper _mapper;
    private readonly IHinhThucXuPhatChinhRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "GetHinhThucXuPhatChinhByIdQueryHandler";

    public GetHinhThucXuPhatChinhByIdQueryHandler(IMapper mapper, IHinhThucXuPhatChinhRepository repository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger;
    }

    public async Task<ApiResult<HinhThucXuPhatChinhDto>> Handle(GetHinhThucXuPhatChinhByIdQuery request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var hinhThucXuPhatChinh = await _repository.GetByIdAsync(request.Id);
        var hinhThucXuPhatChinhDto = _mapper.Map<HinhThucXuPhatChinhDto>(hinhThucXuPhatChinh);

        _logger.Information($"END: {MethodName}");

        return new ApiSuccessResult<HinhThucXuPhatChinhDto>(hinhThucXuPhatChinhDto);
    }
}
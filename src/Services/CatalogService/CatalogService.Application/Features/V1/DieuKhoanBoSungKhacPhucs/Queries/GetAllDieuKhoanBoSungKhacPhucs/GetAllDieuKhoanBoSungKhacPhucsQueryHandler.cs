using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.DieuKhoanBoSungKhacPhucs;
using CatalogService.Application.Parameters.DieuKhoanBoSungKhacPhucs;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.DieuKhoanBoSungKhacPhucs.Queries.GetAllDieuKhoanBoSungKhacPhucs;

public class GetAllDieuKhoanBoSungKhacPhucsQueryHandler : IRequestHandler<GetAllDieuKhoanBoSungKhacPhucsQuery, ApiResult<IEnumerable<DieuKhoanBoSungKhacPhucDto>>>
{
    private readonly IMapper _mapper;
    private readonly IDieuKhoanBoSungKhacPhucRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "GetAllDieuKhoanBoSungKhacPhucsQueryHandler";

    public GetAllDieuKhoanBoSungKhacPhucsQueryHandler(IMapper mapper, IDieuKhoanBoSungKhacPhucRepository repository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger;
    }

    public async Task<ApiResult<IEnumerable<DieuKhoanBoSungKhacPhucDto>>> Handle(GetAllDieuKhoanBoSungKhacPhucsQuery request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var validFilter = _mapper.Map<DieuKhoanBoSungKhacPhucDropDownParameter>(request);
        var cqbhEntities = await _repository.GetAllDieuKhoanBoSungKhacPhucs(validFilter);
        var cqbhDto = _mapper.Map<IEnumerable<DieuKhoanBoSungKhacPhucDto>>(cqbhEntities);

        _logger.Information($"END: {MethodName}");

        return new ApiSuccessResult<IEnumerable<DieuKhoanBoSungKhacPhucDto>>(cqbhDto);
    }
}
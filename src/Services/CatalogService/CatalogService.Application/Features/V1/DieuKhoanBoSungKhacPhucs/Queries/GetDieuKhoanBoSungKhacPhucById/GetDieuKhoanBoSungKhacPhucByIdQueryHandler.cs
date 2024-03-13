using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.DieuKhoanBoSungKhacPhucs;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.DieuKhoanBoSungKhacPhucs.Queries.GetDieuKhoanBoSungKhacPhucById;

public class GetDieuKhoanBoSungKhacPhucByIdQueryHandler : IRequestHandler<GetDieuKhoanBoSungKhacPhucByIdQuery, ApiResult<DieuKhoanBoSungKhacPhucDto>>
{
    private readonly IMapper _mapper;
    private readonly IDieuKhoanBoSungKhacPhucRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "GetDieuKhoanBoSungKhacPhucByIdQueryHandler";

    public GetDieuKhoanBoSungKhacPhucByIdQueryHandler(IMapper mapper, IDieuKhoanBoSungKhacPhucRepository repository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger;
    }

    public async Task<ApiResult<DieuKhoanBoSungKhacPhucDto>> Handle(GetDieuKhoanBoSungKhacPhucByIdQuery request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var dkxpEntity = await _repository.GetDieuKhoanBoSungKhacPhucById(request.Id);
        var dkxpDto = _mapper.Map<DieuKhoanBoSungKhacPhucDto>(dkxpEntity);

        _logger.Information($"END: {MethodName}");

        return new ApiSuccessResult<DieuKhoanBoSungKhacPhucDto>(dkxpDto);
    }
}
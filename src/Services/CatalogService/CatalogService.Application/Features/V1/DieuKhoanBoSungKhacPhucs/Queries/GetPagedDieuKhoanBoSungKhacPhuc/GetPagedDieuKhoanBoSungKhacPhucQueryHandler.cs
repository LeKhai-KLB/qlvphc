using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.DieuKhoanBoSungKhacPhucs;
using CatalogService.Application.Parameters.DieuKhoanBoSungKhacPhucs;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.DieuKhoanBoSungKhacPhucs.Queries.GetPagedDieuKhoanBoSungKhacPhuc;

public class GetPagedDieuKhoanBoSungKhacPhucQueryHandler : IRequestHandler<GetPagedDieuKhoanBoSungKhacPhucQuery, PagedResponse<IEnumerable<DieuKhoanBoSungKhacPhucDto>>>
{
    private readonly IMapper _mapper;
    private readonly IDieuKhoanBoSungKhacPhucRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "GetPagedDieuKhoanBoSungKhacPhucQueryHanlder";

    public GetPagedDieuKhoanBoSungKhacPhucQueryHandler(IMapper mapper, IDieuKhoanBoSungKhacPhucRepository repository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger;
    }

    public async Task<PagedResponse<IEnumerable<DieuKhoanBoSungKhacPhucDto>>> Handle(GetPagedDieuKhoanBoSungKhacPhucQuery request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var validFilter = _mapper.Map<DieuKhoanBoSungKhacPhucParameter>(request);
        var dkxps = await _repository.GetPagedDieuKhoanBoSungKhacPhucAsync(validFilter);
        var metaData = dkxps.GetMetaData();

        _logger.Information($"END: {MethodName}");
        return new PagedResponse<IEnumerable<DieuKhoanBoSungKhacPhucDto>>(_mapper.Map<List<DieuKhoanBoSungKhacPhucDto>>(dkxps), metaData.CurrentPage, metaData.TotalPages, metaData.PageSize, metaData.TotalItems);
    }
}
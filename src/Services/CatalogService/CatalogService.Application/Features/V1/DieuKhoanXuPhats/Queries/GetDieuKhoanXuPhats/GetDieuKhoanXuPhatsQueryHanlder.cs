using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.DieuKhoanXuPhats;
using CatalogService.Application.Parameters.DieuKhoanXuPhats;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.DieuKhoanXuPhats.Queries.GetDieuKhoanXuPhats;

public class GetDieuKhoanXuPhatsQueryHanlder : IRequestHandler<GetDieuKhoanXuPhatsQuery, PagedResponse<IEnumerable<DieuKhoanXuPhatDto>>>
{
    private readonly IMapper _mapper;
    private readonly IDieuKhoanXuPhatRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "GetAllDieuKhoanXuPhatQueryHanlder";

    public GetDieuKhoanXuPhatsQueryHanlder(IMapper mapper, IDieuKhoanXuPhatRepository repository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger;
    }

    public async Task<PagedResponse<IEnumerable<DieuKhoanXuPhatDto>>> Handle(GetDieuKhoanXuPhatsQuery request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var validFilter = _mapper.Map<DieuKhoanXuPhatParameter>(request);
        var dkxps = await _repository.GetPagedDieuKhoanXuPhatAsync(validFilter);
        var metaData = dkxps.GetMetaData();

        _logger.Information($"END: {MethodName}");
        return new PagedResponse<IEnumerable<DieuKhoanXuPhatDto>>(_mapper.Map<List<DieuKhoanXuPhatDto>>(dkxps), metaData.CurrentPage, metaData.TotalPages, metaData.PageSize, metaData.TotalItems);
    }
}
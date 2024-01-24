using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.ChiTietLinhVucXuPhats;
using CatalogService.Application.Parameters.ChiTietLinhVucXuPhats;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.ChiTietLinhVucXuPhats.Queries.GetPagedByLinhVucXuPhatId;

public class GetPagedByLinhVucXuPhatIdQueryHandler : IRequestHandler<GetPagedByLinhVucXuPhatIdQuery, ApiResult<IEnumerable<ChiTietLinhVucXuPhatDto>>>
{
    private readonly IMapper _mapper;
    private readonly IChiTietLinhVucXuPhatRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "GetPagedByLinhVucXuPhatIdQueryHandler";

    public GetPagedByLinhVucXuPhatIdQueryHandler(IMapper mapper, IChiTietLinhVucXuPhatRepository repository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger;
    }

    public async Task<ApiResult<IEnumerable<ChiTietLinhVucXuPhatDto>>> Handle(GetPagedByLinhVucXuPhatIdQuery request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var validFilter = _mapper.Map<ChiTietLinhVucXuPhatParameter>(request);
        var ctlvxps = await _repository.GetPagedByLinhVucXuPhatId(validFilter);
        var metaData = ctlvxps.GetMetaData();

        _logger.Information($"END: {MethodName}");

        return new PagedResponse<IEnumerable<ChiTietLinhVucXuPhatDto>>(_mapper.Map<List<ChiTietLinhVucXuPhatDto>>(ctlvxps), metaData.CurrentPage, metaData.TotalPages, metaData.PageSize, metaData.TotalItems);
    }
}
using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.KetQuaXuPhatHanhChinhs;
using CatalogService.Application.Parameters.KetQuaXuPhatHanhChinhs;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.KetQuaXuPhatHanhChinhs.Queries.GetPagedKetQuaXuPhatHanhChinh;

public class GetPagedKetQuaXuPhatHanhChinhQueryHandler : IRequestHandler<GetPagedKetQuaXuPhatHanhChinhQuery, PagedResponse<IEnumerable<KetQuaXuPhatHanhChinhDto>>>
{
    private readonly IMapper _mapper;
    private readonly IKetQuaXuPhatHanhChinhRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "GetPagedKetQuaXuPhatHanhChinhQueryHandler";

    public GetPagedKetQuaXuPhatHanhChinhQueryHandler(IMapper mapper, IKetQuaXuPhatHanhChinhRepository repository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger;
    }

    public async Task<PagedResponse<IEnumerable<KetQuaXuPhatHanhChinhDto>>> Handle(GetPagedKetQuaXuPhatHanhChinhQuery request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var validFilter = _mapper.Map<KetQuaXuPhatHanhChinhParameter>(request);
        var cqbhs = await _repository.GetPagedKetQuaXuPhatHanhChinhAsync(validFilter);
        var metaData = cqbhs.GetMetaData();

        _logger.Information($"END: {MethodName}");

        return new PagedResponse<IEnumerable<KetQuaXuPhatHanhChinhDto>>(_mapper.Map<List<KetQuaXuPhatHanhChinhDto>>(cqbhs), metaData.CurrentPage, metaData.TotalPages, metaData.PageSize, metaData.TotalItems);
    }
}
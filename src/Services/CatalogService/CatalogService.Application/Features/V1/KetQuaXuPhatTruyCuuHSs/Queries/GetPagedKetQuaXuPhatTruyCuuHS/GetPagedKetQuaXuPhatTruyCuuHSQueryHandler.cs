using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.KetQuaXuPhatTruyCuuHSs;
using CatalogService.Application.Parameters.KetQuaXuPhatTruyCuuHSs;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.KetQuaXuPhatTruyCuuHSs.Queries.GetPagedKetQuaXuPhatTruyCuuHS;

public class GetPagedKetQuaXuPhatTruyCuuHSQueryHandler : IRequestHandler<GetPagedKetQuaXuPhatTruyCuuHSQuery, PagedResponse<IEnumerable<KetQuaXuPhatTruyCuuHSDto>>>
{
    private readonly IMapper _mapper;
    private readonly IKetQuaXuPhatTruyCuuHSRepository _repository;
    private readonly ILogger _logger;
    private const string MethodName = "GetPagedKetQuaXuPhatTruyCuuHSQueryHandler";

    public GetPagedKetQuaXuPhatTruyCuuHSQueryHandler(IMapper mapper, IKetQuaXuPhatTruyCuuHSRepository repository, ILogger logger)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger;
    }

    public async Task<PagedResponse<IEnumerable<KetQuaXuPhatTruyCuuHSDto>>> Handle(GetPagedKetQuaXuPhatTruyCuuHSQuery request, CancellationToken cancellationToken)
    {
        _logger.Information($"BEGIN: {MethodName}");

        var validFilter = _mapper.Map<KetQuaXuPhatTruyCuuHSParameter>(request);
        var cqbhs = await _repository.GetPagedKetQuaXuPhatTruyCuuHSAsync(validFilter);
        var metaData = cqbhs.GetMetaData();

        _logger.Information($"END: {MethodName}");

        return new PagedResponse<IEnumerable<KetQuaXuPhatTruyCuuHSDto>>(_mapper.Map<List<KetQuaXuPhatTruyCuuHSDto>>(cqbhs), metaData.CurrentPage, metaData.TotalPages, metaData.PageSize, metaData.TotalItems);
    }
}
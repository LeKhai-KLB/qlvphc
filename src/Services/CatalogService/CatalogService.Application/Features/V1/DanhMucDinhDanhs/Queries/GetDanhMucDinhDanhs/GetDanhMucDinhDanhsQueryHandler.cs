using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.DanhMucDinhDanhs;
using CatalogService.Application.Parameters.DanhMucDinhDanhs;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.DanhMucDinhDanhs.Queries.GetDanhMucDinhDanhs
{
    public class GetDanhMucDinhDanhsQueryHandler : IRequestHandler<GetDanhMucDinhDanhsQuery, PagedResponse<IEnumerable<DanhMucDinhDanhDto>>>
    {
        private readonly IMapper _mapper;
        private readonly IDanhMucDinhDanhRepository _repository;
        private readonly ILogger _logger;
        private const string MethodName = "GetDanhMucDinhDanhQueryHandler";

        public GetDanhMucDinhDanhsQueryHandler(IMapper mapper, IDanhMucDinhDanhRepository repository, ILogger logger)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger;
        }

        public async Task<PagedResponse<IEnumerable<DanhMucDinhDanhDto>>> Handle(GetDanhMucDinhDanhsQuery request, CancellationToken cancellationToken)
        {
            _logger.Information($"BEGIN: {MethodName}");

            var validFilter = _mapper.Map<DanhMucDinhDanhParameter>(request);
            var danhMucDinhDanhPageList = await _repository.GetPagedDanhMucDinhDanhAsync(validFilter);
            var metaData = danhMucDinhDanhPageList.GetMetaData();

            _logger.Information($"END: {MethodName}");
            return new PagedResponse<IEnumerable<DanhMucDinhDanhDto>>(_mapper.Map<List<DanhMucDinhDanhDto>>(danhMucDinhDanhPageList), metaData.CurrentPage, metaData.TotalPages, metaData.PageSize, metaData.TotalItems);
        }
    }
}
using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.QuanHuyens;
using CatalogService.Application.Parameters.QuanHuyens;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.QuanHuyens.Queries.GetQuanHuyens
{
    public class GetQuanHuyensQueryHandler : IRequestHandler<GetQuanHuyensQuery, PagedResponse<IEnumerable<QuanHuyenDto>>>
    {
        private readonly IMapper _mapper;
        private readonly IQuanHuyenRepository _repository;
        private readonly ILogger _logger;
        private const string MethodName = "GetQuanHuyenQueryHandler";

        public GetQuanHuyensQueryHandler(IMapper mapper, IQuanHuyenRepository repository, ILogger logger)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger;
        }

        public async Task<PagedResponse<IEnumerable<QuanHuyenDto>>> Handle(GetQuanHuyensQuery request, CancellationToken cancellationToken)
        {
            _logger.Information($"BEGIN: {MethodName}");

            var validFilter = _mapper.Map<QuanHuyenParameter>(request);
            var QuanHuyenPageList = await _repository.GetPagedQuanHuyenAsync(validFilter);
            var metaData = QuanHuyenPageList.GetMetaData();

            _logger.Information($"END: {MethodName}");
            return new PagedResponse<IEnumerable<QuanHuyenDto>>(_mapper.Map<List<QuanHuyenDto>>(QuanHuyenPageList), metaData.CurrentPage, metaData.TotalPages, metaData.PageSize, metaData.TotalItems);
        }
    }
}
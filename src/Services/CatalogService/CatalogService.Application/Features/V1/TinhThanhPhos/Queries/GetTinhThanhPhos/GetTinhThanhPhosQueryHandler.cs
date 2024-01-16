using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.TinhThanhPhos;
using CatalogService.Application.Parameters.TinhThanhPhos;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.TinhThanhPhos.Queries.GetTinhThanhPhos
{
    public class GetTinhThanhPhosQueryHandler : IRequestHandler<GetTinhThanhPhosQuery, PagedResponse<IEnumerable<TinhThanhPhoDto>>>
    {
        private readonly IMapper _mapper;
        private readonly ITinhThanhPhoRepository _repository;
        private readonly ILogger _logger;
        private const string MethodName = "GetTinhThanhPhoQueryHandler";

        public GetTinhThanhPhosQueryHandler(IMapper mapper, ITinhThanhPhoRepository repository, ILogger logger)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger;
        }

        public async Task<PagedResponse<IEnumerable<TinhThanhPhoDto>>> Handle(GetTinhThanhPhosQuery request, CancellationToken cancellationToken)
        {
            _logger.Information($"BEGIN: {MethodName}");

            var validFilter = _mapper.Map<TinhThanhPhoParameter>(request);
            var tinhThanhPhoPageList = await _repository.GetPagedTinhThanhPhoAsync(validFilter);
            var metaData = tinhThanhPhoPageList.GetMetaData();

            _logger.Information($"END: {MethodName}");
            return new PagedResponse<IEnumerable<TinhThanhPhoDto>>(_mapper.Map<List<TinhThanhPhoDto>>(tinhThanhPhoPageList), metaData.CurrentPage, metaData.TotalPages, metaData.PageSize, metaData.TotalItems);
        }
    }
}
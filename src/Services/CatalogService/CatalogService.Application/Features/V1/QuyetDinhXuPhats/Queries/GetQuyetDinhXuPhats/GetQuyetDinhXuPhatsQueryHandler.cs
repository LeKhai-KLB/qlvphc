using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.QuyetDinhXuPhats;
using CatalogService.Application.Parameters.QuyetDinhXuPhats;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.QuyetDinhXuPhats.Queries.GetQuyetDinhXuPhats
{
    public class GetQuyetDinhXuPhatsQueryHandler : IRequestHandler<GetQuyetDinhXuPhatsQuery, PagedResponse<IEnumerable<QuyetDinhXuPhatDto>>>
    {
        private readonly IMapper _mapper;
        private readonly IQuyetDinhXuPhatRepository _repository;
        private readonly ILogger _logger;
        private const string MethodName = "GetQuyetDinhXuPhatQueryHandler";

        public GetQuyetDinhXuPhatsQueryHandler(IMapper mapper, IQuyetDinhXuPhatRepository repository, ILogger logger)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger;
        }

        public async Task<PagedResponse<IEnumerable<QuyetDinhXuPhatDto>>> Handle(GetQuyetDinhXuPhatsQuery request, CancellationToken cancellationToken)
        {
            _logger.Information($"BEGIN: {MethodName}");

            var validFilter = _mapper.Map<QuyetDinhXuPhatParameter>(request);
            var quyetDinhXuPhatPageList = await _repository.GetPagedQuyetDinhXuPhatAsync(validFilter);
            var metaData = quyetDinhXuPhatPageList.GetMetaData();

            _logger.Information($"END: {MethodName}");
            return new PagedResponse<IEnumerable<QuyetDinhXuPhatDto>>(_mapper.Map<List<QuyetDinhXuPhatDto>>(quyetDinhXuPhatPageList), metaData.CurrentPage, metaData.TotalPages, metaData.PageSize, metaData.TotalItems);
        }
    }
}
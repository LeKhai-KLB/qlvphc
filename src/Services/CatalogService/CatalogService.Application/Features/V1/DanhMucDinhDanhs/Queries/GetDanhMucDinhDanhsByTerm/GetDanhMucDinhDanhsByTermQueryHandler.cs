using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.DanhMucDinhDanhs;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.DanhMucDinhDanhs.Queries.GetDanhMucDinhDanhsByTerm
{
    public class GetDanhMucDinhDanhsByTermQueryHandler : IRequestHandler<GetDanhMucDinhDanhsByTermQuery, ApiResult<List<DanhMucDinhDanhDto>>>
    {
        private readonly IMapper _mapper;
        private readonly IDanhMucDinhDanhRepository _repository;
        private readonly ILogger _logger;
        private const string MethodName = "GetDanhMucDinhDanhQueryHandler";

        public GetDanhMucDinhDanhsByTermQueryHandler(IMapper mapper, IDanhMucDinhDanhRepository repository, ILogger logger)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger;
        }

        public async Task<ApiResult<List<DanhMucDinhDanhDto>>> Handle(GetDanhMucDinhDanhsByTermQuery request, CancellationToken cancellationToken)
        {
            _logger.Information($"BEGIN: {MethodName}");

            var danhMucDinhDanhEntities = await _repository.GetDanhMucDinhDanhsByTerm(request.Term);
            var danhMucDinhDanhs = _mapper.Map<List<DanhMucDinhDanhDto>>(danhMucDinhDanhEntities);

            _logger.Information($"END: {MethodName}");
            return new ApiSuccessResult<List<DanhMucDinhDanhDto>>(danhMucDinhDanhs);
        }
    }
}
using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.HinhThucXuPhatChinhs;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.HinhThucXuPhatChinhs.Queries.GetHinhThucXuPhatChinhs
{
    public class GetHinhThucXuPhatChinhsQueryHandler : IRequestHandler<GetHinhThucXuPhatChinhsQuery, ApiResult<IEnumerable<HinhThucXuPhatChinhDto>>>
    {
        private readonly IMapper _mapper;
        private readonly IHinhThucXuPhatChinhRepository _repository;
        private readonly ILogger _logger;
        private const string MethodName = "GetHinhThucXuPhatChinhQueryHandler";

        public GetHinhThucXuPhatChinhsQueryHandler(IMapper mapper, IHinhThucXuPhatChinhRepository repository, ILogger logger)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger;
        }

        public async Task<ApiResult<IEnumerable<HinhThucXuPhatChinhDto>>> Handle(GetHinhThucXuPhatChinhsQuery request, CancellationToken cancellationToken)
        {
            _logger.Information($"BEGIN: {MethodName}");

            var htxps = await _repository.GetAllHinhThucXuPhatChinhs();
            var htxpDtos = _mapper.Map<IEnumerable<HinhThucXuPhatChinhDto>>(htxps);

            _logger.Information($"END: {MethodName}");

            return new ApiSuccessResult<IEnumerable<HinhThucXuPhatChinhDto>>(htxpDtos);
        
        }
    }
}
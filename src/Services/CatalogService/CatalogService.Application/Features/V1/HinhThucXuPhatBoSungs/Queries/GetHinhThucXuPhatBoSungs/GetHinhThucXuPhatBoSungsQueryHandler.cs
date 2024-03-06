using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.HinhThucXuPhatBoSungs;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.HinhThucXuPhatBoSungs.Queries.GetHinhThucXuPhatBoSungs
{
    public class GetHinhThucXuPhatBoSungsQueryHandler : IRequestHandler<GetHinhThucXuPhatBoSungsQuery, ApiResult<IEnumerable<HinhThucXuPhatBoSungDto>>>
    {
        private readonly IMapper _mapper;
        private readonly IHinhThucXuPhatBoSungRepository _repository;
        private readonly ILogger _logger;
        private const string MethodName = "GetHinhThucXuPhatBoSungQueryHandler";

        public GetHinhThucXuPhatBoSungsQueryHandler(IMapper mapper, IHinhThucXuPhatBoSungRepository repository, ILogger logger)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger;
        }

        public async Task<ApiResult<IEnumerable<HinhThucXuPhatBoSungDto>>> Handle(GetHinhThucXuPhatBoSungsQuery request, CancellationToken cancellationToken)
        {
            _logger.Information($"BEGIN: {MethodName}");

            var htxps = await _repository.GetAllHinhThucXuPhatBoSungs();
            var htxpDtos = _mapper.Map<IEnumerable<HinhThucXuPhatBoSungDto>>(htxps);

            _logger.Information($"END: {MethodName}");

            return new ApiSuccessResult<IEnumerable<HinhThucXuPhatBoSungDto>>(htxpDtos);
        
        }
    }
}
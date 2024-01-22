using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.DieuKhoanXuPhats;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.DieuKhoanXuPhats.Queries.GetDieuKhoanXuPhatsByTerm
{
    public class GetDieuKhoanXuPhatsByTermQueryHandler : IRequestHandler<GetDieuKhoanXuPhatsByTermQuery, ApiResult<List<DieuKhoanXuPhatDto>>>
    {
        private readonly IMapper _mapper;
        private readonly IDieuKhoanXuPhatRepository _repository;
        private readonly ILogger _logger;
        private const string MethodName = "GetDieuKhoanXuPhatQueryHandler";

        public GetDieuKhoanXuPhatsByTermQueryHandler(IMapper mapper, IDieuKhoanXuPhatRepository repository, ILogger logger)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger;
        }

        public async Task<ApiResult<List<DieuKhoanXuPhatDto>>> Handle(GetDieuKhoanXuPhatsByTermQuery request, CancellationToken cancellationToken)
        {
            _logger.Information($"BEGIN: {MethodName}");

            var DieuKhoanXuPhatEntities = await _repository.GetDieuKhoanXuPhatsByTerm(request.Term);
            var DieuKhoanXuPhats = _mapper.Map<List<DieuKhoanXuPhatDto>>(DieuKhoanXuPhatEntities);

            _logger.Information($"END: {MethodName}");
            return new ApiSuccessResult<List<DieuKhoanXuPhatDto>>(DieuKhoanXuPhats);
        }
    }
}
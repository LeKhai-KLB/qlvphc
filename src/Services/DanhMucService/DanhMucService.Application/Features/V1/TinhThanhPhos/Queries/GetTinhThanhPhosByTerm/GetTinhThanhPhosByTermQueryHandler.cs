using AutoMapper;
using DanhMucService.Application.Common.Interfaces;
using DanhMucService.Application.Common.Models.TinhThanhPhos;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace DanhMucService.Application.Features.V1.TinhThanhPhos.Queries.GetTinhThanhPhosByTerm
{
    public class GetTinhThanhPhosByTermQueryHandler : IRequestHandler<GetTinhThanhPhosByTermQuery, ApiResult<List<TinhThanhPhoDto>>>
    {
        private readonly IMapper _mapper;
        private readonly ITinhThanhPhoRepository _repository;
        private readonly ILogger _logger;
        private const string MethodName = "GetTinhThanhPhoQueryHandler";

        public GetTinhThanhPhosByTermQueryHandler(IMapper mapper, ITinhThanhPhoRepository repository, ILogger logger)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger;
        }

        public async Task<ApiResult<List<TinhThanhPhoDto>>> Handle(GetTinhThanhPhosByTermQuery request, CancellationToken cancellationToken)
        {
            _logger.Information($"BEGIN: {MethodName}");

            var tinhThanhPhoEntities = await _repository.GetTinhThanhPhosByTerm(request.Term);
            var tinhThanhPhos = _mapper.Map<List<TinhThanhPhoDto>>(tinhThanhPhoEntities);

            _logger.Information($"END: {MethodName}");
            return new ApiSuccessResult<List<TinhThanhPhoDto>>(tinhThanhPhos);
        }
    }
}
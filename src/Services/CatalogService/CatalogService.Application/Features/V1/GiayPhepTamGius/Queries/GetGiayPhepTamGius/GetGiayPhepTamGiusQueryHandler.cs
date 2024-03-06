using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.GiayPhepTamGius;
using CatalogService.Application.Parameters.GiayPhepTamGius;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.GiayPhepTamGius.Queries.GetGiayPhepTamGius
{
    public class GetGiayPhepTamGiusQueryHandler : IRequestHandler<GetGiayPhepTamGiusQuery, PagedResponse<IEnumerable<GiayPhepTamGiuDto>>>
    {
        private readonly IMapper _mapper;
        private readonly IGiayPhepTamGiuRepository _repository;
        private readonly ILogger _logger;
        private const string MethodName = "GetGiayPhepTamGiuQueryHandler";

        public GetGiayPhepTamGiusQueryHandler(IMapper mapper, IGiayPhepTamGiuRepository repository, ILogger logger)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger;
        }

        public async Task<PagedResponse<IEnumerable<GiayPhepTamGiuDto>>> Handle(GetGiayPhepTamGiusQuery request, CancellationToken cancellationToken)
        {
            _logger.Information($"BEGIN: {MethodName}");

            var validFilter = _mapper.Map<GiayPhepTamGiuParameter>(request);
            var giayPhepTamGiuPageList = await _repository.GetPagedGiayPhepTamGiuAsync(validFilter);
            var metaData = giayPhepTamGiuPageList.GetMetaData();

            _logger.Information($"END: {MethodName}");
            return new PagedResponse<IEnumerable<GiayPhepTamGiuDto>>(_mapper.Map<List<GiayPhepTamGiuDto>>(giayPhepTamGiuPageList), metaData.CurrentPage, metaData.TotalPages, metaData.PageSize, metaData.TotalItems);
        }
    }
}
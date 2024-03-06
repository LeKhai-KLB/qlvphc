using AutoMapper;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.TangVatPhuongTienTamGius;
using CatalogService.Application.Parameters.TangVatPhuongTienTamGius;
using MediatR;
using Serilog;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.TangVatPhuongTienTamGius.Queries.GetTangVatPhuongTienTamGius
{
    public class GetTangVatPhuongTienTamGiusQueryHandler : IRequestHandler<GetTangVatPhuongTienTamGiusQuery, PagedResponse<IEnumerable<TangVatPhuongTienTamGiuDto>>>
    {
        private readonly IMapper _mapper;
        private readonly ITangVatPhuongTienTamGiuRepository _repository;
        private readonly ILogger _logger;
        private const string MethodName = "GetTangVatPhuongTienTamGiuQueryHandler";

        public GetTangVatPhuongTienTamGiusQueryHandler(IMapper mapper, ITangVatPhuongTienTamGiuRepository repository, ILogger logger)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger;
        }

        public async Task<PagedResponse<IEnumerable<TangVatPhuongTienTamGiuDto>>> Handle(GetTangVatPhuongTienTamGiusQuery request, CancellationToken cancellationToken)
        {
            _logger.Information($"BEGIN: {MethodName}");

            var validFilter = _mapper.Map<TangVatPhuongTienTamGiuParameter>(request);
            var tangVatPhuongTienTamGiuPageList = await _repository.GetPagedTangVatPhuongTienTamGiuAsync(validFilter);
            var metaData = tangVatPhuongTienTamGiuPageList.GetMetaData();

            _logger.Information($"END: {MethodName}");
            return new PagedResponse<IEnumerable<TangVatPhuongTienTamGiuDto>>(_mapper.Map<List<TangVatPhuongTienTamGiuDto>>(tangVatPhuongTienTamGiuPageList), metaData.CurrentPage, metaData.TotalPages, metaData.PageSize, metaData.TotalItems);
        }
    }
}
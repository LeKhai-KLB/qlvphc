
using CatalogService.Application.Common.Models.DanhMucDinhDanhs;
using CatalogService.Application.Parameters.DanhMucDinhDanhs;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.DanhMucDinhDanhs.Queries.GetDanhMucDinhDanhs
{
    public class GetDanhMucDinhDanhsQuery : IRequest<PagedResponse<IEnumerable<DanhMucDinhDanhDto>>>
    {
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
        public string? OrderBy { get; set; }
        public string? Name { get; set; }
        public bool? IsDeleted { get; set; }

        public string? SearchTerm { get; set; }
        public GetDanhMucDinhDanhsQuery(DanhMucDinhDanhParameter request)
        {
            PageNumber = request.PageNumber;
            PageSize = request.PageSize;
            OrderBy = request.OrderBy;
            Name = request.Name;
            IsDeleted = request.IsDeleted;
            SearchTerm = request.SearchTerm;
        }
    }
}
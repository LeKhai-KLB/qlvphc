
using CatalogService.Application.Common.Models.QuanHuyens;
using CatalogService.Application.Parameters.QuanHuyens;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.QuanHuyens.Queries.GetQuanHuyens
{
    public class GetQuanHuyensQuery : IRequest<PagedResponse<IEnumerable<QuanHuyenDto>>>
    {
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
        public string? OrderBy { get; set; }
        public string? Name { get; set; }
        public bool? IsDeleted { get; set; }
        public GetQuanHuyensQuery(QuanHuyenParameter request)
        {
            PageNumber = request.PageNumber;
            PageSize = request.PageSize;
            OrderBy = request.OrderBy;
            Name = request.Name;
            IsDeleted = request.IsDeleted;
        }
    }
}

using CatalogService.Application.Common.Models.GiayPhepTamGius;
using CatalogService.Application.Parameters.GiayPhepTamGius;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.GiayPhepTamGius.Queries.GetGiayPhepTamGius
{
    public class GetGiayPhepTamGiusQuery : IRequest<PagedResponse<IEnumerable<GiayPhepTamGiuDto>>>
    {
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
        public string? OrderBy { get; set; }
        public string? Ten { get; set; }
        public bool? IsDeleted { get; set; }
        public GetGiayPhepTamGiusQuery(GiayPhepTamGiuParameter request)
        {
            PageNumber = request.PageNumber;
            PageSize = request.PageSize;
            OrderBy = request.OrderBy;
            Ten = request.Ten;
            IsDeleted = request.IsDeleted;
        }
    }
}
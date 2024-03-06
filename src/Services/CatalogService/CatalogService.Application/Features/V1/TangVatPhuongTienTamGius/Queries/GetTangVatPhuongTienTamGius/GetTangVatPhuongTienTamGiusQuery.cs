
using CatalogService.Application.Common.Models.TangVatPhuongTienTamGius;
using CatalogService.Application.Parameters.TangVatPhuongTienTamGius;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.TangVatPhuongTienTamGius.Queries.GetTangVatPhuongTienTamGius
{
    public class GetTangVatPhuongTienTamGiusQuery : IRequest<PagedResponse<IEnumerable<TangVatPhuongTienTamGiuDto>>>
    {
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
        public string? OrderBy { get; set; }
        public string? Ten { get; set; }
        public bool? IsDeleted { get; set; }
        public GetTangVatPhuongTienTamGiusQuery(TangVatPhuongTienTamGiuParameter request)
        {
            PageNumber = request.PageNumber;
            PageSize = request.PageSize;
            OrderBy = request.OrderBy;
            Ten = request.Ten;
            IsDeleted = request.IsDeleted;
        }
    }
}

using CatalogService.Application.Common.Models.QuyetDinhXuPhats;
using CatalogService.Application.Parameters.QuyetDinhXuPhats;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.QuyetDinhXuPhats.Queries.GetQuyetDinhXuPhats
{
    public class GetQuyetDinhXuPhatsQuery : IRequest<PagedResponse<IEnumerable<QuyetDinhXuPhatDto>>>
    {
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
        public string? OrderBy { get; set; }
        public string? SoQuyetDinh { get; set; }
        public bool? IsDeleted { get; set; }
        public GetQuyetDinhXuPhatsQuery(QuyetDinhXuPhatParameter request)
        {
            PageNumber = request.PageNumber;
            PageSize = request.PageSize;
            OrderBy = request.OrderBy;
            SoQuyetDinh = request.SoQuyetDinh;
            IsDeleted = request.IsDeleted;
        }
    }
}
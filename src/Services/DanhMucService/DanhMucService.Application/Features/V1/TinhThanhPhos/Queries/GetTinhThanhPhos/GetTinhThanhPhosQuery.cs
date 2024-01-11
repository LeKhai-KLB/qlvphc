
using DanhMucService.Application.Common.Models.TinhThanhPhos;
using DanhMucService.Application.Parameters.TinhThanhPhos;
using MediatR;
using Shared.SeedWord;

namespace DanhMucService.Application.Features.V1.TinhThanhPhos.Queries.GetTinhThanhPhos
{
    public class GetTinhThanhPhosQuery : IRequest<PagedResponse<IEnumerable<TinhThanhPhoDto>>>
    {
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
        public string? OrderBy { get; set; }
        public string? Name { get; set; }
        public bool? IsDeleted { get; set; }
        public GetTinhThanhPhosQuery(TinhThanhPhoParameter request)
        {
            PageNumber = request.PageNumber;
            PageSize = request.PageSize;
            OrderBy = request.OrderBy;
            Name = request.Name;
            IsDeleted = request.IsDeleted;
        }
    }
}
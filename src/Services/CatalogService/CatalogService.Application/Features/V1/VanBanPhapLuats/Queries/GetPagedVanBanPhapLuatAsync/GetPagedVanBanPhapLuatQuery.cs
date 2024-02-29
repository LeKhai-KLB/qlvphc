using CatalogService.Application.Common.Models.VanBanPhapLuats;
using CatalogService.Application.Parameters.VanBanPhapLuats;
using CatalogService.Domain.Constants;
using MediatR;
using Shared.SeedWord;

namespace CatalogService.Application.Features.V1.VanBanPhapLuats.Queries.GetPagedVanBanPhapLuatAsync;

public class GetPagedVanBanPhapLuatQuery : IRequest<PagedResponse<IEnumerable<VanBanPhapLuatDto>>>
{
    public string? SoHieu { get; set; }

    public int? CoQuanBanHanhId { get; set; }

    public int? LoaiVanBanId { get; set; }

    public DateTime? NgayBanHanhTu { get; set; }

    public DateTime? NgayBanHanhDen { get; set; }

    public TrangThaiVanBan? TrangThai { get; set; }

    public string? SearchTerm { get; set; }

    public int? PageNumber { get; set; }

    public int? PageSize { get; set; }

    public string? OrderBy { get; set; }

    public GetPagedVanBanPhapLuatQuery(VanBanPhapLuatParameter request)
    {
        SearchTerm = request.SearchTerm;
        PageNumber = request.PageNumber;
        PageSize = request.PageSize;
        OrderBy = request.OrderBy;
        SoHieu = request.SoHieu;
        CoQuanBanHanhId = request.CoQuanBanHanhId;
        LoaiVanBanId = request.LoaiVanBanId;
        NgayBanHanhTu = request.NgayBanHanhTu;
        NgayBanHanhDen = request.NgayBanHanhDen;
        TrangThai = request.TrangThai;
    }
}
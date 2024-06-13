using System.ComponentModel.DataAnnotations.Schema;
using CatalogService.Domain.Constants;
using Contracts.Domains;

namespace CatalogService.Domain.Entities;

public class HoSoXuLyViPham : EntityAuditBase<int>
{
    [Column(TypeName = "nvarchar(255)")]
    public string SoHoSo { get; set; }

    public DateTime NgayHoSo { get; set; }

    [Column(TypeName = "nvarchar(512)")]
    public string TenHoSo { get; set; }

    public int? CaNhanViPhamId { get; set; }

    public bool IsCaNhanViPhamKhac {  get; set; }

    public string? ThongTinKhac { get; set; }

    public string? HinhAnhViPham { get; set; }

    public TrangThaiHoSoViPham TrangThaiHoSoViPham { get; set; }

    public TinhTietViPham TinhTietViPham { get; set; }

    public LoaiVuViecViPham LoaiVuViecViPham { get; set; }

    public List<HoSoXuLyViPham_VanBanGiaiQuyet> HSXLVP_VanBanGiaiQuyets { get; set; }

    public List<TangVatPhuongTienTamGiu> TangVatPhuongTienTamGius { get; set; }
}
using System.ComponentModel.DataAnnotations.Schema;
using Contracts.Domains;

namespace CatalogService.Domain.Entities;

public class QuyetDinhXuPhat : EntityAuditBase<int>
{
    public int HoSoXuLyViPhamId { get; set; }
    public DateTime NgayNhapQuyetDinh { get; set; }

    [Column(TypeName = "nvarchar(255)")]
    public string SoQuyetDinh { get; set; }

    public DateTime NgayQuyetDinh { get; set; }

    public DateTime HieuLucThiHanhNgay { get; set; }

    public int CoQuanBanHanhId { get; set; }

    public int NguoiRaQuyetDinhId { get; set; }

    public int LoaiDoiTuongViPham { get; set; }

    [ForeignKey("DoiTuongViPham")]
    public int DoiTuongViPhamId { get; set; }

    [Column(TypeName = "nvarchar(255)")]
    public string? DoiTuongViPhamKhac { get; set; }

    [Column(TypeName = "nvarchar(512)")]

    public string CanCuVanBan { get; set; }

    [Column(TypeName = "nvarchar(512)")]
    public string CanCuQuyDinh { get; set; }
    public long? SoTienPhat { get; set; }

    [Column(TypeName = "nvarchar(255)")]
    public string? SoTienPhatBangChu { get; set; }
    public long? TienKhacPhuc { get; set; }

    [Column(TypeName = "nvarchar(255)")]
    public string? NoiThucHien { get; set; }
    public long? TienTruyThu { get; set; }
    public int? ThoiHanKhacPhucHauQua { get; set; }
    public int? ThoiHanThucHienXuPhatBoSung { get; set; }

    public int NoiNopTienPhat { get; set; }

    [Column(TypeName = "nvarchar(255)")]
    public string? NoiNopTienPhatTuNhap { get; set; }

    [Column(TypeName = "nvarchar(255)")]
    public string DiaDiemViPham { get; set; }

    public int HinhThucXuPhatChinh { get; set; }

    [Column(TypeName = "nvarchar(255)")]
    public string? TinhTietTangNang { get; set; }

    [Column(TypeName = "nvarchar(255)")]
    public string? TinhTietGiamNhe { get; set; }

    [Column(TypeName = "nvarchar(255)")]
    public string HinhThucXuPhatCuThe { get; set; }

    public int? HinhThucXuPhatBoSung { get; set; }

    [Column(TypeName = "nvarchar(255)")]

    public string? HinhThucXuPhatBoSungCuThe { get; set; }

    public int BienPhapKhacPhucHauQua { get; set; }

    [Column(TypeName = "nvarchar(255)")]

    public string? BienPhapKhacPhucHauQuaCuThe { get; set; }

    [Column(TypeName = "nvarchar(255)")]
    public string? NoiDungLienQuanKhacPhucHauQua { get; set; }

    [Column(TypeName = "nvarchar(255)")]

    public string DonViPhoiHopThucHien { get; set; }

    [Column(TypeName = "nvarchar(255)")]

    public string NoiNhan { get; set; }

    public bool IsDeleted { get; set; }

    public List<ChiTietQuyetDinhXuPhat> ChiTietQuyetDinhXuPhats { get; set; }

    public virtual CoQuanBanHanh CoQuanBanHanh { get; set; }

    public virtual HoSoXuLyViPham HoSoXuLyViPham { get; set; }

    public virtual CongDan DoiTuongViPham { get; set; }
}
using CatalogService.Domain.Constants;

namespace CatalogService.Application.Common.Models.HanhViViPhams;

public class CreateHanhViViPhamDto
{
    public int? QuyetDinhXuPhatId { get; set; }

    public int? HoSoXuLyViPhamId { get; set; }

    public int LinhVucXuPhatId { get; set; }

    public int DieuKhoanXuPhatId { get; set; }

    public int? DieuKhoanBoSungId { get; set; }

    public int? DieuKhoanKhacPhucId { get; set; }

    public string? QuyDinh { get; set; }

    public TinhTietViPham TinhTietViPham { get; set; }

    public long MucPhat { get; set; }

    public string? GhiChu { get; set; }
}
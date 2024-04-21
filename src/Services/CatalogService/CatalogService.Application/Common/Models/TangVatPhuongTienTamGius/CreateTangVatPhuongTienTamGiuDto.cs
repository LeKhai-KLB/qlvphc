namespace CatalogService.Application.Common.Models.TangVatPhuongTienTamGius;

public class CreateTangVatPhuongTienTamGiuDto
{
    public int HoSoXuLyViPhamId { get; set; }

    public string Ten { get; set; }

    public string DonViTinh { get; set; }

    public int SoLuong { get; set; }

    public string ChungLoai { get; set; }

    public string TinhTrang { get; set; }

    public string? GhiChu { get; set; }
}
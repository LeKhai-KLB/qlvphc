namespace CatalogService.Application.Common.Models.DanhMucDinhDanhs;

public class CreateDanhMucDinhDanhDto
{
    public string MaDinhDanh { get; set; }
    public string Ten { get; set; }
    public string DiaChi { get; set; }
    public string? Email { get; set; }
    public string? DienThoai { get; set; }
    public string? Website { get; set; }
    public string? MaDinhDanhTCVN { get; set; }
}
namespace CatalogService.Application.Common.Models.ChiTietLinhVucXuPhats;

public class CreateChiTietLinhVucXuPhatDto
{
    public int LinhVucXuPhatId { get; set; }

    public string? Dieu { get; set; }

    public string? Khoan { get; set; }

    public string? Diem { get; set; }
}
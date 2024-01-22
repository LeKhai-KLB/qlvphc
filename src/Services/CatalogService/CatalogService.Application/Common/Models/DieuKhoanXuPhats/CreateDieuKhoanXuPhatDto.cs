namespace CatalogService.Application.Common.Models.DieuKhoanXuPhats;

public class CreateDieuKhoanXuPhatDto
{
    public int LinhVucXuPhatId { get; set; }
    public string Dieu { get; set; }
    public string Khoan { get; set; }
    public string Diem { get; set; }
}
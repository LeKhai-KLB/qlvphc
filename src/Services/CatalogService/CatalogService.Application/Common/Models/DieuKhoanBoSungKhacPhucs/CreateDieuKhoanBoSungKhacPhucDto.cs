using CatalogService.Domain.Constants;

namespace CatalogService.Application.Common.Models.DieuKhoanBoSungKhacPhucs;

public class CreateDieuKhoanBoSungKhacPhucDto
{
    public int DieuKhoanXuPhatId { get; set; }

    public string? Dieu { get; set; }

    public string? Khoan { get; set; }

    public string? Diem { get; set; }

    public LoaiDieuKhoan LoaiDieuKhoan { get; set; }

    public bool? IsDeleted { get; set; }
}
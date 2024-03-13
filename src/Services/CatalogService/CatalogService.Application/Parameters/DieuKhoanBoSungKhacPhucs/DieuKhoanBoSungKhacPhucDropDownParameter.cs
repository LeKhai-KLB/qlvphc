using CatalogService.Domain.Constants;
using Shared.SeedWord;

namespace CatalogService.Application.Parameters.DieuKhoanBoSungKhacPhucs;

public class DieuKhoanBoSungKhacPhucDropDownParameter : RequestParameters
{
    public int DieuKhoanXuPhatId { get; set; }

    public LoaiDieuKhoan LoaiDieuKhoan { get; set; }
}
namespace CatalogService.Application.Common.Models.LinhVucXuPhats;

public class CreateLinhVucXuPhatDto
{
    public string TenLinhVuc { get; set; }

    public string NhomLinhVuc { get; set; }

    public string NghiDinh { get; set; }

    public string HanhVi_QuyetDinh { get; set; }

    public string DanChungNghiDinh { get; set; }

    public bool HienThi { get; set; }

    public bool HetHieuLuc { get; set; }
}
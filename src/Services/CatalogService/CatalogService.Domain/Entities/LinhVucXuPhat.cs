using Contracts.Domains;

namespace CatalogService.Domain.Entities;

public class LinhVucXuPhat : EntityAuditBase<int>
{
    public string TenLinhVuc { get; set; }

    public string NhomLinhVuc { get; set; }

    public string NghiDinh { get; set; }

    public string HanhVi_QuyetDinh { get; set; }

    public string DanChungNghiDinh { get; set; }

    public bool HienThi { get; set; }

    public bool HetHieuLuc { get; set; }

    public List<ChiTietLinhVucXuPhat> ChiTietLinhVucXuPhat { get; set; }
}
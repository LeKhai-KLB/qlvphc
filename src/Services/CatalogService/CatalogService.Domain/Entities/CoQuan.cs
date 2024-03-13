using Contracts.Domains;
using Shared.Common.Constants;

namespace CatalogService.Domain.Entities;

public  class CoQuan : EntityAuditBase<int>
{
    public string TenCoQuan { get; set; }

    public string DiaChi { get; set; }

    public string DienThoai { get; set; }

    public string Email { get; set; }

    public string Website { get; set; }

    public string SoFax { get; set; }

    public CapCoQuan CapCoQuan { get; set; }
}
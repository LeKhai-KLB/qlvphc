﻿using Contracts.Domains;
using Shared.Common.Constants;

namespace CatalogService.Domain.Entities;

public class ToChuc : EntityAuditBase<int>
{
    public string TenTC { get; set; }

    public string? DiaChi { get; set; }

    public string? MaSo { get; set; }

    public string? SoChungNhan { get; set; }

    public string? GiayPhepSo { get; set; }

    public DateTime? NgayGiayPhep { get; set; }

    public string? NoiCap { get; set; }

    public string? TenNguoiDaiDien { get; set; }

    public Genders? GioiTinh { get; set; }

    public string? ChucDanh { get; set; }
}
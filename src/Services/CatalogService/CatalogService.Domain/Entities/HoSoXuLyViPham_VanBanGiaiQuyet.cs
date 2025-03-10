﻿using Contracts.Domains;
using System.ComponentModel.DataAnnotations.Schema;

namespace CatalogService.Domain.Entities;

public class HoSoXuLyViPham_VanBanGiaiQuyet : EntityAuditBase<int>
{
    [Column(Order = 0)]
    public int HoSoXuLyViPhamId { get; set; }

    [Column(Order = 1)]
    public int VanBanGiaiQuyetId { get; set; }

    public string? SoQuyetDinh {  get; set; }

    public DateTime NgayNhap {  get; set; }

    public virtual HoSoXuLyViPham HoSoXuLyViPham { get; set; }

    public virtual VanBanGiaiQuyet VanBanGiaiQuyet { get; set; }
}
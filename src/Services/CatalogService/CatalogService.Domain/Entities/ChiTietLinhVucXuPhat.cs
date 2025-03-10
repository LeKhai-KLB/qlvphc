﻿using System.ComponentModel.DataAnnotations.Schema;
using Contracts.Domains;

namespace CatalogService.Domain.Entities;

public class ChiTietLinhVucXuPhat : EntityAuditBase<int>
{
    public int LinhVucXuPhatId { get; set; }

    [Column(TypeName = "nvarchar(4000)")]
    public string? Dieu { get; set; }

    [Column(TypeName = "nvarchar(4000)")]
    public string? Khoan { get; set; }

    [Column(TypeName = "nvarchar(4000)")]
    public string? Diem { get; set; }

    public LinhVucXuPhat LinhVucXuPhat { get; set; }
}
﻿namespace CatalogService.Application.Common.Models.HoSoXuLyViPhams;

public class CreateHoSoXuLyViPham_VanBanGiaiQuyetDto
{
    public int HoSoXuLyViPhamId { get; set; }

    public int VanBanGiaiQuyetId { get; set; }

    public string SoQuyetDinh { get; set; }

    public DateTime NgayNhap { get; set; }
}
﻿namespace CatalogService.Application.Common.Models.GiayPhepTamGius;

public class CreateGiayPhepTamGiuDto
{
    public int HoSoXuLyViPhamId { get; set; }

    public string Ten { get; set; }

    public int SoLuong { get; set; }

    public string TinhTrang { get; set; }

    public string? GhiChu { get; set; }
}
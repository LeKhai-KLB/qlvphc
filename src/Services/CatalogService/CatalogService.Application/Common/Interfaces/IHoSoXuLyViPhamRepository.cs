using CatalogService.Application.Parameters.HoSoXuLyViPhams;
using CatalogService.Domain.Entities;
using Contracts.Common.Interfaces;
using Shared.SeedWord;

namespace CatalogService.Application.Common.Interfaces;

public interface IHoSoXuLyViPhamRepository : IRepositoryBaseAsync<HoSoXuLyViPham, int>
{
    Task<PageList<HoSoXuLyViPham>> GetPagedHoSoXuLyViPhamAsync(HoSoXuLyViPhamParameter parameter);
    Task<HoSoXuLyViPham> GetHoSoXuLyViPhamById(int id);
    Task<int> CreateHoSoXuLyViPham(HoSoXuLyViPham request);
    Task UpdateHoSoXuLyViPham(HoSoXuLyViPham request);
    Task DeleteHoSoXuLyViPham(HoSoXuLyViPham entity);
    Task<bool> CheckExistHoSoXuLyViPham(int id);
}
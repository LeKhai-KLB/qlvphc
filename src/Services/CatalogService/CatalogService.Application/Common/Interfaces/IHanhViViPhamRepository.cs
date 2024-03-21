using CatalogService.Application.Parameters.HanhViViPhams;
using CatalogService.Domain.Entities;
using Contracts.Common.Interfaces;
using Shared.SeedWord;

namespace CatalogService.Application.Common.Interfaces;

public interface IHanhViViPhamRepository : IRepositoryBaseAsync<HanhViViPham, int>
{
    Task<PageList<HanhViViPham>> GetPagedHanhViViPham(HanhViViPhamParameter parameter);
    Task<IEnumerable<string?>> GetQDHVVPByHoSoXuLyViPhamId(int hsvpId);
    Task<HanhViViPham> GetHanhViViPhamById(int id);
    Task CreateHanhViViPham(HanhViViPham request);
    Task UpdateHanhViViPham(HanhViViPham request);
    Task DeleteHanhViViPham(HanhViViPham entity);
    Task<bool> CheckExistHanhViViPham(int id);
}
using CatalogService.Domain.Entities;
using Contracts.Common.Interfaces;

namespace CatalogService.Application.Common.Interfaces;

public interface IVanBanLienQuanRepository : IRepositoryBaseAsync<VanBanLienQuan, int>
{
    Task<IEnumerable<VanBanLienQuan>> GetVanBanLienQuanByVanBanPhapLuatId(int id);
    Task<VanBanLienQuan> GetVanBanLienQuanById(int id);
    Task CreateVanBanLienQuan(VanBanLienQuan request);
    Task UpdateVanBanLienQuan(VanBanLienQuan request);
    Task DeleteVanBanLienQuan(VanBanLienQuan entity);
    Task<bool> CheckExistVanBanLienQuan(string ten);
}
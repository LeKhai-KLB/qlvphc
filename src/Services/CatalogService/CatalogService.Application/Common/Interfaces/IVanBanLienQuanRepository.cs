using CatalogService.Application.Parameters.VanBanLienQuans;
using CatalogService.Domain.Entities;
using Contracts.Common.Interfaces;
using Shared.SeedWord;

namespace CatalogService.Application.Common.Interfaces;

public interface IVanBanLienQuanRepository : IRepositoryBaseAsync<VanBanLienQuan, int>
{
    Task<PageList<VanBanLienQuan>> GetPagedByVanBanPhapLuatId(VanBanLienQuanParameter parameter);
    Task<VanBanLienQuan> GetVanBanLienQuanById(int id);
    Task CreateVanBanLienQuan(VanBanLienQuan request);
    Task UpdateVanBanLienQuan(VanBanLienQuan request);
    Task DeleteVanBanLienQuan(VanBanLienQuan entity);
    Task<bool> CheckExistVanBanLienQuan(string ten);
}
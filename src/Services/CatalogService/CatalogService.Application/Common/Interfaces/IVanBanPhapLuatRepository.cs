using CatalogService.Application.Parameters.VanBanPhapLuats;
using CatalogService.Domain.Entities;
using Contracts.Common.Interfaces;
using Shared.SeedWord;

namespace CatalogService.Application.Common.Interfaces;

public interface IVanBanPhapLuatRepository : IRepositoryBaseAsync<VanBanPhapLuat, int>
{
    Task<IEnumerable<VanBanPhapLuat>> GetAllVanBanPhapLuat();
    Task<PageList<VanBanPhapLuat>> GetPagedVanBanPhapLuatAsync(VanBanPhapLuatParameter parameter);
    Task<VanBanPhapLuat> GetVanBanPhapLuatById(int id);
    Task CreateVanBanPhapLuat(VanBanPhapLuat request);
    Task UpdateVanBanPhapLuat(VanBanPhapLuat request);
    Task DeleteVanBanPhapLuat(VanBanPhapLuat entity);
    Task<bool> CheckExistVanBanPhapLuat(string soHieu);
}
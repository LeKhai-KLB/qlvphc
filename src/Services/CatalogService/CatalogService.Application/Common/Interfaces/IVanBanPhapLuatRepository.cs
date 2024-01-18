using CatalogService.Domain.Entities;
using Contracts.Common.Interfaces;

namespace CatalogService.Application.Common.Interfaces;

public interface IVanBanPhapLuatRepository : IRepositoryBaseAsync<VanBanPhapLuat, int>
{
    Task<IEnumerable<VanBanPhapLuat>> GetAllVanBanPhapLuat();
    Task<VanBanPhapLuat> GetVanBanPhapLuatById(int id);
    Task CreateVanBanPhapLuat(VanBanPhapLuat request);
    Task UpdateVanBanPhapLuat(VanBanPhapLuat request);
    Task DeleteVanBanPhapLuat(VanBanPhapLuat entity);
    Task<bool> CheckExistVanBanPhapLuat(string soHieu);
}
using CatalogService.Domain.Entities;
using Contracts.Common.Interfaces;

namespace CatalogService.Application.Common.Interfaces;

public interface ILoaiVanBanRepository : IRepositoryBaseAsync<LoaiVanBan, int>
{
    Task<IEnumerable<LoaiVanBan>> GetAllLoaiVanBan();
    Task<LoaiVanBan> GetLoaiVanBanById(int id);
    Task CreateLoaiVanBan(LoaiVanBan request);
    Task UpdateLoaiVanBan(LoaiVanBan request);
    Task DeleteLoaiVanBan(LoaiVanBan entity);
    Task<bool> CheckExistLoaiVanBan(string ten);
}
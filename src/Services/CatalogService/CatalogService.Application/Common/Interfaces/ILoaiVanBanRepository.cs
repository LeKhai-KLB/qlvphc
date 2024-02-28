using CatalogService.Application.Parameters.LoaiVanBans;
using CatalogService.Domain.Entities;
using Contracts.Common.Interfaces;
using Shared.SeedWord;

namespace CatalogService.Application.Common.Interfaces;

public interface ILoaiVanBanRepository : IRepositoryBaseAsync<LoaiVanBan, int>
{
    Task<IEnumerable<LoaiVanBan>> GetLoaiVanBansByTerm(string? term);
    Task<PageList<LoaiVanBan>> GetPagedLoaiVanBanAsync(LoaiVanBanParameter parameter);
    Task<LoaiVanBan> GetLoaiVanBanById(int id);
    Task CreateLoaiVanBan(LoaiVanBan request);
    Task UpdateLoaiVanBan(LoaiVanBan request);
    Task DeleteLoaiVanBan(LoaiVanBan entity);
    Task<bool> CheckExistLoaiVanBan(string ten);
}
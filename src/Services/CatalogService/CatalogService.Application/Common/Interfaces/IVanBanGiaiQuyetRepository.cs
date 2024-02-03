using CatalogService.Application.Parameters.VanBanGiaiQuyets;
using CatalogService.Domain.Entities;
using Contracts.Common.Interfaces;
using Shared.SeedWord;

namespace CatalogService.Application.Common.Interfaces;

public interface IVanBanGiaiQuyetRepository : IRepositoryBaseAsync<VanBanGiaiQuyet, int>
{
    Task<IEnumerable<VanBanGiaiQuyet>> GetVanBanGiaiQuyetByTerm(string? term);
    Task<PageList<VanBanGiaiQuyet>> GetPagedVanBanGiaiQuyetAsync(VanBanGiaiQuyetParameter parameter);
    Task<VanBanGiaiQuyet> GetVanBanGiaiQuyetById(int id);
    Task CreateVanBanGiaiQuyet(VanBanGiaiQuyet request);
    Task UpdateVanBanGiaiQuyet(VanBanGiaiQuyet request);
    Task DeleteVanBanGiaiQuyet(VanBanGiaiQuyet entity);
    Task<bool> CheckExistVanBanGiaiQuyet(string maGiayTo);
}
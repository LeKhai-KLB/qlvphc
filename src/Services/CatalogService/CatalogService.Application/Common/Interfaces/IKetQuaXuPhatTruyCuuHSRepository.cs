using CatalogService.Application.Parameters.KetQuaXuPhatTruyCuuHSs;
using CatalogService.Domain.Entities;
using Contracts.Common.Interfaces;
using Shared.SeedWord;

namespace CatalogService.Application.Common.Interfaces;

public interface IKetQuaXuPhatTruyCuuHSRepository : IRepositoryBaseAsync<KetQuaXuPhatTruyCuuHS, int>
{
    Task<IEnumerable<KetQuaXuPhatTruyCuuHS>> GetAllKetQuaXuPhatTruyCuuHSs();
    Task<PageList<KetQuaXuPhatTruyCuuHS>> GetPagedKetQuaXuPhatTruyCuuHSAsync(KetQuaXuPhatTruyCuuHSParameter parameter);
    Task<KetQuaXuPhatTruyCuuHS> GetKetQuaXuPhatTruyCuuHSById(int id);
    Task CreateKetQuaXuPhatTruyCuuHS(KetQuaXuPhatTruyCuuHS request);
    Task UpdateKetQuaXuPhatTruyCuuHS(KetQuaXuPhatTruyCuuHS request);
    Task DeleteKetQuaXuPhatTruyCuuHS(KetQuaXuPhatTruyCuuHS entity);
    Task<bool> CheckExistKetQuaXuPhatTruyCuuHS(int id);
}
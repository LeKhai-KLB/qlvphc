using CatalogService.Application.Parameters.KetQuaXuPhatHanhChinhs;
using CatalogService.Domain.Entities;
using Contracts.Common.Interfaces;
using Shared.SeedWord;

namespace CatalogService.Application.Common.Interfaces;

public interface IKetQuaXuPhatHanhChinhRepository : IRepositoryBaseAsync<KetQuaXuPhatHanhChinh, int>
{
    Task<IEnumerable<KetQuaXuPhatHanhChinh>> GetAllKetQuaXuPhatHanhChinhs();
    Task<PageList<KetQuaXuPhatHanhChinh>> GetPagedKetQuaXuPhatHanhChinhAsync(KetQuaXuPhatHanhChinhParameter parameter);
    Task<KetQuaXuPhatHanhChinh> GetKetQuaXuPhatHanhChinhById(int id);
    Task CreateKetQuaXuPhatHanhChinh(KetQuaXuPhatHanhChinh request);
    Task UpdateKetQuaXuPhatHanhChinh(KetQuaXuPhatHanhChinh request);
    Task DeleteKetQuaXuPhatHanhChinh(KetQuaXuPhatHanhChinh entity);
    Task<bool> CheckExistKetQuaXuPhatHanhChinh(int id);
}
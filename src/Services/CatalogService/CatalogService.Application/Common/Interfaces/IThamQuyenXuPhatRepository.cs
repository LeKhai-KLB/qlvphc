using CatalogService.Application.Parameters.ThamQuyenXuPhats;
using CatalogService.Domain.Entities;
using Contracts.Common.Interfaces;
using Shared.SeedWord;

namespace CatalogService.Application.Common.Interfaces;

public interface IThamQuyenXuPhatRepository : IRepositoryBaseAsync<ThamQuyenXuPhat, int>
{
    Task<IEnumerable<ThamQuyenXuPhat>> GetAllThamQuyenXuPhats();
    Task<PageList<ThamQuyenXuPhat>> GetPagedThamQuyenXuPhatAsync(ThamQuyenXuPhatParameter parameter);
    Task<ThamQuyenXuPhat> GetThamQuyenXuPhatById(int id);
    Task CreateThamQuyenXuPhat(ThamQuyenXuPhat request);
    Task UpdateThamQuyenXuPhat(ThamQuyenXuPhat request);
    Task DeleteThamQuyenXuPhat(ThamQuyenXuPhat entity);
}
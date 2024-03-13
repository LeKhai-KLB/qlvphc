using CatalogService.Application.Parameters.CoQuans;
using CatalogService.Domain.Entities;
using Contracts.Common.Interfaces;
using Shared.SeedWord;

namespace CatalogService.Application.Common.Interfaces;

public interface ICoQuanRepository : IRepositoryBaseAsync<CoQuan, int>
{
    Task<IEnumerable<CoQuan>> GetAllCoQuans();
    Task<PageList<CoQuan>> GetPagedCoQuanAsync(CoQuanParameter parameter);
    Task<CoQuan> GetCoQuanById(int id);
    Task CreateCoQuan(CoQuan request);
    Task UpdateCoQuan(CoQuan request);
    Task DeleteCoQuan(CoQuan entity);
    Task<bool> CheckExistCoQuan(int id);
}
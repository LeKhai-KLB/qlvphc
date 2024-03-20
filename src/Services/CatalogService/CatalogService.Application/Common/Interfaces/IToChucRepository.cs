using CatalogService.Application.Parameters.ToChucs;
using CatalogService.Domain.Entities;
using Contracts.Common.Interfaces;
using Shared.SeedWord;

namespace CatalogService.Application.Common.Interfaces;

public interface IToChucRepository : IRepositoryBaseAsync<ToChuc, int>
{
    Task<IEnumerable<ToChuc>> GetAllToChucs();
    Task<PageList<ToChuc>> GetPagedToChucAsync(ToChucParameter parameter);
    Task<ToChuc> GetToChucById(int id);
    Task CreateToChuc(ToChuc request);
    Task UpdateToChuc(ToChuc request);
    Task DeleteToChuc(ToChuc entity);
    Task<bool> CheckExistToChuc(int id);
}
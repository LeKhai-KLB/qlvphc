using CatalogService.Application.Parameters.CoQuanBanHanhs;
using CatalogService.Domain.Entities;
using Contracts.Common.Interfaces;
using Shared.SeedWord;

namespace CatalogService.Application.Common.Interfaces;

public interface ICoQuanBanHanhRepository : IRepositoryBaseAsync<CoQuanBanHanh, int>
{
    Task<IEnumerable<CoQuanBanHanh>> GetCoQuanBanHanhsByTerm(string? term);
    Task<PageList<CoQuanBanHanh>> GetPagedCoQuanBanHanhAsync(CoQuanBanHanhParameter parameter);
    Task<CoQuanBanHanh> GetCoQuanBanHanhById(int id);
    Task CreateCoQuanBanHanh(CoQuanBanHanh request);
    Task UpdateCoQuanBanHanh(CoQuanBanHanh request);
    Task DeleteCoQuanBanHanh(CoQuanBanHanh entity);
    Task<bool> CheckExistCoQuanBanHanh(int id);
}
using CatalogService.Domain.Entities;
using Contracts.Common.Interfaces;

namespace CatalogService.Application.Common.Interfaces;

public interface ICoQuanBanHanhRepository : IRepositoryBaseAsync<CoQuanBanHanh, int>
{
    Task<IEnumerable<CoQuanBanHanh>> GetAllCoQuanBanHanh();
    Task<CoQuanBanHanh> GetCoQuanBanHanhById(int id);
    Task CreateCoQuanBanHanh(CoQuanBanHanh request);
    Task UpdateCoQuanBanHanh(CoQuanBanHanh request);
    Task DeleteCoQuanBanHanh(CoQuanBanHanh entity);
    Task<bool> CheckExistCoQuanBanHanh(string ten);
}
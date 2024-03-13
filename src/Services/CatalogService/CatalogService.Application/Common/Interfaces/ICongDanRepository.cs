using CatalogService.Application.Parameters.CongDans;
using CatalogService.Domain.Entities;
using Contracts.Common.Interfaces;
using Shared.SeedWord;

namespace CatalogService.Application.Common.Interfaces;

public interface ICongDanRepository : IRepositoryBaseAsync<CongDan, int>
{
    Task<IEnumerable<CongDan>> GetAllCongDans();
    Task<PageList<CongDan>> GetPagedCongDanAsync(CongDanParameter parameter);
    Task<CongDan> GetCongDanById(int id);
    Task CreateCongDan(CongDan request);
    Task UpdateCongDan(CongDan request);
    Task DeleteCongDan(CongDan entity);
    Task<bool> CheckExistCongDan(int id);
}
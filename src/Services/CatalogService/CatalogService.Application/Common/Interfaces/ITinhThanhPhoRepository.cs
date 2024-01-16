using Contracts.Common.Interfaces;
using CatalogService.Application.Parameters.TinhThanhPhos;
using CatalogService.Domain.Entities;
using Shared.SeedWord;

namespace CatalogService.Application.Common.Interfaces
{
    public interface ITinhThanhPhoRepository : IRepositoryBaseAsync<TinhThanhPho, int>
    {
        Task<IEnumerable<TinhThanhPho>> GetTinhThanhPhosByTerm(string? term);
        Task<PageList<TinhThanhPho>> GetPagedTinhThanhPhoAsync(TinhThanhPhoParameter parameter);
        Task CreateTinhThanhPho(TinhThanhPho request);
        Task UpdateTinhThanhPho(TinhThanhPho request);
        Task DeleteTinhThanhPho(TinhThanhPho entity);
        Task<bool> CheckExistMaDinhDanhTinhThanhPho(string maDinhDanh);
    }
}

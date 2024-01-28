using Contracts.Common.Interfaces;
using CatalogService.Application.Parameters.DanhMucDinhDanhs;
using CatalogService.Domain.Entities;
using Shared.SeedWord;

namespace CatalogService.Application.Common.Interfaces
{
    public interface IDanhMucDinhDanhRepository : IRepositoryBaseAsync<DanhMucDinhDanh, int>
    {
        Task<IEnumerable<DanhMucDinhDanh>> GetDanhMucDinhDanhsByTerm(string? term);
        Task<PageList<DanhMucDinhDanh>> GetPagedDanhMucDinhDanhAsync(DanhMucDinhDanhParameter parameter);
        Task CreateDanhMucDinhDanh(DanhMucDinhDanh request);
        Task UpdateDanhMucDinhDanh(DanhMucDinhDanh request);
        Task DeleteDanhMucDinhDanh(DanhMucDinhDanh entity);
        Task<bool> CheckExistMaDinhDanhDanhMucDinhDanh(string maDinhDanh);
    }
}

using Contracts.Common.Interfaces;
using CatalogService.Domain.Entities;
using CatalogService.Application.Parameters.QuanHuyens;
using Shared.SeedWord;

namespace CatalogService.Application.Common.Interfaces
{
    public interface IQuanHuyenRepository : IRepositoryBaseAsync<QuanHuyen, int>
    {
        Task<PageList<QuanHuyen>> GetPagedQuanHuyenAsync(QuanHuyenParameter parameter);
        Task<IEnumerable<QuanHuyen>> GetQuanHuyenByTinhThanhPhoId(int id);
        Task CreateQuanHuyen(QuanHuyen request);
        Task UpdateQuanHuyen(QuanHuyen request);
        Task DeleteQuanHuyen(QuanHuyen entity);
        Task<bool> CheckExistMaDinhDanhQuanHuyen(string maDinhDanh);
    }
}

using Contracts.Common.Interfaces;
using CatalogService.Domain.Entities;

namespace CatalogService.Application.Common.Interfaces
{
    public interface IQuanHuyenRepository : IRepositoryBaseAsync<QuanHuyen, int>
    {
        Task<IEnumerable<QuanHuyen>> GetQuanHuyenByTinhThanhPhoId(int id);
        Task CreateQuanHuyen(QuanHuyen request);
        Task UpdateQuanHuyen(QuanHuyen request);
        Task DeleteQuanHuyen(QuanHuyen entity);
        Task<bool> CheckExistMaDinhDanhQuanHuyen(string maDinhDanh);
    }
}

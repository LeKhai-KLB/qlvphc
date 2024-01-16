using Contracts.Common.Interfaces;
using CatalogService.Domain.Entities;

namespace CatalogService.Application.Common.Interfaces
{
    public interface IXaPhuongRepository : IRepositoryBaseAsync<XaPhuong, int>
    {
        Task<IEnumerable<XaPhuong>> GetXaPhuongByQuanHuyenId(int id);
        Task CreateXaPhuong(XaPhuong request);
        Task UpdateXaPhuong(XaPhuong request);
        Task DeleteXaPhuong(XaPhuong entity);
        Task<bool> CheckExistMaDinhDanhXaPhuong(string maDinhDanh);
    }
}

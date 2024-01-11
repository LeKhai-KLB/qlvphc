using Contracts.Common.Interfaces;
using DanhMucService.Domain.Entities;

namespace DanhMucService.Application.Common.Interfaces
{
    public interface IQuanHuyenRepository : IRepositoryBaseAsync<QuanHuyen, int>
    {
        Task<IEnumerable<QuanHuyen>> GetQuanHuyen();
        Task CreateQuanHuyen(QuanHuyen request);
        Task UpdateQuanHuyen(QuanHuyen request);
        Task DeleteQuanHuyen(QuanHuyen entity);
    }
}

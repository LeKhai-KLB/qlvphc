using Contracts.Common.Interfaces;
using CatalogService.Application.Parameters.QuyetDinhXuPhats;
using CatalogService.Domain.Entities;
using Shared.SeedWord;

namespace CatalogService.Application.Common.Interfaces
{
    public interface IQuyetDinhXuPhatRepository : IRepositoryBaseAsync<QuyetDinhXuPhat, int>
    {
        Task<IEnumerable<QuyetDinhXuPhat>> GetQuyetDinhXuPhatByHoSoXuLyViPhamId(int id);
        Task<PageList<QuyetDinhXuPhat>> GetPagedQuyetDinhXuPhatAsync(QuyetDinhXuPhatParameter parameter);
        Task CreateQuyetDinhXuPhat(QuyetDinhXuPhat request);
        Task UpdateQuyetDinhXuPhat(QuyetDinhXuPhat request);
        Task DeleteQuyetDinhXuPhat(QuyetDinhXuPhat entity);
    }
}

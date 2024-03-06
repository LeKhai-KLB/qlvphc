using Contracts.Common.Interfaces;
using CatalogService.Domain.Entities;

namespace CatalogService.Application.Common.Interfaces
{
    public interface IHinhThucXuPhatChinhRepository : IRepositoryBaseAsync<HinhThucXuPhatChinh, int>
    {
        Task<IEnumerable<HinhThucXuPhatChinh>> GetAllHinhThucXuPhatChinhs();
        Task CreateHinhThucXuPhatChinh(HinhThucXuPhatChinh request);
        Task UpdateHinhThucXuPhatChinh(HinhThucXuPhatChinh request);
        Task DeleteHinhThucXuPhatChinh(HinhThucXuPhatChinh entity);
    }
}

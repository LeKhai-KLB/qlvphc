using Contracts.Common.Interfaces;
using CatalogService.Domain.Entities;

namespace CatalogService.Application.Common.Interfaces
{
    public interface IHinhThucXuPhatBoSungRepository : IRepositoryBaseAsync<HinhThucXuPhatBoSung, int>
    {
        Task<IEnumerable<HinhThucXuPhatBoSung>> GetAllHinhThucXuPhatBoSungs();
        Task CreateHinhThucXuPhatBoSung(HinhThucXuPhatBoSung request);
        Task UpdateHinhThucXuPhatBoSung(HinhThucXuPhatBoSung request);
        Task DeleteHinhThucXuPhatBoSung(HinhThucXuPhatBoSung entity);
    }
}

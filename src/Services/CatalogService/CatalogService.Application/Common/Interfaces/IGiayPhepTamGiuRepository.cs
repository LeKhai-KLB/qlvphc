using Contracts.Common.Interfaces;
using CatalogService.Domain.Entities;
using CatalogService.Application.Parameters.GiayPhepTamGius;
using Shared.SeedWord;

namespace CatalogService.Application.Common.Interfaces
{
    public interface IGiayPhepTamGiuRepository : IRepositoryBaseAsync<GiayPhepTamGiu, int>
    {

        Task<PageList<GiayPhepTamGiu>> GetPagedGiayPhepTamGiuAsync(GiayPhepTamGiuParameter parameter);
        Task<IEnumerable<GiayPhepTamGiu>> GetGiayPhepTamGiuByHoSoXuLyViPhamId(int id);
        Task CreateGiayPhepTamGiu(GiayPhepTamGiu request);
        Task UpdateGiayPhepTamGiu(GiayPhepTamGiu request);
        Task DeleteGiayPhepTamGiu(GiayPhepTamGiu entity);
    }
}

using Contracts.Common.Interfaces;
using CatalogService.Domain.Entities;
using CatalogService.Application.Parameters.TangVatPhuongTienTamGius;
using Shared.SeedWord;

namespace CatalogService.Application.Common.Interfaces
{
    public interface ITangVatPhuongTienTamGiuRepository : IRepositoryBaseAsync<TangVatPhuongTienTamGiu, int>
    {

        Task<PageList<TangVatPhuongTienTamGiu>> GetPagedTangVatPhuongTienTamGiuAsync(TangVatPhuongTienTamGiuParameter parameter);
        Task<IEnumerable<TangVatPhuongTienTamGiu>> GetTangVatPhuongTienTamGiuByHoSoXuLyViPhamId(int id);
        Task CreateTangVatPhuongTienTamGiu(TangVatPhuongTienTamGiu request);
        Task UpdateTangVatPhuongTienTamGiu(TangVatPhuongTienTamGiu request);
        Task DeleteTangVatPhuongTienTamGiu(TangVatPhuongTienTamGiu entity);
    }
}

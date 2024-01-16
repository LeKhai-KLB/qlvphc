using CatalogService.Domain.Entities;
using Contracts.Common.Interfaces;

namespace CatalogService.Application.Common.Interfaces;

public interface IChiTietLinhVucXuPhatRepository : IRepositoryBaseAsync<ChiTietLinhVucXuPhat, int>
{
    Task<IEnumerable<ChiTietLinhVucXuPhat>> GetChiTietByLinhVucXuPhatId(int id);
    Task<ChiTietLinhVucXuPhat> GetChiTietLinhVucXuPhatById(int id);
    Task CreateChiTietLinhVucXuPhat(ChiTietLinhVucXuPhat request);
    Task UpdateChiTietLinhVucXuPhat(ChiTietLinhVucXuPhat request);
    Task DeleteChiTietLinhVucXuPhat(ChiTietLinhVucXuPhat entity);
    Task<bool> CheckExistChiTietLinhVucXuPhat(int id);
}
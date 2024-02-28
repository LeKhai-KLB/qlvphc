using CatalogService.Application.Parameters.ChiTietLinhVucXuPhats;
using CatalogService.Domain.Entities;
using Contracts.Common.Interfaces;
using Shared.SeedWord;

namespace CatalogService.Application.Common.Interfaces;

public interface IChiTietLinhVucXuPhatRepository : IRepositoryBaseAsync<ChiTietLinhVucXuPhat, int>
{
    Task<IEnumerable<ChiTietLinhVucXuPhat>> GetChiTietLinhVucXuPhatsByTerm(int linhVucXuPhatId, string? term);
    Task<PageList<ChiTietLinhVucXuPhat>> GetPagedByLinhVucXuPhatId(ChiTietLinhVucXuPhatParameter parameter);
    Task<ChiTietLinhVucXuPhat> GetChiTietLinhVucXuPhatById(int id);
    Task CreateChiTietLinhVucXuPhat(ChiTietLinhVucXuPhat request);
    Task UpdateChiTietLinhVucXuPhat(ChiTietLinhVucXuPhat request);
    Task DeleteChiTietLinhVucXuPhat(ChiTietLinhVucXuPhat entity);
    Task<bool> CheckExistChiTietLinhVucXuPhat(int id);
}
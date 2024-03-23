using CatalogService.Application.Parameters.KhoBacs;
using CatalogService.Domain.Entities;
using Contracts.Common.Interfaces;
using Shared.SeedWord;

namespace CatalogService.Application.Common.Interfaces;

public interface IKhoBacRepository : IRepositoryBaseAsync<KhoBac, int>
{
    Task<IEnumerable<KhoBac>> GetAllKhoBacs();
    Task<PageList<KhoBac>> GetPagedKhoBacAsync(KhoBacParameter parameter);
    Task<KhoBac> GetKhoBacById(int id);
    Task CreateKhoBac(KhoBac request);
    Task UpdateKhoBac(KhoBac request);
    Task DeleteKhoBac(KhoBac entity);
    Task<bool> CheckExistKhoBac(int id);
}
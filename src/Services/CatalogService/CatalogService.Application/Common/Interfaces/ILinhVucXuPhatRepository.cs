using CatalogService.Application.Parameters.LinhVucXuPhats;
using CatalogService.Domain.Entities;
using Contracts.Common.Interfaces;
using Shared.SeedWord;

namespace CatalogService.Application.Common.Interfaces;

public interface ILinhVucXuPhatRepository : IRepositoryBaseAsync<LinhVucXuPhat, int>
{
    Task<PageList<LinhVucXuPhat>> GetPagedLinhVucXuPhatAsync(LinhVucXuPhatParameter parameter);
    Task<LinhVucXuPhat> GetLinhVucXuPhatById(int id);
    Task CreateLinhVucXuPhat(LinhVucXuPhat request);
    Task UpdateLinhVucXuPhat(LinhVucXuPhat request);
    Task DeleteLinhVucXuPhat(LinhVucXuPhat entity);
    Task<bool> CheckExistLinhVucXuPhat(string ten, string nhom);
    Task<bool> CheckExistLinhVucXuPhat(int id);
}
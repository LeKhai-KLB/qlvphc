using CatalogService.Domain.Entities;
using Contracts.Common.Interfaces;

namespace CatalogService.Application.Common.Interfaces;

public interface ILinhVucXuPhatRepository : IRepositoryBaseAsync<LinhVucXuPhat, int>
{
    Task<LinhVucXuPhat> GetLinhVucXuPhatById(int id);
    Task CreateLinhVucXuPhat(LinhVucXuPhat request);
    Task UpdateLinhVucXuPhat(LinhVucXuPhat request);
    Task DeleteLinhVucXuPhat(LinhVucXuPhat entity);
    Task<bool> CheckExistLinhVucXuPhat(string ten, string nhom);
    Task<bool> CheckExistLinhVucXuPhat(int id);
}
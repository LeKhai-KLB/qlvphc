using CatalogService.Application.Parameters.DieuKhoanXuPhats;
using CatalogService.Domain.Entities;
using Contracts.Common.Interfaces;
using Shared.SeedWord;

namespace CatalogService.Application.Common.Interfaces;

public interface IDieuKhoanXuPhatRepository : IRepositoryBaseAsync<DieuKhoanXuPhat, int>
{
    Task<IEnumerable<DieuKhoanXuPhat>> GetAllDieuKhoanXuPhats();
    Task<PageList<DieuKhoanXuPhat>> GetPagedDieuKhoanXuPhatAsync(DieuKhoanXuPhatParameter parameter);
    Task<DieuKhoanXuPhat> GetDieuKhoanXuPhatById(int id);
    Task CreateDieuKhoanXuPhat(DieuKhoanXuPhat request);
    Task UpdateDieuKhoanXuPhat(DieuKhoanXuPhat request);
    Task DeleteDieuKhoanXuPhat(DieuKhoanXuPhat entity);
}
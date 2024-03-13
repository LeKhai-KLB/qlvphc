using CatalogService.Application.Parameters.DieuKhoanBoSungKhacPhucs;
using CatalogService.Domain.Entities;
using Contracts.Common.Interfaces;
using Shared.SeedWord;

namespace CatalogService.Application.Common.Interfaces;

public interface IDieuKhoanBoSungKhacPhucRepository : IRepositoryBaseAsync<DieuKhoanBoSungKhacPhuc, int>
{
    Task<IEnumerable<DieuKhoanBoSungKhacPhuc>> GetAllDieuKhoanBoSungKhacPhucs(DieuKhoanBoSungKhacPhucDropDownParameter parameter);
    Task<PageList<DieuKhoanBoSungKhacPhuc>> GetPagedDieuKhoanBoSungKhacPhucAsync(DieuKhoanBoSungKhacPhucParameter parameter);
    Task<DieuKhoanBoSungKhacPhuc> GetDieuKhoanBoSungKhacPhucById(int id);
    Task CreateDieuKhoanBoSungKhacPhuc(DieuKhoanBoSungKhacPhuc request);
    Task UpdateDieuKhoanBoSungKhacPhuc(DieuKhoanBoSungKhacPhuc request);
    Task DeleteDieuKhoanBoSungKhacPhuc(DieuKhoanBoSungKhacPhuc entity);
    Task<bool> CheckExistDieuKhoanBoSungKhacPhuc(int id);
}
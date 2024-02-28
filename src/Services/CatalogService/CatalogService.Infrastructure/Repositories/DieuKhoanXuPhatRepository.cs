using Contracts.Common.Interfaces;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Domain.Entities;
using CatalogService.Infrastructure.Persistence;
using Infrastructure.Common;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Shared.SeedWord;
using CatalogService.Application.Parameters.DieuKhoanXuPhats;

namespace CatalogService.Infrastructure.Repositories;

public class DieuKhoanXuPhatRepository : RepositoryBase<DieuKhoanXuPhat, int, CatalogServiceContext>, IDieuKhoanXuPhatRepository
{
    private readonly DbSet<DieuKhoanXuPhat> _dieuKhoanXuPhat;
    public DieuKhoanXuPhatRepository(CatalogServiceContext context, IUnitOfWork<CatalogServiceContext> unitOfWork) : base(context, unitOfWork)
    {
        _dieuKhoanXuPhat = context.Set<DieuKhoanXuPhat>();
    }

    public async Task<PageList<DieuKhoanXuPhat>> GetPagedDieuKhoanXuPhatAsync(DieuKhoanXuPhatParameter parameter)
    {
        var result = _dieuKhoanXuPhat.Filter(parameter)
            .Include(x => x.LinhVucXuPhat)
            .OrderBy(x => x.Id);

        return await PageList<DieuKhoanXuPhat>.ToPageList(result, parameter.PageNumber, parameter.PageSize);
    }

    public async Task<IEnumerable<DieuKhoanXuPhat>> GetDieuKhoanXuPhatsByTerm(string? term)
    {
        return await FindByCondition(x => x.IsDeleted == false
                && string.IsNullOrEmpty(term)
                || x.Dieu.Contains(term)
                || x.Khoan.Contains(term)
                || x.Diem.Contains(term))
            .Include(x => x.LinhVucXuPhat)
            .ToListAsync();
    }

    public async Task<DieuKhoanXuPhat> GetDieuKhoanXuPhatById(int id)
    {
        return await GetByIdAsync(id);
    }

    public async Task CreateDieuKhoanXuPhat(DieuKhoanXuPhat request)
    {
        await CreateAsync(request);
    }

    public async Task UpdateDieuKhoanXuPhat(DieuKhoanXuPhat request)
    {
        await UpdateAsync(request);
    }

    public async Task DeleteDieuKhoanXuPhat(DieuKhoanXuPhat entity)
    {
        await DeleteAsync(entity);
    }
}
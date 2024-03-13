using Contracts.Common.Interfaces;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Domain.Entities;
using CatalogService.Infrastructure.Persistence;
using Infrastructure.Common;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Shared.SeedWord;
using CatalogService.Application.Parameters.DieuKhoanBoSungKhacPhucs;

namespace CatalogService.Infrastructure.Repositories;

public class DieuKhoanBoSungKhacPhucRepository : RepositoryBase<DieuKhoanBoSungKhacPhuc, int, CatalogServiceContext>, IDieuKhoanBoSungKhacPhucRepository
{
    private readonly DbSet<DieuKhoanBoSungKhacPhuc> _dieuKhoanBoSungKhacPhuc;

    public DieuKhoanBoSungKhacPhucRepository(CatalogServiceContext context, IUnitOfWork<CatalogServiceContext> unitOfWork) : base(context, unitOfWork)
    {
        _dieuKhoanBoSungKhacPhuc = context.Set<DieuKhoanBoSungKhacPhuc>();
    }

    public async Task<IEnumerable<DieuKhoanBoSungKhacPhuc>> GetAllDieuKhoanBoSungKhacPhucs(DieuKhoanBoSungKhacPhucDropDownParameter parameter)
    {
        return await _dieuKhoanBoSungKhacPhuc.Filter(parameter).ToListAsync();
    }

    public async Task<PageList<DieuKhoanBoSungKhacPhuc>> GetPagedDieuKhoanBoSungKhacPhucAsync(DieuKhoanBoSungKhacPhucParameter parameter)
    {
        var query = _dieuKhoanBoSungKhacPhuc.Filter(parameter);

        if (!string.IsNullOrEmpty(parameter.OrderBy))
        {
            query = query.OrderBy(parameter.OrderBy);
        }

        if (!string.IsNullOrEmpty(parameter.SearchTerm))
        {
            query = query
                .Where(x => x.IsDeleted == false
                    && (string.IsNullOrEmpty(parameter.SearchTerm)
                    || x.Dieu.Contains(parameter.SearchTerm)
                    || x.Khoan.Contains(parameter.SearchTerm)
                    || x.Diem.Contains(parameter.SearchTerm)));
        }

        query = query.Include(x => x.DieuKhoanXuPhat);

        return await PageList<DieuKhoanBoSungKhacPhuc>.ToPageList(query, parameter.PageNumber, parameter.PageSize);
    }

    public async Task<DieuKhoanBoSungKhacPhuc> GetDieuKhoanBoSungKhacPhucById(int id)
    {
        return await GetByIdAsync(id);
    }

    public async Task CreateDieuKhoanBoSungKhacPhuc(DieuKhoanBoSungKhacPhuc request)
    {
        await CreateAsync(request);
    }

    public async Task UpdateDieuKhoanBoSungKhacPhuc(DieuKhoanBoSungKhacPhuc request)
    {
        await UpdateAsync(request);
    }

    public async Task DeleteDieuKhoanBoSungKhacPhuc(DieuKhoanBoSungKhacPhuc entity)
    {
        await DeleteAsync(entity);
    }

    public async Task<bool> CheckExistDieuKhoanBoSungKhacPhuc(int id)
    {
        var dks = await FindByCondition(x => x.Id.Equals(id)).ToListAsync();
        return dks != null && dks.Any();
    }
}
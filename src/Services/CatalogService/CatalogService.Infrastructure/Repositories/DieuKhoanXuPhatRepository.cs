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
        var query = _dieuKhoanXuPhat.Filter(parameter);

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

        query = query.Include(x => x.LinhVucXuPhat);

        return await PageList<DieuKhoanXuPhat>.ToPageList(query, parameter.PageNumber, parameter.PageSize);
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
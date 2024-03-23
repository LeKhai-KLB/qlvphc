using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Parameters.KhoBacs;
using CatalogService.Domain.Entities;
using CatalogService.Infrastructure.Persistence;
using Contracts.Common.Interfaces;
using Infrastructure.Common;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Shared.SeedWord;

namespace CatalogService.Infrastructure.Repositories;

public class KhoBacRepository : RepositoryBase<KhoBac, int, CatalogServiceContext>, IKhoBacRepository
{
    private readonly DbSet<KhoBac> _KhoBac;

    public KhoBacRepository(CatalogServiceContext context, IUnitOfWork<CatalogServiceContext> unitOfWork) : base(context, unitOfWork)
    {
        _KhoBac = context.Set<KhoBac>();
    }

    public async Task<IEnumerable<KhoBac>> GetAllKhoBacs()
    {
        return await FindAll().ToListAsync();
    }

    public async Task<PageList<KhoBac>> GetPagedKhoBacAsync(KhoBacParameter parameter)
    {
        var query = _KhoBac.Filter(parameter);

        if (!string.IsNullOrEmpty(parameter.OrderBy))
        {
            query = query.OrderBy(parameter.OrderBy);
        }

        if (!string.IsNullOrEmpty(parameter.SearchTerm))
        {
            query = query.Where(x => string.IsNullOrEmpty(parameter.SearchTerm)
                || x.TenKhoBac.Contains(parameter.SearchTerm)
                || x.TaiKhoan.Contains(parameter.SearchTerm)
                || x.DiaChi.Contains(parameter.SearchTerm)
                || x.DiaDiemGiaoDich.Contains(parameter.SearchTerm)
                || x.TenCoQuan.Contains(parameter.SearchTerm));
        }

        return await PageList<KhoBac>.ToPageList(query, parameter.PageNumber, parameter.PageSize);
    }

    public async Task<KhoBac> GetKhoBacById(int id)
    {
        return await GetByIdAsync(id);
    }

    public async Task CreateKhoBac(KhoBac request)
    {
        await CreateAsync(request);
    }

    public async Task UpdateKhoBac(KhoBac request)
    {
        await UpdateAsync(request);
    }

    public async Task DeleteKhoBac(KhoBac entity)
    {
        await DeleteAsync(entity);
    }

    public async Task<bool> CheckExistKhoBac(int id)
    {
        var KhoBacs = await FindByCondition(x => x.Id.Equals(id)).ToListAsync();
        return KhoBacs != null && KhoBacs.Any();
    }
}
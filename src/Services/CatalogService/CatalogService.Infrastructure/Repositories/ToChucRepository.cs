using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Parameters.ToChucs;
using CatalogService.Domain.Entities;
using CatalogService.Infrastructure.Persistence;
using Contracts.Common.Interfaces;
using Infrastructure.Common;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Shared.SeedWord;

namespace CatalogService.Infrastructure.Repositories;

public class ToChucRepository : RepositoryBase<ToChuc, int, CatalogServiceContext>, IToChucRepository
{
    private readonly DbSet<ToChuc> _ToChuc;

    public ToChucRepository(CatalogServiceContext context, IUnitOfWork<CatalogServiceContext> unitOfWork) : base(context, unitOfWork)
    {
        _ToChuc = context.Set<ToChuc>();
    }

    public async Task<IEnumerable<ToChuc>> GetAllToChucs()
    {
        return await FindAll().ToListAsync();
    }

    public async Task<PageList<ToChuc>> GetPagedToChucAsync(ToChucParameter parameter)
    {
        var query = _ToChuc.Filter(parameter);

        if (!string.IsNullOrEmpty(parameter.OrderBy))
        {
            query = query.OrderBy(parameter.OrderBy);
        }

        if (!string.IsNullOrEmpty(parameter.SearchTerm))
        {
            query = query.Where(x => string.IsNullOrEmpty(parameter.SearchTerm)
                || x.TenNguoiDaiDien.Contains(parameter.SearchTerm)
                || x.TenTC.Contains(parameter.SearchTerm)
                || x.DiaChi.Contains(parameter.SearchTerm)
                || x.MaSo.Contains(parameter.SearchTerm)
                || x.DiaChi.Contains(parameter.SearchTerm)
                || x.SoChungNhan.Contains(parameter.SearchTerm)
                || x.GiayPhepSo.Contains(parameter.SearchTerm)
                || x.NoiCap.Contains(parameter.SearchTerm)
                || x.ChucDanh.Contains(parameter.SearchTerm));
        }

        return await PageList<ToChuc>.ToPageList(query, parameter.PageNumber, parameter.PageSize);
    }

    public async Task<ToChuc> GetToChucById(int id)
    {
        return await GetByIdAsync(id);
    }

    public async Task CreateToChuc(ToChuc request)
    {
        await CreateAsync(request);
    }

    public async Task UpdateToChuc(ToChuc request)
    {
        await UpdateAsync(request);
    }

    public async Task DeleteToChuc(ToChuc entity)
    {
        await DeleteAsync(entity);
    }

    public async Task<bool> CheckExistToChuc(int id)
    {
        var ToChucs = await FindByCondition(x => x.Id.Equals(id)).ToListAsync();
        return ToChucs != null && ToChucs.Any();
    }
}
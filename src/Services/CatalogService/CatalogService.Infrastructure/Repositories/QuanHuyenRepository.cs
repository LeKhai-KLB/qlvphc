using Contracts.Common.Interfaces;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Domain.Entities;
using CatalogService.Infrastructure.Persistence;
using Infrastructure.Common;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Shared.SeedWord;
using CatalogService.Application.Parameters.QuanHuyens;

namespace CatalogService.Infrastructure.Repositories;

public class QuanHuyenRepository : RepositoryBase<QuanHuyen, int, CatalogServiceContext>, IQuanHuyenRepository
{
    private readonly DbSet<QuanHuyen> _quanHuyen;
    public QuanHuyenRepository(CatalogServiceContext context, IUnitOfWork<CatalogServiceContext> unitOfWork) : base(context, unitOfWork)
    {
        _quanHuyen = context.Set<QuanHuyen>();
    }

    public async Task<PageList<QuanHuyen>> GetPagedQuanHuyenAsync(QuanHuyenParameter parameter)
    {
        var result = _quanHuyen.Filter(parameter)
            .Include(x => x.TinhThanhPho)
            .OrderBy(x => x.Ten);

        return await PageList<QuanHuyen>.ToPageList(result, parameter.PageNumber, parameter.PageSize);
    }

    public async Task<IEnumerable<QuanHuyen>> GetQuanHuyenByTinhThanhPhoId(int id)
    {
        var result = FindByCondition(x => x.TinhThanhPhoId.Equals(id)).OrderBy(x => x.Ten);

        return result;
    }

    public async Task CreateQuanHuyen(QuanHuyen request)
    {
        await CreateAsync(request);
    }

    public async Task UpdateQuanHuyen(QuanHuyen request)
    {
        await UpdateAsync(request);
    }

    public async Task DeleteQuanHuyen(QuanHuyen entity)
    {
        await DeleteAsync(entity);
    }

    public async Task<bool> CheckExistMaDinhDanhQuanHuyen(string maDinhDanh)
    {
        var quanHuyen = await FindByCondition(x => x.MaDinhDanh.Equals(maDinhDanh)).ToListAsync();
        return quanHuyen != null && quanHuyen.Any();
    }
}
using Contracts.Common.Interfaces;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Domain.Entities;
using CatalogService.Infrastructure.Persistence;
using Infrastructure.Common;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.Infrastructure.Repositories;

public class QuanHuyenRepository : RepositoryBase<QuanHuyen, int, CatalogServiceContext>, IQuanHuyenRepository
{
    public QuanHuyenRepository(CatalogServiceContext context, IUnitOfWork<CatalogServiceContext> unitOfWork) : base(context, unitOfWork)
    {
        
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
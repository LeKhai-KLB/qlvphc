using CatalogService.Application.Common.Interfaces;
using CatalogService.Domain.Entities;
using CatalogService.Infrastructure.Persistence;
using Contracts.Common.Interfaces;
using Infrastructure.Common;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.Infrastructure.Repositories;

public class LinhVucXuPhatRepository : RepositoryBase<LinhVucXuPhat, int, CatalogServiceContext>, ILinhVucXuPhatRepository
{
    public LinhVucXuPhatRepository(CatalogServiceContext context, IUnitOfWork<CatalogServiceContext> unitOfWork) : base(context, unitOfWork)
    {

    }

    public async Task<LinhVucXuPhat> GetLinhVucXuPhatById(int id)
    {
        return await GetByIdAsync(id);
    }

    public async Task CreateLinhVucXuPhat(LinhVucXuPhat request)
    {
        await CreateAsync(request);
    }

    public async Task UpdateLinhVucXuPhat(LinhVucXuPhat request)
    {
        await UpdateAsync(request);
    }

    public async Task DeleteLinhVucXuPhat(LinhVucXuPhat entity)
    {
        await DeleteAsync(entity);
    }

    public async Task<bool> CheckExistLinhVucXuPhat(string ten, string nhom)
    {
        var linhvuc = await FindByCondition(x => x.TenLinhVuc.Equals(ten) && x.NhomLinhVuc.Equals(nhom)).ToListAsync();
        return linhvuc != null && linhvuc.Any();
    }

    public async Task<bool> CheckExistLinhVucXuPhat(int id)
    {
        var linhvuc = await FindByCondition(x => x.Id.Equals(id)).ToListAsync();
        return linhvuc != null && linhvuc.Any();
    }
}
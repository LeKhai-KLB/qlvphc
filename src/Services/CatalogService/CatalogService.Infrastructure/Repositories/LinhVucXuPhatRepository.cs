using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Parameters.LinhVucXuPhats;
using CatalogService.Domain.Entities;
using CatalogService.Infrastructure.Persistence;
using Contracts.Common.Interfaces;
using Infrastructure.Common;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Shared.SeedWord;

namespace CatalogService.Infrastructure.Repositories;

public class LinhVucXuPhatRepository : RepositoryBase<LinhVucXuPhat, int, CatalogServiceContext>, ILinhVucXuPhatRepository
{
    private readonly DbSet<LinhVucXuPhat> _linhVucXuPhat;

    public LinhVucXuPhatRepository(CatalogServiceContext context, IUnitOfWork<CatalogServiceContext> unitOfWork) : base(context, unitOfWork)
    {
        _linhVucXuPhat = context.Set<LinhVucXuPhat>();
    }

    public async Task<IEnumerable<LinhVucXuPhat>> GetAllLinhVucXuPhat()
    {
        return await FindAll().ToListAsync();
    }

    public async Task<PageList<LinhVucXuPhat>> GetPagedLinhVucXuPhatAsync(LinhVucXuPhatParameter parameter)
    {
        var result = _linhVucXuPhat.Filter(parameter).OrderBy(x => x.Id);

        return await PageList<LinhVucXuPhat>.ToPageList(result, parameter.PageNumber, parameter.PageSize);
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
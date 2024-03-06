using Contracts.Common.Interfaces;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Domain.Entities;
using CatalogService.Infrastructure.Persistence;
using Infrastructure.Common;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Shared.SeedWord;
using CatalogService.Application.Parameters.GiayPhepTamGius;

namespace CatalogService.Infrastructure.Repositories;

public class GiayPhepTamGiuRepository : RepositoryBase<GiayPhepTamGiu, int, CatalogServiceContext>, IGiayPhepTamGiuRepository
{
    private readonly DbSet<GiayPhepTamGiu> _GiayPhepTamGiu;
    public GiayPhepTamGiuRepository(CatalogServiceContext context, IUnitOfWork<CatalogServiceContext> unitOfWork) : base(context, unitOfWork)
    {
        _GiayPhepTamGiu = context.Set<GiayPhepTamGiu>();
    }

    public async Task<PageList<GiayPhepTamGiu>> GetPagedGiayPhepTamGiuAsync(GiayPhepTamGiuParameter parameter)
    {
        var result = _GiayPhepTamGiu.Filter(parameter)
            .OrderBy(x => x.Ten);

        return await PageList<GiayPhepTamGiu>.ToPageList(result, parameter.PageNumber, parameter.PageSize);
    }

    public async Task<IEnumerable<GiayPhepTamGiu>> GetGiayPhepTamGiuByHoSoXuLyViPhamId(int id)
    {
        var result = FindByCondition(x => x.HoSoXuLyViPhamId.Equals(id)).OrderBy(x => x.Ten);

        return result;
    }

    public async Task CreateGiayPhepTamGiu(GiayPhepTamGiu request)
    {
        await CreateAsync(request);
    }

    public async Task UpdateGiayPhepTamGiu(GiayPhepTamGiu request)
    {
        await UpdateAsync(request);
    }

    public async Task DeleteGiayPhepTamGiu(GiayPhepTamGiu entity)
    {
        await DeleteAsync(entity);
    }
}
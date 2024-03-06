using Contracts.Common.Interfaces;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Domain.Entities;
using CatalogService.Infrastructure.Persistence;
using Infrastructure.Common;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Shared.SeedWord;
using CatalogService.Application.Parameters.TangVatPhuongTienTamGius;

namespace CatalogService.Infrastructure.Repositories;

public class TangVatPhuongTienTamGiuRepository : RepositoryBase<TangVatPhuongTienTamGiu, int, CatalogServiceContext>, ITangVatPhuongTienTamGiuRepository
{
    private readonly DbSet<TangVatPhuongTienTamGiu> _TangVatPhuongTienTamGiu;
    public TangVatPhuongTienTamGiuRepository(CatalogServiceContext context, IUnitOfWork<CatalogServiceContext> unitOfWork) : base(context, unitOfWork)
    {
        _TangVatPhuongTienTamGiu = context.Set<TangVatPhuongTienTamGiu>();
    }

    public async Task<PageList<TangVatPhuongTienTamGiu>> GetPagedTangVatPhuongTienTamGiuAsync(TangVatPhuongTienTamGiuParameter parameter)
    {
        var result = _TangVatPhuongTienTamGiu.Filter(parameter)
            .OrderBy(x => x.Ten);

        return await PageList<TangVatPhuongTienTamGiu>.ToPageList(result, parameter.PageNumber, parameter.PageSize);
    }

    public async Task<IEnumerable<TangVatPhuongTienTamGiu>> GetTangVatPhuongTienTamGiuByHoSoXuLyViPhamId(int id)
    {
        var result = FindByCondition(x => x.HoSoXuLyViPhamId.Equals(id)).OrderBy(x => x.Ten);

        return result;
    }

    public async Task CreateTangVatPhuongTienTamGiu(TangVatPhuongTienTamGiu request)
    {
        await CreateAsync(request);
    }

    public async Task UpdateTangVatPhuongTienTamGiu(TangVatPhuongTienTamGiu request)
    {
        await UpdateAsync(request);
    }

    public async Task DeleteTangVatPhuongTienTamGiu(TangVatPhuongTienTamGiu entity)
    {
        await DeleteAsync(entity);
    }
}
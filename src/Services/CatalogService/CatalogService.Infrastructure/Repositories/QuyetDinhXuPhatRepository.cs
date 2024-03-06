using Contracts.Common.Interfaces;
using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Parameters.QuyetDinhXuPhats;
using CatalogService.Domain.Entities;
using CatalogService.Infrastructure.Persistence;
using Infrastructure.Common;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Shared.SeedWord;

namespace CatalogService.Infrastructure.Repositories;

public class QuyetDinhXuPhatRepository : RepositoryBase<QuyetDinhXuPhat, int, CatalogServiceContext>, IQuyetDinhXuPhatRepository
{
    private readonly DbSet<QuyetDinhXuPhat> _quyetDinhXuPhat;
    public QuyetDinhXuPhatRepository(CatalogServiceContext context, IUnitOfWork<CatalogServiceContext> unitOfWork) : base(context, unitOfWork)
    {
        _quyetDinhXuPhat = context.Set<QuyetDinhXuPhat>();
    }

    public async Task<IEnumerable<QuyetDinhXuPhat>> GetQuyetDinhXuPhatByHoSoXuLyViPhamId(int id)
    {
        var result = FindByCondition(x => x.HoSoXuLyViPhamId.Equals(id)).OrderBy(x => x.Id)
                        .Include(x=>x.ChiTietQuyetDinhXuPhats);

        return result;
    }

    public async Task<PageList<QuyetDinhXuPhat>> GetPagedQuyetDinhXuPhatAsync(QuyetDinhXuPhatParameter parameter)
    {
        var result = _quyetDinhXuPhat.Filter(parameter)
            .OrderBy(x => x.SoQuyetDinh);

        return await PageList<QuyetDinhXuPhat>.ToPageList(result, parameter.PageNumber, parameter.PageSize);
    }
    
    public async Task CreateQuyetDinhXuPhat(QuyetDinhXuPhat request)
    {
        await CreateAsync(request);
    }

    public async Task UpdateQuyetDinhXuPhat(QuyetDinhXuPhat request)
    {
        await UpdateAsync(request);
    }

    public async Task DeleteQuyetDinhXuPhat(QuyetDinhXuPhat entity)
    {
        await DeleteAsync(entity);
    }
}
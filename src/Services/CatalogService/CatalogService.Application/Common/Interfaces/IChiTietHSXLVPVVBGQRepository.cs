using CatalogService.Application.Parameters.ChiTietHSXLVPVVBGQs;
using CatalogService.Domain.Entities;
using Contracts.Common.Interfaces;
using Shared.SeedWord;

namespace CatalogService.Application.Common.Interfaces;

public interface IChiTietHSXLVPVVBGQRepository : IRepositoryBaseAsync<ChiTietHSXLVPVVBGQ, int>
{
    Task<PageList<ChiTietHSXLVPVVBGQ>> GetPagedChiTietHSXLVPVVBGQAsync(ChiTietHSXLVPVVBGQParameter parameter);
    Task<ChiTietHSXLVPVVBGQ> GetChiTietHSXLVPVVBGQById(int id);
    Task CreateChiTietHSXLVPVVBGQ(ChiTietHSXLVPVVBGQ request);
    Task UpdateChiTietHSXLVPVVBGQ(ChiTietHSXLVPVVBGQ request);
    Task DeleteChiTietHSXLVPVVBGQ(ChiTietHSXLVPVVBGQ entity);
    Task<bool> CheckExistChiTietHSXLVPVVBGQ(int id);
}
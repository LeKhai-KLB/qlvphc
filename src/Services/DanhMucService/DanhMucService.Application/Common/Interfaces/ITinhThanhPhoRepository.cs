using Contracts.Common.Interfaces;
using DanhMucService.Application.Parameters.TinhThanhPhos;
using DanhMucService.Domain.Entities;
using Shared.SeedWord;

namespace DanhMucService.Application.Common.Interfaces
{
    public interface ITinhThanhPhoRepository : IRepositoryBaseAsync<TinhThanhPho, int>
    {
        Task<IEnumerable<TinhThanhPho>> GetTinhThanhPhosByTerm(string? term);
        Task<PageList<TinhThanhPho>> GetPagedTinhThanhPhoAsync(TinhThanhPhoParameter parameter);
        Task CreateTinhThanhPho(TinhThanhPho request);
        Task UpdateTinhThanhPho(TinhThanhPho request);
        Task DeleteTinhThanhPho(TinhThanhPho entity);
        Task<bool> CheckExistMaDiaDanhTinhThanhPho(string maDiaDanh);
    }
}

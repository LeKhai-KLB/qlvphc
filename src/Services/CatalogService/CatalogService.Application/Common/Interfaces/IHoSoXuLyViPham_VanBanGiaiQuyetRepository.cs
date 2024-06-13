using CatalogService.Application.Parameters.HoSoXuLyViPhams;
using CatalogService.Domain.Entities;
using Contracts.Common.Interfaces;
using Shared.SeedWord;

namespace CatalogService.Application.Common.Interfaces;

public interface IHoSoXuLyViPham_VanBanGiaiQuyetRepository : IRepositoryBaseAsync<HoSoXuLyViPham_VanBanGiaiQuyet, int>
{
    Task<PageList<HoSoXuLyViPham_VanBanGiaiQuyet>> GetPagedVanBanByHSVPId(HSVPVanBanGiaiQuyetParameter parameter);
    Task<List<HoSoXuLyViPham_VanBanGiaiQuyet>> GetHoSoXuLyViPham_VanBanGiaiQuyetsByHoSoXuLyViPhamId(int hsxlvpId);
    Task<HoSoXuLyViPham_VanBanGiaiQuyet> GetHSVPVanBanById(int hsId, int vbId);
    Task CreateHSVPVanBan(HoSoXuLyViPham_VanBanGiaiQuyet request);
    Task UpdateHSVPVanBan(HoSoXuLyViPham_VanBanGiaiQuyet request);
    Task DeleteHSVPVanBan(HoSoXuLyViPham_VanBanGiaiQuyet entity);
    Task<bool> CheckExistHSVPVanBan(int hsId, int vbId);
}
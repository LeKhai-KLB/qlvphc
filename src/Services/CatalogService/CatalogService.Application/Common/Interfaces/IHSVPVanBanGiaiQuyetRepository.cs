using CatalogService.Application.Parameters.HoSoXuLyViPhams;
using CatalogService.Domain.Entities;
using Shared.SeedWord;

namespace CatalogService.Application.Common.Interfaces;

public interface IHSVPVanBanGiaiQuyetRepository
{
    Task<PageList<HSXLVP_VanBanGiaiQuyet>> GetPagedVanBanByHSVPId(HSVPVanBanGiaiQuyetParameter parameter);
    Task<HSXLVP_VanBanGiaiQuyet> GetHSVPVanBanById(int hsId, int vbId);
    Task CreateHSVPVanBan(HSXLVP_VanBanGiaiQuyet request);
    Task UpdateHSVPVanBan(HSXLVP_VanBanGiaiQuyet request);
    Task DeleteHSVPVanBan(HSXLVP_VanBanGiaiQuyet entity);
    Task<bool> CheckExistHSVPVanBan(int hsId, int vbId);
}
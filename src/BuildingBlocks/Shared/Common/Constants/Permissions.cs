namespace Shared.Common.Constants;

public static class Permissions
{
    public static class CustomClaimTypes
    {
        public const string Permission = "Permission";
    }

    public class Users
    {
        //Only For SuperAdmins
        public const string SuperAdminView = $"{CustomClaimTypes.Permission}s.Users.SuperAdminView";
        public const string SuperAdminCreate = $"{CustomClaimTypes.Permission}s.Users.SuperAdminCreate";

        //All
        public const string View = $"{CustomClaimTypes.Permission}s.Users.View";
        public const string Create = $"{CustomClaimTypes.Permission}s.Users.Create";
        public const string Edit = $"{CustomClaimTypes.Permission}s.Users.Edit";
        public const string Delete = $"{CustomClaimTypes.Permission}s.Users.Delete";

        //Guest or Basic
        public const string ViewById = $"{CustomClaimTypes.Permission}s.Users.ViewById";
    }

    public class LinhVucXuPhats
    {
        //Only For SuperAdmins
        public const string SuperAdminView = $"{CustomClaimTypes.Permission}s.LinhVucXuPhats.SuperAdminView";
        public const string SuperAdminCreate = $"{CustomClaimTypes.Permission}s.LinhVucXuPhats.SuperAdminCreate";

        //All
        public const string View = $"{CustomClaimTypes.Permission}s.LinhVucXuPhats.View";
        public const string Create = $"{CustomClaimTypes.Permission}s.LinhVucXuPhats.Create";
        public const string Edit = $"{CustomClaimTypes.Permission}s.LinhVucXuPhats.Edit";
        public const string Delete = $"{CustomClaimTypes.Permission}s.LinhVucXuPhats.Delete";

        //Guest or Basic
        public const string ViewById = $"{CustomClaimTypes.Permission}s.LinhVucXuPhats.ViewById";
    }

    public class ChiTietLinhVucXuPhats
    {
        //Only For SuperAdmins
        public const string SuperAdminView = $"{CustomClaimTypes.Permission}s.ChiTietLinhVucXuPhats.SuperAdminView";
        public const string SuperAdminCreate = $"{CustomClaimTypes.Permission}s.ChiTietLinhVucXuPhats.SuperAdminCreate";

        //All
        public const string View = $"{CustomClaimTypes.Permission}s.ChiTietLinhVucXuPhats.View";
        public const string Create = $"{CustomClaimTypes.Permission}s.ChiTietLinhVucXuPhats.Create";
        public const string Edit = $"{CustomClaimTypes.Permission}s.ChiTietLinhVucXuPhats.Edit";
        public const string Delete = $"{CustomClaimTypes.Permission}s.ChiTietLinhVucXuPhats.Delete";

        //Guest or Basic
        public const string ViewById = $"{CustomClaimTypes.Permission}s.ChiTietLinhVucXuPhats.ViewById";
    }

    public class CoQuanBanHanhs
    {
        //Only For SuperAdmins
        public const string SuperAdminView = $"{CustomClaimTypes.Permission}s.CoQuanBanHanhs.SuperAdminView";
        public const string SuperAdminCreate = $"{CustomClaimTypes.Permission}s.CoQuanBanHanhs.SuperAdminCreate";

        //All
        public const string View = $"{CustomClaimTypes.Permission}s.CoQuanBanHanhs.View";
        public const string Create = $"{CustomClaimTypes.Permission}s.CoQuanBanHanhs.Create";
        public const string Edit = $"{CustomClaimTypes.Permission}s.CoQuanBanHanhs.Edit";
        public const string Delete = $"{CustomClaimTypes.Permission}s.CoQuanBanHanhs.Delete";

        //Guest or Basic
        public const string ViewById = $"{CustomClaimTypes.Permission}s.CoQuanBanHanhs.ViewById";
    }

    public class LoaiVanBans
    {
        //Only For SuperAdmins
        public const string SuperAdminView = $"{CustomClaimTypes.Permission}s.LoaiVanBans.SuperAdminView";
        public const string SuperAdminCreate = $"{CustomClaimTypes.Permission}s.LoaiVanBans.SuperAdminCreate";

        //All
        public const string View = $"{CustomClaimTypes.Permission}s.LoaiVanBans.View";
        public const string Create = $"{CustomClaimTypes.Permission}s.LoaiVanBans.Create";
        public const string Edit = $"{CustomClaimTypes.Permission}s.LoaiVanBans.Edit";
        public const string Delete = $"{CustomClaimTypes.Permission}s.LoaiVanBans.Delete";

        //Guest or Basic
        public const string ViewById = $"{CustomClaimTypes.Permission}s.LoaiVanBans.ViewById";
    }

    public class VanBanPhapLuats
    {
        //Only For SuperAdmins
        public const string SuperAdminView = $"{CustomClaimTypes.Permission}s.VanBanPhapLuats.SuperAdminView";
        public const string SuperAdminCreate = $"{CustomClaimTypes.Permission}s.VanBanPhapLuats.SuperAdminCreate";

        //All
        public const string View = $"{CustomClaimTypes.Permission}s.VanBanPhapLuats.View";
        public const string Create = $"{CustomClaimTypes.Permission}s.VanBanPhapLuats.Create";
        public const string Edit = $"{CustomClaimTypes.Permission}s.VanBanPhapLuats.Edit";
        public const string Delete = $"{CustomClaimTypes.Permission}s.VanBanPhapLuats.Delete";

        //Guest or Basic
        public const string ViewById = $"{CustomClaimTypes.Permission}s.VanBanPhapLuats.ViewById";
    }

    public class VanBanGiaiQuyets
    {
        //Only For SuperAdmins
        public const string SuperAdminView = $"{CustomClaimTypes.Permission}s.VanBanGiaiQuyets.SuperAdminView";
        public const string SuperAdminCreate = $"{CustomClaimTypes.Permission}s.VanBanGiaiQuyets.SuperAdminCreate";

        //All
        public const string View = $"{CustomClaimTypes.Permission}s.VanBanGiaiQuyets.View";
        public const string Create = $"{CustomClaimTypes.Permission}s.VanBanGiaiQuyets.Create";
        public const string Edit = $"{CustomClaimTypes.Permission}s.VanBanGiaiQuyets.Edit";
        public const string Delete = $"{CustomClaimTypes.Permission}s.VanBanGiaiQuyets.Delete";

        //Guest or Basic
        public const string ViewById = $"{CustomClaimTypes.Permission}s.VanBanGiaiQuyets.ViewById";
    }

    public class VanBanLienQuans
    {
        //Only For SuperAdmins
        public const string SuperAdminView = $"{CustomClaimTypes.Permission}s.VanBanLienQuans.SuperAdminView";
        public const string SuperAdminCreate = $"{CustomClaimTypes.Permission}s.VanBanLienQuans.SuperAdminCreate";

        //All
        public const string View = $"{CustomClaimTypes.Permission}s.VanBanLienQuans.View";
        public const string Create = $"{CustomClaimTypes.Permission}s.VanBanLienQuans.Create";
        public const string Edit = $"{CustomClaimTypes.Permission}s.VanBanLienQuans.Edit";
        public const string Delete = $"{CustomClaimTypes.Permission}s.VanBanLienQuans.Delete";

        //Guest or Basic
        public const string ViewById = $"{CustomClaimTypes.Permission}s.VanBanLienQuans.ViewById";
    }

    public class ThamQuyenXuPhats
    {
        //Only For SuperAdmins
        public const string SuperAdminView = $"{CustomClaimTypes.Permission}s.ThamQuyenXuPhats.SuperAdminView";
        public const string SuperAdminCreate = $"{CustomClaimTypes.Permission}s.ThamQuyenXuPhats.SuperAdminCreate";

        //All
        public const string View = $"{CustomClaimTypes.Permission}s.ThamQuyenXuPhats.View";
        public const string Create = $"{CustomClaimTypes.Permission}s.ThamQuyenXuPhats.Create";
        public const string Edit = $"{CustomClaimTypes.Permission}s.ThamQuyenXuPhats.Edit";
        public const string Delete = $"{CustomClaimTypes.Permission}s.ThamQuyenXuPhats.Delete";

        //Guest or Basic
        public const string ViewById = $"{CustomClaimTypes.Permission}s.ThamQuyenXuPhats.ViewById";
    }

    public class CoQuans
    {
        //Only For SuperAdmins
        public const string SuperAdminView = $"{CustomClaimTypes.Permission}s.CoQuans.SuperAdminView";
        public const string SuperAdminCreate = $"{CustomClaimTypes.Permission}s.CoQuans.SuperAdminCreate";

        //All
        public const string View = $"{CustomClaimTypes.Permission}s.CoQuans.View";
        public const string Create = $"{CustomClaimTypes.Permission}s.CoQuans.Create";
        public const string Edit = $"{CustomClaimTypes.Permission}s.CoQuans.Edit";
        public const string Delete = $"{CustomClaimTypes.Permission}s.CoQuans.Delete";

        //Guest or Basic
        public const string ViewById = $"{CustomClaimTypes.Permission}s.CoQuans.ViewById";
    }

    public class CongDans
    {
        //Only For SuperAdmins
        public const string SuperAdminView = $"{CustomClaimTypes.Permission}s.CongDans.SuperAdminView";
        public const string SuperAdminCreate = $"{CustomClaimTypes.Permission}s.CongDans.SuperAdminCreate";

        //All
        public const string View = $"{CustomClaimTypes.Permission}s.CongDans.View";
        public const string Create = $"{CustomClaimTypes.Permission}s.CongDans.Create";
        public const string Edit = $"{CustomClaimTypes.Permission}s.CongDans.Edit";
        public const string Delete = $"{CustomClaimTypes.Permission}s.CongDans.Delete";

        //Guest or Basic
        public const string ViewById = $"{CustomClaimTypes.Permission}s.CongDans.ViewById";
    }

    public class DieuKhoanBoSungKhacPhucs
    {
        //Only For SuperAdmins
        public const string SuperAdminView = $"{CustomClaimTypes.Permission}s.DieuKhoanBoSungKhacPhucs.SuperAdminView";
        public const string SuperAdminCreate = $"{CustomClaimTypes.Permission}s.DieuKhoanBoSungKhacPhucs.SuperAdminCreate";

        //All
        public const string View = $"{CustomClaimTypes.Permission}s.DieuKhoanBoSungKhacPhucs.View";
        public const string Create = $"{CustomClaimTypes.Permission}s.DieuKhoanBoSungKhacPhucs.Create";
        public const string Edit = $"{CustomClaimTypes.Permission}s.DieuKhoanBoSungKhacPhucs.Edit";
        public const string Delete = $"{CustomClaimTypes.Permission}s.DieuKhoanBoSungKhacPhucs.Delete";

        //Guest or Basic
        public const string ViewById = $"{CustomClaimTypes.Permission}s.DieuKhoanBoSungKhacPhucs.ViewById";
    }

    public class HoSoXuLyViPhams
    {
        //Only For SuperAdmins
        public const string SuperAdminView = $"{CustomClaimTypes.Permission}s.HoSoXuLyViPhams.SuperAdminView";
        public const string SuperAdminCreate = $"{CustomClaimTypes.Permission}s.HoSoXuLyViPhams.SuperAdminCreate";

        //All
        public const string View = $"{CustomClaimTypes.Permission}s.HoSoXuLyViPhams.View";
        public const string Create = $"{CustomClaimTypes.Permission}s.HoSoXuLyViPhams.Create";
        public const string Edit = $"{CustomClaimTypes.Permission}s.HoSoXuLyViPhams.Edit";
        public const string Delete = $"{CustomClaimTypes.Permission}s.HoSoXuLyViPhams.Delete";

        //Guest or Basic
        public const string ViewById = $"{CustomClaimTypes.Permission}s.HoSoXuLyViPhams.ViewById";
    }

    public class HSVPVanBanGiaiQuyets
    {
        //Only For SuperAdmins
        public const string SuperAdminView = $"{CustomClaimTypes.Permission}s.HSVPVanBanGiaiQuyets.SuperAdminView";
        public const string SuperAdminCreate = $"{CustomClaimTypes.Permission}s.HSVPVanBanGiaiQuyets.SuperAdminCreate";

        //All
        public const string View = $"{CustomClaimTypes.Permission}s.HSVPVanBanGiaiQuyets.View";
        public const string Create = $"{CustomClaimTypes.Permission}s.HSVPVanBanGiaiQuyets.Create";
        public const string Edit = $"{CustomClaimTypes.Permission}s.HSVPVanBanGiaiQuyets.Edit";
        public const string Delete = $"{CustomClaimTypes.Permission}s.HSVPVanBanGiaiQuyets.Delete";

        //Guest or Basic
        public const string ViewById = $"{CustomClaimTypes.Permission}s.HSVPVanBanGiaiQuyets.ViewById";
    }

    public class HanhViViPhams
    {
        //Only For SuperAdmins
        public const string SuperAdminView = $"{CustomClaimTypes.Permission}s.HanhViViPhams.SuperAdminView";
        public const string SuperAdminCreate = $"{CustomClaimTypes.Permission}s.HanhViViPhams.SuperAdminCreate";

        //All
        public const string View = $"{CustomClaimTypes.Permission}s.HanhViViPhams.View";
        public const string Create = $"{CustomClaimTypes.Permission}s.HanhViViPhams.Create";
        public const string Edit = $"{CustomClaimTypes.Permission}s.HanhViViPhams.Edit";
        public const string Delete = $"{CustomClaimTypes.Permission}s.HanhViViPhams.Delete";

        //Guest or Basic
        public const string ViewById = $"{CustomClaimTypes.Permission}s.HanhViViPhams.ViewById";
    }

    public class DieuKhoanXuPhats
    {
        //Only For SuperAdmins
        public const string SuperAdminView = $"{CustomClaimTypes.Permission}s.DieuKhoanXuPhats.SuperAdminView";
        public const string SuperAdminCreate = $"{CustomClaimTypes.Permission}s.DieuKhoanXuPhats.SuperAdminCreate";

        //All
        public const string View = $"{CustomClaimTypes.Permission}s.DieuKhoanXuPhats.View";
        public const string Create = $"{CustomClaimTypes.Permission}s.DieuKhoanXuPhats.Create";
        public const string Edit = $"{CustomClaimTypes.Permission}s.DieuKhoanXuPhats.Edit";
        public const string Delete = $"{CustomClaimTypes.Permission}s.DieuKhoanXuPhats.Delete";

        //Guest or Basic
        public const string ViewById = $"{CustomClaimTypes.Permission}s.DieuKhoanXuPhats.ViewById";
    }

    public static List<string> GeneratePermissionsForModule(string roleName, string module)
    {
        switch (roleName)
        {
            case "SuperAdmin":
                return new List<string>()
                {
                    $"{CustomClaimTypes.Permission}s.{module}.SuperAdminView",
                    $"{CustomClaimTypes.Permission}s.{module}.SuperAdminCreate",
                    $"{CustomClaimTypes.Permission}s.{module}.ViewById",
                    $"{CustomClaimTypes.Permission}s.{module}.Create",
                    $"{CustomClaimTypes.Permission}s.{module}.View",
                    $"{CustomClaimTypes.Permission}s.{module}.Edit",
                    $"{CustomClaimTypes.Permission}s.{module}.Delete"
                };
            case "Admin":
                return new List<string>()
                {
                    $"{CustomClaimTypes.Permission}s.{module}.ViewById",
                    $"{CustomClaimTypes.Permission}s.{module}.Create",
                    $"{CustomClaimTypes.Permission}s.{module}.View",
                    $"{CustomClaimTypes.Permission}s.{module}.Edit",
                    $"{CustomClaimTypes.Permission}s.{module}.Delete"
                };
            default:
                return new List<string>()
                {
                    $"{CustomClaimTypes.Permission}s.{module}.ViewById"
                };
        }
    }
}
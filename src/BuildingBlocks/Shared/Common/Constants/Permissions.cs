﻿namespace Shared.Common.Constants;

public static class Permissions
{
    public static class CustomClaimTypes
    {
        public const string Permission = "Permission";
    }

    public static class Users
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

    public static class LinhVucXuPhats
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

    public static class ChiTietLinhVucXuPhats
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

    public static class CoQuanBanHanhs
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

    public static class LoaiVanBans
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

    public static class VanBanPhapLuats
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

    public static class VanBanGiaiQuyets
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

    public static class VanBanLienQuans
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
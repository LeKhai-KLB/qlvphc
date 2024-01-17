namespace Shared.Common.Constants;

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
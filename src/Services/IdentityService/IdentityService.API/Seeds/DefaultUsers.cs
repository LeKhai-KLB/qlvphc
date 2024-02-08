using IdentityService.Domain.Constants;
using IdentityService.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Shared.Common.Constants;
using System.Security.Claims;

namespace IdentityService.API.Seeds;

public static class DefaultUsers
{
    public static async Task SeedBasicUserAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
    {
        var defaultUser = new User
        {
            UserName = "basicuser",
            Email = "basicuser",
            EmailConfirmed = true
        };

        if (userManager.Users.All(u => u.Id != defaultUser.Id))
        {
            var user = await userManager.FindByEmailAsync(defaultUser.Email);
            if (user == null)
            {
                await userManager.CreateAsync(defaultUser, "123Pa$$word!");
                await userManager.AddToRoleAsync(defaultUser, Roles.Basic.ToString());
            }

            await roleManager.SeedClaimsForRoles(Roles.Basic.ToString());
        }
    }

    public static async Task SeedSuperAdminAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
    {
        var defaultUser = new User
        {
            UserName = "superadmin",
            Email = "superadmin",
            EmailConfirmed = true
        };

        if (userManager.Users.All(u => u.Id != defaultUser.Id))
        {
            var user = await userManager.FindByEmailAsync(defaultUser.Email);
            if (user == null)
            {
                await userManager.CreateAsync(defaultUser, "123Pa$$word!");
                await userManager.AddToRoleAsync(defaultUser, Roles.SuperAdmin.ToString());
            }

            await roleManager.SeedClaimsForRoles(Roles.SuperAdmin.ToString());
        }
    }

    private async static Task SeedClaimsForRoles(this RoleManager<IdentityRole> roleManager, string roleName)
    {
        var role = await roleManager.FindByNameAsync(roleName);
        await roleManager.AddPermissionClaim(role, nameof(Permissions.Users));
        await roleManager.AddPermissionClaim(role, nameof(Permissions.LinhVucXuPhats));
        await roleManager.AddPermissionClaim(role, nameof(Permissions.ChiTietLinhVucXuPhats));
        await roleManager.AddPermissionClaim(role, nameof(Permissions.CoQuanBanHanhs));
        await roleManager.AddPermissionClaim(role, nameof(Permissions.LoaiVanBans));
        await roleManager.AddPermissionClaim(role, nameof(Permissions.VanBanPhapLuats));
        await roleManager.AddPermissionClaim(role, nameof(Permissions.VanBanLienQuans));
        await roleManager.AddPermissionClaim(role, nameof(Permissions.VanBanGiaiQuyets));
    }

    public static async Task AddPermissionClaim(this RoleManager<IdentityRole> roleManager, IdentityRole role, string module)
    {
        var allClaims = await roleManager.GetClaimsAsync(role);
        var allPermissions = Permissions.GeneratePermissionsForModule(role.Name, module);

        foreach (var permission in allPermissions)
        {
            if (!allClaims.Any(a => a.Type == "Permission" && a.Value == permission))
            {
                await roleManager.AddClaimAsync(role, new Claim("Permission", permission));
            }
        }
    }
}
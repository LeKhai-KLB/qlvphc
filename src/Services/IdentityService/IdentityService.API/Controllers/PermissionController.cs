﻿using System.Security.Claims;
using IdentityService.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shared.Common.Constants;
using static Shared.Common.Constants.Permissions;

namespace IdentityService.API.Controllers
{
    [Route("api")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer", Roles = "SuperAdmin")]
    public class PermissionsController : ControllerBase
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;
        public PermissionsController(RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        [HttpPost("AddPermission/{Role}")]
        [Authorize(Permissions.Users.SuperAdminCreate)]
        public async Task<IActionResult> AddPermissions(string Role)
        {
            if (Role != null)
            {
                switch (Role)
                {
                    case "SuperAdmin":
                        var superAdmin = await _roleManager.FindByNameAsync(Role);
                        await _roleManager.AddClaimAsync(superAdmin, new Claim(CustomClaimTypes.Permission, Permissions.Users.SuperAdminView));
                        await _roleManager.AddClaimAsync(superAdmin, new Claim(CustomClaimTypes.Permission, Permissions.Users.SuperAdminCreate));
                        await _roleManager.AddClaimAsync(superAdmin, new Claim(CustomClaimTypes.Permission, Permissions.Users.View));
                        await _roleManager.AddClaimAsync(superAdmin, new Claim(CustomClaimTypes.Permission, Permissions.Users.Edit));
                        await _roleManager.AddClaimAsync(superAdmin, new Claim(CustomClaimTypes.Permission, Permissions.Users.Create));
                        await _roleManager.AddClaimAsync(superAdmin, new Claim(CustomClaimTypes.Permission, Permissions.Users.Delete));
                        await _roleManager.AddClaimAsync(superAdmin, new Claim(CustomClaimTypes.Permission, Permissions.Users.ViewById));
                        break;
                    case "Admin":
                        var Admin = await _roleManager.FindByNameAsync(Role);
                        await _roleManager.AddClaimAsync(Admin, new Claim(CustomClaimTypes.Permission, Permissions.Users.View));
                        await _roleManager.AddClaimAsync(Admin, new Claim(CustomClaimTypes.Permission, Permissions.Users.Create));
                        await _roleManager.AddClaimAsync(Admin, new Claim(CustomClaimTypes.Permission, Permissions.Users.Edit));
                        await _roleManager.AddClaimAsync(Admin, new Claim(CustomClaimTypes.Permission, Permissions.Users.ViewById));
                        break;
                    default:
                        var Guest = await _roleManager.FindByNameAsync("guest");
                        await _roleManager.AddClaimAsync(Guest, new Claim(CustomClaimTypes.Permission, Permissions.Users.ViewById));
                        break;
                }

                var userRole = await _userManager.FindByNameAsync(Role);

                return Ok(userRole);
            }

            return BadRequest("Role not defined!");
        }
    }
}
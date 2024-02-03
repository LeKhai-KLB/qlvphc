using Microsoft.AspNetCore.Authorization;
using Shared.Common.Constants;

namespace Infrastructure.Extensions;

public static class AuthorizationOptionsExtensions
{
    public static void AddPermissionPolicies<T>(this AuthorizationOptions options)
    {
        var permissions = typeof(T).GetFields().Select(f => (string)f.GetValue(null));

        foreach (var permission in permissions)
        {
            options.AddPolicy(permission, builder =>
            {
                builder.RequireClaim(Permissions.CustomClaimTypes.Permission, permission);
            });
        }
    }
}
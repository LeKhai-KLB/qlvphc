using Infrastructure.Permission;
using Microsoft.AspNetCore.Authorization;

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
                builder.AddRequirements(new PermissionRequirement(permission));
            });
        }
    }
}
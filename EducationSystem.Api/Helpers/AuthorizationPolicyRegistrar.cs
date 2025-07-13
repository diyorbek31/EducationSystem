using EducationSystem.Domain.Enums;

namespace EducationSystem.Api.Helpers;

public static class AuthorizationPolicyRegistrar
{
    public static void AddPermissionPolicies(this IServiceCollection services)
    {
        services.AddAuthorization(options =>
        {
            var permissions = Enum.GetNames(typeof(EnumPermission));
            foreach (var permission in permissions)
            {
                options.AddPolicy(permission, policy =>
                    policy.RequireClaim("permission", permission));
            }
        });
    }
}


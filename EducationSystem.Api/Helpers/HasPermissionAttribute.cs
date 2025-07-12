using EducationSystem.Domain.Authorization;
using EducationSystem.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EducationSystem.Api.Helpers;

public class HasPermissionAttribute : AuthorizeAttribute, IAuthorizationFilter
{
    private readonly string _requiredPermission;

    public HasPermissionAttribute(EnumPermission permission)
    {
        _requiredPermission = permission.ToString();
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var user = context.HttpContext.User;
        var hasPermission = user.HasClaim("permission", _requiredPermission);

        if (!hasPermission)
        {
            context.Result = new ForbidResult();
        }
    }
}

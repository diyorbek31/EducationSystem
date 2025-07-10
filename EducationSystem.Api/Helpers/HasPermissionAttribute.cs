using EducationSystem.Domain.Authorization;
using EducationSystem.Domain.Enums;
using Microsoft.AspNetCore.Authorization;

namespace EducationSystem.Api.Helpers;

public class HasPermissionAttribute(EnumPermission permission) :
    AuthorizeAttribute(permission.ToString());

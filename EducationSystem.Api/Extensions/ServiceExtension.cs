using EducationSystem.Data.IRepositories;
using EducationSystem.Data.Repositories;
using EducationSystem.Service.Interfaces;
using EducationSystem.Service.Services;

namespace EducationSystem.Api.Extensions;

public static class ServiceExtension
{
    public static void AddCustomService(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IGroupService, GroupService>();
        services.AddScoped<IRoleService, RoleService>();    
        services.AddScoped<IPermissionService, PermissionService>();    
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
    }
}

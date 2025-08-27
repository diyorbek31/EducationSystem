using EducationSystem.Data.DbContexts;
using EducationSystem.Domain.Authorization;
using EducationSystem.Domain.Commons;
using EducationSystem.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace EducationSystem.Api;

public static class Dependencies
{
    public delegate void EnumEntityMapBuilder<in T>(T entity, string key, int value);
    public static async Task<WebApplication> MapEnumsToEntityAsync(WebApplication webApplication)
    {
        using var scope = webApplication.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        await MapEnumToEntityAsync<Permission, EnumPermission>(dbContext, (entity, key, value) =>
        {
            entity.Id = value;
            entity.Name = key;
            entity.IsSystemDefined = true;
        });

        return webApplication;
    }

    public static async Task MapEnumToEntityAsync<TEntity, TEnum>(
        this DbContext context,
        EnumEntityMapBuilder<TEntity> builder
    )
        where TEntity : Auditable
        where TEnum : Enum
    {
        var set = context.Set<TEntity>();

        ArgumentNullException.ThrowIfNull(set);

        var values = Enum.GetValues(typeof(TEnum)).Cast<object>();

        EnumGroupAttribute? group = default!;
        foreach (var helper in values)
        {
            if (!(await set.AnyAsync(x => x.Id == (int)helper)))
            {
                var entity = Activator.CreateInstance<TEntity>();
                var attr = typeof(TEnum).GetMember(helper.ToString()!).FirstOrDefault()
                    ?.GetCustomAttribute<EnumGroupAttribute>();

                group = attr ?? group;

                entity.GroupName = group?.GroupName ?? "Default";
                entity.Id = (int)helper;

                builder(entity, helper.ToString()!, (int)helper);
                entity.IsSystemDefined = true;

                set.Add(entity);
            }
        }

        await context.SaveChangesAsync();
    }

}

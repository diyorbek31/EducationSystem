using EducationSystem.Data.DbContexts;
using EducationSystem.Domain.Authorization;
using EducationSystem.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json.Linq;
using System.Runtime.CompilerServices;

namespace EducationSystem.Api;

public static class Dependencies
{
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

    private static async Task MapEnumToEntityAsync<TEntity, TEnum>(
    AppDbContext dbContext,
    Action<TEntity, string, int> mapAction)
    where TEntity : class, new()
    where TEnum : Enum
    {
        var enumValues = Enum.GetValues(typeof(TEnum)).Cast<TEnum>().ToList();
        var dbSet = dbContext.Set<TEntity>();

        // Load existing entities from DB
        var existingEntities = await dbSet.ToListAsync();

        foreach (var enumValue in enumValues)
        {
            var name = enumValue.ToString();
            var id = Convert.ToInt32(enumValue);

            // Check if already exists
            bool exists = existingEntities.Any();

            if (exists)
                continue; // ✅ Skip duplicates

            var entity = new TEntity();
            mapAction(entity, name, id);
            dbSet.Add(entity);
        }

        await dbContext.SaveChangesAsync();
    }

}

using EducationSystem.Domain.Attributes;
using EducationSystem.Domain.Commons;
using Microsoft.EntityFrameworkCore;
namespace EducationSystem.Api;

public static class Dependencies
{
    public delegate void EnumEntityMapBuilder<in T>(T entity, string key, int value);
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
                var attr = typeof(TEnum).GetMember(helper.ToString()!).FirstOrDefault();
                set.Add(entity);
            }
        }

        await context.SaveChangesAsync();
    }
}

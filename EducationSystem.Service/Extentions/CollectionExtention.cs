using EducationSystem.Domain.Commons;
using EducationSystem.Domain.Congirations;
using Microsoft.Web.Infrastructure;
using Newtonsoft.Json;

namespace EducationSystem.Service.Extentions;

public static class CollectionExtention
{
    public static IQueryable<TEntity> ToPagedList<TEntity>(this IQueryable<TEntity> source, PaginationParams @params)
    {
        if (@params.PageIndex < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(@params.PageIndex), "The page index must be greater than or equal to 1.");
        }

        if (@params.PageSize < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(@params.PageSize), "The page size must be greater than or equal to 1.");
        }
        int skip = (@params.PageIndex - 1) * @params.PageSize;

        return source.Skip(skip).Take(@params.PageSize);
    }
}

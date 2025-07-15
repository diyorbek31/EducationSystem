using EducationSystem.Domain.Commons;
using EducationSystem.Domain.Congirations;
using Microsoft.Web.Infrastructure;
using Newtonsoft.Json;

namespace EducationSystem.Service.Extentions;

public static class CollectionExtension
{
    public static IQueryable<TEntity> ToPagedList<TEntity>(this IQueryable<TEntity> source, PaginationParams @params)
    {
         return source
            .Skip((@params.PageIndex - 1) * @params.PageSize)
            .Take(@params.PageSize);
    }
}


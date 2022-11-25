using MeControla.Core.Data.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace MeControla.Core.Extensions
{
    public static class QueryableExtensions
    {
#if !DEBUG
        [System.Diagnostics.DebuggerStepThrough]
#endif
        public static IQueryable<TEntity> SetPagination<TEntity>(this IQueryable<TEntity> query, IPaginationFilter paginationFilter)
        {
            if (paginationFilter == null)
                return query;

            return query.Skip(GetSkip(paginationFilter)).Take(paginationFilter.PageSize);
        }

        private static int GetSkip(IPaginationFilter paginationFilter)
           => (paginationFilter.PageNumber - 1) * paginationFilter.PageSize;

#if !DEBUG
        [System.Diagnostics.DebuggerStepThrough]
#endif
        public static IQueryable<TEntity> SetPredicate<TEntity>(this IQueryable<TEntity> query, Expression<Func<TEntity, bool>> predicate)
        {
            if (predicate == null)
                return query;

            return query.Where(predicate);
        }
    }
}
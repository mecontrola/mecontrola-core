using MeControla.Core.Repositories;
using System;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;

namespace MeControla.Core.Extensions
{
    public static class QueryableExtension
    {
        [DebuggerStepThrough]
        public static IQueryable<TEntity> SetPagination<TEntity>(this IQueryable<TEntity> query, IPaginationFilter paginationFilter)
            => paginationFilter == null
             ? query
             : query.Skip(GetSkip(paginationFilter)).Take(paginationFilter.PageSize);

        [DebuggerStepThrough]
        private static int GetSkip(IPaginationFilter paginationFilter)
           => (paginationFilter.PageNumber - 1) * paginationFilter.PageSize;

        [DebuggerStepThrough]
        public static IQueryable<TEntity> SetPredicate<TEntity>(this IQueryable<TEntity> query, Expression<Func<TEntity, bool>> predicate)
            => predicate == null
             ? query
             : query.Where(predicate);
    }
}
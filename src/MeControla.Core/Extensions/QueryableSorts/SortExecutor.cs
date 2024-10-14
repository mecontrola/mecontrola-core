using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace MeControla.Core.Extensions.QueryableSorts;

/// <summary>
/// Responsible for applying sorting logic to an IQueryable based on SortExpressions.
/// </summary>
internal static class SortExecutor
{
    /// <summary>
    /// Applies sorting expressions to the IQueryable.
    /// </summary>
    /// <typeparam name="TEntity">The entity type.</typeparam>
    /// <param name="query">The query to be sorted.</param>
    /// <param name="sortExpressions">A collection of SortExpression objects.</param>
    /// <returns>The sorted IQueryable.</returns>
    [RequiresUnreferencedCode("This method uses reflection, which may not be compatible with trimming.")]
    public static IQueryable<TEntity> ApplySorting<TEntity>(IQueryable<TEntity> query, IEnumerable<SortExpression> sortExpressions)
    {
        IOrderedQueryable<TEntity> orderedQuery = null;

        foreach (var sortExpression in sortExpressions)
        {
            var type = typeof(TEntity);
            var parameter = Expression.Parameter(type, "x");
            var property = type.GetProperty(sortExpression.Property, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance)
                        ?? throw new ArgumentException($"Property '{sortExpression.Property}' does not exist.");

            var propertyAccess = Expression.MakeMemberAccess(parameter, property);
            var orderByExp = Expression.Lambda(propertyAccess, parameter);

            if (orderedQuery == null)
                orderedQuery = ApplyInitialSort(query, sortExpression, orderByExp);
            else
                ApplySubsequentSort(ref orderedQuery, sortExpression, orderByExp);
        }

        return orderedQuery ?? query;
    }

    [RequiresUnreferencedCode("This method uses reflection, which may not be compatible with trimming.")]
    private static IOrderedQueryable<TEntity> ApplyInitialSort<TEntity>(IQueryable<TEntity> query, SortExpression sortExpression, LambdaExpression orderByExp)
        => sortExpression.Direction == SortDirection.Ascending
         ? Queryable.OrderBy(query, (dynamic)orderByExp)
         : Queryable.OrderByDescending(query, (dynamic)orderByExp);

    [RequiresUnreferencedCode("This method uses reflection, which may not be compatible with trimming.")]
    private static void ApplySubsequentSort<TEntity>(ref IOrderedQueryable<TEntity> orderedQuery, SortExpression sortExpression, LambdaExpression orderByExp)
        => orderedQuery = sortExpression.Direction == SortDirection.Ascending
         ? Queryable.ThenBy(orderedQuery, (dynamic)orderByExp)
         : Queryable.ThenByDescending(orderedQuery, (dynamic)orderByExp);
}
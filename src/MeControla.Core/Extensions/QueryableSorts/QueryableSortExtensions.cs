using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace MeControla.Core.Extensions.QueryableSorts;

/// <summary>
/// Provides sorting extension methods for IQueryable.
/// </summary>
internal static class QueryableSortExtensions
{
    /// <summary>
    /// Applies sorting to the IQueryable based on the provided sort criteria.
    /// Supports multiple sorting fields in the format: "fieldName1_asc,fieldName2_desc".
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity being queried.</typeparam>
    /// <param name="query">The IQueryable on which to apply sorting.</param>
    /// <param name="sortBy">A comma-separated string containing sorting fields and directions (asc/desc).</param>
    /// <returns>A sorted IQueryable.</returns>
    [RequiresUnreferencedCode("This method uses reflection, which may not be compatible with trimming.")]
    public static IQueryable<TEntity> ApplySorting<TEntity>(this IQueryable<TEntity> query, string sortBy)
    {
        ArgumentNullException.ThrowIfNull(query);

        if (sortBy.IsNullOrWhiteSpace())
            return query;

        var sortExpressions = SortParser.Parse(sortBy);
        var sortedQuery = SortExecutor.ApplySorting(query, sortExpressions);

        return sortedQuery;
    }
}
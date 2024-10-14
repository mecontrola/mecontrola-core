using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using MeControla.Core.Extensions.QueryableFilters.FilterStrategies;

namespace MeControla.Core.Extensions.QueryableFilters;

/// <summary>
/// Provides extension methods for applying filters to queryable sources.
/// </summary>
internal static class QueryableFilterExtensions
{
    /// <summary>
    /// A list de <see cref="IFilterStrategy"/> implementations.
    /// </summary>
    private static readonly Dictionary<string, IFilterStrategy> filterStrategies = new()
    {
        { EqualFilterStrategy.Name, new EqualFilterStrategy() },
        { NotEqualFilterStrategy.Name, new NotEqualFilterStrategy() },
        { GreaterThanFilterStrategy.Name, new GreaterThanFilterStrategy() },
        { GreaterThanOrEqualFilterStrategy.Name, new GreaterThanOrEqualFilterStrategy() },
        { LessThanFilterStrategy.Name, new LessThanFilterStrategy() },
        { LessThanOrEqualFilterStrategy.Name, new LessThanOrEqualFilterStrategy() },
        { ContainsFilterStrategy.Name, new ContainsFilterStrategy() },
        { NotContainsFilterStrategy.Name, new NotContainsFilterStrategy() },
        { StartsWithFilterStrategy.Name, new StartsWithFilterStrategy() },
        { NotStartsWithFilterStrategy.Name, new NotStartsWithFilterStrategy() },
        { EndsWithFilterStrategy.Name, new EndsWithFilterStrategy() },
        { NotEndsWithFilterStrategy.Name, new NotEndsWithFilterStrategy() }
    };

    /// <summary>
    /// Applies filters to the provided queryable entity set based on the filter criteria.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity being queried.</typeparam>
    /// <param name="query">The original IQueryable collection.</param>
    /// <param name="filterBy">The filter string to apply. It can contain multiple filters separated by commas.</param>
    /// <returns>An IQueryable representing the filtered result set.</returns>
    /// <exception cref="ArgumentNullException">Thrown if the query is null.</exception>
    [RequiresUnreferencedCode("This method uses reflection, which may not be compatible with trimming.")]
    public static IQueryable<TEntity> ApplyFilters<TEntity>(this IQueryable<TEntity> query, string filterBy)
    {
        ArgumentNullException.ThrowIfNull(query);

        if (filterBy.IsNullOrWhiteSpace())
            return query;

        var filters = FilterParser.Parse(filterBy);

        foreach (var filter in filters)
        {
            if (!filterStrategies.TryGetValue(filter.Operation, out IFilterStrategy strategy))
                throw new InvalidOperationException($"Unsupported filter operation: {filter.Operation}.");

            query = strategy.ApplyFilter(query, filter.Property, filter.Operation, filter.Value);
        }

        return query;
    }
}
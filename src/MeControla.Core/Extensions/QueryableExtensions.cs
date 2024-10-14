/***********************************************************************************
 * Copyright 2024 Me Controla
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 ***********************************************************************************/

using MeControla.Core.Extensions.QueryableFilters;
using MeControla.Core.Extensions.QueryableSorts;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;

namespace MeControla.Core.Extensions;

/// <summary>
/// Provides extension methods for <see cref="IQueryable{TEntity}"/> to facilitate pagination and predicate filtering.
/// </summary>
public static class QueryableExtensions
{
    /// <summary>
    /// Sets pagination on the given queryable sequence based on the specified pagination parameters.
    /// If the pagination is null, no paginating is applied.
    /// </summary>
    /// <typeparam name="TEntity">The type of entities in the queryable.</typeparam>
    /// <param name="query">The queryable sequence to apply pagination to.</param>
    /// <param name="pagination">The pagination parameters to be applied. If null, the original query is returned.</param>
    /// <returns>An <see cref="IQueryable{TEntity}"/> that has pagination applied.</returns>
    /// <exception cref="ArgumentNullException">Thrown if the query is null.</exception>
#if !DEBUG
    [System.Diagnostics.DebuggerStepThrough]
#endif
    public static IQueryable<TEntity> SetPagination<TEntity>(this IQueryable<TEntity> query, IPagination pagination)
    {
        ArgumentNullException.ThrowIfNull(query);

        return pagination == null
             ? query
             : query.Skip(GetSkip(pagination)).Take((int)pagination.Limit);
    }

    private static int GetSkip(IPagination pagination)
       => (int)((pagination.Page - 1) * pagination.Limit);

    /// <summary>
    /// Applies filtering to the query based on the specified filter criteria.
    /// If the filter is null or empty, no filtering is applied.
    /// </summary>
    /// <typeparam name="TEntity">The type of entities in the queryable.</typeparam>
    /// <param name="query">The queryable sequence to apply filter to.</param>
    /// <param name="filterBy">The filter criteria in a string format, typically received from the request query string.</param>
    /// <returns>An <see cref="IQueryable{TEntity}"/> that has filter applied.</returns>
    /// <exception cref="ArgumentNullException">Thrown if the query is null.</exception>
#if !DEBUG
    [System.Diagnostics.DebuggerStepThrough]
#endif
    [RequiresUnreferencedCode("This method uses reflection, which may not be compatible with trimming.")]
    public static IQueryable<TEntity> SetFilterBy<TEntity>(this IQueryable<TEntity> query, string filterBy)
        => query.ApplyFilters(filterBy);

    /// <summary>
    /// Applies sorting to the query based on the specified sort criteria.
    /// If the sort criteria is null or empty, no sorting is applied.
    /// </summary>
    /// <typeparam name="TEntity">The type of entities in the queryable.</typeparam>
    /// <param name="query">The queryable sequence to apply sort to.</param>
    /// <param name="sortBy">The sort criteria in a string format, typically received from the request query string.</param>
    /// <returns>An <see cref="IQueryable{TEntity}"/> that has sort applied.</returns>
    /// <exception cref="ArgumentNullException">Thrown if the query is null.</exception>
#if !DEBUG
    [System.Diagnostics.DebuggerStepThrough]
#endif
    [RequiresUnreferencedCode("This method uses reflection, which may not be compatible with trimming.")]
    public static IQueryable<TEntity> SetSortBy<TEntity>(this IQueryable<TEntity> query, string sortBy)
        => query.ApplySorting(sortBy);

    /// <summary>
    /// Sets a filter predicate on the given queryable sequence.
    /// If the predicate is null, no predicating is applied.
    /// </summary>
    /// <typeparam name="TEntity">The type of entities in the queryable.</typeparam>
    /// <param name="query">The queryable sequence to apply the predicate to.</param>
    /// <param name="predicate">The filter expression to be applied. If null, the original query is returned.</param>
    /// <returns>An <see cref="IQueryable{TEntity}"/> that has the predicate applied.</returns>
    /// <exception cref="ArgumentNullException">Thrown if the query is null.</exception>
#if !DEBUG
    [System.Diagnostics.DebuggerStepThrough]
#endif
    public static IQueryable<TEntity> SetPredicate<TEntity>(this IQueryable<TEntity> query, Expression<Func<TEntity, bool>> predicate)
    {
        ArgumentNullException.ThrowIfNull(query);

        return predicate == null
             ? query
             : query.Where(predicate);
    }
}
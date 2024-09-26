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

using System;
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
    /// </summary>
    /// <typeparam name="TEntity">The type of entities in the queryable.</typeparam>
    /// <param name="query">The queryable sequence to apply pagination to.</param>
    /// <param name="pagination">The pagination parameters to be applied. If null, the original query is returned.</param>
    /// <returns>An <see cref="IQueryable{TEntity}"/> that has pagination applied.</returns>
#if !DEBUG
    [System.Diagnostics.DebuggerStepThrough]
#endif
    public static IQueryable<TEntity> SetPagination<TEntity>(this IQueryable<TEntity> query, IPagination pagination)
        => pagination == null
         ? query
         : query.Skip(GetSkip(pagination)).Take((int)pagination.Limit);

    private static int GetSkip(IPagination pagination)
       => (int)((pagination.Page - 1) * pagination.Limit);

    /// <summary>
    /// Sets a filter predicate on the given queryable sequence.
    /// </summary>
    /// <typeparam name="TEntity">The type of entities in the queryable.</typeparam>
    /// <param name="query">The queryable sequence to apply the predicate to.</param>
    /// <param name="predicate">The filter expression to be applied. If null, the original query is returned.</param>
    /// <returns>An <see cref="IQueryable{TEntity}"/> that has the predicate applied.</returns>
#if !DEBUG
    [System.Diagnostics.DebuggerStepThrough]
#endif
    public static IQueryable<TEntity> SetPredicate<TEntity>(this IQueryable<TEntity> query, Expression<Func<TEntity, bool>> predicate)
        => predicate == null
         ? query
         : query.Where(predicate);
}
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

using System.Collections;
using System.Collections.Generic;

#pragma warning disable IDE0130 // Namespace does not match folder structure
namespace System.Linq;
#pragma warning restore IDE0130 // Namespace does not match folder structure

/// <summary>
/// Provides extension methods for IEnumerable to support pagination.
/// </summary>
public static class EnumerableExtension
{
    /// <summary>
    /// Paginates the source IEnumerable based on the given pagination settings.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source collection.</typeparam>
    /// <param name="source">The source collection to paginate.</param>
    /// <param name="pagination">An object containing the pagination settings, such as page number and limit.</param>
    /// <param name="total">The total number of items in storage in database.</param>
    /// <returns>A paginated collection that implements IPagination of the specified type.</returns>
    public static IPagination<TSource> PaginationBy<TSource>(this IEnumerable<TSource> source, IPagination pagination, long total)
        => new PaginationEnumerable<TSource>(source, pagination, total);
}

/// <summary>
/// Defines the pagination settings, such as page number and limit.
/// </summary>
public interface IPagination
{
    /// <summary>
    /// Gets the current page number to be retrieved.
    /// </summary>
    long Page { get; }

    /// <summary>
    /// Gets the number of items to be retrieved per page.
    /// </summary>
    long Limit { get; }

    /// <summary>
    /// Gets or sets the fields to be filtered and their values.
    /// </summary>
    string FilterBy { get; set; }

    /// <summary>
    /// Gets or sets the fields to be sorted and their order.
    /// </summary>
    string SortBy { get; set; }
}

/// <summary>
/// Extends IPagination to include a strongly-typed enumeration of elements
/// and provides the total number of items.
/// </summary>
/// <typeparam name="TElement">The type of the elements in the paginated collection.</typeparam>
public interface IPagination<out TElement> : IPagination, IEnumerable<TElement>
{
    /// <summary>
    /// Gets the total number of items storage in database.
    /// </summary>
    long Total { get; }
}

internal sealed partial class PaginationEnumerable<TSource> : IPagination<TSource>
{
    private readonly IEnumerable<TSource> _source;

    public long Page { get; }
    public long Limit { get; }
    public long Total { get; }
    public string FilterBy { get; set; }
    public string SortBy { get; set; }

    public PaginationEnumerable(IEnumerable<TSource> source, IPagination pagination, long total)
    {
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(pagination);

        _source = source;

        Page = pagination.Page;
        Limit = pagination.Limit;
        Total = total;
        FilterBy = pagination.FilterBy;
        SortBy = pagination.SortBy;
    }

    public IEnumerator<TSource> GetEnumerator()
        => _source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator()
        => GetEnumerator();
}
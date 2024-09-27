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

using System.Collections.Generic;
using System.Linq;

namespace MeControla.Core.Extensions;

/// <summary>
/// Provides extension methods for <see cref="IList{T}"/> to simplify null and empty checks, and other utility functions.
/// </summary>
public static class ListExtensions
{
    /// <summary>
    /// Determines whether the <see cref="IList{T}"/> is null or contains no elements.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list.</typeparam>
    /// <param name="enumerable">The list to check.</param>
    /// <returns><c>true</c> if the list is null or empty; otherwise, <c>false</c>.</returns>
#if !DEBUG
    [System.Diagnostics.DebuggerStepThrough]
#endif
    public static bool IsNullOrEmpty<T>(this IList<T> enumerable)
        => enumerable == null || !enumerable.Any();

    /// <summary>
    /// Determines whether the <see cref="IList{T}"/> is not null and contains at least one element.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list.</typeparam>
    /// <param name="enumerable">The list to check.</param>
    /// <returns><c>true</c> if the list is not null and contains at least one element; otherwise, <c>false</c>.</returns>
#if !DEBUG
    [System.Diagnostics.DebuggerStepThrough]
#endif
    public static bool IsNotNullAndAny<T>(this IList<T> enumerable)
        => enumerable != null && enumerable.Any();

    /// <summary>
    /// Converts the <see cref="IList{T}"/> to a list, or returns an empty list if the source is null or empty.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list.</typeparam>
    /// <param name="enumerable">The list to convert.</param>
    /// <returns>A new <see cref="List{T}"/> containing the elements of the source list, or an empty list if the source is null or empty.</returns>
#if !DEBUG
    [System.Diagnostics.DebuggerStepThrough]
#endif
    public static IList<T> ToListOrEmpty<T>(this IList<T> enumerable)
        => enumerable.IsNullOrEmpty() ? [] : enumerable.ToList();
}
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

namespace MeControla.Core.Extensions;

/// <summary>
/// Provides extension methods for working with collections.
/// </summary>
public static class CollectionExtensions
{
    /// <summary>
    /// Adds all elements from the specified <see cref="IEnumerable{T}"/> to the target <see cref="ICollection{T}"/>.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the collection.</typeparam>
    /// <param name="source">The target collection where elements will be added.</param>
    /// <param name="target">The source collection containing elements to be added.</param>
    /// <example>
    /// Example usage:
    /// <code>
    /// var list = new List&lt;int&gt;();
    /// var numbers = new int[] { 1, 2, 3 };
    /// list.AddList(numbers); // list now contains 1, 2, 3
    /// </code>
    /// </example>
    /// <remarks>
    /// This method iterates through the target collection and adds each item to the source collection. It uses an extension method <c>ForEach</c> to perform the addition.
    /// </remarks>
    public static void AddList<T>(this ICollection<T> source, IEnumerable<T> target)
        => target.ForEach(source.Add);

    /// <summary>
    /// Replaces the current elements of the <see cref="ICollection{T}"/> with the elements from the specified <see cref="IEnumerable{T}"/>.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    /// <param name="source">The source collection to be cleared and populated.</param>
    /// <param name="target">The target enumerable containing the elements to be added to the source collection.</param>
    public static void SetList<T>(this ICollection<T> source, IEnumerable<T> target)
    {
        source.Clear();
        source.AddList(target);
    }
}
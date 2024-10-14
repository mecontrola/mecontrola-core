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
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace MeControla.Core.Extensions;

/// <summary>
/// Provides extension methods for IEnumerable types to simplify common operations such as null checking, 
/// transformation to lists, and performing actions on collections.
/// </summary>
public static class EnumerableExtensions
{
    /// <summary>
    /// Determines whether the given enumerable is null or contains no elements.
    /// </summary>
    /// <typeparam name="T">The type of elements in the enumerable.</typeparam>
    /// <param name="enumerable">The enumerable to check.</param>
    /// <returns>True if the enumerable is null or empty; otherwise, false.</returns>
#if !DEBUG
    [System.Diagnostics.DebuggerStepThrough]
#endif
    public static bool IsNullOrEmpty<T>(this IEnumerable<T> enumerable)
        => enumerable == null || !enumerable.Any();

    /// <summary>
    /// Determines whether the given enumerable is not null and contains at least one element.
    /// </summary>
    /// <typeparam name="T">The type of elements in the enumerable.</typeparam>
    /// <param name="enumerable">The enumerable to check.</param>
    /// <returns>True if the enumerable is not null and contains at least one element; otherwise, false.</returns>
#if !DEBUG
    [System.Diagnostics.DebuggerStepThrough]
#endif
    public static bool IsNotNullAndAny<T>(this IEnumerable<T> enumerable)
        => enumerable != null && enumerable.Any();

    /// <summary>
    /// Converts the given enumerable to a list. If the enumerable is null or empty, returns an empty list.
    /// </summary>
    /// <typeparam name="T">The type of elements in the enumerable.</typeparam>
    /// <param name="enumerable">The enumerable to convert.</param>
    /// <returns>A list containing the elements of the enumerable, or an empty list if the enumerable is null or empty.</returns>
#if !DEBUG
    [System.Diagnostics.DebuggerStepThrough]
#endif
    public static IList<T> ToListOrEmpty<T>(this IEnumerable<T> enumerable)
        => enumerable.IsNullOrEmpty() ? [] : enumerable.ToList();

    /// <summary>
    /// Projects each element of a sequence into a new form and returns a list. 
    /// If the source sequence is null or empty, returns an empty list.
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the source sequence.</typeparam>
    /// <typeparam name="TResult">The type of elements in the result sequence.</typeparam>
    /// <param name="source">The sequence to project.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>A list of transformed elements, or an empty list if the source is null or empty.</returns>
#if !DEBUG
    [System.Diagnostics.DebuggerStepThrough]
#endif
    public static IList<TResult> SelectToListOrEmpty<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        => source.IsNullOrEmpty() ? [] : source.Select(selector).ToList();

    /// <summary>
    /// Projects each element of a sequence into a new form, using the element's index in the sequence, 
    /// and returns a list. If the source sequence is null or empty, returns an empty list.
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the source sequence.</typeparam>
    /// <typeparam name="TResult">The type of elements in the result sequence.</typeparam>
    /// <param name="source">The sequence to project.</param>
    /// <param name="selector">A transform function to apply to each element, the second parameter of the function
    /// represents the index of the source element.</param>
    /// <returns>A list of transformed elements, or an empty list if the source is null or empty.</returns>
#if !DEBUG
    [System.Diagnostics.DebuggerStepThrough]
#endif
    public static IList<TResult> SelectToListOrEmpty<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, int, TResult> selector)
        => source.IsNullOrEmpty() ? [] : source.Select(selector).ToList();

    /// <summary>
    /// Executes the specified action on each element of the sequence.
    /// </summary>
    /// <typeparam name="T">The type of elements in the source sequence.</typeparam>
    /// <param name="source">The sequence on which the action will be executed.</param>
    /// <param name="action">The action to execute on each element.</param>
#if !DEBUG
    [System.Diagnostics.DebuggerStepThrough]
#endif
    public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
    {
        ArgumentNullException.ThrowIfNull(source);

        foreach (T item in source)
            action(item);
    }

    /// <summary>
    /// Finds all the indices of the elements that match the given predicate.
    /// </summary>
    /// <typeparam name="T">The type of elements in the source sequence.</typeparam>
    /// <param name="source">The sequence to search.</param>
    /// <param name="match">The predicate to test each element against.</param>
    /// <returns>An enumerable of indices where the elements match the predicate.</returns>
#if !DEBUG
    [System.Diagnostics.DebuggerStepThrough]
#endif
    public static IEnumerable<int> FindIndexAll<T>(this IEnumerable<T> source, Predicate<T> match)
    {
        ArgumentNullException.ThrowIfNull(source);

        return Enumerable.Range(0, source.Count())
                         .Where(i => match(source.ElementAt(i)));
    }

    /// <summary>
    /// Computes the sum of a sequence of TimeSpan values projected by a selector function.
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the source sequence.</typeparam>
    /// <param name="source">The sequence to sum.</param>
    /// <param name="selector">A function to extract a TimeSpan from each element.</param>
    /// <returns>The sum of the selected TimeSpan values.</returns>
#if !DEBUG
    [System.Diagnostics.DebuggerStepThrough]
#endif
    public static TimeSpan Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, TimeSpan> selector)
    {
        ArgumentNullException.ThrowIfNull(source);

        return source.Select(selector)
                     .Aggregate(TimeSpan.Zero, (t1, t2) => t1 + t2);
    }

    /// <summary>
    /// Computes the average of a sequence of TimeSpan values projected by a selector function.
    /// </summary>
    /// <typeparam name="TSource">The type of elements in the source sequence.</typeparam>
    /// <param name="source">The sequence to average.</param>
    /// <param name="selector">A function to extract a TimeSpan from each element.</param>
    /// <returns>The average of the selected TimeSpan values.</returns>
#if !DEBUG
    [System.Diagnostics.DebuggerStepThrough]
#endif
    public static TimeSpan Average<TSource>(this IEnumerable<TSource> source, Func<TSource, TimeSpan> selector)
    {
        ArgumentNullException.ThrowIfNull(source);

        return source.Sum(selector) / source.Count();
    }

    /// <summary>
    /// Converts the given enumerable to an ObservableCollection.
    /// </summary>
    /// <typeparam name="T">The type of elements in the source sequence.</typeparam>
    /// <param name="source">The sequence to convert.</param>
    /// <returns>An ObservableCollection containing the elements of the source.</returns>
#if !DEBUG
    [System.Diagnostics.DebuggerStepThrough]
#endif
    public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> source)
    {
        ArgumentNullException.ThrowIfNull(source);

        return new ObservableCollection<T>(source);
    }
}
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
using System.Linq;

namespace MeControla.Core.Extensions;

/// <summary>
/// Provides extension methods for working with <see cref="IDictionary{TKey, TValue}"/> objects.
/// </summary>
public static class DictionaryExtensions
{
    /// <summary>
    /// Determines whether the specified dictionary contains any elements.
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the dictionary.</typeparam>
    /// <typeparam name="TValue">The type of values in the dictionary.</typeparam>
    /// <param name="source">The dictionary to check.</param>
    /// <returns><c>true</c> if the dictionary is not null and contains at least one element; otherwise, <c>false</c>.</returns>
    /// <example>
    /// Example usage:
    /// <code>
    /// var dict = new Dictionary&lt;int, string&gt; { { 1, "value1" } };
    /// bool hasElements = dict.HasAny(); // returns true
    /// </code>
    /// </example>
#if !DEBUG
    [System.Diagnostics.DebuggerStepThrough]
#endif
    public static bool HasAny<TKey, TValue>(this IDictionary<TKey, TValue> source)
        => source != null && source.Any();

    /// <summary>
    /// Determines whether the specified dictionary contains any elements that satisfy a condition.
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the dictionary.</typeparam>
    /// <typeparam name="TValue">The type of values in the dictionary.</typeparam>
    /// <param name="source">The dictionary to check.</param>
    /// <param name="predicate">A function to test each key/value pair for a condition.</param>
    /// <returns><c>true</c> if the dictionary is not null and contains at least one element that satisfies the condition; otherwise, <c>false</c>.</returns>
    /// <example>
    /// Example usage:
    /// <code>
    /// var dict = new Dictionary&lt;int, string&gt; { { 1, "value1" }, { 2, "value2" } };
    /// bool hasSpecific = dict.HasAny(kvp => kvp.Key == 2); // returns true
    /// </code>
    /// </example>
    /// <exception cref="ArgumentNullException">Thrown if the <paramref name="predicate"/> is null.</exception>
#if !DEBUG
    [System.Diagnostics.DebuggerStepThrough]
#endif
    public static bool HasAny<TKey, TValue>(this IDictionary<TKey, TValue> source, Func<KeyValuePair<TKey, TValue>, bool> predicate)
        => source != null && source.Any(predicate);
}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace MeControla.Core.Extensions
{
    public static class EnumerableExtension
    {
        [DebuggerStepThrough]
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> enumerable)
            => enumerable == null || !enumerable.Any();

        [DebuggerStepThrough]
        public static bool IsNotNullAndAny<T>(this IEnumerable<T> enumerable)
            => enumerable != null && enumerable.Any();

        [DebuggerStepThrough]
        public static IList<T> ToListOrNull<T>(this IEnumerable<T> enumerable)
            => enumerable.IsNullOrEmpty() ? null : enumerable.ToList();

        [DebuggerStepThrough]
        public static IList<TResult> SelectToListOrNull<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
            => source.IsNullOrEmpty() ? null : source.Select(selector).ToList();

        [DebuggerStepThrough]
        public static IList<TResult> SelectToListOrNull<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, int, TResult> selector)
            => source.IsNullOrEmpty() ? null : source.Select(selector).ToList();

        [DebuggerStepThrough]
        public static void ForEach<T>(this IEnumerable<T> enumeration, Action<T> action)
        {
            foreach (T item in enumeration)
                action(item);
        }

        [DebuggerStepThrough]
        public static IEnumerable<int> FindIndexAll<T>(this IEnumerable<T> data, Predicate<T> match)
        {
            var list = (List<T>)data;

            return Enumerable.Range(0, data.Count())
                             .Where(i => match(list[i]));
        }
    }
}
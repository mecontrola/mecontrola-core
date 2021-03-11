using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace MeControla.Core.Extensions
{
    public static class ListExtension
    {
        [DebuggerStepThrough]
        public static bool IsNullOrEmpty<T>(this IList<T> enumerable)
            => enumerable == null || !enumerable.Any();

        [DebuggerStepThrough]
        public static bool IsNotNullAndAny<T>(this IList<T> enumerable)
            => enumerable != null && enumerable.Any();

        [DebuggerStepThrough]
        public static IList<T> ToListOrNull<T>(this IList<T> enumerable)
            => enumerable.IsNullOrEmpty() ? null : enumerable.ToList();
    }
}
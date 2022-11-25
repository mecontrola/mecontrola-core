using System.Collections.Generic;
using System.Linq;

namespace MeControla.Core.Extensions
{
    public static class ListExtensions
    {
#if !DEBUG
        [System.Diagnostics.DebuggerStepThrough]
#endif
        public static bool IsNullOrEmpty<T>(this IList<T> enumerable)
            => enumerable == null || !enumerable.Any();

#if !DEBUG
        [System.Diagnostics.DebuggerStepThrough]
#endif
        public static bool IsNotNullAndAny<T>(this IList<T> enumerable)
            => enumerable != null && enumerable.Any();

#if !DEBUG
        [System.Diagnostics.DebuggerStepThrough]
#endif
        public static IList<T> ToListOrNull<T>(this IList<T> enumerable)
            => enumerable.IsNullOrEmpty() ? null : enumerable.ToList();
    }
}
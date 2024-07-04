using System;
using System.Collections.Generic;
using System.Linq;

namespace MeControla.Core.Extensions
{
    public static class DictionaryExtensions
    {
#if !DEBUG
        [System.Diagnostics.DebuggerStepThrough]
#endif
        public static bool HasAny<TKey, TValue>(this IDictionary<TKey, TValue> elm)
            => elm != null && elm.Any();

#if !DEBUG
        [System.Diagnostics.DebuggerStepThrough]
#endif
        public static bool HasAny<TKey, TValue>(this IDictionary<TKey, TValue> elm, Func<KeyValuePair<TKey, TValue>, bool> predicate)
            => elm != null && elm.Any(predicate);
    }
}
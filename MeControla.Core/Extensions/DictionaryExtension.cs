using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace MeControla.Core.Extensions
{
    public static class DictionaryExtension
    {
        [DebuggerStepThrough]
        public static bool HasAny<TKey, TValue>(this IDictionary<TKey, TValue> elm)
            => elm != null && elm.Any();
    }
}
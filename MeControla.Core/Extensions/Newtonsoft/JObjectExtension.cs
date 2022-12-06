using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics.CodeAnalysis;

namespace MeControla.Core.Extensions.Newtonsoft
{
    public static class JObjectExtension
    {
#if !DEBUG
        [System.Diagnostics.DebuggerStepThrough]
#endif
        [SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "<Pending>")]
        public static T ToAnonymousType<T>(this JObject source, T template)
            => source.ToObject<T>();

#if !DEBUG
        [System.Diagnostics.DebuggerStepThrough]
#endif
        [SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "<Pending>")]
        public static T ToAnonymousType<T>(this JObject source, T template, JsonSerializer jsonSerializer)
            => source.ToObject<T>(jsonSerializer);
    }
}
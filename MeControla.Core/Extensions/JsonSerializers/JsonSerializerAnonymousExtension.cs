using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

namespace MeControla.Core.Extensions.JsonSerializers
{
    public static class JsonSerializerAnonymousExtension
    {
#if !DEBUG
        [System.Diagnostics.DebuggerStepThrough]
#endif
        [RequiresUnreferencedCode("IDE0060:Remove unused parameter")]
        public static T ToAnonymousType<T>(this string source, T template)
            => JsonSerializer.Deserialize<T>(source);

#if !DEBUG
        [System.Diagnostics.DebuggerStepThrough]
#endif
        [RequiresUnreferencedCode("IDE0060:Remove unused parameter")]
        public static T ToAnonymousType<T>(this string source, T template, JsonSerializerOptions jsonSerializer)
            => JsonSerializer.Deserialize<T>(source, jsonSerializer);
    }
}
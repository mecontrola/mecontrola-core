using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

namespace MeControla.Core.Extensions.JsonSerializers
{
    public static class JsonSerializerAnonymousExtension
    {
#if !DEBUG
        [System.Diagnostics.DebuggerStepThrough]
#endif
        [RequiresUnreferencedCode("Use 'MethodFriendlyToTrimming' instead")]
        public static T ToAnonymousType<T>(this string source)
            => JsonSerializer.Deserialize<T>(source);

#if !DEBUG
        [System.Diagnostics.DebuggerStepThrough]
#endif
        [RequiresUnreferencedCode("Use 'MethodFriendlyToTrimming' instead")]
        public static T ToAnonymousType<T>(this string source, JsonSerializerOptions jsonSerializer)
            => JsonSerializer.Deserialize<T>(source, jsonSerializer);
    }
}
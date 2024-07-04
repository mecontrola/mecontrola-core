using Microsoft.Extensions.Configuration;
using System.Diagnostics.CodeAnalysis;

namespace MeControla.Core.Extensions
{
    public static class ConfigurationExtensions
    {
#if !DEBUG
        [System.Diagnostics.DebuggerStepThrough]
#endif
        [RequiresUnreferencedCode("Use 'MethodFriendlyToTrimming' instead")]
        public static T Load<T>(this IConfiguration configuration)
            where T : new()
        {
            var section = configuration.GetSection(typeof(T).Name);
            if (!section.Exists())
                return default;

            var cfg = new T();

            section.Bind(cfg);

            return cfg;
        }
    }
}
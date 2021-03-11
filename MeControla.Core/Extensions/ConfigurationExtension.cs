using Microsoft.Extensions.Configuration;
using System.Diagnostics;

namespace MeControla.Core.Extensions
{
    public static class ConfigurationExtension
    {
        [DebuggerStepThrough]
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
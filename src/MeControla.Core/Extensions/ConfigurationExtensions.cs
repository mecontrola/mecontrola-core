using Microsoft.Extensions.Configuration;
using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace MeControla.Core.Extensions
{
    public static class ConfigurationExtensions
    {
        private const string FILENAME_APPSETTINGS_DEFAULT = "appsettings.json";

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

#if !DEBUG
        [System.Diagnostics.DebuggerStepThrough]
#endif
        [RequiresUnreferencedCode("Serialization may require unreferenced code.")]
        public static IConfiguration SetValue<T>(this IConfiguration configuration, string key, T value)
            => SetValue(configuration, key, value, FILENAME_APPSETTINGS_DEFAULT);

#if !DEBUG
        [System.Diagnostics.DebuggerStepThrough]
#endif
        [RequiresUnreferencedCode("Serialization may require unreferenced code.")]
        public static IConfiguration SetValue<T>(this IConfiguration configuration, string key, T value, string filename)
        {
            var filePath = GetAppSettingsFilePath(filename);
            var json = File.ReadAllText(filePath);
            var jsonObj = JsonNode.Parse(json);

            var sections = key.Split(':');
            JsonNode node = jsonObj;

            for (int i = 0; i < sections.Length - 1; i++)
            {
                var section = sections[i];
                if (node![section] == null)
                    node[section] = new JsonObject();

                node = node[section];
            }

            node![sections[^1]] = JsonValue.Create(value);

            string output = jsonObj.ToJsonString(GetJsonOptions());

            File.WriteAllText(filePath, output);

            return configuration;
        }

        private static string GetAppSettingsFilePath(string filename)
            => Path.Combine(AppContext.BaseDirectory, filename);

        [RequiresUnreferencedCode("Serialization may require unreferenced code.")]
        private static JsonSerializerOptions GetJsonOptions()
            => new()
            {
                WriteIndented = true,
                TypeInfoResolver = JsonSerializerOptions.Default.TypeInfoResolver
            };
    }
}
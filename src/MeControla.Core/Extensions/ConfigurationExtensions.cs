/***********************************************************************************
 * Copyright 2024 Me Controla
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 ***********************************************************************************/

using Microsoft.Extensions.Configuration;
using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace MeControla.Core.Extensions;

/// <summary>
/// Provides extension methods for <see cref="IConfiguration"/> to facilitate configuration loading and value setting.
/// </summary>
public static class ConfigurationExtensions
{
    private const string FILENAME_APPSETTINGS_DEFAULT = "appsettings.json";

    /// <summary>
    /// Loads configuration settings into an instance of the specified type.
    /// </summary>
    /// <typeparam name="T">The type of the object to load the configuration into.</typeparam>
    /// <param name="configuration">The <see cref="IConfiguration"/> instance to load from.</param>
    /// <returns>An instance of <typeparamref name="T"/> populated with the configuration values.</returns>
#if !DEBUG
    [System.Diagnostics.DebuggerStepThrough]
#endif
    [RequiresUnreferencedCode("Use 'MethodFriendlyToTrimming' instead")]
    public static T? Load<T>(this IConfiguration configuration)
        where T : new()
    {
        var section = configuration.GetSection(typeof(T).Name);
        if (!section.Exists())
            return default;

        var cfg = new T();

        section.Bind(cfg);

        return cfg;
    }

    /// <summary>
    /// Sets a value in the configuration with the specified key.
    /// </summary>
    /// <typeparam name="T">The type of the value being set.</typeparam>
    /// <param name="configuration">The <see cref="IConfiguration"/> instance to set the value in.</param>
    /// <param name="key">The key for the configuration value.</param>
    /// <param name="value">The value to set for the specified key.</param>
    /// <returns>The updated <see cref="IConfiguration"/> instance.</returns>
#if !DEBUG
    [System.Diagnostics.DebuggerStepThrough]
#endif
    [RequiresUnreferencedCode("Serialization may require unreferenced code.")]
    public static IConfiguration SetValue<T>(this IConfiguration configuration, string key, T value)
        => SetValue(configuration, key, value, FILENAME_APPSETTINGS_DEFAULT);

    /// <summary>
    /// Sets a value in the configuration with the specified key and associates it with a filename.
    /// </summary>
    /// <typeparam name="T">The type of the value being set.</typeparam>
    /// <param name="configuration">The <see cref="IConfiguration"/> instance to set the value in.</param>
    /// <param name="key">The key for the configuration value.</param>
    /// <param name="value">The value to set for the specified key.</param>
    /// <param name="filename">The name of the file to associate with the configuration value.</param>
    /// <returns>The updated <see cref="IConfiguration"/> instance.</returns>
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
        JsonNode? node = jsonObj;

        for (int i = 0; i < sections.Length - 1; i++)
        {
            var section = sections[i];
            if (node![section] == null)
                node[section] = new JsonObject();

            node = node[section];
        }

        node![sections[^1]] = JsonValue.Create(value);

        var output = jsonObj?.ToJsonString(GetJsonOptions()) ?? string.Empty;

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
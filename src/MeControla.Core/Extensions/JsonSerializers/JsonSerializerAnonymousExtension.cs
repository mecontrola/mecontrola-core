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

using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

namespace MeControla.Core.Extensions.JsonSerializers;

/// <summary>
/// Extension class for deserializing JSON strings into anonymous types using <see cref="JsonSerializer"/>.
/// </summary>
public static class JsonSerializerAnonymousExtension
{
    internal const string EXCEPTION_ARGUMENT_SOURCE_MESSAGE = "The source string cannot be null or empty.";
    internal const string EXCEPTION_DESERIALIZING_MESSAGE = "Error deserializing the JSON string.";

    /// <summary>
    /// Deserializes a JSON string into an anonymous type.
    /// </summary>
    /// <typeparam name="T">The target anonymous or explicit type.</typeparam>
    /// <param name="source">The JSON string to be deserialized.</param>
    /// <returns>An object of type <typeparamref name="T"/> deserialized from the JSON.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="source"/> parameter is null or empty.</exception>
    /// <exception cref="JsonException">Thrown when the string is not valid JSON.</exception>
#if !DEBUG
    [System.Diagnostics.DebuggerStepThrough]
#endif
    [RequiresUnreferencedCode("Use 'MethodFriendlyToTrimming' instead")]
    public static T? ToAnonymousType<T>(this string source)
        => InternalToAnonymousType<T>(source, null);

    /// <summary>
    /// Deserializes a JSON string into an anonymous type using custom serialization options.
    /// </summary>
    /// <typeparam name="T">The target anonymous or explicit type.</typeparam>
    /// <param name="source">The JSON string to be deserialized.</param>
    /// <param name="jsonSerializerOptions">Custom deserialization options.</param>
    /// <returns>An object of type <typeparamref name="T"/> deserialized from the JSON.</returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown when the <paramref name="source"/> or <paramref name="jsonSerializerOptions"/> is null.
    /// </exception>
    /// <exception cref="JsonException">Thrown when the string is not valid JSON.</exception>
#if !DEBUG
    [System.Diagnostics.DebuggerStepThrough]
#endif
    [RequiresUnreferencedCode("Use 'MethodFriendlyToTrimming' instead")]
    public static T? ToAnonymousType<T>(this string source, JsonSerializerOptions jsonSerializerOptions)
        => InternalToAnonymousType<T>(source, jsonSerializerOptions);

    [RequiresUnreferencedCode("Use 'MethodFriendlyToTrimming' instead")]
    private static T? InternalToAnonymousType<T>(this string source, JsonSerializerOptions? jsonSerializerOptions)
    {
        if (source.IsNullOrWhiteSpace())
            throw new ArgumentNullException(nameof(source), EXCEPTION_ARGUMENT_SOURCE_MESSAGE);

        try
        {
            return JsonSerializer.Deserialize<T>(source, jsonSerializerOptions);
        }
        catch (JsonException ex)
        {
            throw new JsonException(EXCEPTION_DESERIALIZING_MESSAGE, ex);
        }
    }
}
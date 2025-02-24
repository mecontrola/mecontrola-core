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

using System.Globalization;
using System.Text.Json.Serialization;

#pragma warning disable IDE0130 // Namespace does not match folder structure
namespace System.Text.Json;
#pragma warning restore IDE0130 // Namespace does not match folder structure

/// <summary>
/// A custom JSON converter for handling <see cref="DateTime"/> serialization and deserialization
/// using a specified date format.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="DateTimeConverter"/> class
/// with a specified date format for conversion.
/// </remarks>
/// <param name="dateFormat">The date format string to use for parsing and formatting <see cref="DateTime"/> values.</param>
public class DateTimeConverter(string dateFormat) : JsonConverter<DateTime>
{
    /// <summary>
    /// Reads and converts a JSON string to a <see cref="DateTime"/> object using the specified date format.
    /// </summary>
    /// <param name="reader">The <see cref="Utf8JsonReader"/> to read from.</param>
    /// <param name="typeToConvert">The type to convert, which is <see cref="DateTime"/>.</param>
    /// <param name="options">Options for reading JSON.</param>
    /// <returns>A <see cref="DateTime"/> object parsed from the JSON string.</returns>
    /// <exception cref="FormatException">Thrown if the string cannot be parsed into a <see cref="DateTime"/>.</exception>
    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();

        ArgumentException.ThrowIfNullOrWhiteSpace(value);

        return DateTime.ParseExact(value, dateFormat, CultureInfo.InvariantCulture);
    }

    /// <summary>
    /// Writes a <see cref="DateTime"/> object to a JSON string using the specified date format.
    /// </summary>
    /// <param name="writer">The <see cref="Utf8JsonWriter"/> to write to.</param>
    /// <param name="value">The <see cref="DateTime"/> value to write.</param>
    /// <param name="options">Options for writing JSON.</param>
    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        => writer.WriteStringValue(value.ToString(dateFormat, CultureInfo.InvariantCulture));
}
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
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MeControla.Core.Extensions;

/// <summary>
/// Extensions for String type as commonly used methods.
/// </summary>
public static partial class StringExtensions
{
    private static readonly TimeSpan REGEX_TIMEOUT = TimeSpan.FromSeconds(2);

    /// <summary>
    /// Determines whether the specified string is null or an empty string.
    /// </summary>
    /// <param name="value">The input string.</param>
    /// <returns>True if the string is null or empty; otherwise, false.</returns>
#if !DEBUG
    [System.Diagnostics.DebuggerStepThrough]
#endif
    public static bool IsNullOrEmpty(this string value)
        => string.IsNullOrEmpty(value);

    /// <summary>
    /// Determines whether the specified string is null, empty, or consists only of white-space characters.
    /// </summary>
    /// <param name="value">The input string.</param>
    /// <returns>True if the string is null, empty, or consists only of white-space characters; otherwise, false.</returns>
#if !DEBUG
    [System.Diagnostics.DebuggerStepThrough]
#endif
    public static bool IsNullOrWhiteSpace(this string value)
        => string.IsNullOrWhiteSpace(value);

    /// <summary>
    /// Converts the string to a Guid if possible.
    /// </summary>
    /// <param name="value">The input string.</param>
    /// <returns>The Guid representation of the string, or Guid.Empty if conversion fails.</returns>
#if !DEBUG
    [System.Diagnostics.DebuggerStepThrough]
#endif
    public static Guid ToGuid(this string value)
        => Guid.Parse(value);

    /// <summary>
    /// Constructs a DateTime from a string. The string must specify a date and optionally
    /// a time in a culture-specific or universal format. Leading and trailing whitespace
    /// characters are allowed.
    /// </summary>
    /// <param name="value">The input string.</param>
    /// <returns>The DateTime convert value.</returns>
#if !DEBUG
    [System.Diagnostics.DebuggerStepThrough]
#endif
    public static DateTime ToDateTime(this string value)
        => DateTime.Parse(value, CultureInfo.CurrentCulture);

    /// <summary>
    /// Converts the string to PascalCase format (first letter of each word capitalized).
    /// </summary>
    /// <param name="value">The input string.</param>
    /// <returns>The string in PascalCase format.</returns>
#if !DEBUG
    [System.Diagnostics.DebuggerStepThrough]
#endif
    public static string ToPascalCase(this string value)
        => value.ToTitleCase().Replace(" ", string.Empty);

    private const string PATTERN_CAMEL_CASE = @"[A-Z]{2,}(?=[A-Z][a-z]+[0-9]*|\b)|[A-Z]?[a-z]+[0-9]*|[A-Z]|[0-9]+";
    private static Regex RegexCamelCase()
        => new(PATTERN_CAMEL_CASE, RegexOptions.None, REGEX_TIMEOUT);

    /// <summary>
    /// Converts the string to CamelCase format (first letter lowercase, subsequent words with an uppercase first letter).
    /// </summary>
    /// <param name="value">The input string.</param>
    /// <returns>The string in CamelCase format.</returns>
#if !DEBUG
    [System.Diagnostics.DebuggerStepThrough]
#endif
    public static string ToCamelCase(this string value)
        => new(CultureInfo.InvariantCulture.TextInfo
                                           .ToTitleCase(string.Join(" ", RegexCamelCase().Matches(value)).ToLowerInvariant())
                                           .Replace(@" ", string.Empty)
                                           .Select((x, i) => i == 0 ? char.ToLowerInvariant(x) : x)
                                           .ToArray());

    private const string PATTERN_SNAKE_KEBAB_TITLE_CASE = @"[A-Z]{2,}(?=[A-Z][a-z]+[0-9]*|\b)|[A-Z]?[a-z]+[0-9]*|[A-Z]|[0-9]+";

    private static Regex RegexSnakeKebabTitleCase()
        => new(PATTERN_SNAKE_KEBAB_TITLE_CASE, RegexOptions.None, REGEX_TIMEOUT);

    /// <summary>
    /// Converts the string to SnakeCase format (words separated by "_", all lowercase).
    /// </summary>
    /// <param name="value">The input string.</param>
    /// <returns>The string in SnakeCase format.</returns>
#if !DEBUG
    [System.Diagnostics.DebuggerStepThrough]
#endif
    public static string ToSnakeCase(this string value)
    {
        var matches = RegexSnakeKebabTitleCase().Matches(value);
        return string.Join("_", matches)
                     .ToLowerInvariant();
    }

    /// <summary>
    /// Converts the string to KebabCase format (words separated by "-", all lowercase).
    /// </summary>
    /// <param name="value">The input string.</param>
    /// <returns>The string in KebabCase format.</returns>
#if !DEBUG
    [System.Diagnostics.DebuggerStepThrough]
#endif
    public static string ToKebabCase(this string value)
    {
        var matches = RegexSnakeKebabTitleCase().Matches(value);
        return string.Join("-", matches)
                     .ToLowerInvariant();
    }

    /// <summary>
    /// Converts the string to TitleCase format (first letter of each word capitalized).
    /// </summary>
    /// <param name="value">The input string.</param>
    /// <returns>The string in TitleCase format.</returns>
#if !DEBUG
    [System.Diagnostics.DebuggerStepThrough]
#endif
    public static string ToTitleCase(this string value)
    {
        var matches = RegexSnakeKebabTitleCase().Matches(value);
        return new CultureInfo("en-US", false).TextInfo
                                              .ToTitleCase(string.Join(" ", matches)
                                                                 .ToLowerInvariant());
    }

    /// <summary>
    /// Removes all non-numeric characters from the given string.
    /// </summary>
    /// <param name="value">The input string from which to remove non-numeric characters.</param>
    /// <returns>
    /// A string containing only the numeric characters extracted from the original string.
    /// If the input string is <c>null</c>, returns <c>null</c>.
    /// </returns>
#if !DEBUG
    [System.Diagnostics.DebuggerStepThrough]
#endif
    public static string OnlyNumbers(this string value)
        => Regex.Replace(value, @"\D+", string.Empty, RegexOptions.None, REGEX_TIMEOUT);

    /// <summary>
    /// Encodes the specified string into a Base64-encoded string using UTF-8 encoding.
    /// </summary>
    /// <param name="value">The string to encode.</param>
    /// <returns>The Base64-encoded representation of the input string.</returns>
    /// <exception cref="ArgumentNullException">Thrown if the input string is null.</exception>
#if !DEBUG
    [System.Diagnostics.DebuggerStepThrough]
#endif
    public static string Base64Encode(this string value)
    {
        if (value.IsNullOrEmpty())
            throw new ArgumentNullException(nameof(value), "Input string cannot be null or empty.");

        var bytes = Encoding.UTF8.GetBytes(value);
        return Convert.ToBase64String(bytes);
    }

    /// <summary>
    /// Decodes a Base64-encoded string to its original UTF-8 string format.
    /// </summary>
    /// <param name="value">The string to convert</param>
    /// <returns>The decoded string in UTF-8 format.</returns>
    /// <exception cref="ArgumentNullException">Thrown if the input string is null.</exception>
    /// <exception cref="FormatException">Thrown if the input string is not a valid Base64 string.</exception>
#if !DEBUG
    [System.Diagnostics.DebuggerStepThrough]
#endif
    public static string Base64Decode(this string value)
    {
        if (value.IsNullOrEmpty())
            throw new ArgumentNullException(nameof(value), "Input string cannot be null or empty.");

        var bytes = Convert.FromBase64String(value);
        return Encoding.UTF8.GetString(bytes);
    }

    /// <summary>
    /// Trims the whitespace from anywhere of the string.
    /// Whitespace is defined by char.IsWhiteSpace.
    /// </summary>
    /// <param name="value">The input string.</param>
    /// <returns>The clean string.</returns>
#if !DEBUG
    [System.Diagnostics.DebuggerStepThrough]
#endif
    public static string TrimAll(this string value)
        => Regex.Replace(value, @"\s+", " ", RegexOptions.None, REGEX_TIMEOUT).Trim();

    /// <summary>
    /// Converts a string representation of a date and time to a nullable <see cref="DateTime"/>.
    /// </summary>
    /// <param name="value">The string value to convert. If <c>null</c> or not in a valid date format, returns <c>null</c>.</param>
    /// <returns>
    /// A nullable <see cref="DateTime"/> representing the converted date and time. 
    /// Returns <c>null</c> if the input string is <c>null</c> or cannot be parsed into a valid date and time.
    /// </returns>
#if !DEBUG
    [System.Diagnostics.DebuggerStepThrough]
#endif
    public static DateTime? ToNullableDateTime(this string value)
    {
        try
        {
            return Convert.ToDateTime(value, CultureInfo.InvariantCulture);
        }
        catch (FormatException)
        {
            return null;
        }
    }

    /// <summary>
    /// Converts a string representation of a number to a nullable <see cref="decimal"/>.
    /// </summary>
    /// <param name="value">The string value to convert. If <c>null</c> or not in a valid numeric format, returns <c>null</c>.</param>
    /// <returns>
    /// A nullable <see cref="decimal"/> representing the converted number. 
    /// Returns <c>null</c> if the input string is <c>null</c> or cannot be parsed into a valid decimal number.
    /// </returns>
#if !DEBUG
    [System.Diagnostics.DebuggerStepThrough]
#endif
    public static decimal? ToDecimal(this string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return null;

        var str = value.Replace(",", ".");
        str = Regex.Replace(str, @"[^\d|.]", string.Empty, RegexOptions.None, REGEX_TIMEOUT);

        try
        {
            return decimal.Parse(str, CultureInfo.InvariantCulture.NumberFormat);
        }
        catch (FormatException)
        {
            return null;
        }
        catch (OverflowException)
        {
            return null;
        }
    }

    /// <summary>
    /// Converts the first letter of the string to uppercase and the remaining letters to lowercase.
    /// </summary>
    /// <param name="value">The input string.</param>
    /// <returns>The string with the first letter in uppercase and the rest in lowercase.</returns>
#if !DEBUG
    [System.Diagnostics.DebuggerStepThrough]
#endif
    public static string ToFirstUpper(this string value)
        => string.IsNullOrWhiteSpace(value)
         ? string.Empty
         : $"{value[0].ToString().ToUpperInvariant()}{value[1..]}";

    /// <summary>
    /// Extracts all consonants from the given string.
    /// </summary>
    /// <param name="value">The input string.</param>
    /// <returns>Only according to string consonants</returns>
#if !DEBUG
    [System.Diagnostics.DebuggerStepThrough]
#endif
    public static string GetConsonants(this string value)
        => Regex.Replace(value, "[aeiou]", string.Empty, RegexOptions.IgnoreCase, REGEX_TIMEOUT);

    /// <summary>
    /// Convert all first letters of a string to uppercase.
    /// </summary>
    /// <param name="value">The input string.</param>
    /// <returns>A string with words with the first letter capitalized.</returns>
#if !DEBUG
    [System.Diagnostics.DebuggerStepThrough]
#endif
    public static string GetUpperLetters(this string value)
        => string.Concat(value.Where(c => c >= 'A' && c <= 'Z'));

    /// <summary>
    /// Formats the specified string using the provided arguments.
    /// </summary>
    /// <param name="value">The string template with placeholders.</param>
    /// <param name="args">The arguments to be inserted into the template.</param>
    /// <returns>A formatted string with the arguments inserted.</returns>
#if !DEBUG
    [System.Diagnostics.DebuggerStepThrough]
#endif
    public static string Format(this string value, params object[] args)
    {
        if (value.IsNullOrWhiteSpace())
            throw new ArgumentNullException(nameof(value), "Template string cannot be null or empty.");

        return string.Format(CultureInfo.InvariantCulture, value, args);
    }
}
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

using System.Linq;

namespace MeControla.Core.Extensions.DataStorage;

/// <summary>
/// Provides extension methods for manipulating and formatting string values, 
/// specifically for generating table and column prefixes.
/// </summary>
public static class StringExtension
{
    /// <summary>
    /// Formats a string value as a column name by converting it to snake case and 
    /// appending a given prefix.
    /// </summary>
    /// <param name="value">The string value to be converted.</param>
    /// <param name="prefix">The prefix to prepend to the string.</param>
    /// <returns>The formatted column name in snake case with the specified prefix.</returns>
#if !DEBUG
    [System.Diagnostics.DebuggerStepThrough]
#endif
    public static string GetColumnName(this string value, string prefix)
        => $"{prefix}_{value.ToSnakeCase()}";

    /// <summary>
    /// Generates a prefix for a table name based on the string value. 
    /// It either concatenates the first letter of each word or creates a prefix based on consonants.
    /// </summary>
    /// <param name="value">The string value representing the table name.</param>
    /// <returns>A string representing the generated table prefix.</returns>
#if !DEBUG
    [System.Diagnostics.DebuggerStepThrough]
#endif
    public static string GetPrefixTable(this string value)
    {
        var valueTmp = value.ToTitleCase().TrimAll();
        var words = valueTmp.Split(" ");
        var prefix = string.Empty;

        prefix = words.Length > 1
               ? string.Concat(words.Select(x => x[0])).ToLower()
               : $"{valueTmp[0]}{valueTmp[1..].GetConsonants()}"[..2];

        return prefix.ToLower();
    }

    /// <summary>
    /// Generates a prefix for a column name based on the string value. 
    /// It uses different strategies depending on the number of words in the input string.
    /// </summary>
    /// <param name="value">The string value representing the column name.</param>
    /// <returns>A string representing the generated column prefix.</returns>
#if !DEBUG
    [System.Diagnostics.DebuggerStepThrough]
#endif
    public static string GetPrefixColumn(this string value)
    {
        var valueTmp = value.ToTitleCase().TrimAll();
        var words = valueTmp.Split(" ");
        var prefix = string.Empty;

        prefix = words.Length switch
        {
            >= 3 => valueTmp.GetUpperLetters(),
            2 => string.Concat(words.Select(x => x[..1] + x[1..].GetConsonants()[..1])),
            _ => $"{valueTmp[0]}{CheckSingleWord(valueTmp)}"[..3],
        };

        return prefix.ToLower();

        static string CheckSingleWord(string word)
        {
            var prefix = word[1..].GetConsonants();
            return prefix.Length == 1 ? $"{prefix}{word[^1]}" : prefix;
        }
    }
}
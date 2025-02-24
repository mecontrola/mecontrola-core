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

namespace MeControla.Core.Extensions;

using System;
using System.Text.RegularExpressions;

/// <summary>
/// Provides extension methods for string manipulation, specifically for extracting version information.
/// </summary>
public static class StringVersionExtensions
{
    private static readonly TimeSpan REGEX_TIMEOUT = TimeSpan.FromSeconds(2);

    private const string REGEX_VERSION_KEY = "version";
    private const string REGEX_VERSION = $@"(?<{REGEX_VERSION_KEY}>[0-9]+.[0-9]+.[0-9]+(.[0-9]+)?)";

    private static readonly Regex VersionRegex = new(REGEX_VERSION, RegexOptions.Compiled, REGEX_TIMEOUT);

    /// <summary>
    /// Extracts the version number from the given string using a regex pattern.
    /// </summary>
    /// <param name="value">The string containing the version information.</param>
    /// <returns>
    /// A <see cref="Version"/> object representing the extracted version, or <c>null</c> if the version
    /// string is not found or invalid.
    /// </returns>
#if !DEBUG
    [System.Diagnostics.DebuggerStepThrough]
#endif
    public static Version? GetVersion(this string value)
    {
        if (value.IsNullOrWhiteSpace())
            return null;

        var match = VersionRegex.Match(value);
        return match.Success
             ? new(match.GetValueOrDefault(REGEX_VERSION_KEY)!)
             : null;
    }
}
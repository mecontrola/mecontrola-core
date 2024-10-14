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

namespace MeControla.Core.Extensions;

/// <summary>
/// Provides extension methods for working with integers.
/// </summary>
public static class IntegerExtensions
{
    /// <summary>
    /// Pads the integer with leading zeros to ensure it reaches the specified total length.
    /// </summary>
    /// <param name="source">The integer to be padded.</param>
    /// <param name="length">The total length of the resulting string, including any leading zeros.</param>
    /// <returns>A string representation of the integer, padded with leading zeros if necessary to reach the specified length.</returns>
    /// <example>
    /// Example usage:
    /// <code>
    /// int number = 42;
    /// string padded = number.Pad(5); // Returns "00042"
    /// </code>
    /// </example>
    /// <remarks>
    /// The method formats the integer using the "D" format specifier, which pads the number with leading zeros.
    /// </remarks>
    public static string Pad(this int source, int length)
        => source.ToString($"D{length}", CultureInfo.InvariantCulture);
}
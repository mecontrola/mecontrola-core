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

namespace MeControla.Core.Extensions;

/// <summary>
/// Provides extension methods for working with <see cref="DateTime"/> objects.
/// </summary>
public static class DateTimeExtensions
{
    /// <summary>
    /// Retrieves the week number of the year for the specified <see cref="DateTime"/> value.
    /// </summary>
    /// <param name="value">The <see cref="DateTime"/> to calculate the week number for.</param>
    /// <returns>The week number of the year, as an integer.</returns>
    /// <example>
    /// Example usage:
    /// <code>
    /// var date = new DateTime(2024, 9, 25);
    /// int weekOfYear = date.GetWeekOfYear(); 
    /// // Output could be 39, depending on the culture's calendar.
    /// </code>
    /// </example>
    /// <remarks>
    /// This method uses the current culture's calendar and assumes that weeks start on Monday and follow the <see cref="CalendarWeekRule.FirstFourDayWeek"/> rule.
    /// </remarks>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown if the <see cref="DateTime"/> value is outside the valid range of dates supported by the calendar.
    /// </exception>
#if !DEBUG
    [System.Diagnostics.DebuggerStepThrough]
#endif
    public static int GetWeekOfYear(this DateTime value)
        => CultureInfo.CurrentCulture
                      .Calendar
                      .GetWeekOfYear(value, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
}
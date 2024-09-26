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
using System.ComponentModel;
using System.Reflection;

namespace MeControla.Core.Extensions;

/// <summary>
/// Provides extension methods for working with Enums, such as retrieving the description attribute.
/// </summary>
public static class EnumExtensions
{
    /// <summary>
    /// Retrieves the description of an enum value if a <see cref="DescriptionAttribute"/> is applied to it.
    /// </summary>
    /// <param name="value">The enum value for which the description is to be retrieved.</param>
    /// <returns>
    /// The description of the enum value as defined by the <see cref="DescriptionAttribute"/>, 
    /// or null if no description attribute is found.
    /// </returns>
    /// <example>
    /// Given an enum with a description:
    /// <code>
    /// public enum Status
    /// {
    ///     [Description("Operation completed successfully")]
    ///     Success,
    ///     
    ///     [Description("Operation failed")]
    ///     Failure
    /// }
    /// 
    /// var description = Status.Success.GetDescription(); // Returns "Operation completed successfully"
    /// </code>
    /// </example>
    public static string GetDescription(this Enum value)
        => value.GetType()
                .GetField(value.ToString())
                .GetCustomAttribute<DescriptionAttribute>()?
                .Description ?? null;
}
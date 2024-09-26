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
using System.Reflection;

namespace MeControla.Core.Extensions;

/// <summary>
/// Provides extension methods for working with <see cref="FieldInfo"/>, 
/// specifically for retrieving custom attributes.
/// </summary>
public static class FieldInfoExtensions
{
    /// <summary>
    /// Retrieves a custom attribute of a specified type from a <see cref="FieldInfo"/> object.
    /// </summary>
    /// <typeparam name="T">The type of the attribute to retrieve. Must inherit from <see cref="Attribute"/>.</typeparam>
    /// <param name="fieldInfo">The <see cref="FieldInfo"/> from which to retrieve the attribute.</param>
    /// <returns>
    /// The custom attribute of type <typeparamref name="T"/> if found, otherwise null.
    /// </returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="fieldInfo"/> is null.</exception>
    /// <example>
    /// Given a field with a custom attribute:
    /// <code>
    /// public class SampleClass
    /// {
    ///     [Description("Sample field")]
    ///     public string Field;
    /// }
    /// 
    /// var fieldInfo = typeof(SampleClass).GetField("Field");
    /// var description = fieldInfo.GetCustomAttribute&lt;DescriptionAttribute&gt;();
    /// </code>
    /// </example>
    public static T GetCustomAttribute<T>(this FieldInfo fieldInfo)
        where T : Attribute
        => (T)fieldInfo.GetCustomAttribute(typeof(T));
}
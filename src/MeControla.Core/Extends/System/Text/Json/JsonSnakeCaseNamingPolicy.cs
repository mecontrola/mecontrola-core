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

using MeControla.Core.Extensions;

namespace System.Text.Json;

/// <summary>
/// A <see cref="JsonNamingPolicy"/> implementation that converts property names to snake_case.
/// </summary>
/// <remarks>
/// This class is used to ensure that property names are serialized in snake_case format.
/// The <see cref="ConvertName"/> method applies the snake_case conversion to the property names.
/// </remarks>
public class JsonSnakeCaseNamingPolicy : JsonNamingPolicy
{
#if !DEBUG
[System.Diagnostics.DebuggerStepThrough]
#endif
    /// <summary>
    /// Converts the specified property name to snake_case format.
    /// </summary>
    /// <param name="name">The name of the property to be converted.</param>
    /// <returns>The property name in snake_case format.</returns>
    public override string ConvertName(string name)
        => name.ToSnakeCase();
}
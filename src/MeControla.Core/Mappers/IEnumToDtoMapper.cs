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

using MeControla.Core.Data.Enums;
using System;
using System.Collections.Generic;

namespace MeControla.Core.Mappers;

/// <summary>
/// Defines a contract for mapping objects of type <typeparamref name="TParam"/>, which extends <see cref="Enum"/>, 
/// to objects of type <typeparamref name="TResult"/>, which implement <see cref="IEnumDto"/>.
/// </summary>
/// <typeparam name="TParam">The source type that extends <see cref="Enum"/> to be mapped from.</typeparam>
/// <typeparam name="TResult">The destination type that implements <see cref="IEnumDto"/> to be mapped to.</typeparam>
public interface IEnumToDtoMapper<TParam, TResult>
    where TParam : Enum
    where TResult : IEnumDto
{
    /// <summary>
    /// Maps an instance of <typeparamref name="TParam"/> to a new instance of <typeparamref name="TResult"/>.
    /// </summary>
    /// <param name="obj">The source object to be mapped.</param>
    /// <returns>A new instance of <typeparamref name="TResult"/> mapped from the source object.</returns>
    TResult ToMap(TParam obj);

    /// <summary>
    /// Maps an instance of <typeparamref name="TParam"/> to an existing instance of <typeparamref name="TResult"/>.
    /// </summary>
    /// <param name="obj">The source object to be mapped.</param>
    /// <param name="result">The existing destination object to be populated with the mapped values.</param>
    /// <returns>The populated <typeparamref name="TResult"/> instance.</returns>
    TResult ToMap(TParam obj, TResult result);

    /// <summary>
    /// Maps a collection of <typeparamref name="TParam"/> instances to a list of <typeparamref name="TResult"/> instances.
    /// </summary>
    /// <typeparam name="T">The type of collection containing the source objects, which must implement both <see cref="IList{TParam}"/> and <see cref="ICollection{TParam}"/>.</typeparam>
    /// <param name="list">The collection of source objects to be mapped.</param>
    /// <returns>A list of mapped <typeparamref name="TResult"/> instances.</returns>
    IList<TResult> ToMapList<T>(T list)
        where T : IList<TParam>, ICollection<TParam>;
}
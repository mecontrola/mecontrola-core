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

using AutoMapper;
using MeControla.Core.Data.Enums;
using MeControla.Core.Extensions;
using System;
using System.Globalization;

namespace MeControla.Core.Mappers;

/// <summary>
/// Provides a base implementation for mapping enumeration values of type <typeparamref name="TParam"/> 
/// to DTOs of type <typeparamref name="TResult"/>.
/// </summary>
/// <typeparam name="TParam">The enum type to be mapped. Must be a struct and an enum.</typeparam>
/// <typeparam name="TResult">The DTO type that extends <see cref="BaseEnumItemDto"/>. Must have a parameterless constructor.</typeparam>
#if !DEBUG
[System.Diagnostics.DebuggerStepThrough]
#endif
public abstract class BaseEnumToDtoMapper<TParam, TResult> : InternalBaseMapper<TParam, TResult>, IEnumToDtoMapper<TParam, TResult>
    where TParam : struct, Enum
    where TResult : BaseEnumItemDto, new()
{
    /// <summary>
    /// Configures the mapping between the enum <typeparamref name="TParam"/> and the DTO <typeparamref name="TResult"/>.
    /// </summary>
    /// <param name="map">The <see cref="IMappingExpression{TParam, TResult}"/> used to define the mapping configuration.</param>
    protected override void MapFields(IMappingExpression<TParam, TResult> map)
        => map.ConvertUsing((source, destionation) =>
        {
            if (!Enum.IsDefined(typeof(TParam), source))
                return null;

            destionation ??= new TResult();
            destionation.Id = Convert.ToUInt32(source, CultureInfo.InvariantCulture);
            destionation.Value = source.GetDescription();

            return destionation;
        });
}
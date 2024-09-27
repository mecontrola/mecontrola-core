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

using MeControla.Core.Data.Dtos;
using MeControla.Core.Data.Entities;

namespace MeControla.Core.Mappers;

/// <summary>
/// Defines a contract for mapping objects of type <typeparamref name="TParam"/>, which implement <see cref="IInputDto"/>, 
/// to objects of type <typeparamref name="TResult"/>, which implement <see cref="IEntity"/>.
/// </summary>
/// <typeparam name="TParam">The source type that implements <see cref="IInputDto"/> to be mapped from.</typeparam>
/// <typeparam name="TResult">The destination type that implements <see cref="IEntity"/> to be mapped to.</typeparam>
public interface IInputDtoToEntityMapper<TParam, TResult> : IMapper<TParam, TResult>
    where TParam : class, IInputDto
    where TResult : class, IEntity
{ }
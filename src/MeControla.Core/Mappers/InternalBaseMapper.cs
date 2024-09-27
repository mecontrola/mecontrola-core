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
using System.Collections.Generic;
using System.Linq;

namespace MeControla.Core.Mappers;

/// <summary>
/// Provides a base class for internal mapping logic between objects of type <typeparamref name="TParam"/> and <typeparamref name="TResult"/>.
/// </summary>
/// <typeparam name="TParam">The source type to be mapped from.</typeparam>
/// <typeparam name="TResult">The destination type to be mapped to. Must be a reference type.</typeparam>
#if !DEBUG
[System.Diagnostics.DebuggerStepThrough]
#endif
public abstract class InternalBaseMapper<TParam, TResult>
     where TResult : class
{
    private readonly IMapper mapper;

    /// <summary>
    /// Creates the mapping configuration defined through the <see cref="MapFields"/> method in its constructor, 
    /// to be used later in the methods <see cref="ToMap(TParam)"/>, <see cref="ToMap(TParam, TResult)"/> e <see cref="ToMapList"/>.
    /// </summary>
    protected InternalBaseMapper()
        => mapper = new MapperConfiguration(cfg => CreateMap(cfg)).CreateMapper();

    private void CreateMap(IMapperConfigurationExpression cfg)
        => MapFields(cfg.CreateMap<TParam, TResult>());

    /// <summary>
    /// Method used to configure the mapping between the two types defined in the construction of the class.
    /// </summary>
    /// <param name="map">The <see cref="IMappingExpression{TParam, TResult}"/> used to define the mapping configuration.</param>
    protected virtual void MapFields(IMappingExpression<TParam, TResult> map)
    { }

    /// <summary>
    /// Maps an instance of <typeparamref name="TParam"/> to a new instance of <typeparamref name="TResult"/>.
    /// </summary>
    /// <param name="obj">The source object to be mapped.</param>
    /// <returns>A new instance of <typeparamref name="TResult"/> mapped from the source object.</returns>
    public TResult ToMap(TParam obj)
        => mapper.Map<TResult>(obj);

    /// <summary>
    /// Maps an instance of <typeparamref name="TParam"/> to an existing instance of <typeparamref name="TResult"/>.
    /// </summary>
    /// <param name="obj">The source object to be mapped.</param>
    /// <param name="result">The existing destination object to be populated with the mapped values.</param>
    /// <returns>The populated <typeparamref name="TResult"/> instance.</returns>
    public TResult ToMap(TParam obj, TResult result)
        => mapper.Map(obj, result);

    /// <summary>
    /// Maps a collection of <typeparamref name="TParam"/> instances to a list of <typeparamref name="TResult"/> instances.
    /// </summary>
    /// <typeparam name="T">The type of collection containing the source objects, which must implement both <see cref="IList{TParam}"/> and <see cref="ICollection{TParam}"/>.</typeparam>
    /// <param name="list">The collection of source objects to be mapped.</param>
    /// <returns>A list of mapped <typeparamref name="TResult"/> instances.</returns>
    public IList<TResult> ToMapList<T>(T list)
        where T : IList<TParam>, ICollection<TParam>
        => list.Select(itm => ToMap(itm)).ToList();
}
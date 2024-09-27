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

namespace MeControla.Core.Data.Entities;

/// <summary>
/// Represents an entity with multiple foreign keys and references to root and target entities.
/// </summary>
/// <typeparam name="TRoot">The type of the root entity, which must implement <see cref="IEntity"/>.</typeparam>
/// <typeparam name="TTarget">The type of the target entity, which must implement <see cref="IEntity"/>.</typeparam>
/// <remarks>
/// This interface extends <see cref="IForeignKeysManyEntity"/> and defines properties for references to the root entity <c>Root</c> 
/// and the target entity <c>Target</c>, in addition to the foreign key properties.
/// </remarks>
public interface IManyEntity<TRoot, TTarget> : IForeignKeysManyEntity
    where TRoot : IEntity
    where TTarget : IEntity
{
    /// <summary>
    /// Gets or sets the reference to the root entity.
    /// </summary>
    TRoot Root { get; set; }

    /// <summary>
    /// Gets or sets the reference to the target entity.
    /// </summary>
    TTarget Target { get; set; }
}
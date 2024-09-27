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
/// Represents an entity with multiple foreign keys.
/// </summary>
/// <remarks>
/// This interface defines properties for the root entity's identifier <c>RootId</c> and the target entity's identifier <c>TargetId</c>
/// that should be implemented by any class that needs to represent relationships between multiple entities.
/// </remarks>
public interface IForeignKeysManyEntity
{
    /// <summary>
    /// Gets or sets the identifier of the root entity.
    /// </summary>
    long RootId { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the target entity.
    /// </summary>
    long TargetId { get; set; }
}
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

namespace MeControla.Core.Data.Entities;

/// <summary>
/// Represents an entity that includes deletion timestamps and logical deletion flag.
/// </summary>
/// <remarks>
/// This interface extends <see cref="IModificationDateTimeEntity"/> and defines properties
/// for creation time <c>CreatedAt</c> and updation time <c>UpdatedAt</c>.
/// Also extends <see cref="ISoftEntity"/> and define logical deletion flag <c>IsDeleted</c>.
/// </remarks>
public interface IModificationLogicDateTimeEntity : IModificationDateTimeEntity, ISoftEntity
{
    /// <summary>
    /// Gets or sets the date and time when the entity was deleted.
    /// This property is nullable.
    /// </summary>
    DateTime? DeletedAt { get; set; }
}
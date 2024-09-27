﻿/***********************************************************************************
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
/// Represents an entity that includes creation and modification timestamps.
/// </summary>
/// <remarks>
/// This interface extends <see cref="IEntity"/>.
/// This interface defines properties for an identifier <c>Id</c> and a universally
/// unique identifier <c>Uuid</c> that should be implemented by all entities.
/// </remarks>
public interface IModificationDateTimeEntity : IEntity
{
    /// <summary>
    /// Gets or sets the date and time when the entity was created.
    /// </summary>
    DateTime CreatedAt { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the entity was last updated.
    /// This property is nullable.
    /// </summary>
    DateTime? UpdatedAt { get; set; }
}
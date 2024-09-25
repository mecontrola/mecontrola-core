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
/// Represents an entity that includes creation and modification user ids.
/// </summary>
/// <remarks>
/// This interface extends <see cref="IModificationDateTimeEntity"/> and defines properties for creation user id <c>CreatedUserId</c> 
/// and optional last update user id <c>UpdatedUserId</c>.
/// </remarks>
public interface IModificationEntity : IModificationDateTimeEntity
{
    /// <summary>
    /// Gets or sets the user id who created the entity.
    /// </summary>
    long CreatedUserId { get; set; }

    /// <summary>
    /// Gets or sets the user id who las updated the entity.
    /// This property is nullable.
    /// </summary>
    long? UpdatedUserId { get; set; }
}
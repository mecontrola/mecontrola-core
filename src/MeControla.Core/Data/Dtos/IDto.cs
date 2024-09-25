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

namespace MeControla.Core.Data.Dtos;

/// <summary>
/// Defines a Data Transfer Object (DTO) interface.
/// </summary>
/// <remarks>
/// This interface defines a <c>Id</c> property of type <c>Guid</c>
/// that must be implemented by all DTOs that have a unique identifier.
/// </remarks>
public interface IDto
{
    /// <summary>
    /// Gets or sets the unique identifier for the DTO.
    /// </summary>
    Guid Id { get; set; }
}
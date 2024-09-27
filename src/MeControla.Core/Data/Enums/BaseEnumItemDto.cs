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

namespace MeControla.Core.Data.Enums
{
    /// <summary>
    /// Abstract class used to define mapping an item from an Enum to a Dto.
    /// </summary>
    public abstract class BaseEnumItemDto : IEnumDto
    {
        /// <summary>
        /// Gets or sets the unique identifier of the Enum item.
        /// </summary>
        public uint Id { get; set; }
        /// <summary>
        /// Gets or sets the description of the Enum item.
        /// </summary>
        public string Value { get; set; }
    }
}
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

using MeControla.Core.Data.Entities;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.Core.Repositories;

/// <summary>
/// Defines an asynchronous repository interface for entities that support many-to-many relationships.
/// </summary>
/// <typeparam name="TEntity">The type of the entity that the repository will handle. 
/// Must implement <see cref="IForeignKeysManyEntity"/>.</typeparam>
public interface IManyAsyncRepository<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TEntity>
   where TEntity : IForeignKeysManyEntity
{
    /// <summary>
    /// Asynchronously creates a new entity in the data store.
    /// </summary>
    /// <param name="obj">The entity to be created.</param>
    /// <param name="cancellationToken">
    /// A cancellation token that can be used to cancel the asynchronous operation.
    /// </param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains a boolean value indicating whether the creation was successful.
    /// </returns>
    Task<bool> CreateAsync(TEntity obj, CancellationToken cancellationToken);

    /// <summary>
    /// Asynchronously removes an entity from the data store.
    /// </summary>
    /// <param name="obj">The entity to be removed.</param>
    /// <param name="cancellationToken">
    /// A cancellation token that can be used to cancel the asynchronous operation.
    /// </param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains a boolean value indicating whether the removal was successful.
    /// </returns>
    Task<bool> RemoveAsync(TEntity obj, CancellationToken cancellationToken);

    /// <summary>
    /// Asynchronously checks if a given entity exists in the data store.
    /// </summary>
    /// <param name="obj">The entity to be checked for existence.</param>
    /// <param name="cancellationToken">
    /// A cancellation token that can be used to cancel the asynchronous operation.
    /// </param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains a boolean value indicating whether the entity exists.
    /// </returns>
    Task<bool> ExistsAsync(TEntity obj, CancellationToken cancellationToken);
}
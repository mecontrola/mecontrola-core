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
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.Core.Repositories;

/// <summary>
/// Defines the basic operations to be implementation for an asynchronous repository handling basic operations with entities.
/// </summary>
/// <typeparam name="TEntity">The type of entity being managed by the repository.</typeparam>
public interface IAsyncRepository<TEntity>
    where TEntity : class, IEntity
{
    /// <summary>
    /// Gets the <see cref="IDbContextFacade"/> for managing database transactions and connections.
    /// </summary>
    /// <returns>An instance of the <see cref="IDbContextFacade"/> implementation.</returns>
    IDbContextFacade Database();

    /// <summary>
    /// Asynchronously returns the number of elements in a sequence.
    /// </summary>
    /// <param name="cancellationToken">A <see cref="CancellationToken" /> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the number of elements in the input sequence.
    /// </returns>
    Task<long> CountAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Asynchronously returns the number of elements in a sequence.
    /// </summary>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken" /> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the number of elements in the input sequence.
    /// </returns>
    Task<long> CountAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);

    /// <summary>
    /// Asynchronously retrieves a paginated list of entities.
    /// </summary>
    /// <param name="pagination">The pagination details to apply to the query, including page and limit.</param>
    /// <param name="cancellationToken">A cancellation token that can be used to cancel the operation.</param>
    /// <returns>A task representing the asynchronous operation, containing a paginated list of entities.</returns>
    [RequiresUnreferencedCode("This method uses reflection, which may not be compatible with trimming.")]
    Task<IPagination<TEntity>> FindAllPagedAsync(IPagination pagination, CancellationToken cancellationToken);

    /// <summary>
    /// Asynchronously retrieves a paginated list of entities that match the given predicate.
    /// </summary>
    /// <param name="pagination">The pagination details to apply to the query, including page and limit.</param>
    /// <param name="predicate">An expression that filters the entities.</param>
    /// <param name="cancellationToken">A cancellation token that can be used to cancel the operation.</param>
    /// <returns>A task representing the asynchronous operation, containing a paginated list of entities matching the predicate.</returns>
    [RequiresUnreferencedCode("This method uses reflection, which may not be compatible with trimming.")]
    Task<IPagination<TEntity>> FindAllPagedAsync(IPagination pagination, Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);

    /// <summary>
    /// Asynchronously finds all entities.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains a list of entities.</returns>
    Task<IList<TEntity>> FindAllAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Asynchronously finds all entities that match the provided predicate.
    /// </summary>
    /// <param name="predicate">An expression to filter the entities.</param>
    /// <param name="cancellationToken">A cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains a list of entities that satisfy the given predicate.</returns>
    Task<IList<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);

    /// <summary>
    /// Asynchronously finds a single entity that matches the specified identifier.
    /// </summary>
    /// <param name="id">
    /// The identifier used to filter the entities. This is a condition that the entity must satisfy.
    /// </param>
    /// <param name="cancellationToken">
    /// A <see cref="CancellationToken"/> that can be used to cancel the asynchronous operation.
    /// </param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains the entity that matches
    /// the predicate, or <see langword="null"/> if no entity is found.
    /// </returns>
    Task<TEntity?> FindAsync(long id, CancellationToken cancellationToken);

    /// <summary>
    /// Asynchronously finds a single entity that matches the specified uuid.
    /// </summary>
    /// <param name="uuid">
    /// The uuid used to filter the entities. This is a condition that the entity must satisfy.
    /// </param>
    /// <param name="cancellationToken">
    /// A <see cref="CancellationToken"/> that can be used to cancel the asynchronous operation.
    /// </param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains the entity that matches
    /// the predicate, or <see langword="null"/> if no entity is found.
    /// </returns>
    Task<TEntity?> FindAsync(Guid uuid, CancellationToken cancellationToken);

    /// <summary>
    /// Asynchronously finds a single entity that matches the specified predicate.
    /// </summary>
    /// <param name="predicate">
    /// An expression used to filter the entities. This is a condition that the entity must satisfy.
    /// </param>
    /// <param name="cancellationToken">
    /// A <see cref="CancellationToken"/> that can be used to cancel the asynchronous operation.
    /// </param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains the entity that matches
    /// the predicate, or <see langword="null"/> if no entity is found.
    /// </returns>
    Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);

    /// <summary>
    /// Asynchronously saves the specified entity. If the entity exists, it is updated; otherwise, it is created.
    /// </summary>
    /// <param name="obj">The entity to be saved.</param>
    /// <param name="cancellationToken">
    /// A <see cref="CancellationToken"/> that can be used to cancel the asynchronous operation.
    /// </param>
    /// <returns>
    /// A task representing the asynchronous operation. The task result contains the saved entity.
    /// </returns>
    Task<TEntity?> SaveAsync(TEntity obj, CancellationToken cancellationToken);

    /// <summary>
    /// Asynchronously creates a new entity in the repository.
    /// </summary>
    /// <param name="obj">The entity to be created.</param>
    /// <param name="cancellationToken">
    /// A <see cref="CancellationToken"/> that can be used to cancel the asynchronous operation.
    /// </param>
    /// <returns>
    /// A task representing the asynchronous operation. The task result contains the newly created entity.
    /// </returns>
    Task<TEntity> CreateAsync(TEntity obj, CancellationToken cancellationToken);

    /// <summary>
    /// Asynchronously updates an existing entity in the repository.
    /// </summary>
    /// <param name="obj">The entity to be updated.</param>
    /// <param name="cancellationToken">
    /// A <see cref="CancellationToken"/> that can be used to cancel the asynchronous operation.
    /// </param>
    /// <returns>
    /// A task representing the asynchronous operation. The task result contains <see langword="true"/> if the entity was updated successfully; otherwise, <see langword="false"/>.
    /// </returns>
    Task<bool> UpdateAsync(TEntity obj, CancellationToken cancellationToken);

    /// <summary>
    /// Asynchronously removes the specified entity from the repository.
    /// </summary>
    /// <param name="obj">The entity to be removed.</param>
    /// <param name="cancellationToken">
    /// A <see cref="CancellationToken"/> that can be used to cancel the asynchronous operation.
    /// </param>
    /// <returns>
    /// A task representing the asynchronous operation. The task result contains <see langword="true"/> if the entity was removed successfully; otherwise, <see langword="false"/>.
    /// </returns>
    Task<bool> RemoveAsync(TEntity obj, CancellationToken cancellationToken);

    /// <summary>
    /// Asynchronously checks if an entity with the specified identifier exists.
    /// </summary>
    /// <param name="id">The identifier of the entity to check for existence.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A task representing the asynchronous operation, containing a boolean result:
    /// <c>true</c> if the entity exists; otherwise, <c>false</c>.
    /// </returns>
    Task<bool> ExistsAsync(long id, CancellationToken cancellationToken);

    /// <summary>
    /// Asynchronously checks if an entity with the specified uuid exists.
    /// </summary>
    /// <param name="uuid">The uuid of the entity to check for existence.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A task representing the asynchronous operation, containing a boolean result:
    /// <c>true</c> if the entity exists; otherwise, <c>false</c>.
    /// </returns>
    Task<bool> ExistsAsync(Guid uuid, CancellationToken cancellationToken);

    /// <summary>
    /// Asynchronously determines whether any element of a sequence satisfies a condition.
    /// </summary>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A task representing the asynchronous operation, containing a boolean result:
    /// <c>true</c> if the entity exists; otherwise, <c>false</c>.
    /// </returns>
    Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);
}
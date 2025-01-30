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

using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using NetCoreCodeAnalysis = System.Diagnostics.CodeAnalysis;

namespace MeControla.Core.Repositories;

/// <summary>
/// Defines the operations of a database context in Entity Framework Core, allowing
/// for change tracking, entity manipulation, and asynchronous operations.
/// </summary>
public interface IDbContext : IDisposable, IAsyncDisposable, IInfrastructure<IServiceProvider>, IResettableService
{
    /// <summary>
    /// Gets the <see cref="ChangeTracker"/> that provides access to information about entity tracking and change management in the context.
    /// </summary>
    ChangeTracker ChangeTracker { get; }
    /// <summary>
    /// Gets the <see cref="DatabaseFacade"/> that provides access to database-related operations such as transactions and command execution.
    /// </summary>
    DatabaseFacade Database { get; }
    /// <summary>
    /// Gets the <see cref="DbContextId"/> that uniquely identifies this context instance.
    /// </summary>
    DbContextId ContextId { get; }

    /// <summary>
    /// Adds the specified entity to the context in the Added state so that it will be inserted into the database when <see cref="SaveChanges()"/> is called.
    /// </summary>
    /// <param name="entity">The entity to be added.</param>
    EntityEntry Add([NotNull] object entity);

    /// <summary>
    /// Adds the specified entity of type <typeparamref name="TEntity"/> to the context in the Added state.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity to be added.</typeparam>
    /// <param name="entity">The entity to add.</param>
    EntityEntry<TEntity> Add<TEntity>([NotNull] TEntity entity) where TEntity : class;

    /// <summary>
    /// Asynchronously adds the specified entity to the context and schedules it for insertion into the database when <see cref="SaveChangesAsync(CancellationToken)"/> is called.
    /// </summary>
    /// <param name="entity">The entity to be added.</param>
    /// <param name="cancellationToken">The cancellation token to observe during the operation.</param>
    ValueTask<EntityEntry> AddAsync([NotNull] object entity, CancellationToken cancellationToken = default);

    /// <summary>
    /// Asynchronously adds the specified entity of type <typeparamref name="TEntity"/> to the context.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity to be added.</typeparam>
    /// <param name="entity">The entity to add.</param>
    /// <param name="cancellationToken">The cancellation token to observe during the operation.</param>
    ValueTask<EntityEntry<TEntity>> AddAsync<TEntity>([NotNull] TEntity entity, CancellationToken cancellationToken = default) where TEntity : class;

    /// <summary>
    /// Adds the given entities to the context. The entities will be tracked by the context and inserted into the database when SaveChanges is called.
    /// </summary>
    /// <param name="entities">An array of entities to add.</param>
    void AddRange([NotNull] params object[] entities);

    /// <summary>
    /// Adds the given entities to the context. The entities will be tracked by the context and inserted into the database when SaveChanges is called.
    /// </summary>
    /// <param name="entities">An enumerable of entities to add.</param>
    void AddRange([NotNull] IEnumerable<object> entities);

    /// <summary>
    /// Asynchronously adds the given entities to the context. The entities will be tracked by the context and inserted into the database when SaveChanges is called.
    /// </summary>
    /// <param name="entities">An enumerable of entities to add.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task AddRangeAsync([NotNull] IEnumerable<object> entities, CancellationToken cancellationToken = default);

    /// <summary>
    /// Asynchronously adds the given entities to the context. The entities will be tracked by the context and inserted into the database when SaveChanges is called.
    /// </summary>
    /// <param name="entities">An array of entities to add.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task AddRangeAsync([NotNull] params object[] entities);

    /// <summary>
    /// Attaches the given entity to the context. The entity will be tracked by the context and no insert, update, or delete operations will be performed.
    /// </summary>
    /// <param name="entity">The entity to attach.</param>
    /// <returns>An EntityEntry for the attached entity.</returns>
    EntityEntry Attach([NotNull] object entity);

    /// <summary>
    /// Attaches the given entity to the context. The entity will be tracked by the context and no insert, update, or delete operations will be performed.
    /// </summary>
    /// <param name="entity">The entity to attach.</param>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <returns>An EntityEntry for the attached entity.</returns>
    EntityEntry<TEntity> Attach<TEntity>([NotNull] TEntity entity) where TEntity : class;

    /// <summary>
    /// Attaches the given entities to the context. The entities will be tracked by the context and no insert, update, or delete operations will be performed.
    /// </summary>
    /// <param name="entities">An enumerable of entities to attach.</param>
    void AttachRange([NotNull] IEnumerable<object> entities);

    /// <summary>
    /// Attaches the given entities to the context. The entities will be tracked by the context and no insert, update, or delete operations will be performed.
    /// </summary>
    /// <param name="entities">An array of entities to attach.</param>
    void AttachRange([NotNull] params object[] entities);

    /// <summary>
    /// Gets the EntityEntry for the given entity. This provides access to change tracking information.
    /// </summary>
    /// <param name="entity">The entity to track.</param>
    /// <returns>An EntityEntry for the given entity.</returns>
    EntityEntry Entry([NotNull] object entity);

    /// <summary>
    /// Gets the EntityEntry for the given entity. This provides access to change tracking information.
    /// </summary>
    /// <param name="entity">The entity to track.</param>
    /// <returns>An EntityEntry for the given entity.</returns>
    EntityEntry<TEntity> Entry<TEntity>([NotNull] TEntity entity) where TEntity : class;

    /// <summary>
    /// Determines whether the specified object is equal to the current object.
    /// </summary>
    /// <param name="obj">The object to compare with the current object.</param>
    /// <returns>True if the specified object is equal to the current object; otherwise, false.</returns>
    bool Equals(object obj);

    /// <summary>
    /// Finds an entity by its primary key values. Returns null if the entity is not found.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity to find.</typeparam>
    /// <param name="keyValues">The primary key values of the entity.</param>
    /// <returns>The entity found, or null if not found.</returns>
    TEntity Find<[NetCoreCodeAnalysis.DynamicallyAccessedMembers(NetCoreCodeAnalysis.DynamicallyAccessedMemberTypes.PublicMethods)] TEntity>([CanBeNull] params object[] keyValues) where TEntity : class;

    /// <summary>
    /// Finds an entity by its primary key values and type. Returns null if the entity is not found.
    /// </summary>
    /// <param name="entityType">The type of the entity to find.</param>
    /// <param name="keyValues">The primary key values of the entity.</param>
    /// <returns>The entity found, or null if not found.</returns>
    object Find([NetCoreCodeAnalysis.DynamicallyAccessedMembers(NetCoreCodeAnalysis.DynamicallyAccessedMemberTypes.PublicMethods), NotNull] Type entityType, [CanBeNull] params object[] keyValues);

    /// <summary>
    /// Asynchronously finds an entity by its primary key values and type. Returns null if the entity is not found.
    /// </summary>
    /// <param name="entityType">The type of the entity to find.</param>
    /// <param name="keyValues">The primary key values of the entity.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A ValueTask representing the entity found, or null if not found.</returns>
    ValueTask<object> FindAsync([NetCoreCodeAnalysis.DynamicallyAccessedMembers(NetCoreCodeAnalysis.DynamicallyAccessedMemberTypes.PublicMethods), NotNull] Type entityType, [CanBeNull] object[] keyValues, CancellationToken cancellationToken);

    /// <summary>
    /// Asynchronously finds an entity by its primary key values and type. Returns null if the entity is not found.
    /// </summary>
    /// <param name="entityType">The type of the entity to find.</param>
    /// <param name="keyValues">The primary key values of the entity.</param>
    /// <returns>A ValueTask representing the entity found, or null if not found.</returns>
    ValueTask<object> FindAsync([NetCoreCodeAnalysis.DynamicallyAccessedMembers(NetCoreCodeAnalysis.DynamicallyAccessedMemberTypes.PublicMethods), NotNull] Type entityType, [CanBeNull] params object[] keyValues);

    /// <summary>
    /// Asynchronously finds an entity by its primary key values. Returns null if the entity is not found.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity to find.</typeparam>
    /// <param name="keyValues">The primary key values of the entity.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A ValueTask representing the entity found, or null if not found.</returns>
    ValueTask<TEntity> FindAsync<[NetCoreCodeAnalysis.DynamicallyAccessedMembers(NetCoreCodeAnalysis.DynamicallyAccessedMemberTypes.PublicMethods)] TEntity>([CanBeNull] object[] keyValues, CancellationToken cancellationToken) where TEntity : class;

    /// <summary>
    /// Asynchronously finds an entity by its primary key values. Returns null if the entity is not found.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity to find.</typeparam>
    /// <param name="keyValues">The primary key values of the entity.</param>
    /// <returns>A ValueTask representing the entity found, or null if not found.</returns>
    ValueTask<TEntity> FindAsync<[NetCoreCodeAnalysis.DynamicallyAccessedMembers(NetCoreCodeAnalysis.DynamicallyAccessedMemberTypes.PublicMethods)] TEntity>([CanBeNull] params object[] keyValues) where TEntity : class;

    /// <summary>
    /// Serves as the default hash function for the context.
    /// </summary>
    /// <returns>A hash code for the current object.</returns>
    int GetHashCode();

    /// <summary>
    /// Removes the given entity from the context. The entity will be deleted from the database when SaveChanges is called.
    /// </summary>
    /// <param name="entity">The entity to remove.</param>
    /// <returns>An EntityEntry for the removed entity.</returns>
    EntityEntry Remove([NotNull] object entity);

    /// <summary>
    /// Removes the given entity from the context. The entity will be deleted from the database when SaveChanges is called.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <param name="entity">The entity to remove.</param>
    /// <returns>An EntityEntry for the removed entity.</returns>
    EntityEntry<TEntity> Remove<TEntity>([NotNull] TEntity entity) where TEntity : class;

    /// <summary>
    /// Removes the given entities from the context. The entities will be deleted from the database when SaveChanges is called.
    /// </summary>
    /// <param name="entities">An enumerable of entities to remove.</param>
    void RemoveRange([NotNull] IEnumerable<object> entities);

    /// <summary>
    /// Removes the given entities from the context. The entities will be deleted from the database when SaveChanges is called.
    /// </summary>
    /// <param name="entities">An array of entities to remove.</param>
    void RemoveRange([NotNull] params object[] entities);

    /// <summary>
    /// Saves all changes made in this context to the database.
    /// </summary>
    /// <param name="acceptAllChangesOnSuccess">Indicates whether <see cref="ChangeTracker.AcceptAllChanges()"/> is called after the changes are sent successfully to the database.</param>
    /// <returns>The number of state entries written to the database.</returns>
    int SaveChanges(bool acceptAllChangesOnSuccess);

    /// <summary>
    /// Saves all changes made in this context to the database.
    /// </summary>
    /// <returns>The number of state entries written to the database.</returns>
    int SaveChanges();

    /// <summary>
    /// Asynchronously saves all changes made in this context to the database.
    /// </summary>
    /// <param name="acceptAllChangesOnSuccess">Indicates whether <see cref="ChangeTracker.AcceptAllChanges()"/> is called after the changes are sent successfully to the database.</param>
    /// <param name="cancellationToken">The cancellation token to observe during the operation.</param>
    /// <returns>The number of state entries written to the database.</returns>
    Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);

    /// <summary>
    /// Asynchronously saves all changes made in this context to the database.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token to observe during the operation.</param>
    /// <returns>The number of state entries written to the database.</returns>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns a string representation of the current context.
    /// </summary>
    /// <returns>A string that represents the current object.</returns>
    string ToString();

    /// <summary>
    /// Updates the given entity in the context. The entity will be updated in the database when SaveChanges is called.
    /// </summary>
    /// <param name="entity">The entity to update.</param>
    /// <returns>An EntityEntry for the updated entity.</returns>
    EntityEntry Update([NotNull] object entity);

    /// <summary>
    /// Updates the given entity in the context. The entity will be updated in the database when SaveChanges is called.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <param name="entity">The entity to update.</param>
    /// <returns>An EntityEntry for the updated entity.</returns>
    EntityEntry<TEntity> Update<TEntity>([NotNull] TEntity entity) where TEntity : class;

    /// <summary>
    /// Updates the given entities in the context. The entities will be updated in the database when SaveChanges is called.
    /// </summary>
    /// <param name="entities">An enumerable of entities to update.</param>
    void UpdateRange([NotNull] IEnumerable<object> entities);

    /// <summary>
    /// Updates the given entities in the context. The entities will be updated in the database when SaveChanges is called.
    /// </summary>
    /// <param name="entities">An array of entities to update.</param>
    void UpdateRange([NotNull] params object[] entities);
}
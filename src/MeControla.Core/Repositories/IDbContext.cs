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

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.Core.Repositories;

/// <summary>
/// Defines the operations of a database context in Entity Framework Core, allowing
/// for change tracking, entity manipulation, and asynchronous operations.
/// </summary>
public interface IDbContext : IDisposable, IAsyncDisposable, IInfrastructure<IServiceProvider>, IResettableService
{
    /// <summary>
    /// Provides access to database related information and operations for this context.
    /// </summary>
    DatabaseFacade Database { get; }

    /// <summary>
    ///     Provides access to information and operations for entity instances this context is tracking.
    /// </summary>
    /// <remarks>
    ///     See <see href="https://aka.ms/efcore-docs-change-tracking">EF Core change tracking</see> for more information and examples.
    /// </remarks>
    ChangeTracker ChangeTracker { get; }

    /// <summary>
    ///     The metadata about the shape of entities, the relationships between them, and how they map to the database.
    ///     May not include all the information necessary to initialize the database.
    /// </summary>
    /// <remarks>
    ///     See <see href="https://aka.ms/efcore-docs-modeling">Modeling entity types and relationships</see> for more information and examples.
    /// </remarks>
    IModel Model { get; }

    /// <summary>
    ///     A unique identifier for the context instance and pool lease, if any.
    /// </summary>
    /// <remarks>
    ///     This identifier is primarily intended as a correlation ID for logging and debugging such
    ///     that it is easy to identify that multiple events are using the same or different context instances.
    /// </remarks>
    DbContextId ContextId { get; }

    /// <summary>
    ///     Creates a <see cref="DbSet{TEntity}" /> that can be used to query and save instances of <typeparamref name="TEntity" />.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         Entity Framework Core does not support multiple parallel operations being run on the same DbContext instance. This
    ///         includes both parallel execution of async queries and any explicit concurrent use from multiple threads.
    ///         Therefore, always await async calls immediately, or use separate DbContext instances for operations that execute
    ///         in parallel. See <see href="https://aka.ms/efcore-docs-threading">Avoiding DbContext threading issues</see> for more information
    ///         and examples.
    ///     </para>
    ///     <para>
    ///         See <see href="https://aka.ms/efcore-docs-query">Querying data with EF Core</see> and
    ///         <see href="https://aka.ms/efcore-docs-change-tracking">Changing tracking</see> for more information and examples.
    ///     </para>
    /// </remarks>
    /// <typeparam name="TEntity">The type of entity for which a set should be returned.</typeparam>
    /// <returns>A set for the given entity type.</returns>
#pragma warning disable CA1716 // Identifiers should not match keywords
    DbSet<TEntity> Set<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes)] TEntity>() where TEntity : class;
#pragma warning restore CA1716 // Identifiers should not match keywords

    /// <summary>
    ///     Creates a <see cref="DbSet{TEntity}" /> for a shared-type entity type that can be used to query and save
    ///     instances of <typeparamref name="TEntity" />.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         Shared-type entity types are typically used for the join entity in many-to-many relationships.
    ///     </para>
    ///     <para>
    ///         See <see href="https://aka.ms/efcore-docs-query">Querying data with EF Core</see>,
    ///         <see href="https://aka.ms/efcore-docs-change-tracking">Changing tracking</see>, and
    ///         <see href="https://aka.ms/efcore-docs-shared-types">Shared entity types</see>  for more information and examples.
    ///     </para>
    /// </remarks>
    /// <param name="name">The name for the shared-type entity type to use.</param>
    /// <typeparam name="TEntity">The type of entity for which a set should be returned.</typeparam>
    /// <returns>A set for the given entity type.</returns>
#pragma warning disable CA1716 // Identifiers should not match keywords
    DbSet<TEntity> Set<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes)] TEntity>(string name) where TEntity : class;
#pragma warning restore CA1716 // Identifiers should not match keywords

    /// <summary>
    ///     Saves all changes made in this context to the database.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         This method will automatically call <see cref="Microsoft.EntityFrameworkCore.ChangeTracking.ChangeTracker.DetectChanges" />
    ///         to discover any changes to entity instances before saving to the underlying database. This can be disabled via
    ///         <see cref="Microsoft.EntityFrameworkCore.ChangeTracking.ChangeTracker.AutoDetectChangesEnabled" />.
    ///     </para>
    ///     <para>
    ///         Entity Framework Core does not support multiple parallel operations being run on the same DbContext instance. This
    ///         includes both parallel execution of async queries and any explicit concurrent use from multiple threads.
    ///         Therefore, always await async calls immediately, or use separate DbContext instances for operations that execute
    ///         in parallel. See <see href="https://aka.ms/efcore-docs-threading">Avoiding DbContext threading issues</see> for more information
    ///         and examples.
    ///     </para>
    ///     <para>
    ///         See <see href="https://aka.ms/efcore-docs-saving-data">Saving data in EF Core</see> for more information and examples.
    ///     </para>
    /// </remarks>
    /// <returns>
    ///     The number of state entries written to the database.
    /// </returns>
    /// <exception cref="DbUpdateException">
    ///     An error is encountered while saving to the database.
    /// </exception>
    /// <exception cref="DbUpdateConcurrencyException">
    ///     A concurrency violation is encountered while saving to the database.
    ///     A concurrency violation occurs when an unexpected number of rows are affected during save.
    ///     This is usually because the data in the database has been modified since it was loaded into memory.
    /// </exception>
    int SaveChanges();

    /// <summary>
    ///     Saves all changes made in this context to the database.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         This method will automatically call <see cref="Microsoft.EntityFrameworkCore.ChangeTracking.ChangeTracker.DetectChanges" />
    ///         to discover any changes to entity instances before saving to the underlying database. This can be disabled via
    ///         <see cref="Microsoft.EntityFrameworkCore.ChangeTracking.ChangeTracker.AutoDetectChangesEnabled" />.
    ///     </para>
    ///     <para>
    ///         Entity Framework Core does not support multiple parallel operations being run on the same DbContext instance. This
    ///         includes both parallel execution of async queries and any explicit concurrent use from multiple threads.
    ///         Therefore, always await async calls immediately, or use separate DbContext instances for operations that execute
    ///         in parallel. See <see href="https://aka.ms/efcore-docs-threading">Avoiding DbContext threading issues</see> for more information
    ///         and examples.
    ///     </para>
    ///     <para>
    ///         See <see href="https://aka.ms/efcore-docs-saving-data">Saving data in EF Core</see> for more information and examples.
    ///     </para>
    /// </remarks>
    /// <param name="acceptAllChangesOnSuccess">
    ///     Indicates whether <see cref="Microsoft.EntityFrameworkCore.ChangeTracking.ChangeTracker.AcceptAllChanges" />
    ///     is called after the changes have been sent successfully to the database.
    /// </param>
    /// <returns>
    ///     The number of state entries written to the database.
    /// </returns>
    /// <exception cref="DbUpdateException">
    ///     An error is encountered while saving to the database.
    /// </exception>
    /// <exception cref="DbUpdateConcurrencyException">
    ///     A concurrency violation is encountered while saving to the database.
    ///     A concurrency violation occurs when an unexpected number of rows are affected during save.
    ///     This is usually because the data in the database has been modified since it was loaded into memory.
    /// </exception>
    int SaveChanges(bool acceptAllChangesOnSuccess);

    /// <summary>
    ///     Saves all changes made in this context to the database.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         This method will automatically call <see cref="Microsoft.EntityFrameworkCore.ChangeTracking.ChangeTracker.DetectChanges" />
    ///         to discover any changes to entity instances before saving to the underlying database. This can be disabled via
    ///         <see cref="Microsoft.EntityFrameworkCore.ChangeTracking.ChangeTracker.AutoDetectChangesEnabled" />.
    ///     </para>
    ///     <para>
    ///         Entity Framework Core does not support multiple parallel operations being run on the same DbContext instance. This
    ///         includes both parallel execution of async queries and any explicit concurrent use from multiple threads.
    ///         Therefore, always await async calls immediately, or use separate DbContext instances for operations that execute
    ///         in parallel. See <see href="https://aka.ms/efcore-docs-threading">Avoiding DbContext threading issues</see> for more
    ///         information and examples.
    ///     </para>
    ///     <para>
    ///         See <see href="https://aka.ms/efcore-docs-saving-data">Saving data in EF Core</see> for more information and examples.
    ///     </para>
    /// </remarks>
    /// <param name="cancellationToken">A <see cref="CancellationToken" /> to observe while waiting for the task to complete.</param>
    /// <returns>
    ///     A task that represents the asynchronous save operation. The task result contains the
    ///     number of state entries written to the database.
    /// </returns>
    /// <exception cref="DbUpdateException">
    ///     An error is encountered while saving to the database.
    /// </exception>
    /// <exception cref="DbUpdateConcurrencyException">
    ///     A concurrency violation is encountered while saving to the database.
    ///     A concurrency violation occurs when an unexpected number of rows are affected during save.
    ///     This is usually because the data in the database has been modified since it was loaded into memory.
    /// </exception>
    /// <exception cref="OperationCanceledException">If the <see cref="CancellationToken" /> is canceled.</exception>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    /// <summary>
    ///     Saves all changes made in this context to the database.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         This method will automatically call <see cref="Microsoft.EntityFrameworkCore.ChangeTracking.ChangeTracker.DetectChanges" />
    ///         to discover any changes to entity instances before saving to the underlying database. This can be disabled via
    ///         <see cref="Microsoft.EntityFrameworkCore.ChangeTracking.ChangeTracker.AutoDetectChangesEnabled" />.
    ///     </para>
    ///     <para>
    ///         Entity Framework Core does not support multiple parallel operations being run on the same DbContext instance. This
    ///         includes both parallel execution of async queries and any explicit concurrent use from multiple threads.
    ///         Therefore, always await async calls immediately, or use separate DbContext instances for operations that execute
    ///         in parallel. See <see href="https://aka.ms/efcore-docs-threading">Avoiding DbContext threading issues</see> for more
    ///         information and examples.
    ///     </para>
    ///     <para>
    ///         See <see href="https://aka.ms/efcore-docs-saving-data">Saving data in EF Core</see> for more information and examples.
    ///     </para>
    /// </remarks>
    /// <param name="acceptAllChangesOnSuccess">
    ///     Indicates whether <see cref="Microsoft.EntityFrameworkCore.ChangeTracking.ChangeTracker.AcceptAllChanges" /> is called after
    ///     the changes have been sent successfully to the database.
    /// </param>
    /// <param name="cancellationToken">A <see cref="CancellationToken" /> to observe while waiting for the task to complete.</param>
    /// <returns>
    ///     A task that represents the asynchronous save operation. The task result contains the
    ///     number of state entries written to the database.
    /// </returns>
    /// <exception cref="DbUpdateException">
    ///     An error is encountered while saving to the database.
    /// </exception>
    /// <exception cref="DbUpdateConcurrencyException">
    ///     A concurrency violation is encountered while saving to the database.
    ///     A concurrency violation occurs when an unexpected number of rows are affected during save.
    ///     This is usually because the data in the database has been modified since it was loaded into memory.
    /// </exception>
    /// <exception cref="OperationCanceledException">If the <see cref="CancellationToken" /> is canceled.</exception>
    Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Begins tracking the given entity, and any other reachable entities that are
    ///     not already being tracked, in the <see cref="EntityState.Added" /> state such that they will
    ///     be inserted into the database when <see cref="SaveChanges()" /> is called.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         Use <see cref="EntityEntry.State" /> to set the state of only a single entity.
    ///     </para>
    ///     <para>
    ///         See <see href="https://aka.ms/efcore-docs-change-tracking">EF Core change tracking</see> for more information and examples.
    ///     </para>
    /// </remarks>
    /// <param name="entity">The entity to add.</param>
    /// <returns>
    ///     The <see cref="EntityEntry" /> for the entity. The entry provides
    ///     access to change tracking information and operations for the entity.
    /// </returns>
    EntityEntry Add(object entity);

    /// <summary>
    ///     Begins tracking the given entity, and any other reachable entities that are
    ///     not already being tracked, in the <see cref="EntityState.Added" /> state such that
    ///     they will be inserted into the database when <see cref="SaveChanges()" /> is called.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         Use <see cref="EntityEntry.State" /> to set the state of only a single entity.
    ///     </para>
    ///     <para>
    ///         See <see href="https://aka.ms/efcore-docs-change-tracking">EF Core change tracking</see> for more information and examples.
    ///     </para>
    /// </remarks>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <param name="entity">The entity to add.</param>
    /// <returns>
    ///     The <see cref="EntityEntry{TEntity}" /> for the entity. The entry provides
    ///     access to change tracking information and operations for the entity.
    /// </returns>
    EntityEntry<TEntity> Add<TEntity>([NotNull] TEntity entity) where TEntity : class;

    /// <summary>
    ///     Begins tracking the given entity, and any other reachable entities that are
    ///     not already being tracked, in the <see cref="EntityState.Added" /> state such that they will
    ///     be inserted into the database when <see cref="SaveChanges()" /> is called.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         Use <see cref="EntityEntry.State" /> to set the state of only a single entity.
    ///     </para>
    ///     <para>
    ///         This method is async only to allow special value generators, such as the one used by
    ///         'Microsoft.EntityFrameworkCore.Metadata.SqlServerValueGenerationStrategy.SequenceHiLo',
    ///         to access the database asynchronously. For all other cases the non async method should be used.
    ///     </para>
    ///     <para>
    ///         Entity Framework Core does not support multiple parallel operations being run on the same DbContext instance. This
    ///         includes both parallel execution of async queries and any explicit concurrent use from multiple threads.
    ///         Therefore, always await async calls immediately, or use separate DbContext instances for operations that execute
    ///         in parallel. See <see href="https://aka.ms/efcore-docs-threading">Avoiding DbContext threading issues</see>
    ///         for more information and examples.
    ///     </para>
    ///     <para>
    ///         See <see href="https://aka.ms/efcore-docs-change-tracking">EF Core change tracking</see> for more information and examples.
    ///     </para>
    /// </remarks>
    /// <param name="entity">The entity to add.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken" /> to observe while waiting for the task to complete.</param>
    /// <returns>
    ///     A task that represents the asynchronous Add operation. The task result contains the
    ///     <see cref="EntityEntry" /> for the entity. The entry provides access to change tracking
    ///     information and operations for the entity.
    /// </returns>
    /// <exception cref="OperationCanceledException">If the <see cref="CancellationToken" /> is canceled.</exception>
    ValueTask<EntityEntry> AddAsync([NotNull] object entity, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Begins tracking the given entity, and any other reachable entities that are
    ///     not already being tracked, in the <see cref="EntityState.Added" /> state such that they will
    ///     be inserted into the database when <see cref="SaveChanges()" /> is called.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         This method is async only to allow special value generators, such as the one used by
    ///         'Microsoft.EntityFrameworkCore.Metadata.SqlServerValueGenerationStrategy.SequenceHiLo',
    ///         to access the database asynchronously. For all other cases the non async method should be used.
    ///     </para>
    ///     <para>
    ///         Entity Framework Core does not support multiple parallel operations being run on the same DbContext instance. This
    ///         includes both parallel execution of async queries and any explicit concurrent use from multiple threads.
    ///         Therefore, always await async calls immediately, or use separate DbContext instances for operations that execute
    ///         in parallel. See <see href="https://aka.ms/efcore-docs-threading">Avoiding DbContext threading issues</see>
    ///         for more information and examples.
    ///     </para>
    ///     <para>
    ///         See <see href="https://aka.ms/efcore-docs-change-tracking">EF Core change tracking</see> for more information and examples.
    ///     </para>
    /// </remarks>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <param name="entity">The entity to add.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken" /> to observe while waiting for the task to complete.</param>
    /// <returns>
    ///     A task that represents the asynchronous Add operation. The task result contains the
    ///     <see cref="EntityEntry{TEntity}" /> for the entity. The entry provides access to change tracking
    ///     information and operations for the entity.
    /// </returns>
    /// <exception cref="OperationCanceledException">If the <see cref="CancellationToken" /> is canceled.</exception>
    ValueTask<EntityEntry<TEntity>> AddAsync<TEntity>([NotNull] TEntity entity, CancellationToken cancellationToken = default) where TEntity : class;

    /// <summary>
    ///     Begins tracking the given entities, and any other reachable entities that are
    ///     not already being tracked, in the <see cref="EntityState.Added" /> state such that they will
    ///     be inserted into the database when <see cref="SaveChanges()" /> is called.
    /// </summary>
    /// <remarks>
    ///     See <see href="https://aka.ms/efcore-docs-change-tracking">EF Core change tracking</see>
    ///     and <see href="https://aka.ms/efcore-docs-attach-range">Using AddRange, UpdateRange, AttachRange, and RemoveRange</see>
    ///     for more information and examples.
    /// </remarks>
    /// <param name="entities">The entities to add.</param>
    void AddRange([NotNull] params object[] entities);

    /// <summary>
    ///     Begins tracking the given entities, and any other reachable entities that are
    ///     not already being tracked, in the <see cref="EntityState.Added" /> state such that they will
    ///     be inserted into the database when <see cref="SaveChanges()" /> is called.
    /// </summary>
    /// <remarks>
    ///     See <see href="https://aka.ms/efcore-docs-change-tracking">EF Core change tracking</see>
    ///     and <see href="https://aka.ms/efcore-docs-attach-range">Using AddRange, UpdateRange, AttachRange, and RemoveRange</see>
    ///     for more information and examples.
    /// </remarks>
    /// <param name="entities">The entities to add.</param>
    void AddRange([NotNull] IEnumerable<object> entities);

    /// <summary>
    ///     Begins tracking the given entity, and any other reachable entities that are
    ///     not already being tracked, in the <see cref="EntityState.Added" /> state such that they will
    ///     be inserted into the database when <see cref="SaveChanges()" /> is called.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         This method is async only to allow special value generators, such as the one used by
    ///         'Microsoft.EntityFrameworkCore.Metadata.SqlServerValueGenerationStrategy.SequenceHiLo',
    ///         to access the database asynchronously. For all other cases the non async method should be used.
    ///     </para>
    ///     <para>
    ///         Entity Framework Core does not support multiple parallel operations being run on the same DbContext instance. This
    ///         includes both parallel execution of async queries and any explicit concurrent use from multiple threads.
    ///         Therefore, always await async calls immediately, or use separate DbContext instances for operations that execute
    ///         in parallel. See <see href="https://aka.ms/efcore-docs-threading">Avoiding DbContext threading issues</see>
    ///         for more information and examples.
    ///     </para>
    ///     <para>
    ///         See <see href="https://aka.ms/efcore-docs-change-tracking">EF Core change tracking</see>
    ///         and <see href="https://aka.ms/efcore-docs-attach-range">Using AddRange, UpdateRange, AttachRange, and RemoveRange</see>
    ///         for more information and examples.
    ///     </para>
    /// </remarks>
    /// <param name="entities">The entities to add.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken" /> to observe while waiting for the task to complete.</param>
    /// <returns>
    ///     A task that represents the asynchronous operation.
    /// </returns>
    /// <exception cref="OperationCanceledException">If the <see cref="CancellationToken" /> is canceled.</exception>
    Task AddRangeAsync([NotNull] IEnumerable<object> entities, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Begins tracking the given entity, and any other reachable entities that are
    ///     not already being tracked, in the <see cref="EntityState.Added" /> state such that they will
    ///     be inserted into the database when <see cref="SaveChanges()" /> is called.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         This method is async only to allow special value generators, such as the one used by
    ///         'Microsoft.EntityFrameworkCore.Metadata.SqlServerValueGenerationStrategy.SequenceHiLo',
    ///         to access the database asynchronously. For all other cases the non async method should be used.
    ///     </para>
    ///     <para>
    ///         Entity Framework Core does not support multiple parallel operations being run on the same DbContext instance. This
    ///         includes both parallel execution of async queries and any explicit concurrent use from multiple threads.
    ///         Therefore, always await async calls immediately, or use separate DbContext instances for operations that execute
    ///         in parallel. See <see href="https://aka.ms/efcore-docs-threading">Avoiding DbContext threading issues</see>
    ///         for more information and examples.
    ///     </para>
    ///     <para>
    ///         See <see href="https://aka.ms/efcore-docs-change-tracking">EF Core change tracking</see>
    ///         and <see href="https://aka.ms/efcore-docs-attach-range">Using AddRange, UpdateRange, AttachRange, and RemoveRange</see>
    ///         for more information and examples.
    ///     </para>
    /// </remarks>
    /// <param name="entities">The entities to add.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task AddRangeAsync([NotNull] params object[] entities);

    /// <summary>
    ///     Begins tracking the given entity and entries reachable from the given entity using
    ///     the <see cref="EntityState.Unchanged" /> state by default, but see below for cases
    ///     when a different state will be used.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         Generally, no database interaction will be performed until <see cref="SaveChanges()" /> is called.
    ///     </para>
    ///     <para>
    ///         A recursive search of the navigation properties will be performed to find reachable entities
    ///         that are not already being tracked by the context. All entities found will be tracked
    ///         by the context.
    ///     </para>
    ///     <para>
    ///         For entity types with generated keys if an entity has its primary key value set
    ///         then it will be tracked in the <see cref="EntityState.Unchanged" /> state. If the primary key
    ///         value is not set then it will be tracked in the <see cref="EntityState.Added" /> state.
    ///         This helps ensure only new entities will be inserted.
    ///         An entity is considered to have its primary key value set if the primary key property is set
    ///         to anything other than the CLR default for the property type.
    ///     </para>
    ///     <para>
    ///         For entity types without generated keys, the state set is always <see cref="EntityState.Unchanged" />.
    ///     </para>
    ///     <para>
    ///         Use <see cref="EntityEntry.State" /> to set the state of only a single entity.
    ///     </para>
    ///     <para>
    ///         See <see href="https://aka.ms/efcore-docs-change-tracking">EF Core change tracking</see> for more information and examples.
    ///     </para>
    /// </remarks>
    /// <param name="entity">The entity to attach.</param>
    /// <returns>
    ///     The <see cref="EntityEntry" /> for the entity. The entry provides
    ///     access to change tracking information and operations for the entity.
    /// </returns>
    EntityEntry Attach([NotNull] object entity);

    /// <summary>
    ///     Begins tracking the given entity and entries reachable from the given entity using
    ///     the <see cref="EntityState.Unchanged" /> state by default, but see below for cases
    ///     when a different state will be used.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         Generally, no database interaction will be performed until <see cref="SaveChanges()" /> is called.
    ///     </para>
    ///     <para>
    ///         A recursive search of the navigation properties will be performed to find reachable entities
    ///         that are not already being tracked by the context. All entities found will be tracked
    ///         by the context.
    ///     </para>
    ///     <para>
    ///         For entity types with generated keys if an entity has its primary key value set
    ///         then it will be tracked in the <see cref="EntityState.Unchanged" /> state. If the primary key
    ///         value is not set then it will be tracked in the <see cref="EntityState.Added" /> state.
    ///         This helps ensure only new entities will be inserted.
    ///         An entity is considered to have its primary key value set if the primary key property is set
    ///         to anything other than the CLR default for the property type.
    ///     </para>
    ///     <para>
    ///         For entity types without generated keys, the state set is always <see cref="EntityState.Unchanged" />.
    ///     </para>
    ///     <para>
    ///         Use <see cref="EntityEntry.State" /> to set the state of only a single entity.
    ///     </para>
    ///     <para>
    ///         See <see href="https://aka.ms/efcore-docs-change-tracking">EF Core change tracking</see> for more information and examples.
    ///     </para>
    /// </remarks>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <param name="entity">The entity to attach.</param>
    /// <returns>
    ///     The <see cref="EntityEntry{TEntity}" /> for the entity. The entry provides
    ///     access to change tracking information and operations for the entity.
    /// </returns>
    EntityEntry<TEntity> Attach<TEntity>(TEntity entity) where TEntity : class;

    /// <summary>
    ///     Begins tracking the given entities and entries reachable from the given entities using
    ///     the <see cref="EntityState.Unchanged" /> state by default, but see below for cases
    ///     when a different state will be used.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         Generally, no database interaction will be performed until <see cref="SaveChanges()" /> is called.
    ///     </para>
    ///     <para>
    ///         A recursive search of the navigation properties will be performed to find reachable entities
    ///         that are not already being tracked by the context. All entities found will be tracked
    ///         by the context.
    ///     </para>
    ///     <para>
    ///         For entity types with generated keys if an entity has its primary key value set
    ///         then it will be tracked in the <see cref="EntityState.Unchanged" /> state. If the primary key
    ///         value is not set then it will be tracked in the <see cref="EntityState.Added" /> state.
    ///         This helps ensure only new entities will be inserted.
    ///         An entity is considered to have its primary key value set if the primary key property is set
    ///         to anything other than the CLR default for the property type.
    ///     </para>
    ///     <para>
    ///         For entity types without generated keys, the state set is always <see cref="EntityState.Unchanged" />.
    ///     </para>
    ///     <para>
    ///         Use <see cref="EntityEntry.State" /> to set the state of only a single entity.
    ///     </para>
    ///     <para>
    ///         See <see href="https://aka.ms/efcore-docs-change-tracking">EF Core change tracking</see>
    ///         and <see href="https://aka.ms/efcore-docs-attach-range">Using AddRange, UpdateRange, AttachRange, and RemoveRange</see>
    ///         for more information and examples.
    ///     </para>
    /// </remarks>
    /// <param name="entities">The entities to attach.</param>
    void AttachRange([NotNull] IEnumerable<object> entities);

    /// <summary>
    ///     Begins tracking the given entities and entries reachable from the given entities using
    ///     the <see cref="EntityState.Unchanged" /> state by default, but see below for cases
    ///     when a different state will be used.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         Generally, no database interaction will be performed until <see cref="SaveChanges()" /> is called.
    ///     </para>
    ///     <para>
    ///         A recursive search of the navigation properties will be performed to find reachable entities
    ///         that are not already being tracked by the context. All entities found will be tracked
    ///         by the context.
    ///     </para>
    ///     <para>
    ///         For entity types with generated keys if an entity has its primary key value set
    ///         then it will be tracked in the <see cref="EntityState.Unchanged" /> state. If the primary key
    ///         value is not set then it will be tracked in the <see cref="EntityState.Added" /> state.
    ///         This helps ensure only new entities will be inserted.
    ///         An entity is considered to have its primary key value set if the primary key property is set
    ///         to anything other than the CLR default for the property type.
    ///     </para>
    ///     <para>
    ///         For entity types without generated keys, the state set is always <see cref="EntityState.Unchanged" />.
    ///     </para>
    ///     <para>
    ///         Use <see cref="EntityEntry.State" /> to set the state of only a single entity.
    ///     </para>
    ///     <para>
    ///         See <see href="https://aka.ms/efcore-docs-change-tracking">EF Core change tracking</see>
    ///         and <see href="https://aka.ms/efcore-docs-attach-range">Using AddRange, UpdateRange, AttachRange, and RemoveRange</see>
    ///         for more information and examples.
    ///     </para>
    /// </remarks>
    /// <param name="entities">The entities to attach.</param>
    void AttachRange([NotNull] params object[] entities);

    /// <summary>
    ///     Begins tracking the given entity and entries reachable from the given entity using
    ///     the <see cref="EntityState.Modified" /> state by default, but see below for cases
    ///     when a different state will be used.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         Generally, no database interaction will be performed until <see cref="SaveChanges()" /> is called.
    ///     </para>
    ///     <para>
    ///         A recursive search of the navigation properties will be performed to find reachable entities
    ///         that are not already being tracked by the context. All entities found will be tracked
    ///         by the context.
    ///     </para>
    ///     <para>
    ///         For entity types with generated keys if an entity has its primary key value set
    ///         then it will be tracked in the <see cref="EntityState.Modified" /> state. If the primary key
    ///         value is not set then it will be tracked in the <see cref="EntityState.Added" /> state.
    ///         This helps ensure new entities will be inserted, while existing entities will be updated.
    ///         An entity is considered to have its primary key value set if the primary key property is set
    ///         to anything other than the CLR default for the property type.
    ///     </para>
    ///     <para>
    ///         For entity types without generated keys, the state set is always <see cref="EntityState.Modified" />.
    ///     </para>
    ///     <para>
    ///         Use <see cref="EntityEntry.State" /> to set the state of only a single entity.
    ///     </para>
    ///     <para>
    ///         See <see href="https://aka.ms/efcore-docs-change-tracking">EF Core change tracking</see> for more information and examples.
    ///     </para>
    /// </remarks>
    /// <param name="entity">The entity to update.</param>
    /// <returns>
    ///     The <see cref="EntityEntry" /> for the entity. The entry provides
    ///     access to change tracking information and operations for the entity.
    /// </returns>
    EntityEntry Update([NotNull] object entity);

    /// <summary>
    ///     Begins tracking the given entity and entries reachable from the given entity using
    ///     the <see cref="EntityState.Modified" /> state by default, but see below for cases
    ///     when a different state will be used.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         Generally, no database interaction will be performed until <see cref="SaveChanges()" /> is called.
    ///     </para>
    ///     <para>
    ///         A recursive search of the navigation properties will be performed to find reachable entities
    ///         that are not already being tracked by the context. All entities found will be tracked
    ///         by the context.
    ///     </para>
    ///     <para>
    ///         For entity types with generated keys if an entity has its primary key value set
    ///         then it will be tracked in the <see cref="EntityState.Modified" /> state. If the primary key
    ///         value is not set then it will be tracked in the <see cref="EntityState.Added" /> state.
    ///         This helps ensure new entities will be inserted, while existing entities will be updated.
    ///         An entity is considered to have its primary key value set if the primary key property is set
    ///         to anything other than the CLR default for the property type.
    ///     </para>
    ///     <para>
    ///         For entity types without generated keys, the state set is always <see cref="EntityState.Modified" />.
    ///     </para>
    ///     <para>
    ///         Use <see cref="EntityEntry.State" /> to set the state of only a single entity.
    ///     </para>
    ///     <para>
    ///         See <see href="https://aka.ms/efcore-docs-change-tracking">EF Core change tracking</see> for more information and examples.
    ///     </para>
    /// </remarks>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <param name="entity">The entity to update.</param>
    /// <returns>
    ///     The <see cref="EntityEntry{TEntity}" /> for the entity. The entry provides
    ///     access to change tracking information and operations for the entity.
    /// </returns>
    EntityEntry<TEntity> Update<TEntity>([NotNull] TEntity entity) where TEntity : class;

    /// <summary>
    ///     Begins tracking the given entities and entries reachable from the given entities using
    ///     the <see cref="EntityState.Modified" /> state by default, but see below for cases
    ///     when a different state will be used.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         Generally, no database interaction will be performed until <see cref="SaveChanges()" /> is called.
    ///     </para>
    ///     <para>
    ///         A recursive search of the navigation properties will be performed to find reachable entities
    ///         that are not already being tracked by the context. All entities found will be tracked
    ///         by the context.
    ///     </para>
    ///     <para>
    ///         For entity types with generated keys if an entity has its primary key value set
    ///         then it will be tracked in the <see cref="EntityState.Modified" /> state. If the primary key
    ///         value is not set then it will be tracked in the <see cref="EntityState.Added" /> state.
    ///         This helps ensure new entities will be inserted, while existing entities will be updated.
    ///         An entity is considered to have its primary key value set if the primary key property is set
    ///         to anything other than the CLR default for the property type.
    ///     </para>
    ///     <para>
    ///         For entity types without generated keys, the state set is always <see cref="EntityState.Modified" />.
    ///     </para>
    ///     <para>
    ///         Use <see cref="EntityEntry.State" /> to set the state of only a single entity.
    ///     </para>
    ///     <para>
    ///         See <see href="https://aka.ms/efcore-docs-change-tracking">EF Core change tracking</see>
    ///         and <see href="https://aka.ms/efcore-docs-attach-range">Using AddRange, UpdateRange, AttachRange, and RemoveRange</see>
    ///         for more information and examples.
    ///     </para>
    /// </remarks>
    /// <param name="entities">The entities to update.</param>
    void UpdateRange([NotNull] IEnumerable<object> entities);

    /// <summary>
    ///     Begins tracking the given entities and entries reachable from the given entities using
    ///     the <see cref="EntityState.Modified" /> state by default, but see below for cases
    ///     when a different state will be used.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         Generally, no database interaction will be performed until <see cref="SaveChanges()" /> is called.
    ///     </para>
    ///     <para>
    ///         A recursive search of the navigation properties will be performed to find reachable entities
    ///         that are not already being tracked by the context. All entities found will be tracked
    ///         by the context.
    ///     </para>
    ///     <para>
    ///         For entity types with generated keys if an entity has its primary key value set
    ///         then it will be tracked in the <see cref="EntityState.Modified" /> state. If the primary key
    ///         value is not set then it will be tracked in the <see cref="EntityState.Added" /> state.
    ///         This helps ensure new entities will be inserted, while existing entities will be updated.
    ///         An entity is considered to have its primary key value set if the primary key property is set
    ///         to anything other than the CLR default for the property type.
    ///     </para>
    ///     <para>
    ///         For entity types without generated keys, the state set is always <see cref="EntityState.Modified" />.
    ///     </para>
    ///     <para>
    ///         Use <see cref="EntityEntry.State" /> to set the state of only a single entity.
    ///     </para>
    ///     <para>
    ///         See <see href="https://aka.ms/efcore-docs-change-tracking">EF Core change tracking</see>
    ///         and <see href="https://aka.ms/efcore-docs-attach-range">Using AddRange, UpdateRange, AttachRange, and RemoveRange</see>
    ///         for more information and examples.
    ///     </para>
    /// </remarks>
    /// <param name="entities">The entities to update.</param>
    void UpdateRange([NotNull] params object[] entities);

    /// <summary>
    ///     Begins tracking the given entity in the <see cref="EntityState.Deleted" /> state such that it will
    ///     be removed from the database when <see cref="SaveChanges()" /> is called.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         If the entity is already tracked in the <see cref="EntityState.Added" /> state then the context will
    ///         stop tracking the entity (rather than marking it as <see cref="EntityState.Deleted" />) since the
    ///         entity was previously added to the context and does not exist in the database.
    ///     </para>
    ///     <para>
    ///         Any other reachable entities that are not already being tracked will be tracked in the same way that
    ///         they would be if <see cref="Attach(object)" /> was called before calling this method.
    ///         This allows any cascading actions to be applied when <see cref="SaveChanges()" /> is called.
    ///     </para>
    ///     <para>
    ///         Use <see cref="EntityEntry.State" /> to set the state of only a single entity.
    ///     </para>
    ///     <para>
    ///         See <see href="https://aka.ms/efcore-docs-change-tracking">EF Core change tracking</see> for more information and examples.
    ///     </para>
    /// </remarks>
    /// <param name="entity">The entity to remove.</param>
    /// <returns>
    ///     The <see cref="EntityEntry" /> for the entity. The entry provides
    ///     access to change tracking information and operations for the entity.
    /// </returns>
    EntityEntry Remove([NotNull] object entity);

    /// <summary>
    ///     Begins tracking the given entity in the <see cref="EntityState.Deleted" /> state such that it will
    ///     be removed from the database when <see cref="SaveChanges()" /> is called.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         If the entity is already tracked in the <see cref="EntityState.Added" /> state then the context will
    ///         stop tracking the entity (rather than marking it as <see cref="EntityState.Deleted" />) since the
    ///         entity was previously added to the context and does not exist in the database.
    ///     </para>
    ///     <para>
    ///         Any other reachable entities that are not already being tracked will be tracked in the same way that
    ///         they would be if <see cref="Attach{TEntity}(TEntity)" /> was called before calling this method.
    ///         This allows any cascading actions to be applied when <see cref="SaveChanges()" /> is called.
    ///     </para>
    ///     <para>
    ///         Use <see cref="EntityEntry.State" /> to set the state of only a single entity.
    ///     </para>
    ///     <para>
    ///         See <see href="https://aka.ms/efcore-docs-change-tracking">EF Core change tracking</see> for more information and examples.
    ///     </para>
    /// </remarks>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <param name="entity">The entity to remove.</param>
    /// <returns>
    ///     The <see cref="EntityEntry{TEntity}" /> for the entity. The entry provides
    ///     access to change tracking information and operations for the entity.
    /// </returns>
    EntityEntry<TEntity> Remove<TEntity>([NotNull] TEntity entity) where TEntity : class;

    /// <summary>
    ///     Begins tracking the given entity in the <see cref="EntityState.Deleted" /> state such that it will
    ///     be removed from the database when <see cref="SaveChanges()" /> is called.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         If any of the entities are already tracked in the <see cref="EntityState.Added" /> state then the context will
    ///         stop tracking those entities (rather than marking them as <see cref="EntityState.Deleted" />) since those
    ///         entities were previously added to the context and do not exist in the database.
    ///     </para>
    ///     <para>
    ///         Any other reachable entities that are not already being tracked will be tracked in the same way that
    ///         they would be if <see cref="AttachRange(IEnumerable{object})" /> was called before calling this method.
    ///         This allows any cascading actions to be applied when <see cref="SaveChanges()" /> is called.
    ///     </para>
    ///     <para>
    ///         See <see href="https://aka.ms/efcore-docs-change-tracking">EF Core change tracking</see>
    ///         and <see href="https://aka.ms/efcore-docs-attach-range">Using AddRange, UpdateRange, AttachRange, and RemoveRange</see>
    ///         for more information and examples.
    ///     </para>
    /// </remarks>
    /// <param name="entities">The entities to remove.</param>
    void RemoveRange([NotNull] IEnumerable<object> entities);

    /// <summary>
    ///     Begins tracking the given entity in the <see cref="EntityState.Deleted" /> state such that it will
    ///     be removed from the database when <see cref="SaveChanges()" /> is called.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         If any of the entities are already tracked in the <see cref="EntityState.Added" /> state then the context will
    ///         stop tracking those entities (rather than marking them as <see cref="EntityState.Deleted" />) since those
    ///         entities were previously added to the context and do not exist in the database.
    ///     </para>
    ///     <para>
    ///         Any other reachable entities that are not already being tracked will be tracked in the same way that
    ///         they would be if <see cref="AttachRange(object[])" /> was called before calling this method.
    ///         This allows any cascading actions to be applied when <see cref="SaveChanges()" /> is called.
    ///     </para>
    ///     <para>
    ///         See <see href="https://aka.ms/efcore-docs-change-tracking">EF Core change tracking</see>
    ///         and <see href="https://aka.ms/efcore-docs-attach-range">Using AddRange, UpdateRange, AttachRange, and RemoveRange</see>
    ///         for more information and examples.
    ///     </para>
    /// </remarks>
    /// <param name="entities">The entities to remove.</param>
    void RemoveRange([NotNull] params object[] entities);

    /// <summary>
    ///     Finds an entity with the given primary key values. If an entity with the given primary key values
    ///     is being tracked by the context, then it is returned immediately without making a request to the
    ///     database. Otherwise, a query is made to the database for an entity with the given primary key values
    ///     and this entity, if found, is attached to the context and returned. If no entity is found, then
    ///     null is returned.
    /// </summary>
    /// <remarks>
    ///     See <see href="https://aka.ms/efcore-docs-find">Using Find and FindAsync</see> for more information and examples.
    /// </remarks>
    /// <typeparam name="TEntity">The type of entity to find.</typeparam>
    /// <param name="keyValues">The values of the primary key for the entity to be found.</param>
    /// <returns>The entity found, or <see langword="null" />.</returns>
    TEntity? Find<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes)] TEntity>(params object?[]? keyValues) where TEntity : class;

    /// <summary>
    ///     Finds an entity with the given primary key values. If an entity with the given primary key values
    ///     is being tracked by the context, then it is returned immediately without making a request to the
    ///     database. Otherwise, a query is made to the database for an entity with the given primary key values
    ///     and this entity, if found, is attached to the context and returned. If no entity is found, then
    ///     null is returned.
    /// </summary>
    /// <remarks>
    ///     See <see href="https://aka.ms/efcore-docs-find">Using Find and FindAsync</see> for more information and examples.
    /// </remarks>
    /// <param name="entityType">The type of entity to find.</param>
    /// <param name="keyValues">The values of the primary key for the entity to be found.</param>
    /// <returns>The entity found, or <see langword="null" />.</returns>
    object? Find([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes)] Type entityType, params object?[]? keyValues);

    /// <summary>
    ///     Finds an entity with the given primary key values. If an entity with the given primary key values
    ///     is being tracked by the context, then it is returned immediately without making a request to the
    ///     database. Otherwise, a query is made to the database for an entity with the given primary key values
    ///     and this entity, if found, is attached to the context and returned. If no entity is found, then
    ///     null is returned.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         Entity Framework Core does not support multiple parallel operations being run on the same DbContext instance. This
    ///         includes both parallel execution of async queries and any explicit concurrent use from multiple threads.
    ///         Therefore, always await async calls immediately, or use separate DbContext instances for operations that execute
    ///         in parallel. See <see href="https://aka.ms/efcore-docs-threading">Avoiding DbContext threading issues</see>
    ///         for more information and examples.
    ///     </para>
    ///     <para>
    ///         See <see href="https://aka.ms/efcore-docs-find">Using Find and FindAsync</see> for more information and examples.
    ///     </para>
    /// </remarks>
    /// <typeparam name="TEntity">The type of entity to find.</typeparam>
    /// <param name="keyValues">The values of the primary key for the entity to be found.</param>
    /// <returns>The entity found, or <see langword="null" />.</returns>
    ValueTask<TEntity?> FindAsync<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes)] TEntity>(params object?[]? keyValues) where TEntity : class;

    /// <summary>
    ///     Finds an entity with the given primary key values. If an entity with the given primary key values
    ///     is being tracked by the context, then it is returned immediately without making a request to the
    ///     database. Otherwise, a query is made to the database for an entity with the given primary key values
    ///     and this entity, if found, is attached to the context and returned. If no entity is found, then
    ///     null is returned.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         Entity Framework Core does not support multiple parallel operations being run on the same DbContext instance. This
    ///         includes both parallel execution of async queries and any explicit concurrent use from multiple threads.
    ///         Therefore, always await async calls immediately, or use separate DbContext instances for operations that execute
    ///         in parallel. See <see href="https://aka.ms/efcore-docs-threading">Avoiding DbContext threading issues</see>
    ///         for more information and examples.
    ///     </para>
    ///     <para>
    ///         See <see href="https://aka.ms/efcore-docs-find">Using Find and FindAsync</see> for more information and examples.
    ///     </para>
    /// </remarks>
    /// <param name="entityType">The type of entity to find.</param>
    /// <param name="keyValues">The values of the primary key for the entity to be found.</param>
    /// <returns>The entity found, or <see langword="null" />.</returns>
    ValueTask<object?> FindAsync([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes)] Type entityType, params object?[]? keyValues);

    /// <summary>
    ///     Finds an entity with the given primary key values. If an entity with the given primary key values
    ///     is being tracked by the context, then it is returned immediately without making a request to the
    ///     database. Otherwise, a query is made to the database for an entity with the given primary key values
    ///     and this entity, if found, is attached to the context and returned. If no entity is found, then
    ///     null is returned.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         Entity Framework Core does not support multiple parallel operations being run on the same DbContext instance. This
    ///         includes both parallel execution of async queries and any explicit concurrent use from multiple threads.
    ///         Therefore, always await async calls immediately, or use separate DbContext instances for operations that execute
    ///         in parallel. See <see href="https://aka.ms/efcore-docs-threading">Avoiding DbContext threading issues</see>
    ///         for more information and examples.
    ///     </para>
    ///     <para>
    ///         See <see href="https://aka.ms/efcore-docs-find">Using Find and FindAsync</see> for more information and examples.
    ///     </para>
    /// </remarks>
    /// <typeparam name="TEntity">The type of entity to find.</typeparam>
    /// <param name="keyValues">The values of the primary key for the entity to be found.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken" /> to observe while waiting for the task to complete.</param>
    /// <returns>The entity found, or <see langword="null" />.</returns>
    /// <exception cref="OperationCanceledException">If the <see cref="CancellationToken" /> is canceled.</exception>
    ValueTask<TEntity?> FindAsync<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes)] TEntity>(object?[]? keyValues, CancellationToken cancellationToken) where TEntity : class;

    /// <summary>
    ///     Finds an entity with the given primary key values. If an entity with the given primary key values
    ///     is being tracked by the context, then it is returned immediately without making a request to the
    ///     database. Otherwise, a query is made to the database for an entity with the given primary key values
    ///     and this entity, if found, is attached to the context and returned. If no entity is found, then
    ///     null is returned.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         Entity Framework Core does not support multiple parallel operations being run on the same DbContext instance. This
    ///         includes both parallel execution of async queries and any explicit concurrent use from multiple threads.
    ///         Therefore, always await async calls immediately, or use separate DbContext instances for operations that execute
    ///         in parallel. See <see href="https://aka.ms/efcore-docs-threading">Avoiding DbContext threading issues</see>
    ///         for more information and examples.
    ///     </para>
    ///     <para>
    ///         See <see href="https://aka.ms/efcore-docs-find">Using Find and FindAsync</see> for more information and examples.
    ///     </para>
    /// </remarks>
    /// <param name="entityType">The type of entity to find.</param>
    /// <param name="keyValues">The values of the primary key for the entity to be found.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken" /> to observe while waiting for the task to complete.</param>
    /// <returns>The entity found, or <see langword="null" />.</returns>
    /// <exception cref="OperationCanceledException">If the <see cref="CancellationToken" /> is canceled.</exception>
    ValueTask<object?> FindAsync([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes)] Type entityType, object?[]? keyValues, CancellationToken cancellationToken);

    /// <summary>
    ///     Gets an <see cref="EntityEntry{TEntity}" /> for the given entity. The entry provides
    ///     access to change tracking information and operations for the entity.
    /// </summary>
    /// <remarks>
    ///     See <see href="https://aka.ms/efcore-docs-entity-entries">Accessing tracked entities in EF Core</see> for more information and
    ///     examples.
    /// </remarks>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <param name="entity">The entity to get the entry for.</param>
    /// <returns>The entry for the given entity.</returns>
    EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

    /// <summary>
    ///     Gets an <see cref="EntityEntry" /> for the given entity. The entry provides
    ///     access to change tracking information and operations for the entity.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         This method may be called on an entity that is not tracked. You can then
    ///         set the <see cref="EntityEntry.State" /> property on the returned entry
    ///         to have the context begin tracking the entity in the specified state.
    ///     </para>
    ///     <para>
    ///         See <see href="https://aka.ms/efcore-docs-entity-entries">Accessing tracked entities in EF Core</see> for more information and
    ///         examples.
    ///     </para>
    /// </remarks>
    /// <param name="entity">The entity to get the entry for.</param>
    /// <returns>The entry for the given entity.</returns>
    EntityEntry Entry(object entity);

    /// <summary>
    ///     Creates a queryable for given query expression.
    /// </summary>
    /// <remarks>
    ///     See <see href="https://aka.ms/efcore-docs-query">Querying data with EF Core</see> for more information and examples.
    /// </remarks>
    /// <typeparam name="TResult">The result type of the query expression.</typeparam>
    /// <param name="expression">The query expression to create.</param>
    /// <returns>An <see cref="IQueryable{T}" /> representing the query.</returns>
    IQueryable<TResult> FromExpression<TResult>(Expression<Func<IQueryable<TResult>>> expression);

    internal const DynamicallyAccessedMemberTypes DynamicallyAccessedMemberTypes = System.Diagnostics.CodeAnalysis.DynamicallyAccessedMemberTypes.PublicConstructors
                                                                                 | System.Diagnostics.CodeAnalysis.DynamicallyAccessedMemberTypes.NonPublicConstructors
                                                                                 | System.Diagnostics.CodeAnalysis.DynamicallyAccessedMemberTypes.PublicProperties
                                                                                 | System.Diagnostics.CodeAnalysis.DynamicallyAccessedMemberTypes.PublicFields
                                                                                 | System.Diagnostics.CodeAnalysis.DynamicallyAccessedMemberTypes.NonPublicProperties
                                                                                 | System.Diagnostics.CodeAnalysis.DynamicallyAccessedMemberTypes.NonPublicFields
                                                                                 | System.Diagnostics.CodeAnalysis.DynamicallyAccessedMemberTypes.Interfaces;
}
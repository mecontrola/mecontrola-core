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
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.Core.Repositories;

/// <summary>
/// Provides a base implementation for an asynchronous repository handling basic operations with entities many-to-many.
/// </summary>
/// <typeparam name="TEntity">The type of entity being managed by the repository.</typeparam>
/// <param name="context">The <see cref="IDbContext"/> used to interact with the database.</param>
/// <param name="dbSet">The <see cref="DbSet{TEntity}"/> that provides access to entities in the database.</param>
public class BaseManyAsyncRepository<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TEntity>(IDbContext context, DbSet<TEntity> dbSet)
    : IManyAsyncRepository<TEntity>
    where TEntity : class, IForeignKeysManyEntity
{
    /// <summary>
    /// The database context used by the repository.
    /// </summary>
    private readonly IDbContext context = context;

    /// <summary>
    /// The <see cref="DbSet{TEntity}"/> representing the entity collection in the database.
    /// </summary>
    private readonly DbSet<TEntity> dbSet = dbSet;

    /// <summary>
    /// Gets the current database context instance associated with the repository.
    /// </summary>
    /// <value>The <see cref="IDbContext"/> used for database operations.</value>
    protected IDbContext Context { get => context; }

    /// <summary>
    /// Gets the <see cref="DbSet{TEntity}"/> associated with the entity type <typeparamref name="TEntity"/>.
    /// </summary>
    /// <value>The <see cref="DbSet{TEntity}"/> used for querying and persisting entities of type <typeparamref name="TEntity"/>.</value>
    protected DbSet<TEntity> DbSet { get => dbSet; }

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
    public virtual async Task<bool> CreateAsync(TEntity obj, CancellationToken cancellationToken)
    {
        Detach(obj, EntityState.Added);

        return await ApplyAlterContextAsync(dbSet => dbSet.Add(obj), cancellationToken);
    }

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
    public virtual async Task<bool> RemoveAsync(TEntity obj, CancellationToken cancellationToken)
    {
        Detach(obj, EntityState.Deleted);

        return await ApplyAlterContextAsync(dbSet => dbSet.Remove(obj), cancellationToken);
    }

    /// <summary>
    /// Asynchronously checks if an entity exists.
    /// </summary>
    /// <param name="obj">The entity to check for existence.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A task representing the asynchronous operation, containing a boolean result:
    /// <see langword="true"/> if the entity exists; otherwise, <see langword="false"/>.
    /// </returns>
    public async Task<bool> ExistsAsync(TEntity obj, CancellationToken cancellationToken)
        => await DbSet.AnyAsync(itm => itm.RootId.Equals(obj.RootId) && itm.TargetId.Equals(obj.TargetId), cancellationToken);

    /// <summary>
    /// Detaches the specified entity from the context, setting its state to the provided <see cref="EntityState"/>.
    /// </summary>
    /// <param name="entity">The entity to detach from the context.</param>
    /// <param name="entityState">The state to be assigned to the entity after detaching.</param>
    protected virtual void Detach(TEntity entity, EntityState entityState)
    {
        var local = DbSet.Local.FirstOrDefault(itm => itm.RootId.Equals(entity.RootId)
                                                   && itm.TargetId.Equals(entity.TargetId));
        var rootId = local?.RootId ?? 0;
        var targetId = local?.TargetId ?? 0;

        if (rootId != 0 && targetId != 0)
            Context.Entry(local).State = EntityState.Detached;

        Context.Entry(entity).State = entityState;
    }

    private async Task<bool> ApplyAlterContextAsync(Action<DbSet<TEntity>> action, CancellationToken cancellationToken)
    {
        action(DbSet);

        return await Context.SaveChangesAsync(cancellationToken) > 0;
    }
}
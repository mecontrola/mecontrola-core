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
using MeControla.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.Core.Repositories;

/// <summary>
/// Provides a base implementation for an asynchronous repository handling basic operations with entities.
/// </summary>
/// <typeparam name="TEntity">The type of entity being managed by the repository.</typeparam>
public abstract class BaseAsyncRepository<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TEntity>
    : ContextRepository<TEntity>, IAsyncRepository<TEntity>
    where TEntity : class, IEntity
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BaseAsyncRepository{TEntity}"/> class.
    /// </summary>
    /// <param name="context">The <see cref="IDbContext"/> used to interact with the database.</param>
    protected BaseAsyncRepository(IDbContext context)
        : base(context)
    { }

    /// <summary>
    /// Asynchronously returns the number of elements in a sequence.
    /// </summary>
    /// <param name="cancellationToken">A <see cref="CancellationToken" /> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the number of elements in the input sequence.
    /// </returns>
    public virtual async Task<long> CountAsync(CancellationToken cancellationToken)
        => await DbSet.LongCountAsync(cancellationToken);

    /// <summary>
    /// Asynchronously returns the number of elements in a sequence.
    /// </summary>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken" /> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the number of elements in the input sequence.
    /// </returns>
    public virtual async Task<long> CountAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
        => await DbSet.LongCountAsync(predicate, cancellationToken);

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
    public async Task<TEntity?> SaveAsync(TEntity obj, CancellationToken cancellationToken)
    {
        try
        {
            if (obj.Id == 0)
                await CreateInternalAsync(obj, cancellationToken);
            else
                await UpdateAsync(obj, cancellationToken);

            return obj;
        }
        catch
        {
            return null;
        }
    }

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
    public virtual async Task<TEntity> CreateAsync(TEntity obj, CancellationToken cancellationToken)
    {
        await CreateInternalAsync(obj, cancellationToken);

        return obj;
    }

    private async Task<bool> CreateInternalAsync(TEntity obj, CancellationToken cancellationToken)
    {
        Detach(obj, EntityState.Added);

        return await ApplyAlterContextAsync(dbSet => dbSet.Add(obj), cancellationToken);
    }

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
    public virtual async Task<bool> UpdateAsync(TEntity obj, CancellationToken cancellationToken)
    {
        Detach(obj, EntityState.Modified);

        return await ApplyAlterContextAsync(dbSet => dbSet.Update(obj), cancellationToken);
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
    /// Asynchronously retrieves a paginated list of entities.
    /// </summary>
    /// <param name="pagination">The pagination details to apply to the query, including page and limit.</param>
    /// <param name="cancellationToken">A cancellation token that can be used to cancel the operation.</param>
    /// <returns>A task representing the asynchronous operation, containing a paginated list of entities.</returns>
    [RequiresUnreferencedCode("This method uses reflection, which may not be compatible with trimming.")]
    public virtual async Task<IPagination<TEntity>> FindAllPagedAsync(IPagination pagination, CancellationToken cancellationToken)
        => await InternalFindAllPagedAsync(pagination, null, cancellationToken);

    /// <summary>
    /// Asynchronously retrieves a paginated list of entities that match the given predicate.
    /// </summary>
    /// <param name="pagination">The pagination details to apply to the query, including page and limit.</param>
    /// <param name="predicate">An expression that filters the entities.</param>
    /// <param name="cancellationToken">A cancellation token that can be used to cancel the operation.</param>
    /// <returns>A task representing the asynchronous operation, containing a paginated list of entities matching the predicate.</returns>
    [RequiresUnreferencedCode("This method uses reflection, which may not be compatible with trimming.")]
    public virtual async Task<IPagination<TEntity>> FindAllPagedAsync(IPagination pagination, Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
        => await InternalFindAllPagedAsync(pagination, predicate, cancellationToken);

    [RequiresUnreferencedCode("This method uses reflection, which may not be compatible with trimming.")]
    private async Task<IPagination<TEntity>> InternalFindAllPagedAsync(IPagination pagination, Expression<Func<TEntity, bool>>? predicate, CancellationToken cancellationToken)
    {
        var query = predicate is null
                  ? DbSet.SetFilterBy(pagination.FilterBy)
                  : DbSet.SetPredicate(predicate)
                         .SetFilterBy(pagination.FilterBy);

        var total = await query.CountAsync(cancellationToken);

        var list = await query.SetPagination(pagination)
                              .SetSortBy(pagination.SortBy)
                              .ToListAsync(cancellationToken);

        return list.PaginationBy(pagination, total);
    }

    /// <summary>
    /// Asynchronously finds all entities.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains a list of entities.</returns>
    public virtual async Task<IList<TEntity>> FindAllAsync(CancellationToken cancellationToken)
        => await InternalFindAllAsync(null, cancellationToken);

    /// <summary>
    /// Asynchronously finds all entities that match the provided predicate.
    /// </summary>
    /// <param name="predicate">An expression to filter the entities.</param>
    /// <param name="cancellationToken">A cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains a list of entities that satisfy the given predicate.</returns>
    public virtual async Task<IList<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
        => await InternalFindAllAsync(predicate, cancellationToken);

    private async Task<IList<TEntity>> InternalFindAllAsync(Expression<Func<TEntity, bool>>? predicate, CancellationToken cancellationToken)
        => predicate is not null
         ? await DbSet.SetPredicate(predicate).ToListAsync(cancellationToken)
         : await DbSet.ToListAsync(cancellationToken);

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
    public virtual async Task<TEntity?> FindAsync(long id, CancellationToken cancellationToken)
        => await FindAsync(itm => itm.Id.Equals(id), cancellationToken);

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
    public virtual async Task<TEntity?> FindAsync(Guid uuid, CancellationToken cancellationToken)
        => await FindAsync(itm => itm.Uuid.Equals(uuid), cancellationToken);

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
    public virtual async Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
        => await DbSet.AsNoTracking()
                      .Where(predicate)
                      .FirstOrDefaultAsync(cancellationToken);

    /// <summary>
    /// Asynchronously checks if an entity with the specified identifier exists.
    /// </summary>
    /// <param name="id">The identifier of the entity to check for existence.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A task representing the asynchronous operation, containing a boolean result:
    /// <c>true</c> if the entity exists; otherwise, <c>false</c>.
    /// </returns>
    public async Task<bool> ExistsAsync(long id, CancellationToken cancellationToken)
            => await ExistsAsync(itm => itm.Id.Equals(id), cancellationToken);

    /// <summary>
    /// Asynchronously checks if an entity with the specified uuid exists.
    /// </summary>
    /// <param name="uuid">The uuid of the entity to check for existence.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A task representing the asynchronous operation, containing a boolean result:
    /// <c>true</c> if the entity exists; otherwise, <c>false</c>.
    /// </returns>
    public async Task<bool> ExistsAsync(Guid uuid, CancellationToken cancellationToken)
        => await ExistsAsync(itm => itm.Uuid.Equals(uuid), cancellationToken);

    /// <summary>
    /// Asynchronously determines whether any element of a sequence satisfies a condition.
    /// </summary>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A task representing the asynchronous operation, containing a boolean result:
    /// <c>true</c> if the entity exists; otherwise, <c>false</c>.
    /// </returns>
    public async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
        => await DbSet.AnyAsync(predicate, cancellationToken);

    /// <summary>
    /// Detaches the specified entity from the context, setting its state to the provided <see cref="EntityState"/>.
    /// </summary>
    /// <param name="entity">The entity to detach from the context.</param>
    /// <param name="entityState">The state to be assigned to the entity after detaching.</param>
    protected virtual void Detach(TEntity entity, EntityState entityState)
    {
        var local = DbSet.Local.FirstOrDefault(itm => itm.Id.Equals(entity.Id));
        var id = local?.Id ?? 0;

        if (local is not null && id != 0)
            Context.Entry(local).State = EntityState.Detached;

        Context.Entry(entity).State = entityState;
    }

    private async Task<bool> ApplyAlterContextAsync(Action<DbSet<TEntity>> action, CancellationToken cancellationToken)
    {
        action(DbSet);

        return Context.Database.CurrentTransaction != null
            || await Context.SaveChangesAsync(cancellationToken) > 0;
    }
}
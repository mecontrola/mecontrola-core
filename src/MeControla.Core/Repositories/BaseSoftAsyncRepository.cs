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
public abstract class BaseSoftAsyncRepository<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TEntity>
    : BaseAsyncRepository<TEntity>, IAsyncRepository<TEntity>
    where TEntity : class, ISoftEntity
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BaseSoftAsyncRepository{TEntity}"/> class.
    /// </summary>
    /// <param name="context">The <see cref="IDbContext"/> used to interact with the database.</param>
    /// <param name="dbSet">The <see cref="DbSet{TEntity}"/> that provides access to entities in the database.</param>
    protected BaseSoftAsyncRepository(IDbContext context, DbSet<TEntity> dbSet)
        : base(context, dbSet)
    { }

    /// <summary>
    /// Asynchronously returns the number of elements in a sequence.
    /// </summary>
    /// <param name="cancellationToken">A <see cref="CancellationToken" /> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the number of elements in the input sequence.
    /// </returns>
    public new virtual async Task<long> CountAsync(CancellationToken cancellationToken)
        => await base.CountAsync(itm => !itm.IsDeleted, cancellationToken);

    /// <summary>
    /// Asynchronously returns the number of elements in a sequence.
    /// </summary>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken" /> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the number of elements in the input sequence.
    /// </returns>
    public new virtual async Task<long> CountAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
        => await base.CountAsync(predicate.Combine(itm => !itm.IsDeleted), cancellationToken);

    /// <summary>
    /// Asynchronously logically removes the specified entity from the repository.
    /// </summary>
    /// <param name="obj">The entity to be removed.</param>
    /// <param name="cancellationToken">
    /// A <see cref="CancellationToken"/> that can be used to cancel the asynchronous operation.
    /// </param>
    /// <returns>
    /// A task representing the asynchronous operation. The task result contains <see langword="true"/> if the entity was removed successfully; otherwise, <see langword="false"/>.
    /// </returns>
    public new virtual async Task<bool> RemoveAsync(TEntity obj, CancellationToken cancellationToken)
    {
        using var transaction = await Context.Database.BeginTransactionAsync(cancellationToken);

        try
        {
            var trackedEntity = Context.ChangeTracker.Entries<TEntity>().FirstOrDefault(e => e.Entity.Id == obj.Id);
            if (trackedEntity != null)
                Context.Entry(trackedEntity.Entity).State = EntityState.Detached;

            Context.Entry(obj).State = EntityState.Deleted;

            var rowsAffected = await Context.SaveChangesAsync(cancellationToken);
            if (rowsAffected == 0)
                throw new DbUpdateConcurrencyException();

            await transaction.RollbackAsync(cancellationToken);

            obj.IsDeleted = true;

            Context.Entry(obj).State = EntityState.Modified;

            await Context.SaveChangesAsync(cancellationToken);

            return true;
        }
        catch (Exception)
        {
            await transaction.RollbackAsync(cancellationToken);

            Context.Entry(obj).State = EntityState.Detached;

            return false;
        }
    }

    /// <summary>
    /// Asynchronously retrieves a paginated list of entities.
    /// </summary>
    /// <param name="pagination">The pagination details to apply to the query, including page and limit.</param>
    /// <param name="cancellationToken">A cancellation token that can be used to cancel the operation.</param>
    /// <returns>A task representing the asynchronous operation, containing a paginated list of entities.</returns>
    [RequiresUnreferencedCode("This method uses reflection, which may not be compatible with trimming.")]
    public new virtual async Task<IPagination<TEntity>> FindAllPagedAsync(IPagination pagination, CancellationToken cancellationToken)
        => await base.FindAllPagedAsync(pagination, itm => !itm.IsDeleted, cancellationToken);

    /// <summary>
    /// Asynchronously retrieves a paginated list of entities that match the given predicate.
    /// </summary>
    /// <param name="pagination">The pagination details to apply to the query, including page and limit.</param>
    /// <param name="predicate">An expression that filters the entities.</param>
    /// <param name="cancellationToken">A cancellation token that can be used to cancel the operation.</param>
    /// <returns>A task representing the asynchronous operation, containing a paginated list of entities matching the predicate.</returns>
    [RequiresUnreferencedCode("This method uses reflection, which may not be compatible with trimming.")]
    public new virtual async Task<IPagination<TEntity>> FindAllPagedAsync(IPagination pagination, Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
        => await base.FindAllPagedAsync(pagination, predicate.Combine(itm => !itm.IsDeleted), cancellationToken);

    /// <summary>
    /// Asynchronously finds all entities.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains a list of entities.</returns>
    public new virtual async Task<IList<TEntity>> FindAllAsync(CancellationToken cancellationToken)
        => await base.FindAllAsync(itm => !itm.IsDeleted, cancellationToken);

    /// <summary>
    /// Asynchronously finds all entities that match the provided predicate.
    /// </summary>
    /// <param name="predicate">An expression to filter the entities.</param>
    /// <param name="cancellationToken">A cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains a list of entities that satisfy the given predicate.</returns>
    public new virtual async Task<IList<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
        => await base.FindAllAsync(predicate.Combine(itm => !itm.IsDeleted), cancellationToken);

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
    public new virtual async Task<TEntity> FindAsync(long id, CancellationToken cancellationToken)
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
    public new virtual async Task<TEntity> FindAsync(Guid uuid, CancellationToken cancellationToken)
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
    public new virtual async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
        => await base.FindAsync(predicate.Combine(itm => !itm.IsDeleted), cancellationToken);

    /// <summary>
    /// Asynchronously checks if an entity with the specified identifier exists.
    /// </summary>
    /// <param name="id">The identifier of the entity to check for existence.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A task representing the asynchronous operation, containing a boolean result:
    /// <c>true</c> if the entity exists; otherwise, <c>false</c>.
    /// </returns>
    public new async Task<bool> ExistsAsync(long id, CancellationToken cancellationToken)
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
    public new async Task<bool> ExistsAsync(Guid uuid, CancellationToken cancellationToken)
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
    public new async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
        => await base.ExistsAsync(predicate.Combine(itm => !itm.IsDeleted), cancellationToken);
}
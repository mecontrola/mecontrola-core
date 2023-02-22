using MeControla.Core.Data.Entities;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.Core.Repositories
{
    public interface IAsyncRepository<TEntity>
        where TEntity : class, IEntity
    {
        DatabaseFacade Database();
        Task<long> CountAsync(CancellationToken cancellationToken);
        Task<long> CountAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);
        Task<IList<TEntity>> FindAllPagedAsync(IPaginationFilter paginationFilter, CancellationToken cancellationToken);
        Task<IList<TEntity>> FindAllPagedAsync(IPaginationFilter paginationFilter, Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);
        Task<IList<TEntity>> FindAllAsync(CancellationToken cancellationToken);
        Task<IList<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);
        Task<TEntity> FindAsync(long id, CancellationToken cancellationToken);
        Task<TEntity> FindAsync(Guid uuid, CancellationToken cancellationToken);
        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);
        Task<TEntity> CreateAsync(TEntity obj, CancellationToken cancellationToken);
        Task<bool> UpdateAsync(TEntity obj, CancellationToken cancellationToken);
        Task<bool> RemoveAsync(TEntity obj, CancellationToken cancellationToken);
        Task<bool> ExistsAsync(long id, CancellationToken cancellationToken);
        Task<bool> ExistsAsync(Guid uuid, CancellationToken cancellationToken);
        Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);
    }
}
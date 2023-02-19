using MeControla.Core.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.Core.Repositories
{
    public class BaseManyAsyncRepository<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TEntity, TRoot, TTarget> : IManyAsyncRepository<TEntity, TRoot, TTarget>
        where TEntity : class, IManyEntity<TRoot, TTarget>
        where TRoot : IEntity
        where TTarget : IEntity
    {
        protected readonly IDbContext context;

        protected readonly DbSet<TEntity> dbSet;

        protected BaseManyAsyncRepository(IDbContext context, DbSet<TEntity> dbSet)
        {
            this.context = context;
            this.dbSet = dbSet;
        }

        public virtual async Task<bool> CreateAsync(TEntity obj, CancellationToken cancellationToken)
            => await ApplyAlterContextAsync(dbSet => dbSet.Add(obj), cancellationToken);

        public virtual async Task<bool> RemoveAsync(TEntity obj, CancellationToken cancellationToken)
            => await ApplyAlterContextAsync(dbSet => dbSet.Remove(obj), cancellationToken);

        public async Task<bool> ExistsAsync(TEntity obj, CancellationToken cancellationToken)
            => await dbSet.AnyAsync(itm => itm.RootId.Equals(obj.RootId) && itm.TargetId.Equals(obj.TargetId), cancellationToken);

        private async Task<bool> ApplyAlterContextAsync(Action<DbSet<TEntity>> action, CancellationToken cancellationToken)
        {
            action(dbSet);

            return await context.SaveChangesAsync(cancellationToken) > 0;
        }
    }
}
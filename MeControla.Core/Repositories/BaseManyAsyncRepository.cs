using MeControla.Core.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
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
        {
            Detach(obj, EntityState.Added);

            return await ApplyAlterContextAsync(dbSet => dbSet.Add(obj), cancellationToken);
        }

        public virtual async Task<bool> RemoveAsync(TEntity obj, CancellationToken cancellationToken)
        {
            Detach(obj, EntityState.Deleted);

            return await ApplyAlterContextAsync(dbSet => dbSet.Remove(obj), cancellationToken);
        }

        public async Task<bool> ExistsAsync(TEntity obj, CancellationToken cancellationToken)
            => await dbSet.AnyAsync(itm => itm.RootId.Equals(obj.RootId) && itm.TargetId.Equals(obj.TargetId), cancellationToken);

        protected virtual void Detach(TEntity entity, EntityState entityState)
        {
            var local = dbSet.Local.FirstOrDefault(itm => itm.RootId.Equals(entity.RootId)
                                                       && itm.TargetId.Equals(entity.TargetId));
            var rootId = local?.RootId ?? 0;
            var targetId = local?.TargetId ?? 0;

            if (rootId != 0 && targetId != 0)
                context.Entry(local).State = EntityState.Detached;

            context.Entry(entity).State = entityState;
        }

        protected async Task<bool> ApplyAlterContextAsync(Action<DbSet<TEntity>> action, CancellationToken cancellationToken)
        {
            action(dbSet);

            return await context.SaveChangesAsync(cancellationToken) > 0;
        }
    }
}
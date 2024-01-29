using MeControla.Core.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.Core.Repositories
{
    public abstract class BaseFilterAsyncRepository<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TEntity, TFilterEntity>
        : BaseAsyncRepository<TEntity>, IFilterAsyncRepository<TEntity, TFilterEntity>
        where TEntity : class, IEntity
        where TFilterEntity : class, IFilterEntity
    {
        protected BaseFilterAsyncRepository(IDbContext context, DbSet<TEntity> dbSet)
            : base(context, dbSet)
        { }

        public abstract Task<IList<TEntity>> FindFilterAllAsync(TFilterEntity filter, CancellationToken cancellationToken);
    }
}
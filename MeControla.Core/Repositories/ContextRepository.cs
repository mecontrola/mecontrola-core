using MeControla.Core.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace MeControla.Core.Repositories
{
    public abstract class ContextRepository<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TEntity>
         where TEntity : class, IEntity
    {
        protected readonly IDbContext context;
        protected readonly DbSet<TEntity> dbSet;
        private DbContextFacade database;

        protected ContextRepository([NotNull] IDbContext context, [NotNull] DbSet<TEntity> dbSet)
        {
            this.context = context;
            this.dbSet = dbSet;
        }

        public IDbContextFacade Database()
            => database ??= new DbContextFacade(context.Database);
    }
}
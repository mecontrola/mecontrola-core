using MeControla.Core.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Diagnostics.CodeAnalysis;

namespace MeControla.Core.Repositories
{
    public abstract class ContextRepository<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TEntity>
         where TEntity : class, IEntity
    {
        protected readonly IDbContext context;
        protected readonly DbSet<TEntity> dbSet;

        protected ContextRepository(IDbContext context, DbSet<TEntity> dbSet)
        {
            this.context = context;
            this.dbSet = dbSet ?? throw new ArgumentNullException(nameof(dbSet));
        }

        public DatabaseFacade Database()
            => context.Database;
    }
}
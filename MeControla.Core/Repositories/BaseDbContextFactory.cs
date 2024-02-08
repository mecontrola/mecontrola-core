using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Diagnostics.CodeAnalysis;

namespace MeControla.Core.Repositories
{
    public abstract class BaseDbContextFactory<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TDbContext>
        : IDesignTimeDbContextFactory<TDbContext>, IDisposable
        where TDbContext : DbContext
    {
        private TDbContext context;

        public TDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TDbContext>();

            Configure(optionsBuilder);

            context = (TDbContext)Activator.CreateInstance(typeof(TDbContext), new object[] { optionsBuilder.Options });

            return context;
        }

        protected abstract void Configure(DbContextOptionsBuilder<TDbContext> options);

        public void Dispose()
        {
            context?.Dispose();

            GC.SuppressFinalize(this);
        }
    }
}
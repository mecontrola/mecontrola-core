using MeControla.Core.Tests.Mocks.Datas.Entities;
using Microsoft.EntityFrameworkCore;

namespace MeControla.Core.Tests.Mocks.Datas.Repositories
{
    public sealed partial class DbAppContext : DbContext, IDbAppContext
    {
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserPermission> UserPermissions { get; set; }

        public DbAppContext(DbContextOptions<DbAppContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserPermission>().HasKey(entity => new { entity.RootId, entity.TargetId });
        }
    }
}
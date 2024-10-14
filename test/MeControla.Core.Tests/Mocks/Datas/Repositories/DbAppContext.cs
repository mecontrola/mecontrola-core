using MeControla.Core.Tests.Mocks.Datas.Entities;
using Microsoft.EntityFrameworkCore;

namespace MeControla.Core.Tests.Mocks.Datas.Repositories;

public sealed partial class DbAppContext(DbContextOptions<DbAppContext> options)
        : DbContext(options), IDbAppContext
{
    public DbSet<Permission> Permissions { get; set; }
    public DbSet<SoftUser> SoftUsers { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserPermission> UserPermissions { get; set; }
    public DbSet<WorkTask> WorkTasks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        => modelBuilder.Entity<UserPermission>().HasKey(entity => new { entity.RootId, entity.TargetId });
}
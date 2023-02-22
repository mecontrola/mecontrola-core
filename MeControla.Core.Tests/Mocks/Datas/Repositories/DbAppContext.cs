using MeControla.Core.Tests.Mocks.Datas.Entities;
using Microsoft.EntityFrameworkCore;

namespace MeControla.Core.Tests.Mocks.Datas.Repositories
{
    public sealed partial class DbAppContext : DbContext, IDbAppContext
    {
        public DbSet<User> Users { get; set; }

        public DbAppContext(DbContextOptions<DbAppContext> options)
            : base(options)
        { }
    }
}
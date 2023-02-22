using MeControla.Core.Tests.Mocks.Datas.Repositories;
using MeControla.Core.Tests.Mocks.Entities;
using Microsoft.EntityFrameworkCore;

namespace MeControla.Core.Tests.Mocks.Repositories
{
    public abstract class BaseRepository
    {
        private const string DATABASE_FILENAME = "storage.db";

        public static IDbAppContext GetDbInstance()
        {
            var context = new DbAppContext(CreateDbOptions());

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            Seed(context);

            return context;
        }

        private static DbContextOptions<DbAppContext> CreateDbOptions()
            => new DbContextOptionsBuilder<DbAppContext>()
                .UseSqlite($"Data Source={DATABASE_FILENAME}")
                .Options;

        private static void Seed(DbAppContext context)
        {
            context.Users.AddRange(UserMock.CreateList());
            context.SaveChanges();
        }
    }
}
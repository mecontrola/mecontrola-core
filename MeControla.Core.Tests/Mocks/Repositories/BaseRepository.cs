using MeControla.Core.Tests.Mocks.Datas.Repositories;
using MeControla.Core.Tests.Mocks.Entities;
using MeControla.Core.Tests.TestingTools;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;

namespace MeControla.Core.Tests.Mocks.Repositories
{
    public abstract class BaseRepository : BaseAsyncMethods, IDisposable
    {
        private const string InMemoryConnectionString = "DataSource=:memory:";

        private SqliteConnection connection;

        protected readonly IDbAppContext context;

        protected BaseRepository()
        {
            connection = new SqliteConnection(InMemoryConnectionString);
            connection.Open();

            var options = new DbContextOptionsBuilder<DbAppContext>()
                                                        .UseSqlite(connection)
                                                        .Options;

            context = new DbAppContext(options);
            context.Database.EnsureCreated();

            Seed(context);
        }

        private static void Seed(IDbAppContext context)
        {
            context.Users.AddRange(UserMock.CreateList());
            context.Permissions.AddRange(PermissionMock.CreateList());
            context.UserPermissions.AddRange(UserPermissionMock.CreateList());
            context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing || connection == null)
                return;

            connection.Dispose();
            connection = null;
        }
    }
}
using FluentAssertions;
using MeControla.Core.Repositories;
using MeControla.Core.Tests.Mocks.Datas.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;

namespace MeControla.Core.Tests.Repositories
{
    public sealed class BaseDbContextFactoryTests
    {
        private class TestDbContextFactory : BaseDbContextFactory<DbAppContext>
        {
            protected override void Configure(DbContextOptionsBuilder<DbAppContext> options)
                => options.UseSqlite("DataSource=:memory:");
        }

        [Fact(DisplayName = "[BaseDbContextFactory.CreateDbContext|Dispose] Cria DbAppContext a través da implementação do BaseDbContextFactory e ao final utiliza o dispose para finalizar o contexto.")]
        public void CreateDbContext_ShouldCreateDbContextWithConfiguredOptions()
        {
            var factory = new TestDbContextFactory();

            var dbContext = factory.CreateDbContext(null);

            dbContext.Should().NotBeNull();
            dbContext.Should().BeOfType<DbAppContext>();
            dbContext.Database.Should().NotBeNull();
            dbContext.Database.ProviderName.Should().NotBeNullOrWhiteSpace();

            factory.Dispose();

            var act = () => dbContext.Database;
            act.Should().Throw<ObjectDisposedException>();
        }
    }
}
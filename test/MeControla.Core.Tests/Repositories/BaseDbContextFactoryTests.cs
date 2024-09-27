using FluentAssertions;
using MeControla.Core.Repositories;
using MeControla.Core.Tests.Mocks.Datas.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;
using Xunit;

namespace MeControla.Core.Tests.Repositories;

public sealed class BaseDbContextFactoryTests
{
    private class TestDbContextFactory : BaseDbContextFactory<DbAppContext>
    {
        protected override void Configure(DbContextOptionsBuilder<DbAppContext> options)
            => options.UseSqlite("DataSource=:memory:");
    }

#if DEBUG
    private class TestDbContextNullFactory : BaseDbContextFactory<DbAppContext>
    {
        protected override void Configure(DbContextOptionsBuilder<DbAppContext> options)
        { }

        protected override DbAppContext CreateInstanceDbContext(DbContextOptionsBuilder<DbAppContext> optionsBuilder)
            => null;
    }
#endif

    [Fact(DisplayName = "[BaseDbContextFactory.CreateDbContext|Dispose] Cria DbAppContext a través da implementação do BaseDbContextFactory e ao final utiliza o dispose para finalizar o contexto.")]
    public void DeveCriarDbContextComConfiguredOptionsNull()
    {
        using var factory = new TestDbContextFactory();

        var dbContext = factory.CreateDbContext(null);

        dbContext.Should().NotBeNull();
        dbContext.Should().BeOfType<DbAppContext>();
        dbContext.Database.Should().NotBeNull();
        dbContext.Database.ProviderName.Should().NotBeNullOrWhiteSpace();

        factory.Dispose();

        var act = () => dbContext.Database;
        act.Should().Throw<ObjectDisposedException>();
    }

#if DEBUG
    [Fact(DisplayName = "[BaseDbContextFactory.CreateDbContext|Dispose] Cria DbAppContext a través da implementação do BaseDbContextFactory e executar dispose quando context for null.")]
    public void DeveChamarDisposeDbContext()
    {
        using var factory = new TestDbContextNullFactory();
        var context = factory.CreateDbContext([]);

        factory.Dispose();

        using var dbContext = context as DbContext;
        dbContext.Should().BeNull();
    }
#endif

    [Fact(DisplayName = "[BaseDbContextFactory.CreateDbContext|Dispose] Cria DbAppContext a través da implementação do BaseDbContextFactory e ao final utiliza o dispose duas vezes e finalizar o contexto sem exceções.")]
    public void DeveChamarDisposeDuasVezesSemExcecao2()
    {
        using var factory = new TestDbContextFactory();

        using var dbContext = factory.CreateDbContext([]);

        dbContext.Dispose();
        factory.Dispose();

        var disposedField = factory.GetType().BaseType.GetField("disposed", BindingFlags.NonPublic | BindingFlags.Instance);
        var disposedValue = (bool)disposedField.GetValue(factory);

        disposedValue.Should().BeTrue();
    }

    [Fact(DisplayName = "[BaseDbContextFactory.CreateDbContext|Dispose] Cria DbAppContext a través da implementação do BaseDbContextFactory e ao final utiliza o dispose duas vezes e finalizar o contexto sem exceções.")]
    public void DeveChamarDisposeDuasVezesSemExcecao()
    {
        var factory = new TestDbContextFactory();

        using var dbContext = factory.CreateDbContext(null);

        dbContext.Dispose();
        dbContext.Dispose();

        dbContext.Should().NotBeNull();
    }
}
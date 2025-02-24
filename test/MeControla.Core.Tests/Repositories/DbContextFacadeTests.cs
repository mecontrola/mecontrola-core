using FluentAssertions;
using MeControla.Core.Repositories;
using MeControla.Core.Tests.Mocks;
using MeControla.Core.Tests.Mocks.Datas.Repositories;
using MeControla.Core.Tests.Mocks.Entities;
using MeControla.Core.Tests.Mocks.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Threading.Tasks;
using Xunit;

namespace MeControla.Core.Tests.Repositories;

public class DbContextFacadeTests : BaseRepository
{
    private readonly IDbContextFacade dbContextFacade;

    private readonly DatabaseFacade databaseFacade;

    public DbContextFacadeTests()
    {
        databaseFacade = context.Database;

        dbContextFacade = new DbContextFacade(context.Database);
    }

    [Fact(DisplayName = "[DbContextFacade.GetDbConnection] Deve retornar a instancia do banco utilizada pelo EntityFramework.")]
    public void DeveRetornarConnectionInstancia()
        => dbContextFacade.GetDbConnection()
                          .Should()
                          .Be(databaseFacade.GetDbConnection());

    [Fact(DisplayName = "[DbContextFacade.EnsureCreated] Deve retornar o mesmo valor que a instancia original.")]
    public void DeveGerarEnsureCreated()
        => dbContextFacade.EnsureCreated()
                          .Should()
                          .Be(databaseFacade.EnsureCreated());

    [Fact(DisplayName = "[DbContextFacade.EnsureCreatedAsync] Deve retornar o mesmo valor que a instancia original.")]
    public void DeveGerarEnsureCreatedAsync()
        => dbContextFacade.EnsureCreatedAsync()
                          .Should()
                          .Be(databaseFacade.EnsureCreatedAsync());

    [Fact(DisplayName = "[DbContextFacade.EnsureDeleted] Deve retornar o mesmo valor que a instancia original.")]
    public void DeveGerarEnsureDeleted()
        => dbContextFacade.EnsureDeleted()
                          .Should()
                          .Be(databaseFacade.EnsureDeleted());

    [Fact(DisplayName = "[DbContextFacade.EnsureDeletedAsync] Deve retornar o mesmo valor que a instancia original.")]
    public void DeveGerarEnsureDeletedAsync()
        => dbContextFacade.EnsureDeletedAsync()
                          .Should()
                          .Be(databaseFacade.EnsureDeletedAsync());

    [Fact(DisplayName = "[DbContextFacade.CanConnect] Deve retornar o mesmo valor que a instancia original.")]
    public void DeveGerarCanConnect()
        => dbContextFacade.CanConnect()
                          .Should()
                          .Be(databaseFacade.CanConnect());

    [Fact(DisplayName = "[DbContextFacade.CanConnectAsync] Deve retornar o mesmo valor que a instancia original.")]
    public void DeveGerarCanConnectAsync()
        => dbContextFacade.CanConnectAsync()
                          .Should()
                          .Be(databaseFacade.CanConnectAsync());

    [Fact(DisplayName = "[DbContextFacade.BeginTransaction] Deve retornar o mesmo valor que a instancia original.")]
    public void DeveGerarBeginTransaction()
    {
        dbContextFacade.BeginTransaction();

        dbContextFacade.CurrentTransaction
                       .Should()
                       .Be(databaseFacade.CurrentTransaction);
    }

    [Fact(DisplayName = "[DbContextFacade.BeginTransactionAsync] Deve retornar o mesmo valor que a instancia original.")]
    public async Task DeveGerarBeginTransactionAsync()
    {
        await dbContextFacade.BeginTransactionAsync();

        dbContextFacade.CurrentTransaction
                       .Should()
                       .Be(databaseFacade.CurrentTransaction);
    }

    [Fact(DisplayName = "[DbContextFacade.CommitTransaction] Deve retornar o mesmo valor que a instancia original.")]
    public async Task DeveGerarCommitTransaction()
    {
        var cancellationToken = GetCancellationToken();
        var repository = new UserRepository(context);

        var transaction = dbContextFacade.BeginTransaction();

        await repository.RemoveAsync(UserMock.CreateUser3(), cancellationToken);

        context.SaveChanges();

        transaction.Commit();

        var actual = await repository.FindAsync(DataMock.INT_ID_3, cancellationToken);

        actual.Should()
              .BeNull();
    }

    [Fact(DisplayName = "[DbContextFacade.CommitTransactionAsync] Deve retornar o mesmo valor que a instancia original.")]
    public async Task DeveGerarCommitTransactionAsync()
    {
        var cancellationToken = GetCancellationToken();
        var repository = new UserRepository(context);

        var transaction = await dbContextFacade.BeginTransactionAsync(cancellationToken);

        await repository.RemoveAsync(UserMock.CreateUser3(), cancellationToken);

        await context.SaveChangesAsync(cancellationToken);

        await transaction.CommitAsync(cancellationToken);

        var actual = await repository.FindAsync(DataMock.INT_ID_3, cancellationToken);

        actual.Should()
              .BeNull();
    }

    [Fact(DisplayName = "[DbContextFacade.RollbackTransaction] Deve retornar o mesmo valor que a instancia original.")]
    public async Task DeveGerarRollbackTransaction()
    {
        var cancellationToken = GetCancellationToken();
        var repository = new UserRepository(context);

        dbContextFacade.BeginTransaction();

        await repository.RemoveAsync(UserMock.CreateUser3(), cancellationToken);

        dbContextFacade.RollbackTransaction();

        var actual = await repository.FindAsync(DataMock.INT_ID_3, cancellationToken);

        actual.Should()
              .NotBeNull();
    }

    [Fact(DisplayName = "[DbContextFacade.RollbackTransactionAsync] Deve retornar o mesmo valor que a instancia original.")]
    public async Task DeveGerarRollbackTransactionAsync()
    {
        var cancellationToken = GetCancellationToken();
        var repository = new UserRepository(context);

        await dbContextFacade.BeginTransactionAsync(cancellationToken);

        await repository.RemoveAsync(UserMock.CreateUser3(), cancellationToken);

        await dbContextFacade.RollbackTransactionAsync(cancellationToken);

        var actual = await repository.FindAsync(DataMock.INT_ID_3, cancellationToken);

        actual.Should()
              .NotBeNull();
    }

    [Fact(DisplayName = "[DbContextFacade.CreateExecutionStrategy] Deve retornar o mesmo valor que a instancia original.")]
    public void DeveGerarCreateExecutionStrategy()
    {
        dbContextFacade.CreateExecutionStrategy()
                       .Should()
                       .BeEquivalentTo(databaseFacade.CreateExecutionStrategy());
    }

    [Fact(DisplayName = "[DbContextFacade.AutoTransactionBehavior] Deve retornar o mesmo valor que a instancia original.")]
    public void DeveGerarAutoTransactionBehavior()
    {
        dbContextFacade.AutoTransactionBehavior = AutoTransactionBehavior.WhenNeeded;

        dbContextFacade.AutoTransactionBehavior
                       .Should()
                       .Be(databaseFacade.AutoTransactionBehavior);
    }

    [Fact(DisplayName = "[DbContextFacade.AutoSavepointsEnabled] Deve retornar o mesmo valor que a instancia original.")]
    public void DeveGerarAutoSavepointsEnabled()
    {
        dbContextFacade.AutoSavepointsEnabled = false;

        dbContextFacade.AutoSavepointsEnabled
                       .Should()
                       .Be(databaseFacade.AutoSavepointsEnabled);
    }

    [Fact(DisplayName = "[DbContextFacade.ProviderName] Deve retornar o mesmo valor que a instancia original.")]
    public void DeveGerarProviderName()
        => dbContextFacade.ProviderName
                          .Should()
                          .Be(databaseFacade.ProviderName);

    [Fact(DisplayName = "[DbContextFacade.ToString] Deve retornar o mesmo valor que a instancia original.")]
    public void DeveGerarToString()
        => dbContextFacade.ToString()
                          .Should()
                          .Be(databaseFacade.ToString());

    [Fact(DisplayName = "[DbContextFacade.Equals] Deve retornar o mesmo valor que a instancia original.")]
    public void DeveGerarEquals()
        => dbContextFacade.Equals(databaseFacade)
                          .Should()
                          .BeTrue();

    [Fact(DisplayName = "[DbContextFacade.GetHashCode] Deve retornar o mesmo valor que a instancia original.")]
    public void DeveGerarGetHashCode()
        => dbContextFacade.GetHashCode()
                          .Should()
                          .Be(databaseFacade.GetHashCode());
}
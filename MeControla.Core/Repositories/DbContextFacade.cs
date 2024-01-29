using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.Core.Repositories
{
    public class DbContextFacade(DatabaseFacade database)
        : IDbContextFacade
    {
        private readonly DatabaseFacade database = database;

        public virtual bool EnsureCreated()
            => database.EnsureCreated();

        public virtual async Task<bool> EnsureCreatedAsync(CancellationToken cancellationToken = default)
            => await database.EnsureCreatedAsync(cancellationToken);

        public virtual bool EnsureDeleted()
            => database.EnsureDeleted();

        public virtual async Task<bool> EnsureDeletedAsync(CancellationToken cancellationToken = default)
            => await database.EnsureDeletedAsync(cancellationToken);

        public virtual bool CanConnect()
            => database.CanConnect();

        public virtual async Task<bool> CanConnectAsync(CancellationToken cancellationToken = default)
            => await database.CanConnectAsync(cancellationToken);

        public virtual IDbContextTransaction BeginTransaction()
            => database.BeginTransaction();

        public virtual Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default)
            => database.BeginTransactionAsync(cancellationToken);

        public virtual void CommitTransaction()
            => database.CommitTransaction();

        public virtual async Task CommitTransactionAsync(CancellationToken cancellationToken = default)
            => await database.CommitTransactionAsync(cancellationToken);

        public virtual void RollbackTransaction()
            => database.RollbackTransaction();

        public virtual async Task RollbackTransactionAsync(CancellationToken cancellationToken = default)
            => await database.RollbackTransactionAsync(cancellationToken);

        public virtual IExecutionStrategy CreateExecutionStrategy()
            => database.CreateExecutionStrategy();

        public virtual IDbContextTransaction CurrentTransaction
            => database.CurrentTransaction;

        [Obsolete("Use " + nameof(AutoTransactionBehavior) + " instead")]
        public virtual bool AutoTransactionsEnabled
        {
            get { return database.AutoTransactionsEnabled; }
            set { database.AutoTransactionsEnabled = value; }
        }

        public virtual AutoTransactionBehavior AutoTransactionBehavior
        {
            get { return database.AutoTransactionBehavior; }
            set { database.AutoTransactionBehavior = value; }
        }

        public virtual bool AutoSavepointsEnabled
        {
            get { return database.AutoSavepointsEnabled; }
            set { database.AutoSavepointsEnabled = value; }
        }

        public virtual string ProviderName
            => database.ProviderName;

        public override string ToString()
            => database.ToString();

        public override bool Equals(object obj)
            => database.Equals(obj);

        public override int GetHashCode()
            => database.GetHashCode();
    }
}
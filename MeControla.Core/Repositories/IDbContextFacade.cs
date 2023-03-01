using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.Core.Repositories
{
    public interface IDbContextFacade
    {
        IDbContextTransaction CurrentTransaction { get; }
        bool AutoTransactionsEnabled { get; set; }
        AutoTransactionBehavior AutoTransactionBehavior { get; set; }
        bool AutoSavepointsEnabled { get; set; }
        string ProviderName { get; }

        IDbContextTransaction BeginTransaction();
        Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default);
        bool CanConnect();
        Task<bool> CanConnectAsync(CancellationToken cancellationToken = default);
        void CommitTransaction();
        Task CommitTransactionAsync(CancellationToken cancellationToken = default);
        IExecutionStrategy CreateExecutionStrategy();
        bool EnsureCreated();
        Task<bool> EnsureCreatedAsync(CancellationToken cancellationToken = default);
        bool EnsureDeleted();
        Task<bool> EnsureDeletedAsync(CancellationToken cancellationToken = default);
        bool Equals(object obj);
        int GetHashCode();
        void RollbackTransaction();
        Task RollbackTransactionAsync(CancellationToken cancellationToken = default);
        string ToString();
    }
}
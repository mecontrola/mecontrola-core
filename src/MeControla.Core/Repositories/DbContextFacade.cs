/***********************************************************************************
 * Copyright 2024 Me Controla
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 ***********************************************************************************/

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.Core.Repositories;

/// <summary>
/// Facade for interacting with the <see cref="DatabaseFacade"/> to provide a simplified interface for database operations.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="DbContextFacade"/> class.
/// </remarks>
/// <param name="database">The <see cref="DatabaseFacade"/> instance to be used for database operations.</param>
public class DbContextFacade(DatabaseFacade database)
    : IDbContextFacade
{
    /// <summary>
    /// Gets the underlying database connection.
    /// </summary>
    /// <returns>The <see cref="IDbConnection"/> for the database.</returns>
    public IDbConnection GetDbConnection()
        => database.GetDbConnection();

    /// <summary>
    /// Ensures that the database is created.
    /// </summary>
    /// <returns><c>true</c> if the database is created; otherwise, <c>false</c>.</returns>
    public virtual bool EnsureCreated()
        => database.EnsureCreated();

    /// <summary>
    /// Asynchronously ensures that the database is created.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns><c>true</c> if the database is created; otherwise, <c>false</c>.</returns>
    public virtual async Task<bool> EnsureCreatedAsync(CancellationToken cancellationToken = default)
        => await database.EnsureCreatedAsync(cancellationToken);

    /// <summary>
    /// Ensures that the database is deleted.
    /// </summary>
    /// <returns><c>true</c> if the database is deleted; otherwise, <c>false</c>.</returns>
    public virtual bool EnsureDeleted()
        => database.EnsureDeleted();

    /// <summary>
    /// Asynchronously ensures that the database is deleted.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns><c>true</c> if the database is deleted; otherwise, <c>false</c>.</returns>
    public virtual async Task<bool> EnsureDeletedAsync(CancellationToken cancellationToken = default)
        => await database.EnsureDeletedAsync(cancellationToken);

    /// <summary>
    /// Checks if a connection to the database can be established.
    /// </summary>
    /// <returns><c>true</c> if a connection can be established; otherwise, <c>false</c>.</returns>
    public virtual bool CanConnect()
        => database.CanConnect();

    /// <summary>
    /// Asynchronously checks if a connection to the database can be established.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns><c>true</c> if a connection can be established; otherwise, <c>false</c>.</returns>
    public virtual async Task<bool> CanConnectAsync(CancellationToken cancellationToken = default)
        => await database.CanConnectAsync(cancellationToken);

    /// <summary>
    /// Begins a new database transaction.
    /// </summary>
    /// <returns>An <see cref="IDbContextTransaction"/> representing the transaction.</returns>
    public virtual IDbContextTransaction BeginTransaction()
        => database.BeginTransaction();

    /// <summary>
    /// Asynchronously begins a new database transaction.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>A task representing the asynchronous operation, with a value of type <see cref="IDbContextTransaction"/>.</returns>
    public virtual Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default)
        => database.BeginTransactionAsync(cancellationToken);

    /// <summary>
    /// Commits the current transaction.
    /// </summary>
    public virtual void CommitTransaction()
        => database.CommitTransaction();

    /// <summary>
    /// Asynchronously commits the current transaction.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>A task representing the asynchronous commit operation.</returns>
    public virtual async Task CommitTransactionAsync(CancellationToken cancellationToken = default)
        => await database.CommitTransactionAsync(cancellationToken);

    /// <summary>
    /// Rolls back the current transaction.
    /// </summary>
    public virtual void RollbackTransaction()
        => database.RollbackTransaction();

    /// <summary>
    /// Asynchronously rolls back the current transaction.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>A task representing the asynchronous rollback operation.</returns>
    public virtual async Task RollbackTransactionAsync(CancellationToken cancellationToken = default)
        => await database.RollbackTransactionAsync(cancellationToken);

    /// <summary>
    /// Creates an execution strategy for database operations.
    /// </summary>
    /// <returns>An <see cref="IExecutionStrategy"/> instance.</returns>
    public virtual IExecutionStrategy CreateExecutionStrategy()
        => database.CreateExecutionStrategy();

    /// <summary>
    /// Gets the current transaction, if any.
    /// </summary>
    public virtual IDbContextTransaction CurrentTransaction
        => database.CurrentTransaction;

    /// <summary>
    /// Gets or sets the behavior for automatic transaction handling.
    /// </summary>
    public virtual AutoTransactionBehavior AutoTransactionBehavior
    {
        get { return database.AutoTransactionBehavior; }
        set { database.AutoTransactionBehavior = value; }
    }

    /// <summary>
    /// Gets or sets a value indicating whether automatic savepoints are enabled.
    /// </summary>
    public virtual bool AutoSavepointsEnabled
    {
        get { return database.AutoSavepointsEnabled; }
        set { database.AutoSavepointsEnabled = value; }
    }

    /// <summary>
    /// Gets the name of the database provider.
    /// </summary>
    public virtual string ProviderName
        => database.ProviderName;

    /// <summary>
    /// Returns a string that represents the current object.
    /// </summary>
    /// <returns>A string that represents the current object.</returns>
    public override string ToString()
        => database.ToString();

    /// <summary>
    /// Determines whether the specified object is equal to the current object.
    /// </summary>
    /// <param name="obj">The object to compare with the current object.</param>
    /// <returns><see langword="true" /> if the specified object is equal to the current object; otherwise, <see langword="false" />.</returns>
    public override bool Equals(object obj)
        => database.Equals(obj);

    /// <summary>
    /// Serves as the default hash function.
    /// </summary>
    /// <returns>A hash code for the current object.</returns>
    public override int GetHashCode()
        => database.GetHashCode();
}
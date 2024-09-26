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
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.Core.Repositories;

/// <summary>
/// Provides an abstraction for managing database context transactions and connection behavior.
/// </summary>
public interface IDbContextFacade
{
    /// <summary>
    /// Gets the current database transaction.
    /// </summary>
    IDbContextTransaction CurrentTransaction { get; }

    /// <summary>
    /// Gets or sets the behavior for automatic transaction handling.
    /// </summary>
    AutoTransactionBehavior AutoTransactionBehavior { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether automatic savepoints are enabled.
    /// </summary>
    bool AutoSavepointsEnabled { get; set; }

    /// <summary>
    /// Gets the name of the database provider.
    /// </summary>
    string ProviderName { get; }

    /// <summary>
    /// Retrieves the current database connection.
    /// </summary>
    /// <returns>The current <see cref="IDbConnection"/>.</returns>
    public IDbConnection GetDbConnection();

    /// <summary>
    /// Begins a new database transaction.
    /// </summary>
    /// <returns>The <see cref="IDbContextTransaction"/> representing the new transaction.</returns>
    IDbContextTransaction BeginTransaction();

    /// <summary>
    /// Begins a new asynchronous database transaction.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>A task representing the asynchronous operation, with the transaction as the result.</returns>
    Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Checks if a connection to the database can be established.
    /// </summary>
    /// <returns><c>true</c> if the connection can be established; otherwise, <c>false</c>.</returns>
    bool CanConnect();

    /// <summary>
    /// Asynchronously checks if a connection to the database can be established.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>A task representing the asynchronous operation, with a value indicating whether the connection can be established.</returns>
    Task<bool> CanConnectAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Commits the current transaction.
    /// </summary>
    void CommitTransaction();

    /// <summary>
    /// Asynchronously commits the current transaction.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task CommitTransactionAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates a new execution strategy.
    /// </summary>
    /// <returns>An <see cref="IExecutionStrategy"/> for executing database commands.</returns>
    IExecutionStrategy CreateExecutionStrategy();

    /// <summary>
    /// Ensures that the database is created.
    /// </summary>
    /// <returns><c>true</c> if the database was created; otherwise, <c>false</c>.</returns>
    bool EnsureCreated();

    /// <summary>
    /// Asynchronously ensures that the database is created.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>A task representing the asynchronous operation, with a value indicating whether the database was created.</returns>
    Task<bool> EnsureCreatedAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Ensures that the database is deleted.
    /// </summary>
    /// <returns><c>true</c> if the database was deleted; otherwise, <c>false</c>.</returns>
    bool EnsureDeleted();

    /// <summary>
    /// Asynchronously ensures that the database is deleted.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>A task representing the asynchronous operation, with a value indicating whether the database was deleted.</returns>
    Task<bool> EnsureDeletedAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Determines whether the specified object is equal to the current object.
    /// </summary>
    /// <param name="obj">The object to compare with the current object.</param>
    /// <returns><c>true</c> if the specified object is equal to the current object; otherwise, <c>false</c>.</returns>
    bool Equals(object obj);

    /// <summary>
    /// Serves as a hash function for the current object.
    /// </summary>
    /// <returns>A hash code for the current object.</returns>
    int GetHashCode();

    /// <summary>
    /// Rolls back the current transaction.
    /// </summary>
    void RollbackTransaction();

    /// <summary>
    /// Asynchronously rolls back the current transaction.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task RollbackTransactionAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns a string that represents the current object.
    /// </summary>
    /// <returns>A string that represents the current object.</returns>
    string ToString();
}
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
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Diagnostics.CodeAnalysis;

namespace MeControla.Core.Repositories;

/// <summary>
/// Provides an interface for a factory that creates instances of <typeparamref name="TDbContext"/> at design time 
/// and supports disposal of resources.
/// </summary>
/// <typeparam name="TDbContext">The type of <see cref="DbContext"/> that the factory creates.</typeparam>
public interface IBaseDbContextFactory<out TDbContext> : IDesignTimeDbContextFactory<TDbContext>, IDisposable
    where TDbContext : DbContext
{ }

/// <summary>
/// Provides a base implementation for a factory that creates instances of <typeparamref name="TDbContext"/>.
/// This class is meant to be inherited to implement custom logic for creating database context instances.
/// </summary>
/// <typeparam name="TDbContext">The type of <see cref="DbContext"/> that the factory creates.</typeparam>
public abstract class BaseDbContextFactory<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TDbContext>
    : IBaseDbContextFactory<TDbContext>
    where TDbContext : DbContext
{
    private TDbContext context;

    private bool disposed;

    /// <summary>
    /// Creates a new instance of a derived context.
    /// </summary>
    /// <param name="args">Arguments provided by the design-time service.</param>
    /// <returns>An instance of <typeparamref name="TDbContext" />.</returns>
    public TDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<TDbContext>();

        Configure(optionsBuilder);

        context = CreateInstanceDbContext(optionsBuilder);

        return context;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="optionsBuilder"></param>
    /// <returns></returns>
#if DEBUG
    protected virtual
#else
    private static
#endif
    TDbContext CreateInstanceDbContext(DbContextOptionsBuilder<TDbContext> optionsBuilder)
       => (TDbContext)Activator.CreateInstance(typeof(TDbContext), [optionsBuilder.Options]);

    /// <summary>
    /// Configures the <see cref="DbContextOptionsBuilder{TDbContext}"/> for the specified <typeparamref name="TDbContext"/>.
    /// </summary>
    /// <param name="options">The options builder to configure.</param>
    /// <remarks>
    /// This method is intended to be implemented by derived classes to set up the specific configuration 
    /// for the <typeparamref name="TDbContext"/> instance, such as setting the connection string, 
    /// configuring database providers, or enabling logging.
    /// </remarks>
    protected abstract void Configure(DbContextOptionsBuilder<TDbContext> options);

    /// <summary>
    /// Releases all resources used by the <see cref="BaseDbContextFactory{TDbContext}"/> class.
    /// </summary>
    /// <remarks>
    /// This method is a public implementation of the <see cref="IDisposable"/> interface. 
    /// It calls the <see cref="Dispose(bool)"/> method with <c>true</c> to release both managed and unmanaged resources.
    /// </remarks>
    public void Dispose()
    {
        Dispose(true);

        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Disposes resources used by the <see cref="BaseDbContextFactory{TDbContext}"/> class.
    /// </summary>
    /// <param name="disposing">
    /// If <c>true</c>, releases both managed and unmanaged resources;
    /// if <c>false</c>, releases only unmanaged resources.
    /// </param>
    protected virtual void Dispose(bool disposing)
    {
        if (disposed)
            return;

        if (disposing)
            context?.Dispose();

        disposed = true;
    }

    /// <summary>
    /// Finalizer for the <see cref="BaseDbContextFactory{TDbContext}"/> class.
    /// Calls <see cref="Dispose(bool)"/> to release unmanaged resources.
    /// </summary>
    ~BaseDbContextFactory()
        => Dispose(false);
}
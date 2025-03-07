﻿/***********************************************************************************
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

using MeControla.Core.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics.CodeAnalysis;

namespace MeControla.Core.Repositories;

/// <summary>
/// Represents a base repository class providing access to a <see cref="DbSet{TEntity}"/> and database context.
/// </summary>
/// <typeparam name="TEntity">
/// The type of entity being managed by the repository. It must implement <see cref="IEntity"/>.
/// </typeparam>
public abstract class ContextRepository<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TEntity>
    where TEntity : class, IEntity
{
    /// <summary>
    /// The database context used by the repository.
    /// </summary>
    private readonly IDbContext context;

    /// <summary>
    /// The <see cref="DbSet{TEntity}"/> representing the entity collection in the database.
    /// </summary>
    private readonly DbSet<TEntity> dbSet;

    private readonly IDbContextFacade database;

    /// <summary>
    /// Initializes a new instance of the <see cref="ContextRepository{TEntity}"/> class.
    /// </summary>
    /// <param name="context">The database context to be used.</param>
    [SuppressMessage("Style", "IDE0290:Use primary constructor", Justification = "Constructor to be protected.")]
    protected ContextRepository(IDbContext context)
    {
        this.context = context ?? throw new ArgumentNullException(nameof(context));
        this.dbSet = context!.Set<TEntity>();
        this.database = new DbContextFacade(Context.Database);
    }

    /// <summary>
    /// Gets the current database context instance associated with the repository.
    /// </summary>
    /// <value>The <see cref="IDbContext"/> used for database operations.</value>
    protected IDbContext Context { get => context; }

    /// <summary>
    /// Gets the <see cref="DbSet{TEntity}"/> associated with the entity type <typeparamref name="TEntity"/>.
    /// </summary>
    /// <value>The <see cref="DbSet{TEntity}"/> used for querying and persisting entities of type <typeparamref name="TEntity"/>.</value>
    protected DbSet<TEntity> DbSet { get => dbSet; }

    /// <summary>
    /// Gets the <see cref="IDbContextFacade"/> for managing database transactions and connections.
    /// </summary>
    /// <returns>An instance of the <see cref="IDbContextFacade"/> implementation.</returns>
    public IDbContextFacade Database() => database;
}
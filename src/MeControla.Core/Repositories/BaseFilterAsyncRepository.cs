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

using MeControla.Core.Data.Entities;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.Core.Repositories;

/// <summary>
/// Serves as a base class for asynchronous repositories that support filtering functionality for entities.
/// </summary>
/// <typeparam name="TEntity">The type of the entity that the repository will handle.</typeparam>
/// <typeparam name="TFilterEntity">The type of the filter entity used for filtering.</typeparam>
public abstract class BaseFilterAsyncRepository<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TEntity, TFilterEntity>(IDbContext context)
    : BaseAsyncRepository<TEntity>(context), IFilterAsyncRepository<TEntity, TFilterEntity>
    where TEntity : class, IEntity
    where TFilterEntity : class, IFilterEntity
{
    /// <summary>
    /// Asynchronously retrieves a list of entities that match the specified filter criteria.
    /// </summary>
    /// <param name="filter">The filter criteria used to find the entities.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of matching entities.</returns>
    public abstract Task<IList<TEntity>> FindFilterAllAsync(TFilterEntity filter, CancellationToken cancellationToken);
}
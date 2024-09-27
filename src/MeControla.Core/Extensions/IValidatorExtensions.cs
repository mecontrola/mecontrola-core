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

using FluentValidation;
using MeControla.Core.Data.Dtos;
using MeControla.Core.Data.Entities;
using MeControla.Core.Exceptions;
using System;

namespace MeControla.Core.Extensions;

/// <summary>
/// Provides extension methods for <see cref="IValidator{TInputDto}"/> to facilitate validation checks.
/// </summary>
#if !DEBUG
[System.Diagnostics.DebuggerStepThrough]
#endif
public static class IValidatorExtensions
{
    /// <summary>
    /// Throws a validation exception if the provided input is not valid according to the specified validator.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity associated with the input DTO.</typeparam>
    /// <typeparam name="TInputDto">The type of the input DTO being validated.</typeparam>
    /// <param name="validator">The validator instance used to validate the input DTO.</param>
    /// <param name="input">The input DTO to validate.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="validator"/> or <paramref name="input"/> is <c>null</c>.</exception>
    /// <exception cref="ValidationException">Thrown when the input DTO is not valid.</exception>
#if !DEBUG
    [System.Diagnostics.DebuggerStepThrough]
    [System.Diagnostics.CodeAnalysis.DoesNotReturn]
#endif
    public static void ThrowIfInvalid<TEntity, TInputDto>(this IValidator<TInputDto> validator, TInputDto input)
        where TEntity : class, IEntity
        where TInputDto : class, IInputDto
    {
        ArgumentNullException.ThrowIfNull(validator);
        ArgumentNullException.ThrowIfNull(input);

        var result = validator.Validate(input);
        if (result.IsValid)
            return;

        ThrowHelper.ThrowValidationException<TEntity>(result);
    }
}

using FluentValidation;
using MeControla.Core.Data.Dtos;
using MeControla.Core.Data.Entities;
using MeControla.Core.Exceptions;
using System;

namespace MeControla.Core.Extensions
{
#if !DEBUG
    [System.Diagnostics.CodeAnalysis.DoesNotReturn]
#endif
    public static class IValidatorExtensions
    {
#if !DEBUG
        [System.Diagnostics.DebuggerStepThrough]
        [System.Diagnostics.CodeAnalysis.DoesNotReturn]
#endif
        public static void ThrowIfInvalid<TEntity, TInputDto>(this IValidator<TInputDto> validator, TInputDto input)
            where TEntity : class, IEntity
            where TInputDto : class, IInputDto
        {
            ArgumentNullException.ThrowIfNull(validator);

            var result = validator.Validate(input);
            if (result.IsValid)
                return;

            throw new FormValidationException(typeof(TEntity), result);
        }
    }
}
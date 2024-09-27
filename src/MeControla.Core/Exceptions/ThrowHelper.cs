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

using FluentValidation.Results;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;

namespace MeControla.Core.Exceptions;

/// <summary>
/// This static class provides helper methods to throw HTTP-related exceptions.
/// The main purpose is to reduce code size and improve readability in BCL code.
/// </summary>
[Pure]
public static class ThrowHelper
{
    /// <summary>
    /// Throws a <see cref="BadGatewayException"/> with a default message.
    /// This method does not return to the caller.
    /// </summary>
    [DoesNotReturn]
    public static void ThrowBadGatewayException()
        => throw new BadGatewayException();

    /// <summary>
    /// Throws a <see cref="BadGatewayException"/> with a specified error message.
    /// </summary>
    /// <param name="message">The error message that describes the exception.</param>
    [DoesNotReturn]
    public static void ThrowBadGatewayException(string message)
        => throw new BadGatewayException(message);

    /// <summary>
    /// Throws a <see cref="BadGatewayException"/> with a specified error message and an inner exception.
    /// </summary>
    /// <param name="message">The error message that describes the exception.</param>
    /// <param name="innerException">The inner exception that caused this exception, or <c>null</c> if there is no inner exception.</param>
    [DoesNotReturn]
    public static void ThrowBadGatewayException(string message, Exception innerException)
        => throw new BadGatewayException(message, innerException);

    /// <summary>
    /// Throws a <see cref="BadRequestException"/> with a default message.
    /// This method does not return to the caller.
    /// </summary>
    [DoesNotReturn]
    public static void ThrowBadRequestException()
        => throw new BadRequestException();

    /// <summary>
    /// Throws a <see cref="BadRequestException"/> with a specified error message.
    /// </summary>
    /// <param name="message">The error message that describes the exception.</param>
    [DoesNotReturn]
    public static void ThrowBadRequestException(string message)
        => throw new BadRequestException(message);

    /// <summary>
    /// Throws a <see cref="BadRequestException"/> with a specified error message and an inner exception.
    /// </summary>
    /// <param name="message">The error message that describes the exception.</param>
    /// <param name="innerException">The inner exception that caused this exception, or <c>null</c> if there is no inner exception.</param>
    [DoesNotReturn]
    public static void ThrowBadRequestException(string message, Exception innerException)
        => throw new BadRequestException(message, innerException);

    /// <summary>
    /// Throws a <see cref="ForbiddenException"/> with a default message.
    /// This method does not return to the caller.
    /// </summary>
    [DoesNotReturn]
    public static void ThrowForbiddenException()
        => throw new ForbiddenException();

    /// <summary>
    /// Throws a <see cref="ForbiddenException"/> with a specified error message.
    /// </summary>
    /// <param name="message">The error message that describes the exception.</param>
    [DoesNotReturn]
    public static void ThrowForbiddenException(string message)
        => throw new ForbiddenException(message);

    /// <summary>
    /// Throws a <see cref="ForbiddenException"/> with a specified error message and an inner exception.
    /// </summary>
    /// <param name="message">The error message that describes the exception.</param>
    /// <param name="innerException">The inner exception that caused this exception, or <c>null</c> if there is no inner exception.</param>
    [DoesNotReturn]
    public static void ThrowForbiddenException(string message, Exception innerException)
        => throw new ForbiddenException(message, innerException);

    /// <summary>
    /// Throws a <see cref="GoneException"/> with a default message.
    /// This method does not return to the caller.
    /// </summary>
    [DoesNotReturn]
    public static void ThrowGoneException()
        => throw new GoneException();

    /// <summary>
    /// Throws a <see cref="GoneException"/> with a specified error message.
    /// </summary>
    /// <param name="message">The error message that describes the exception.</param>
    [DoesNotReturn]
    public static void ThrowGoneException(string message)
        => throw new GoneException(message);

    /// <summary>
    /// Throws a <see cref="GoneException"/> with a specified error message and an inner exception.
    /// </summary>
    /// <param name="message">The error message that describes the exception.</param>
    /// <param name="innerException">The inner exception that caused this exception, or <c>null</c> if there is no inner exception.</param>
    [DoesNotReturn]
    public static void ThrowGoneException(string message, Exception innerException)
        => throw new GoneException(message, innerException);

    /// <summary>
    /// Throws a <see cref="InternalServerErrorException"/> with a default message.
    /// This method does not return to the caller.
    /// </summary>
    [DoesNotReturn]
    public static void ThrowInternalServerErrorException()
        => throw new InternalServerErrorException();

    /// <summary>
    /// Throws a <see cref="InternalServerErrorException"/> with a specified error message.
    /// </summary>
    /// <param name="message">The error message that describes the exception.</param>
    [DoesNotReturn]
    public static void ThrowInternalServerErrorException(string message)
        => throw new InternalServerErrorException(message);

    /// <summary>
    /// Throws a <see cref="InternalServerErrorException"/> with a specified error message and an inner exception.
    /// </summary>
    /// <param name="message">The error message that describes the exception.</param>
    /// <param name="innerException">The inner exception that caused this exception, or <c>null</c> if there is no inner exception.</param>
    [DoesNotReturn]
    public static void ThrowInternalServerErrorException(string message, Exception innerException)
        => throw new InternalServerErrorException(message, innerException);

    /// <summary>
    /// Throws a <see cref="JwtTokenException"/> with a default message.
    /// This method does not return to the caller.
    /// </summary>
    [DoesNotReturn]
    public static void ThrowJwtTokenException()
        => throw new JwtTokenException();

    /// <summary>
    /// Throws a <see cref="JwtTokenException"/> with a specified error message.
    /// </summary>
    /// <param name="message">The error message that describes the exception.</param>
    [DoesNotReturn]
    public static void ThrowJwtTokenException(string message)
        => throw new JwtTokenException(message);

    /// <summary>
    /// Throws a <see cref="JwtTokenException"/> with a specified error message and an inner exception.
    /// </summary>
    /// <param name="message">The error message that describes the exception.</param>
    /// <param name="innerException">The inner exception that caused this exception, or <c>null</c> if there is no inner exception.</param>
    [DoesNotReturn]
    public static void ThrowJwtTokenException(string message, Exception innerException)
        => throw new JwtTokenException(message, innerException);

    /// <summary>
    /// Throws a <see cref="NotFoundException"/> with a default message.
    /// This method does not return to the caller.
    /// </summary>
    [DoesNotReturn]
    public static void ThrowNotFoundException()
        => throw new NotFoundException();

    /// <summary>
    /// Throws a <see cref="NotFoundException"/> with a specified error message.
    /// </summary>
    /// <param name="message">The error message that describes the exception.</param>
    [DoesNotReturn]
    public static void ThrowNotFoundException(string message)
        => throw new NotFoundException(message);

    /// <summary>
    /// Throws a <see cref="NotFoundException"/> with a specified error message and an inner exception.
    /// </summary>
    /// <param name="message">The error message that describes the exception.</param>
    /// <param name="innerException">The inner exception that caused this exception, or <c>null</c> if there is no inner exception.</param>
    [DoesNotReturn]
    public static void ThrowNotFoundException(string message, Exception innerException)
        => throw new NotFoundException(message, innerException);

    /// <summary>
    /// Throws a <see cref="NotImplementedException"/> with a default message.
    /// This method does not return to the caller.
    /// </summary>
    [DoesNotReturn]
    public static void ThrowNotImplementedException()
        => throw new NotImplementedException();

    /// <summary>
    /// Throws a <see cref="NotImplementedException"/> with a specified error message.
    /// </summary>
    /// <param name="message">The error message that describes the exception.</param>
    [DoesNotReturn]
    public static void ThrowNotImplementedException(string message)
        => throw new NotImplementedException(message);

    /// <summary>
    /// Throws a <see cref="NotImplementedException"/> with a specified error message and an inner exception.
    /// </summary>
    /// <param name="message">The error message that describes the exception.</param>
    /// <param name="innerException">The inner exception that caused this exception, or <c>null</c> if there is no inner exception.</param>
    [DoesNotReturn]
    public static void ThrowNotImplementedException(string message, Exception innerException)
        => throw new NotImplementedException(message, innerException);

    /// <summary>
    /// Throws a <see cref="PaymentRequiredException"/> with a default message.
    /// This method does not return to the caller.
    /// </summary>
    [DoesNotReturn]
    public static void ThrowPaymentRequiredException()
        => throw new PaymentRequiredException();

    /// <summary>
    /// Throws a <see cref="PaymentRequiredException"/> with a specified error message.
    /// </summary>
    /// <param name="message">The error message that describes the exception.</param>
    [DoesNotReturn]
    public static void ThrowPaymentRequiredException(string message)
        => throw new PaymentRequiredException(message);

    /// <summary>
    /// Throws a <see cref="PaymentRequiredException"/> with a specified error message and an inner exception.
    /// </summary>
    /// <param name="message">The error message that describes the exception.</param>
    /// <param name="innerException">The inner exception that caused this exception, or <c>null</c> if there is no inner exception.</param>
    [DoesNotReturn]
    public static void ThrowPaymentRequiredException(string message, Exception innerException)
        => throw new PaymentRequiredException(message, innerException);

    /// <summary>
    /// Throws a <see cref="ServiceUnavailableException"/> with a default message.
    /// This method does not return to the caller.
    /// </summary>
    [DoesNotReturn]
    public static void ThrowServiceUnavailableException()
        => throw new ServiceUnavailableException();

    /// <summary>
    /// Throws a <see cref="ServiceUnavailableException"/> with a specified error message.
    /// </summary>
    /// <param name="message">The error message that describes the exception.</param>
    [DoesNotReturn]
    public static void ThrowServiceUnavailableException(string message)
        => throw new ServiceUnavailableException(message);

    /// <summary>
    /// Throws a <see cref="ServiceUnavailableException"/> with a specified error message and an inner exception.
    /// </summary>
    /// <param name="message">The error message that describes the exception.</param>
    /// <param name="innerException">The inner exception that caused this exception, or <c>null</c> if there is no inner exception.</param>
    [DoesNotReturn]
    public static void ThrowServiceUnavailableException(string message, Exception innerException)
        => throw new ServiceUnavailableException(message, innerException);

    /// <summary>
    /// Throws a <see cref="UnauthorizedException"/> with a default message.
    /// This method does not return to the caller.
    /// </summary>
    [DoesNotReturn]
    public static void ThrowUnauthorizedException()
        => throw new UnauthorizedException();

    /// <summary>
    /// Throws a <see cref="UnauthorizedException"/> with a specified error message.
    /// </summary>
    /// <param name="message">The error message that describes the exception.</param>
    [DoesNotReturn]
    public static void ThrowUnauthorizedException(string message)
        => throw new UnauthorizedException(message);

    /// <summary>
    /// Throws a <see cref="UnauthorizedException"/> with a specified error message and an inner exception.
    /// </summary>
    /// <param name="message">The error message that describes the exception.</param>
    /// <param name="innerException">The inner exception that caused this exception, or <c>null</c> if there is no inner exception.</param>
    [DoesNotReturn]
    public static void ThrowUnauthorizedException(string message, Exception innerException)
        => throw new UnauthorizedException(message, innerException);

    /// <summary>
    /// Based on the ValidationResult returned by the FluentValidation validation method,
    /// it retrieves the list of invalid properties and the corresponding errors for each field.
    /// These details are then included as part of the exception.
    /// </summary>
    /// <typeparam name="T">The type of the class that was validated.</typeparam>
    /// <param name="result">The validation result from FluentValidation.</param>
    [DoesNotReturn]
    public static void ThrowValidationException<T>(ValidationResult result)
        where T : class
        => throw new ValidationException<T>(result);

    /// <summary>
    /// Based on the ValidationResult returned by the FluentValidation validation method,
    /// it retrieves the list of invalid properties and the corresponding errors for each field.
    /// These details are then included as part of the exception.
    /// </summary>
    /// <typeparam name="T">The type of the class that was validated.</typeparam>
    /// <param name="result">The validation result from FluentValidation.</param>
    /// <param name="message">The error message that describes the exception.</param>
    [DoesNotReturn]
    public static void ThrowValidationException<T>(ValidationResult result, string message)
        where T : class
        => throw new ValidationException<T>(result, message);

    /// <summary>
    /// Based on the ValidationResult returned by the FluentValidation validation method,
    /// it retrieves the list of invalid properties and the corresponding errors for each field.
    /// These details are then included as part of the exception.
    /// </summary>
    /// <typeparam name="T">The type of the class that was validated.</typeparam>
    /// <param name="result">The validation result from FluentValidation.</param>
    /// <param name="message">The error message that describes the exception.</param>
    /// <param name="innerException">The inner exception that caused this exception, or <c>null</c> if there is no inner exception.</param>
    [DoesNotReturn]
    public static void ThrowValidationException<T>(ValidationResult result, string message, Exception innerException)
        where T : class
        => throw new ValidationException<T>(result, message, innerException);
}
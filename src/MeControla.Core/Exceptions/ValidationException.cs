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
using MeControla.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace MeControla.Core.Exceptions;

/// <summary>
/// Based on the ValidationResult returned by the FluentValidation validation method,
/// it retrieves the list of invalid properties and the corresponding errors for each field.
/// These details are then included as part of the exception.
/// </summary>
/// <param name="type">The type of the class that was validated.</param>
/// <param name="result">The validation result from FluentValidation.</param>
/// <param name="message">The error message that describes the exception.</param>
/// <param name="innerException">The inner exception that caused this exception, or <c>null</c> if there is no inner exception.</param>
public class ValidationException(Type type, ValidationResult result, string message, Exception innerException)
    : HttpException(HttpStatusCode.BadRequest, GetMessage(type, message), innerException)
{
    private const string ERROR_MESSAGE_PARAM = "{entityName}";
    private const string ERROR_MESSAGE = $"The {ERROR_MESSAGE_PARAM} data is not valid. Please adjust the information in the highlighted fields.";

    /// <summary>
    /// Based on the ValidationResult returned by the FluentValidation validation method,
    /// it retrieves the list of invalid properties and the corresponding errors for each field.
    /// These details are then included as part of the exception.
    /// </summary>
    /// <param name="type">The type of the class that was validated.</param>
    /// <param name="result">The validation result from FluentValidation.</param>
    public ValidationException(Type type, ValidationResult result)
        : this(type, result, ERROR_MESSAGE.Replace(ERROR_MESSAGE_PARAM, type.Name))
    { }

    /// <summary>
    /// Based on the ValidationResult returned by the FluentValidation validation method,
    /// it retrieves the list of invalid properties and the corresponding errors for each field.
    /// These details are then included as part of the exception.
    /// </summary>
    /// <param name="type">The type of the class that was validated.</param>
    /// <param name="result">The validation result from FluentValidation.</param>
    /// <param name="message">The error message that describes the exception.</param>
    public ValidationException(Type type, ValidationResult result, string message)
        : this(type, result, message, null)
    { }

    /// <summary>
    /// List of properties with their respective list of errors.
    /// </summary>
    public Dictionary<string, List<string>> PropertyErrors { get; } = result.Errors
                                                                            .GroupBy(itm => itm.PropertyName)
                                                                            .ToDictionary(itm => itm.Key,
                                                                                          itm => itm.Select(val => val.ErrorMessage)
                                                                                                    .ToList());

    private static string GetMessage(Type type, string message)
        => message.IsNullOrWhiteSpace()
         ? ERROR_MESSAGE.Replace(ERROR_MESSAGE_PARAM, type.Name)
         : message;
}

/// <summary>
/// Based on the ValidationResult returned by the FluentValidation validation method,
/// it retrieves the list of invalid properties and the corresponding errors for each field.
/// These details are then included as part of the exception.
/// </summary>
/// <typeparam name="T">The type of the class that was validated.</typeparam>
/// <param name="result">The validation result from FluentValidation.</param>
/// <param name="message">The error message that describes the exception.</param>
/// <param name="innerException">The inner exception that caused this exception, or <c>null</c> if there is no inner exception.</param>
public class ValidationException<T>(ValidationResult result, string message, Exception innerException)
    : ValidationException(typeof(T), result, message, innerException)
    where T : class
{
    /// <summary>
    /// Based on the ValidationResult returned by the FluentValidation validation method,
    /// it retrieves the list of invalid properties and the corresponding errors for each field.
    /// These details are then included as part of the exception.
    /// </summary>
    /// <param name="result"></param>
    /// <param name="message"></param>
    public ValidationException(ValidationResult result, string message)
        : this(result, message, null)
    { }

    /// <summary>
    /// Based on the ValidationResult returned by the FluentValidation validation method,
    /// it retrieves the list of invalid properties and the corresponding errors for each field.
    /// These details are then included as part of the exception.
    /// </summary>
    /// <param name="result"></param>
    public ValidationException(ValidationResult result)
        : this(result, null)
    { }
}
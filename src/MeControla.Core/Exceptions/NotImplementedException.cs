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

using System;
using System.Net;

namespace MeControla.Core.Exceptions;

/// <summary>
/// Exception that represents a "Not Implemented" HTTP error.
/// Inherits from <see cref="HttpException"/> with a status code of 501.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="NotImplementedException"/> class with a specified error message and an inner exception.
/// </remarks>
/// <param name="message">The error message that describes the exception.</param>
/// <param name="innerException">The inner exception that caused this exception, or <c>null</c> if there is no inner exception.</param>
public class NotImplementedException(string message, Exception innerException)
    : HttpException(HttpStatusCode.NotImplemented, message, innerException)
{
    /// <summary>
    /// Initializes a new instance of the <see cref="NotImplementedException"/> class with the default error message.
    /// </summary>
    public NotImplementedException()
        : this(ResourceThrowMessageDefault.NotImplemented)
    { }

    /// <summary>
    /// Initializes a new instance of the <see cref="NotImplementedException"/> class with a specified error message.
    /// </summary>
    /// <param name="message">The error message that describes the exception.</param>
    public NotImplementedException(string message)
        : this(message, null)
    { }
}
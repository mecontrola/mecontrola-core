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

using System;
using System.Net;

namespace MeControla.Core.Exceptions;

/// <summary>
/// Abstract class representing an HTTP exception.
/// This class inherits from <see cref="Exception"/> and includes an HTTP status code.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="HttpException"/> class with a status code, a message, and an inner exception.
/// </remarks>
/// <param name="statusCode">The HTTP status code associated with the exception.</param>
/// <param name="message">The error message that describes the exception.</param>
/// <param name="innerException">The inner exception that caused this exception, or <c>null</c> if there is no inner exception.</param>
public abstract class HttpException(HttpStatusCode statusCode, string message, Exception innerException)
    : Exception(message, innerException)
{
    /// <summary>
    /// Gets the HTTP status code associated with this exception.
    /// </summary>
    public HttpStatusCode StatusCode { get; } = statusCode;
}
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

namespace MeControla.Core.Exceptions;

/// <summary>
/// This class contains default message constants for various HTTP error responses.
/// It is sealed to prevent inheritance and ensure that the messages remain consistent.
/// </summary>
internal sealed class ResourceThrowMessageDefault
{
    /// <summary>
    /// The default message for a "Bad Gateway" error.
    /// </summary>
    public const string BadGateway = "The server received an invalid response from the upstream server while trying to fulfill the request.";

    /// <summary>
    /// The default message for a "Bad Request" error.
    /// </summary>
    internal static string BadRequest { get; } = "The server could not understand the request due to invalid syntax or malformed data.";

    /// <summary>
    /// The default message for a "Conflict" error.
    /// </summary>
    internal static string Conflict { get; } = "The request could not be completed due to a conflict with the current state of the resource.";

    /// <summary>
    /// The default message for a "Forbidden" error.
    /// </summary>
    internal static string Forbidden { get; } = "You do not have permission to access this resource or perform this action.";

    /// <summary>
    /// The default message for a "Gone" error.
    /// </summary>
    public const string Gone = "The requested resource is no longer available and has been permanently removed from the server.";

    /// <summary>
    /// The default message for an "Internal Server Error".
    /// </summary>
    internal static string InternalServerError { get; } = "An unexpected error occurred on the server. Please try again later.";

    /// <summary>
    /// The default message for a "Not Found" error.
    /// </summary>
    internal static string NotFound { get; } = "The requested resource could not be found on the application.";

    /// <summary>
    /// The default message for a "Not Implemented" error.
    /// </summary>
    public const string NotImplemented = "The server does not support the functionality required to fulfill the request";

    /// <summary>
    /// The default message for a "Payment Required" error.
    /// </summary>
    public const string PaymentRequired = "Payment is required to access the requested resource.";

    /// <summary>
    /// The default message for a "Service Unavailable" error.
    /// </summary>
    public const string ServiceUnavailable = "The server is currently unable to handle the request due to temporary overloading or maintenance.";

    /// <summary>
    /// The default message for an "Unauthorized" error.
    /// </summary>
    internal static string Unauthorized { get; } = "You are not authorized to access this resource.";
}
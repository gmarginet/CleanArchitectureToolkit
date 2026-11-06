using System;
using System.Collections.Generic;

namespace Cat.Api.Client;

/// <summary>
/// Thrown by a generated client when a call fails or answers with something it did not expect.
/// The generator settings point at this class, so the generated code needs no exception class of its own.
/// Use <see cref="CatApiCall"/> to turn it into an <c>ICatResponse</c>.
/// </summary>
public class CatApiException : Exception
{
    /// <summary>
    /// Creates the exception with the details of the failed answer.
    /// </summary>
    /// <param name="message">A short description of what went wrong.</param>
    /// <param name="statusCode">The HTTP status code of the answer.</param>
    /// <param name="response">The body of the answer as text, or <c>null</c> when it has none.</param>
    /// <param name="headers">The headers of the answer.</param>
    /// <param name="innerException">The exception that caused this one, if any.</param>
    public CatApiException(
        string message,
        int statusCode,
        string? response,
        IReadOnlyDictionary<string, IEnumerable<string>> headers,
        Exception? innerException)
        : base(message + "\n\nStatus: " + statusCode + "\nResponse: \n" + (response == null ? "(null)" : response.Substring(0, Math.Min(response.Length, 512))), innerException)
    {
        StatusCode = statusCode;
        Response = response;
        Headers = headers;
    }

    /// <summary>The HTTP status code of the answer.</summary>
    public int StatusCode { get; }

    /// <summary>The body of the answer as text, or <c>null</c> when it has none.</summary>
    public string? Response { get; }

    /// <summary>The headers of the answer.</summary>
    public IReadOnlyDictionary<string, IEnumerable<string>> Headers { get; }
}

using System;
using System.Collections.Generic;

namespace Cat.Api.Client;

/// <summary>
/// A <see cref="CatApiException"/> that also carries the error body the generated client read from the answer.
/// </summary>
/// <typeparam name="TResult">The type of the error body, a generated model.</typeparam>
public class CatApiException<TResult> : CatApiException
{
    /// <summary>
    /// Creates the exception with the details of the failed answer and its parsed body.
    /// </summary>
    /// <param name="message">A short description of what went wrong.</param>
    /// <param name="statusCode">The HTTP status code of the answer.</param>
    /// <param name="response">The body of the answer as text, or <c>null</c> when it has none.</param>
    /// <param name="headers">The headers of the answer.</param>
    /// <param name="result">The body of the answer, read into the generated model.</param>
    /// <param name="innerException">The exception that caused this one, if any.</param>
    public CatApiException(
        string message,
        int statusCode,
        string? response,
        IReadOnlyDictionary<string, IEnumerable<string>> headers,
        TResult result,
        Exception? innerException)
        : base(message, statusCode, response, headers, innerException)
    {
        Result = result;
    }

    /// <summary>The body of the answer, read into the generated model.</summary>
    public TResult Result { get; }
}

using Cat.Responses.Abstractions;
using Microsoft.AspNetCore.Http;

namespace Cat.Minimal.Api.Extensions;

/// <summary>
/// Converts responses to their http representation.
/// </summary>
internal static class CatResponseExtensions
{
    /// <summary>
    /// Creates problem details for a failed response, with its errors and the status code and title of its type.
    /// </summary>
    /// <param name="catResponse">The failed response.</param>
    /// <param name="httpContext">The current request.</param>
    /// <returns>The problem details to send to the client.</returns>
    internal static CatProblemDetails ToProblemDetail(this ICatResponse catResponse, HttpContext httpContext)
        => CatProblemDetails.Create(
            httpContext,
            catResponse.Type.ToHttpStatusCode(),
            catResponse.Type.ToTitle(),
            "Look at the CatErrors property for more details.",
            catResponse.ErrorList);
}

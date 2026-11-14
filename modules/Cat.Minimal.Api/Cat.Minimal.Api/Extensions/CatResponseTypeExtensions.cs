using System;
using Cat.Responses.Abstractions;
using Microsoft.AspNetCore.Http;

namespace Cat.Minimal.Api.Extensions;

/// <summary>
/// Converts response types to their http representation.
/// </summary>
internal static class CatResponseTypeExtensions
{
    /// <summary>
    /// Gets the http status code of a response type.
    /// </summary>
    /// <param name="catResponseType">The response type.</param>
    /// <returns>The http status code.</returns>
    /// <exception cref="InvalidOperationException">Thrown when the response type has no status code mapping.</exception>
    internal static int ToHttpStatusCode(this CatResponseType catResponseType)
    {
        return catResponseType switch
        {
            CatResponseType.Succeeded.Ok => StatusCodes.Status200OK,
            CatResponseType.Succeeded.Created => StatusCodes.Status201Created,
            CatResponseType.Succeeded.NoContent => StatusCodes.Status204NoContent,
            CatResponseType.Succeeded.Accepted => StatusCodes.Status202Accepted,
            CatResponseType.Failed.BadRequest => StatusCodes.Status400BadRequest,
            CatResponseType.Failed.Unauthorized => StatusCodes.Status401Unauthorized,
            CatResponseType.Failed.Forbidden => StatusCodes.Status403Forbidden,
            CatResponseType.Failed.NotFound => StatusCodes.Status404NotFound,
            CatResponseType.Failed.Conflict => StatusCodes.Status409Conflict,
            CatResponseType.Failed.InternalServerError => StatusCodes.Status500InternalServerError,
            _ => throw new InvalidOperationException(
                $"CatResponseType {catResponseType.GetType().Name} has no http status code mapping.")
        };
    }

    /// <summary>
    /// Gets the problem details title of a failed response type. Succeeded types have no problem details body, so they have no title.
    /// </summary>
    /// <param name="catResponseType">The failed response type.</param>
    /// <returns>A short, human-readable summary of the problem.</returns>
    /// <exception cref="InvalidOperationException">Thrown when the response type has no title.</exception>
    internal static string ToTitle(this CatResponseType catResponseType)
    {
        return catResponseType switch
        {
            CatResponseType.Failed.BadRequest => "The request isn't valid.",
            CatResponseType.Failed.Unauthorized => "Authentication is required for this request.",
            CatResponseType.Failed.Forbidden => "The caller isn't allowed to perform this request.",
            CatResponseType.Failed.NotFound => "The requested resource was not found.",
            CatResponseType.Failed.Conflict => "The request conflicts with the current state of the resource.",
            CatResponseType.Failed.InternalServerError => "An unexpected error occurred.",
            _ => throw new InvalidOperationException(
                $"CatResponseType {catResponseType.GetType().Name} has no problem details title.")
        };
    }
}

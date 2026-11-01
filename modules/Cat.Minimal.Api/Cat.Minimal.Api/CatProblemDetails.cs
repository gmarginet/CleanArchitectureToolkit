using System.Collections.Generic;
using System.Diagnostics;
using Cat.Responses.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cat.Minimal.Api;

/// <summary>
/// The body of every failed response. It is a standard problem details object plus the CAT errors and a trace id.
/// </summary>
public class CatProblemDetails : ProblemDetails
{
    /// <summary>
    /// The errors of the failed response, each with a code, a message template and arguments.
    /// </summary>
    public IReadOnlyList<ICatError>? CatErrors { get; set; }

    /// <summary>
    /// The id to find this request in the logs.
    /// </summary>
    public string? CatTraceId { get; set; }

    /// <summary>
    /// Gets the id to find the request in the logs.
    /// </summary>
    /// <param name="httpContext">The current request.</param>
    /// <returns>The id of the current activity, or the trace identifier of the request when there is no activity.</returns>
    internal static string GetTraceId(HttpContext httpContext)
        => Activity.Current?.Id ?? httpContext.TraceIdentifier;

    /// <summary>
    /// Creates problem details for the current request, with the trace id filled in.
    /// </summary>
    /// <param name="httpContext">The current request.</param>
    /// <param name="status">The http status code.</param>
    /// <param name="title">A short summary of the problem.</param>
    /// <param name="detail">An explanation specific to this occurrence of the problem.</param>
    /// <param name="catErrors">The errors of the failed response. Defaults to an empty list.</param>
    /// <returns>The new problem details.</returns>
    internal static CatProblemDetails Create(
        HttpContext httpContext,
        int status,
        string title,
        string detail,
        IReadOnlyList<ICatError>? catErrors = null)
        => new()
        {
            Status = status,
            Title = title,
            Detail = detail,
            Instance = httpContext.Request.Path.ToString(),
            CatErrors = catErrors ?? [],
            CatTraceId = GetTraceId(httpContext)
        };
}

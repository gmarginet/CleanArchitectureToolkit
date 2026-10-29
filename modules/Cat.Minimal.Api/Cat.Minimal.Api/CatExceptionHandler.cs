using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Cat.Minimal.Api;

/// <summary>
/// Catches unexpected exceptions, logs them and answers with a 500 <see cref="CatProblemDetails"/>.
/// </summary>
internal sealed class CatExceptionHandler : IExceptionHandler
{
    private readonly ILogger<CatExceptionHandler> _logger;
    private readonly IHostEnvironment _environment;

    /// <summary>
    /// Creates the handler.
    /// </summary>
    /// <param name="logger">Receives the exception.</param>
    /// <param name="environment">Decides whether the exception details may go to the client.</param>
    public CatExceptionHandler(
        ILogger<CatExceptionHandler> logger,
        IHostEnvironment environment)
    {
        _logger = logger;
        _environment = environment;
    }

    /// <summary>
    /// Logs the exception and writes a 500 problem details response.
    /// In the Development environment the type holds the exception type name and the detail holds the exception message.
    /// In every other environment the client gets a generic detail and the trace id to find the exception in the logs.
    /// </summary>
    /// <param name="httpContext">The current request.</param>
    /// <param name="exception">The exception that was thrown.</param>
    /// <param name="cancellationToken">Token to cancel the work.</param>
    /// <returns>Always <c>true</c>, because the handler always writes the response.</returns>
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        var traceId = Activity.Current?.Id ?? httpContext.TraceIdentifier;
        
        _logger.LogError(exception, "An unexpected error occurred (catTraceId: {TraceId})", traceId);
        
        httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        
        var showDetails = _environment.IsDevelopment();

        var problem = new CatProblemDetails
        {
            Type = showDetails ? exception.GetType().Name : null,
            Title = "An unexpected error occurred.",
            Status = StatusCodes.Status500InternalServerError,
            Detail = showDetails ? exception.Message : "Use the CatTraceId to find the error in the logs.",
            Instance = httpContext.Request.Path.ToString(),
            CatErrors = [],
            CatTraceId = traceId
        };
        
        await httpContext.Response.WriteAsJsonAsync(problem, cancellationToken);
        return true;
    }
}
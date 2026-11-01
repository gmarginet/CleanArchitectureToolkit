using System;
using System.Threading;
using System.Threading.Tasks;
using Cat.Minimal.Api.Extensions;
using Cat.Responses.Abstractions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Cat.Minimal.Api;

/// <summary>
/// Catches exceptions that escape an endpoint and answers with a <see cref="CatProblemDetails"/>.
/// Unexpected exceptions become a 500. Request binding failures keep their own status code, usually a 400.
/// A client that closed the request gets no body.
/// </summary>
internal sealed class CatExceptionHandler : IExceptionHandler
{
    // Not an official status code, but widely used (nginx) for a request the client gave up on.
    private const int Status499ClientClosedRequest = 499;
    private const string ProblemJsonContentType = "application/problem+json";

    private readonly ILogger<CatExceptionHandler> _logger;
    private readonly IHostEnvironment _environment;
    private readonly IProblemDetailsService _problemDetailsService;

    /// <summary>
    /// Creates the handler.
    /// </summary>
    /// <param name="logger">Receives the exception.</param>
    /// <param name="environment">Decides whether the exception details may go to the client.</param>
    /// <param name="problemDetailsService">Writes the problem details, so they get the same fields as every other error response.</param>
    public CatExceptionHandler(
        ILogger<CatExceptionHandler> logger,
        IHostEnvironment environment,
        IProblemDetailsService problemDetailsService)
    {
        _logger = logger;
        _environment = environment;
        _problemDetailsService = problemDetailsService;
    }

    /// <summary>
    /// Logs the exception and writes a problem details response.
    /// <list type="bullet">
    /// <item><description>A <see cref="BadHttpRequestException"/> keeps its status code and message, and is logged as information.</description></item>
    /// <item><description>An <see cref="OperationCanceledException"/> from a client that closed the request gets status 499, no body, and is logged as debug.</description></item>
    /// <item><description>Any other exception becomes a 500 and is logged as an error.
    /// In the Development environment the detail holds the exception type name and message.
    /// In every other environment the detail points to the trace id to find the exception in the logs.</description></item>
    /// </list>
    /// </summary>
    /// <param name="httpContext">The current request.</param>
    /// <param name="exception">The exception that was thrown.</param>
    /// <param name="cancellationToken">Token to cancel the work.</param>
    /// <returns><c>true</c> when the handler handled the exception. <c>false</c> when the response has already started, so no body can be written.</returns>
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        // Part of the response is already sent, so a problem details body can't be written anymore.
        if (httpContext.Response.HasStarted) return false;

        var traceId = CatProblemDetails.GetTraceId(httpContext);

        // The client went away. Nobody reads the response, and it isn't an error of the api.
        if (exception is OperationCanceledException && httpContext.RequestAborted.IsCancellationRequested)
        {
            _logger.LogDebug("The client closed the request before it finished (catTraceId: {TraceId})", traceId);
            httpContext.Response.StatusCode = Status499ClientClosedRequest;
            return true;
        }

        // The request couldn't be bound, for example malformed json or a route value that doesn't parse.
        // That is a mistake of the client, so it gets the status code of the exception and the reason.
        if (exception is BadHttpRequestException badHttpRequestException)
        {
            _logger.LogInformation(exception, "The request couldn't be bound (catTraceId: {TraceId})", traceId);

            var statusCode = badHttpRequestException.StatusCode;
            var title = statusCode == StatusCodes.Status400BadRequest
                ? CatResponseType.BadRequest.ToTitle()
                : ReasonPhrases.GetReasonPhrase(statusCode);

            await WriteProblemAsync(
                httpContext,
                CatProblemDetails.Create(httpContext, statusCode, title, badHttpRequestException.Message),
                cancellationToken);
            return true;
        }

        _logger.LogError(exception, "An unexpected error occurred (catTraceId: {TraceId})", traceId);

        var detail = _environment.IsDevelopment()
            ? $"{exception.GetType().Name}: {exception.Message}"
            : "Use the CatTraceId to find the error in the logs.";

        await WriteProblemAsync(
            httpContext,
            CatProblemDetails.Create(
                httpContext,
                StatusCodes.Status500InternalServerError,
                CatResponseType.InternalServerError.ToTitle(),
                detail),
            cancellationToken);
        return true;
    }

    /// <summary>
    /// Writes the problem details as the response, with the status code of the problem.
    /// </summary>
    /// <param name="httpContext">The current request.</param>
    /// <param name="problem">The problem details to write.</param>
    /// <param name="cancellationToken">Token to cancel the work.</param>
    private async Task WriteProblemAsync(HttpContext httpContext, CatProblemDetails problem, CancellationToken cancellationToken)
    {
        httpContext.Response.StatusCode = problem.Status ?? StatusCodes.Status500InternalServerError;

        // Going through the problem details service gives these responses the same fields as every other error
        // response, such as the type link. It declines when the client doesn't accept json, then the body is
        // written directly.
        var written = await _problemDetailsService.TryWriteAsync(new ProblemDetailsContext
        {
            HttpContext = httpContext,
            ProblemDetails = problem
        });
        if (written) return;

        // Null options means the json options the app configured are used.
        await httpContext.Response.WriteAsJsonAsync(problem, options: null, ProblemJsonContentType, cancellationToken);
    }
}

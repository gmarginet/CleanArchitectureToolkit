using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Cat.Api.Gateway.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Cat.Api.Gateway.Middleware;

/// <summary>
/// Gives every request a correlation id and passes it on to the service and back to the caller.
/// </summary>
/// <remarks>
/// A caller may send its own id in the <c>X-Correlation-Id</c> header. The gateway only accepts a short id of
/// plain characters. Anything else could break a log line, so the gateway replaces it with a new id.
/// </remarks>
internal sealed class CorrelationIdMiddleware
{
    private const int MaximumLength = 128;

    private readonly RequestDelegate _next;
    private readonly ILogger<CorrelationIdMiddleware> _logger;

    public CorrelationIdMiddleware(RequestDelegate next, ILogger<CorrelationIdMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var incoming = context.Request.Headers[CatGatewayDefaults.CorrelationIdHeaderName].ToString();
        var id = IsValid(incoming) ? incoming : Guid.NewGuid().ToString("N");

        context.Request.Headers[CatGatewayDefaults.CorrelationIdHeaderName] = id;
        context.Response.OnStarting(() =>
        {
            context.Response.Headers[CatGatewayDefaults.CorrelationIdHeaderName] = id;
            return Task.CompletedTask;
        });

        Activity.Current?.SetTag("cat.correlation_id", id);

        using (_logger.BeginScope(new[] { new System.Collections.Generic.KeyValuePair<string, object>("CorrelationId", id) }))
        {
            await _next(context);
        }
    }

    internal static bool IsValid(string value) =>
        value.Length is > 0 and <= MaximumLength &&
        value.All(c => char.IsAsciiLetterOrDigit(c) || c is '-' or '_' or '.' or ':');
}

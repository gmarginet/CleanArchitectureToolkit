using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Cat.Api.Gateway.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Yarp.ReverseProxy.Model;

namespace Cat.Api.Gateway.Middleware;

/// <summary>
/// Logs one line for every request: the method, the path, the status, the time and the service.
/// </summary>
/// <remarks>
/// The line never holds the query string, a header or a body, so a token or a personal value in them
/// does not end up in the log. The path can still hold an id, so treat the log as sensitive.
/// </remarks>
internal sealed class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<RequestLoggingMiddleware> _logger;

    public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var start = Stopwatch.GetTimestamp();
        try
        {
            await _next(context);
        }
        finally
        {
            var elapsed = Stopwatch.GetElapsedTime(start).TotalMilliseconds;
            var service = context.GetEndpoint()?.Metadata.GetMetadata<RouteModel>()?.Config.Metadata?
                .GetValueOrDefault(CatProxyConfigBuilder.ServiceMetadataKey) ?? "-";
            var status = context.Response.StatusCode;

            _logger.Log(
                status >= 500 ? LogLevel.Warning : LogLevel.Information,
                "{Method} {Path} answered {StatusCode} in {ElapsedMilliseconds:0.0} ms (service {Service})",
                context.Request.Method,
                context.Request.Path.Value,
                status,
                elapsed,
                service);
        }
    }
}

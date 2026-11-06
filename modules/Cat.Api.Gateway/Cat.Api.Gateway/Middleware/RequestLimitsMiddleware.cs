using System.Threading.Tasks;
using Cat.Api.Gateway.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;

namespace Cat.Api.Gateway.Middleware;

/// <summary>
/// Rejects a request body that is larger than <see cref="CatGatewayLimitsOptions.MaxRequestBodySize"/>.
/// </summary>
internal sealed class RequestLimitsMiddleware
{
    private readonly RequestDelegate _next;
    private readonly CatGatewayConfigurationProvider _configuration;

    public RequestLimitsMiddleware(RequestDelegate next, CatGatewayConfigurationProvider configuration)
    {
        _next = next;
        _configuration = configuration;
    }

    public Task InvokeAsync(HttpContext context)
    {
        var limit = _configuration.Options.Limits.MaxRequestBodySize;

        if (context.Request.ContentLength > limit)
        {
            context.Response.StatusCode = StatusCodes.Status413PayloadTooLarge;
            return Task.CompletedTask;
        }

        var feature = context.Features.Get<IHttpMaxRequestBodySizeFeature>();
        if (feature is { IsReadOnly: false }) feature.MaxRequestBodySize = limit;

        return _next(context);
    }
}

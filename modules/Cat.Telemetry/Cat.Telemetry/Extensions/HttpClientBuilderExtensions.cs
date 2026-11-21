using System.Diagnostics;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Http;
using Microsoft.Extensions.Options;

namespace Cat.Telemetry.Extensions;

/// <summary>
/// Puts a trace boundary on an <see cref="IHttpClientBuilder"/>.
/// </summary>
public static class HttpClientBuilderExtensions
{
    /// <summary>
    /// Keeps the trace out of the requests of this client. No <c>traceparent</c>, <c>tracestate</c> or <c>baggage</c> header
    /// leaves, so a third party gets no ids of ours. The call is still a span in the trace of the caller.
    /// </summary>
    /// <remarks>
    /// The headers are written by the primary handler, after every delegating handler, so this sets the propagator of the
    /// primary handler. It never creates a handler of its own. It runs after every other setup of the client, so a primary handler
    /// that you set, such as one with a client certificate, stays and only loses the headers. A primary handler that is not a
    /// <see cref="SocketsHttpHandler"/>, such as one of a test, is left alone.
    /// </remarks>
    /// <param name="builder">The builder of the client.</param>
    /// <returns>The same builder, for chaining.</returns>
    public static IHttpClientBuilder AddCatTelemetryBoundary(this IHttpClientBuilder builder)
    {
        builder.Services.AddOptions<HttpClientFactoryOptions>(builder.Name).PostConfigure(options =>
            options.HttpMessageHandlerBuilderActions.Add(handlerBuilder =>
            {
                if (handlerBuilder.PrimaryHandler is SocketsHttpHandler sockets)
                {
                    sockets.ActivityHeadersPropagator = DistributedContextPropagator.CreateNoOutputPropagator();
                }
            }));
        return builder;
    }
}

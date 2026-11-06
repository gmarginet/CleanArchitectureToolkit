using System;
using System.Collections.Generic;
using System.Linq;
using Cat.Api.Gateway.Abstractions;
using Cat.Api.Gateway.Assertion;
using Cat.Api.Gateway.Configuration;
using Yarp.ReverseProxy.Transforms;
using Yarp.ReverseProxy.Transforms.Builder;

namespace Cat.Api.Gateway.Transforms;

/// <summary>
/// Adds the security transforms to every route, also to routes that come from plain YARP configuration.
/// </summary>
/// <remarks>
/// <list type="bullet">
/// <item><description>Removes the headers a caller could use to fake an identity, and the gateway assertion header.</description></item>
/// <item><description>Replaces the <c>X-Forwarded-*</c> headers, unless you trust an earlier proxy.</description></item>
/// <item><description>Adds the gateway assertion to routes of a service that is gateway only.</description></item>
/// </list>
/// The header removal runs after YARP copied the request headers, so the copy cannot bring a header back.
/// </remarks>
internal sealed class CatGatewayTransformProvider : ITransformProvider
{
    private static readonly string[] BuiltInStripHeaders =
    [
        CatGatewayDefaults.AssertionHeaderName,
        "X-User",
        "X-User-Id",
        "X-Forwarded-User",
        "X-Authenticated-User",
        "X-Remote-User",
        "X-Original-User"
    ];

    private readonly CatGatewayConfigurationProvider _configuration;
    private readonly CatGatewaySigningKeys _signingKeys;

    public CatGatewayTransformProvider(CatGatewayConfigurationProvider configuration, CatGatewaySigningKeys signingKeys)
    {
        _configuration = configuration;
        _signingKeys = signingKeys;
    }

    public void ValidateRoute(TransformRouteValidationContext context)
    {
    }

    public void ValidateCluster(TransformClusterValidationContext context)
    {
    }

    public void Apply(TransformBuilderContext context)
    {
        var headers = _configuration.Options.Headers;
        var trust = headers.TrustForwardedHeaders;

        var strip = BuiltInStripHeaders.Concat(headers.StripHeaders).ToList();
        if (!trust) strip.Add("Forwarded");

        context.AddXForwarded(trust ? ForwardedTransformActions.Append : ForwardedTransformActions.Set);

        context.AddRequestTransform(transform =>
        {
            foreach (var header in strip) transform.ProxyRequest.Headers.Remove(header);
            return default;
        });

        var metadata = context.Route.Metadata;
        if (metadata is not null &&
            metadata.TryGetValue(CatProxyConfigBuilder.GatewayOnlyMetadataKey, out var gatewayOnly) && gatewayOnly == "true" &&
            metadata.TryGetValue(CatProxyConfigBuilder.ServiceMetadataKey, out var service))
        {
            context.AddRequestTransform(transform =>
            {
                transform.ProxyRequest.Headers.TryAddWithoutValidation(
                    CatGatewayDefaults.AssertionHeaderName,
                    _signingKeys.GetAssertion(service));
                return default;
            });
        }
    }
}

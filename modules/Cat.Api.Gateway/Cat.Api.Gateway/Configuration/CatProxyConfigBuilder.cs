using System;
using System.Collections.Generic;
using System.Linq;
using Yarp.ReverseProxy.Configuration;
using Yarp.ReverseProxy.Forwarder;

namespace Cat.Api.Gateway.Configuration;

/// <summary>
/// Turns the gateway configuration into YARP routes and clusters. The conventions live here.
/// </summary>
internal static class CatProxyConfigBuilder
{
    /// <summary>
    /// The metadata key that holds the name of the service of a route.
    /// </summary>
    public const string ServiceMetadataKey = "Cat.Service";

    /// <summary>
    /// The metadata key that says a route sends the gateway assertion. The value is <c>true</c>.
    /// </summary>
    public const string GatewayOnlyMetadataKey = "Cat.GatewayOnly";

    private const string AnonymousPolicy = "anonymous";

    public static (IReadOnlyList<RouteConfig> Routes, IReadOnlyList<ClusterConfig> Clusters) Build(CatGatewayOptions options)
    {
        var routes = new List<RouteConfig>();
        var clusters = new List<ClusterConfig>();

        foreach (var (name, service) in options.Services)
        {
            var prefix = CatGatewayOptionsValidator.EffectivePath(name, service);
            var metadata = new Dictionary<string, string> { [ServiceMetadataKey] = name };
            if (CatGatewayOptionsValidator.EffectiveGatewayOnly(options, service))
                metadata[GatewayOnlyMetadataKey] = "true";

            IReadOnlyList<IReadOnlyDictionary<string, string>>? transforms = service.StripPrefix && prefix != "/"
                ? [new Dictionary<string, string> { ["PathRemovePrefix"] = prefix }]
                : null;

            // A route without an authorization policy falls back to the policy that requires a token.
            routes.Add(new RouteConfig
            {
                RouteId = name,
                ClusterId = name,
                Match = new RouteMatch { Path = (prefix == "/" ? string.Empty : prefix) + "/{**catchAll}" },
                Metadata = metadata,
                Transforms = transforms
            });

            var index = 0;
            foreach (var text in service.Anonymous)
            {
                AnonymousPattern.TryParse(text, out var pattern, out _);
                routes.Add(new RouteConfig
                {
                    RouteId = $"{name}.anonymous.{index++}",
                    ClusterId = name,
                    Order = -1,
                    AuthorizationPolicy = AnonymousPolicy,
                    Match = new RouteMatch { Path = pattern.ToRouteTemplate(prefix), Methods = pattern.Methods },
                    Metadata = metadata,
                    Transforms = transforms
                });
            }

            clusters.Add(BuildCluster(options, name, service));
        }

        return (routes, clusters);
    }

    private static ClusterConfig BuildCluster(CatGatewayOptions options, string name, CatGatewayServiceOptions service)
    {
        var destinations = CatGatewayOptionsValidator.EffectiveAddresses(service)
            .Select((address, i) => (Key: $"d{i}", Address: address))
            .ToDictionary(d => d.Key, d => new DestinationConfig { Address = d.Address });

        return new ClusterConfig
        {
            ClusterId = name,
            Destinations = destinations,
            HttpRequest = new ForwarderRequestConfig { ActivityTimeout = CatGatewayOptionsValidator.EffectiveTimeout(options, service) },
            HealthCheck = string.IsNullOrEmpty(service.HealthCheckPath)
                ? null
                : new HealthCheckConfig
                {
                    Active = new ActiveHealthCheckConfig
                    {
                        Enabled = true,
                        Interval = service.HealthCheckInterval,
                        Timeout = TimeSpan.FromSeconds(5),
                        Policy = "ConsecutiveFailures",
                        Path = service.HealthCheckPath
                    }
                }
        };
    }
}

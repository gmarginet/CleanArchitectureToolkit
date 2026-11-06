using System;
using System.Collections.Generic;
using System.Threading;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using Yarp.ReverseProxy.Configuration;

namespace Cat.Api.Gateway.Configuration;

/// <summary>
/// Gives YARP the routes and clusters of the gateway, and keeps them current when the configuration changes.
/// </summary>
/// <remarks>
/// A new configuration is bound and checked before it goes live. When it fails the check, the provider logs the
/// errors and keeps the last good configuration. It never throws from a reload, because that would end the process.
/// The first configuration has no earlier one, so an error there stops the start.
/// </remarks>
internal sealed class CatGatewayConfigurationProvider : IProxyConfigProvider, IDisposable
{
    private readonly IConfiguration _section;
    private readonly bool _signingKeyAvailable;
    private readonly ILogger<CatGatewayConfigurationProvider> _logger;
    private readonly IDisposable _registration;
    private readonly object _gate = new();
    private Snapshot _current;

    public CatGatewayConfigurationProvider(
        IConfiguration section,
        bool signingKeyAvailable,
        ILogger<CatGatewayConfigurationProvider> logger)
    {
        _section = section;
        _signingKeyAvailable = signingKeyAvailable;
        _logger = logger;

        var options = Bind();
        var errors = CatGatewayOptionsValidator.Validate(options, signingKeyAvailable);
        if (errors.Count > 0)
            throw new InvalidOperationException(
                "The gateway configuration is not valid:" + Environment.NewLine + string.Join(Environment.NewLine, errors));

        _current = Snapshot.Create(options);
        _registration = ChangeToken.OnChange(_section.GetReloadToken, Reload);
    }

    /// <summary>
    /// The configuration that is live now.
    /// </summary>
    public CatGatewayOptions Options => Volatile.Read(ref _current).Options;

    /// <inheritdoc />
    public IProxyConfig GetConfig() => Volatile.Read(ref _current).Config;

    public void Dispose()
    {
        _registration.Dispose();
        Volatile.Read(ref _current).Config.Cancel();
    }

    private CatGatewayOptions Bind() => _section.Get<CatGatewayOptions>() ?? new CatGatewayOptions();

    private void Reload()
    {
        try
        {
            var options = Bind();
            var errors = CatGatewayOptionsValidator.Validate(options, _signingKeyAvailable);
            if (errors.Count > 0)
            {
                _logger.LogError(
                    "The changed gateway configuration is not valid and is ignored. The gateway keeps the last good configuration. {Errors}",
                    string.Join(" | ", errors));
                return;
            }

            Snapshot previous;
            lock (_gate)
            {
                previous = _current;
                Volatile.Write(ref _current, Snapshot.Create(options));
            }

            previous.Config.Cancel();
            _logger.LogInformation("The gateway configuration changed and is now live.");
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, "The changed gateway configuration could not be read and is ignored.");
        }
    }

    private sealed record Snapshot(CatGatewayOptions Options, ProxyConfig Config)
    {
        public static Snapshot Create(CatGatewayOptions options)
        {
            var (routes, clusters) = CatProxyConfigBuilder.Build(options);
            return new Snapshot(options, new ProxyConfig(routes, clusters));
        }
    }

    private sealed class ProxyConfig : IProxyConfig
    {
        private readonly CancellationTokenSource _source = new();

        public ProxyConfig(IReadOnlyList<RouteConfig> routes, IReadOnlyList<ClusterConfig> clusters)
        {
            Routes = routes;
            Clusters = clusters;
            ChangeToken = new CancellationChangeToken(_source.Token);
        }

        public IReadOnlyList<RouteConfig> Routes { get; }
        public IReadOnlyList<ClusterConfig> Clusters { get; }
        public IChangeToken ChangeToken { get; }

        public void Cancel()
        {
            try { _source.Cancel(); }
            catch (ObjectDisposedException) { }
        }
    }
}

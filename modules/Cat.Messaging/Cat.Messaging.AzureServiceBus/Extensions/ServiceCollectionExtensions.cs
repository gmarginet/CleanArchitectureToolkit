using Azure.Messaging.ServiceBus;
using Azure.Messaging.ServiceBus.Administration;
using Cat.Messaging.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

namespace Cat.Messaging.AzureServiceBus.Extensions;

/// <summary>
/// Registration helpers for the Azure Service Bus transport.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registers the Azure Service Bus transport, and the helper that creates the queues and topics on request.
    /// Nothing is created at startup. Call <see cref="ICatServiceBusTopology.EnsureTopologyAsync"/> when you want the entities.
    /// The administration client connects only when it is used, so a service that never creates entities needs no manage right.
    /// </summary>
    /// <param name="services">The service collection to add to.</param>
    /// <param name="configure">Sets the connection string, and the optional callbacks that change the options of the SDK.</param>
    /// <returns>The same service collection, so calls can be chained.</returns>
    public static IServiceCollection AddCatMessagingAzureServiceBus(this IServiceCollection services,
        Action<CatServiceBusOptions> configure)
    {
        services.AddOptions<CatServiceBusOptions>().Configure(configure);

        services.TryAddSingleton(provider => CreateClient(provider.GetRequiredService<IOptions<CatServiceBusOptions>>().Value));
        services.TryAddSingleton(provider => CreateAdministrationClient(provider.GetRequiredService<IOptions<CatServiceBusOptions>>().Value));
        services.TryAddSingleton<ICatMessageTransport, ServiceBusMessageTransport>();
        services.TryAddSingleton<ICatServiceBusTopology, ServiceBusTopology>();

        return services;
    }

    internal static ServiceBusClient CreateClient(CatServiceBusOptions options)
    {
        var clientOptions = new ServiceBusClientOptions();
        options.ConfigureClient?.Invoke(clientOptions);
        return new ServiceBusClient(options.ConnectionString, clientOptions);
    }

    internal static ServiceBusAdministrationClient CreateAdministrationClient(CatServiceBusOptions options)
    {
        var clientOptions = new ServiceBusAdministrationClientOptions();
        options.ConfigureAdministrationClient?.Invoke(clientOptions);
        return new ServiceBusAdministrationClient(options.ResolveAdministrationConnectionString(), clientOptions);
    }

    /// <summary>
    /// Turns the dead letter metric on. It is off by default, because reading the counts needs the manage right on the namespace.
    /// The metric is the gauge <c>cat.messaging.dead_letters</c> on the meter <c>Cat.Messaging</c>.
    /// Call it after <see cref="AddCatMessagingAzureServiceBus"/>.
    /// </summary>
    /// <param name="services">The service collection to add to.</param>
    /// <param name="configure">Sets the queues and subscriptions to watch.</param>
    /// <returns>The same service collection, so calls can be chained.</returns>
    public static IServiceCollection AddCatDeadLetterMetric(this IServiceCollection services,
        Action<CatDeadLetterMetricsOptions> configure)
    {
        services.AddOptions<CatDeadLetterMetricsOptions>().Configure(configure);
        services.AddHostedService<DeadLetterMetricsService>();

        return services;
    }
}

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
    /// <param name="configure">Sets the connection string.</param>
    /// <returns>The same service collection, so calls can be chained.</returns>
    public static IServiceCollection AddCatMessagingAzureServiceBus(this IServiceCollection services,
        Action<CatServiceBusOptions> configure)
    {
        services.AddOptions<CatServiceBusOptions>().Configure(configure);

        services.TryAddSingleton(provider => new ServiceBusClient(provider.GetRequiredService<IOptions<CatServiceBusOptions>>().Value.ConnectionString));
        services.TryAddSingleton(provider => new ServiceBusAdministrationClient(
            provider.GetRequiredService<IOptions<CatServiceBusOptions>>().Value.ResolveAdministrationConnectionString()));
        services.TryAddSingleton<ICatMessageTransport, ServiceBusMessageTransport>();
        services.TryAddSingleton<ICatServiceBusTopology, ServiceBusTopology>();

        return services;
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

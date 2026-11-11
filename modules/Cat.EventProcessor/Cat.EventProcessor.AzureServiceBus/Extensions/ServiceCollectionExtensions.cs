using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Cat.EventProcessor.AzureServiceBus.Extensions;

/// <summary>
/// Registration helpers for the Azure Service Bus listener.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registers the listener that starts a processor for every declared message type.
    /// Call it after <c>AddCatEventProcessor</c> and <c>AddCatMessagingAzureServiceBus</c>, which holds the connection.
    /// </summary>
    /// <param name="services">The service collection to add to.</param>
    /// <param name="configure">Sets the subscription name of this service.</param>
    /// <returns>The same service collection, so calls can be chained.</returns>
    public static IServiceCollection AddCatEventProcessorAzureServiceBus(this IServiceCollection services,
        Action<CatEventProcessorServiceBusOptions> configure)
    {
        services.AddOptions<CatEventProcessorServiceBusOptions>().Configure(configure);
        services.TryAddSingleton<ListenerStatus>();
        services.TryAddSingleton<ICatEventProcessorTopology, EventProcessorTopology>();
        services.AddSingleton<ServiceBusListener>();
        services.AddHostedService(provider => provider.GetRequiredService<ServiceBusListener>());

        return services;
    }

    /// <summary>
    /// Adds the health check of the listeners. It is unhealthy when a listener has stopped, and degraded for a minute after an error.
    /// </summary>
    /// <param name="builder">The health checks builder.</param>
    /// <param name="name">The name of the check. The default is <c>cat-event-processor</c>.</param>
    /// <returns>The same builder, so calls can be chained.</returns>
    public static IHealthChecksBuilder AddCatEventProcessorHealthCheck(this IHealthChecksBuilder builder, string name = "cat-event-processor")
    {
        builder.Services.TryAddSingleton<ListenerStatus>();
        return builder.AddCheck<EventProcessorHealthCheck>(name);
    }
}

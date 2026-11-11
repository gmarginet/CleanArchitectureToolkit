using System;
using Cat.EventProcessor.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Cat.EventProcessor.Extensions;

/// <summary>
/// Registration helpers for the event processor.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// The configuration section that holds the settings per message type, in the form
    /// <c>CatEventProcessor:Messages:OrderPlaced:MaxConcurrentCalls</c>.
    /// </summary>
    public const string ConfigurationSectionName = "CatEventProcessor:Messages";

    /// <summary>
    /// Registers the receiver and the message types the service receives.
    /// The message types come from the code. The settings per message type come from the code too,
    /// and the configuration wins, so whoever runs the service can change a setting without a build.
    /// Register a broker too, such as <c>Cat.EventProcessor.AzureServiceBus</c>, and the service request module.
    /// </summary>
    /// <param name="services">The service collection to add to.</param>
    /// <param name="configuration">The configuration of the service.</param>
    /// <param name="declare">Declares the message types.</param>
    /// <returns>The same service collection, so calls can be chained.</returns>
    public static IServiceCollection AddCatEventProcessor(this IServiceCollection services,
        IConfiguration configuration,
        Action<CatEventProcessorBuilder> declare)
    {
        var builder = new CatEventProcessorBuilder();
        declare(builder);

        foreach (var registration in builder.Registrations)
        {
            configuration.GetSection(ConfigurationSectionName).GetSection(registration.MessageType.Name).Bind(registration.Options);
        }

        services.AddSingleton<ICatReceiveRegistry>(new ReceiveRegistry(builder.Registrations));
        services.TryAddSingleton<ICatMessageReceiver, CatMessageReceiver>();

        return services;
    }
}

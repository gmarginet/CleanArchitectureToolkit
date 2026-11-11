using Cat.Messaging.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Cat.Messaging.Extensions;

/// <summary>
/// Registration helpers for the messaging module.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registers the message sender and the name convention.
    /// Messages go straight to the <see cref="ICatMessageTransport"/>, so register a transport too,
    /// such as the one from <c>Cat.Messaging.AzureServiceBus</c>.
    /// Add the outbox after this call when messages must not get lost.
    /// </summary>
    /// <param name="services">The service collection to add to.</param>
    /// <returns>The same service collection, so calls can be chained.</returns>
    public static IServiceCollection AddCatMessagingModule(this IServiceCollection services)
    {
        services.TryAddSingleton<ICatMessageNameResolver, CatMessageNameResolver>();
        services.TryAddSingleton<ICatMessageSerializer, SystemTextJsonMessageSerializer>();
        services.TryAddScoped<ICatOutgoingMessageSink, DirectMessageSink>();
        services.TryAddScoped<ICatMessageSender, CatMessageSender>();

        return services;
    }
}

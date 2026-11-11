using System;
using Cat.Messaging.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Cat.Messaging.Outbox.Extensions;

/// <summary>
/// Registration helpers for the outbox.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Turns the outbox on. The message sender then stores messages instead of sending them,
    /// and a background service sends the stored messages to the transport.
    /// Call it after <c>AddCatMessagingModule</c>, and register an <see cref="ICatOutboxStore"/> too,
    /// such as the one from <c>Cat.Messaging.Outbox.EFCore</c>.
    /// </summary>
    /// <param name="services">The service collection to add to.</param>
    /// <param name="configure">Changes the settings of the outbox sender.</param>
    /// <returns>The same service collection, so calls can be chained.</returns>
    public static IServiceCollection AddCatMessagingOutbox(this IServiceCollection services,
        Action<CatOutboxOptions>? configure = null)
    {
        services.RemoveAll<ICatOutgoingMessageSink>();
        services.AddScoped<ICatOutgoingMessageSink, OutboxMessageSink>();

        var options = services.AddOptions<CatOutboxOptions>();
        if (configure is not null)
        {
            options.Configure(configure);
        }

        services.AddHostedService<OutboxSender>();

        return services;
    }
}

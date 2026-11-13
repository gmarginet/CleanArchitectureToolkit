using Cat.Sql.Cdc.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Cat.Sql.Cdc.Messaging.Extensions;

/// <summary>
/// Registration helpers for the bridge between the change data capture module and <c>Cat.Messaging</c>.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registers the sink that sends every change as an event message through <c>ICatMessageSender</c>.
    /// Register <c>Cat.Messaging</c> as well.
    /// </summary>
    /// <param name="services">The service collection to add to.</param>
    /// <returns>The service collection.</returns>
    public static IServiceCollection AddCatSqlCdcMessaging(this IServiceCollection services)
    {
        services.AddSingleton<ICatChangeSink, CatMessagingChangeSink>();
        return services;
    }
}

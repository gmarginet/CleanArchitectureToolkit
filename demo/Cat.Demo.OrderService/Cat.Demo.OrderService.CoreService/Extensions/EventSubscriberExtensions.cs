using System;
using Cat.Demo.OrderService.CoreService.EventSubscribers;
using Microsoft.Extensions.DependencyInjection;

namespace Cat.Demo.OrderService.CoreService.Extensions;

public static class EventSubscriberExtensions
{
    /// <summary>Registers the order event subscribers as singletons. Call <see cref="ActivateCatDemoOrderEventSubscribers"/> after the app is built.</summary>
    public static IServiceCollection AddCatDemoOrderEventSubscribers(this IServiceCollection services)
    {
        services.AddSingleton<OrderAuditSubscriber>();
        services.AddSingleton<OrderStatusSubscriber>();
        services.AddSingleton<StockReleaseSubscriber>();
        return services;
    }

    /// <summary>
    /// Creates the subscribers, so they subscribe themselves to the event aggregator.
    /// The aggregator holds them with weak references, and the container keeps them alive.
    /// </summary>
    public static IServiceProvider ActivateCatDemoOrderEventSubscribers(this IServiceProvider services)
    {
        services.GetRequiredService<OrderAuditSubscriber>();
        services.GetRequiredService<OrderStatusSubscriber>();
        services.GetRequiredService<StockReleaseSubscriber>();
        return services;
    }
}

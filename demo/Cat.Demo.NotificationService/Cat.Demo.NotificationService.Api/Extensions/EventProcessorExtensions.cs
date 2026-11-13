using System;
using System.Threading;
using System.Threading.Tasks;
using Cat.Demo.InventoryService.Contracts.Messages;
using Cat.Demo.OrderService.Contracts.Messages;
using Cat.EventProcessor.AzureServiceBus;
using Cat.EventProcessor.AzureServiceBus.Extensions;
using Cat.EventProcessor.Extensions;
using Cat.Messaging.AzureServiceBus.Extensions;
using Cat.Messaging.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cat.Demo.NotificationService.Api.Extensions;

public static class EventProcessorExtensions
{
    /// <summary>The name Notifications uses on the topic of every message it receives.</summary>
    public const string SubscriptionName = "notifications";

    /// <summary>
    /// Declares the messages Notifications receives and starts the listener for them.
    /// It only works when the host gives Notifications the connection string <c>messaging</c> (Aspire does).
    /// Without it nothing is registered, so <c>dotnet run</c> keeps working on its own.
    /// </summary>
    /// <returns><c>true</c> when the listener is registered.</returns>
    public static bool AddCatDemoNotificationEventProcessor(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("messaging");
        if (string.IsNullOrWhiteSpace(connectionString))
        {
            return false;
        }

        services.AddCatMessagingModule();
        services.AddCatMessagingAzureServiceBus(options =>
        {
            options.ConnectionString = connectionString;
            options.AdministrationConnectionString = configuration["Messaging:AdministrationConnectionString"] ?? string.Empty;
        });

        services.AddCatEventProcessor(configuration, processor => processor.Receive<OrderConfirmed>().Receive<LowStockReport>().Receive<StockChanged>());
        services.AddCatEventProcessorAzureServiceBus(options => options.SubscriptionName = SubscriptionName);
        services.AddHealthChecks().AddCatEventProcessorHealthCheck();

        return true;
    }

    /// <summary>
    /// Creates the subscription of Notifications on the topic of every message it receives. It skips what exists.
    /// The topics come from Orders and Inventory, which create them at their own startup. Call this in development only.
    /// </summary>
    public static async Task InitializeNotificationEventProcessorAsync(this IServiceProvider services, CancellationToken cancellationToken = default)
    {
        var topology = services.GetService<ICatEventProcessorTopology>();
        if (topology is null)
        {
            return;
        }

        await topology.EnsureSubscriptionsAsync(cancellationToken);
    }
}

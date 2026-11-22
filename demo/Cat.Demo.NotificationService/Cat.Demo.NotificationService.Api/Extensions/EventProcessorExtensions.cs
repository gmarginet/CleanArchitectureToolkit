using System;
using System.Threading;
using System.Threading.Tasks;
using Cat.Demo.InventoryService.Contracts.Messages;
using Cat.Demo.OrderService.Contracts.Messages;
using Cat.EventProcessor.Abstractions;
using Cat.EventProcessor.Authorization.Extensions;
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
    /// The AppHost gives Notifications the connection string <c>messaging</c> of the Service Bus emulator.
    /// </summary>
    public static void AddCatDemoNotificationEventProcessor(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("messaging")
            ?? throw new InvalidOperationException("The connection string messaging is missing. Start the demo with the AppHost.");

        services.AddCatMessagingModule();
        services.AddCatMessagingAzureServiceBus(options =>
        {
            options.ConnectionString = connectionString;
            options.AdministrationConnectionString = configuration["Messaging:AdministrationConnectionString"] ?? string.Empty;
        });

        // A message needs a valid token of a logged in caller. Notifications sends no messages, so it needs no token of its own.
        services.AddCatEventProcessor(configuration, processor => processor
            .Receive<OrderConfirmed>(RequireLogin)
            .Receive<LowStockReport>(RequireLogin)
            .Receive<StockChanged>(RequireLogin)
            // A mail is built in the language of the message. A mail to the admin sets its own language, see AdminCulture.
            .ApplySenderCulture());
        services.AddCatEventProcessorAzureServiceBus(options => options.SubscriptionName = SubscriptionName);

        services.AddCatEventProcessorAuthorization();

        services.AddHealthChecks().AddCatEventProcessorHealthCheck();
    }

    private static void RequireLogin(CatReceiveOptions options) => options.Require(policy => policy.RequireAuthenticatedUser());

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

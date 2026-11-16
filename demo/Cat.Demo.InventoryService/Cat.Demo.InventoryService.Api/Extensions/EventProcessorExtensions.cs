using System;
using System.Threading;
using System.Threading.Tasks;
using Cat.Demo.InventoryService.Contracts.Messages;
using Cat.Demo.OrderService.Contracts.Messages;
using Cat.Demo.ServiceDefaults;
using Cat.EventProcessor.Authorization.Extensions;
using Cat.EventProcessor.AzureServiceBus;
using Cat.EventProcessor.AzureServiceBus.Extensions;
using Cat.EventProcessor.Extensions;
using Cat.Messaging.AzureServiceBus;
using Cat.Messaging.AzureServiceBus.Extensions;
using Cat.Messaging.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cat.Demo.InventoryService.Api.Extensions;

public static class EventProcessorExtensions
{
    /// <summary>
    /// The name Inventory uses on the topic of every message it receives.
    /// </summary>
    public const string SubscriptionName = "inventory";

    /// <summary>
    /// Declares the messages Inventory receives and starts the listener for them.
    /// It only works when the host gives Inventory the connection string <c>messaging</c> (Aspire does).
    /// Without it nothing is registered, so <c>dotnet run</c> keeps working on its own.
    /// </summary>
    /// <returns><c>true</c> when the listener is registered.</returns>
    public static bool AddCatDemoInventoryEventProcessor(this IServiceCollection services, IConfiguration configuration)
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

        // With an authority in the configuration (the AppHost sets it) a message needs a valid token of a logged in caller,
        // and a message of Inventory carries the client credentials token of Inventory. Without one, the messages run with no token.
        var authenticationOn = !string.IsNullOrWhiteSpace(configuration["Authentication:Authority"]);

        services.AddCatEventProcessor(configuration, processor => processor.Receive<OrderConfirmed>(options =>
        {
            if (authenticationOn)
            {
                options.Require(policy => policy.RequireAuthenticatedUser());
            }
        }));
        services.AddCatEventProcessorAzureServiceBus(options => options.SubscriptionName = SubscriptionName);

        if (authenticationOn)
        {
            services.AddDemoClientCredentials(configuration);
            services.AddDemoMessageTokens();
            services.AddCatEventProcessorAuthorization();
        }

        services.AddHealthChecks().AddCatEventProcessorHealthCheck();

        return true;
    }

    /// <summary>
    /// Creates the topic of every message in the contracts project of Inventory, which is the low stock report. It skips what exists.
    /// Call it in development only. The emulator forgets its entities at every restart, so Inventory creates them again at startup.
    /// </summary>
    public static async Task InitializeInventoryMessagingAsync(this IServiceProvider services, CancellationToken cancellationToken = default)
    {
        var topology = services.GetService<ICatServiceBusTopology>();
        if (topology is null)
        {
            return;
        }

        await topology.EnsureTopologyAsync([typeof(LowStockReport).Assembly], cancellationToken);
    }

    /// <summary>
    /// Creates the subscription of Inventory on the topic of every message it receives. It skips what exists.
    /// The topic comes from Orders, which creates it at its own startup. Call this in development only.
    /// </summary>
    public static async Task InitializeInventoryEventProcessorAsync(this IServiceProvider services, CancellationToken cancellationToken = default)
    {
        var topology = services.GetService<ICatEventProcessorTopology>();
        if (topology is null)
        {
            return;
        }

        await topology.EnsureSubscriptionsAsync(cancellationToken);
    }
}

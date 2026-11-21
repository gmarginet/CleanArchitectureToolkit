using System;
using System.Threading;
using System.Threading.Tasks;
using Cat.Demo.OrderService.Contracts.Messages;
using Cat.Demo.OrderService.CoreService.Messages;
using Cat.Demo.OrderService.Infrastructure.DataAccess;
using Cat.Messaging.Abstractions;
using Cat.Messaging.AzureServiceBus;
using Cat.Messaging.AzureServiceBus.Extensions;
using Cat.Messaging.Extensions;
using Cat.Outbox.EFCore.Extensions;
using Cat.Outbox.Extensions;
using Cat.Sagas;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cat.Demo.OrderService.Infrastructure.Extensions;

public static class OrderMessagingExtensions
{
    /// <summary>
    /// Registers messaging with the outbox in the order database. A message that a command handler publishes is saved
    /// with the order data and sent to the bus by a background service afterwards.
    /// The AppHost gives Orders the connection string <c>messaging</c> of the Service Bus emulator.
    /// </summary>
    public static IServiceCollection AddCatDemoOrderMessaging(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCatMessagingModule();

        var connectionString = configuration.GetConnectionString("messaging")
            ?? throw new InvalidOperationException("The connection string messaging is missing. Start the demo with the AppHost.");
        services.AddCatMessagingAzureServiceBus(options =>
        {
            options.ConnectionString = connectionString;
            options.AdministrationConnectionString = configuration["Messaging:AdministrationConnectionString"] ?? string.Empty;
        });
        services.AddCatOutboxEfCore<OrderDbContext>();
        services.AddCatOutbox(options => options.PollInterval = TimeSpan.FromSeconds(1));

        return services;
    }

    /// <summary>
    /// Creates the topic of every message in the contracts project of Orders. It skips what exists.
    /// Call it in development only. The emulator forgets its entities at every restart, so Orders creates them again at startup.
    /// </summary>
    public static async Task InitializeOrderMessagingAsync(this IServiceProvider services, CancellationToken cancellationToken = default)
    {
        var topology = services.GetService<ICatServiceBusTopology>();
        if (topology is null)
        {
            return;
        }

        // The saga module holds the timeout message. It is a command, so it gets a queue of Orders.
        // The core of Orders holds the four payment messages: two commands with a queue each, two events with a topic each.
        await topology.EnsureTopologyAsync(
            [typeof(OrderConfirmed).Assembly, typeof(CatSagaTimeout).Assembly, typeof(TakePayment).Assembly], cancellationToken);
    }
}

using System;
using System.Threading;
using System.Threading.Tasks;
using Cat.Demo.OrderService.Contracts.Messages;
using Cat.Demo.OrderService.Infrastructure.DataAccess;
using Cat.Demo.OrderService.Infrastructure.Fakes;
using Cat.Messaging.Abstractions;
using Cat.Messaging.AzureServiceBus;
using Cat.Messaging.AzureServiceBus.Extensions;
using Cat.Messaging.Extensions;
using Cat.Messaging.Outbox.EFCore.Extensions;
using Cat.Messaging.Outbox.Extensions;
using Cat.Sagas;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cat.Demo.OrderService.Infrastructure.Extensions;

public static class OrderMessagingExtensions
{
    /// <summary>
    /// Registers messaging with the outbox in the order database. A message that a command handler publishes is saved
    /// with the order data and sent to the bus by a background service afterwards.
    /// The bus is on when the host gives Orders the connection string <c>messaging</c> (Aspire does).
    /// Without it, <see cref="FakeMessageTransport"/> logs the messages, so <c>dotnet run</c> keeps working on its own.
    /// </summary>
    public static IServiceCollection AddCatDemoOrderMessaging(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCatMessagingModule();

        var connectionString = configuration.GetConnectionString("messaging");
        if (!string.IsNullOrWhiteSpace(connectionString))
        {
            services.AddCatMessagingAzureServiceBus(options =>
            {
                options.ConnectionString = connectionString;
                options.AdministrationConnectionString = configuration["Messaging:AdministrationConnectionString"] ?? string.Empty;
            });
            services.AddCatMessagingOutboxEfCore<OrderDbContext>();
            services.AddCatMessagingOutbox(options => options.PollInterval = TimeSpan.FromSeconds(1));
        }
        else
        {
            services.AddSingleton<ICatMessageTransport, FakeMessageTransport>();
        }

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
        await topology.EnsureTopologyAsync([typeof(OrderConfirmed).Assembly, typeof(CatSagaTimeout).Assembly], cancellationToken);
    }
}

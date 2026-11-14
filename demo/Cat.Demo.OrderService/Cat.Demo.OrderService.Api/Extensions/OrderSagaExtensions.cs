using System;
using System.Threading;
using System.Threading.Tasks;
using Cat.Demo.OrderService.CoreService.Workflows;
using Cat.Demo.OrderService.Infrastructure.DataAccess;
using Cat.Demo.PaymentService.Contracts.Messages;
using Cat.Demo.ServiceDefaults;
using Cat.EventProcessor.Authorization.Extensions;
using Cat.EventProcessor.AzureServiceBus;
using Cat.EventProcessor.AzureServiceBus.Extensions;
using Cat.EventProcessor.Extensions;
using Cat.EventProcessor.Inbox.EFCore.Extensions;
using Cat.Sagas;
using Cat.Sagas.EFCore.Extensions;
using Cat.Sagas.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cat.Demo.OrderService.Api.Extensions;

public static class OrderSagaExtensions
{
    /// <summary>
    /// The name Orders uses on the topic of every message it receives.
    /// </summary>
    public const string SubscriptionName = "orders";

    /// <summary>
    /// Registers the place order saga. The instances live in the order database, next to the orders.
    /// The settings of the workflow come from the section <c>Orders</c>: <c>PaymentTimeoutSeconds</c> is how long an order waits for Payment.
    /// </summary>
    /// <returns><c>true</c> when the listener for the answers is registered, which needs the connection string <c>messaging</c> (Aspire gives it).</returns>
    public static bool AddCatDemoOrderSagas(this IServiceCollection services, IConfiguration configuration)
    {
        var placeOrderOptions = new PlaceOrderOptions();
        var seconds = configuration.GetValue<int?>("Orders:PaymentTimeoutSeconds");
        if (seconds.HasValue)
        {
            placeOrderOptions.PaymentTimeout = TimeSpan.FromSeconds(seconds.Value);
        }

        services.AddSingleton(placeOrderOptions);

        services.AddCatSagasModule();
        services.AddCatSagasEFCore<OrderDbContext>();
        services.AddCatSaga<PlaceOrderWorkflow, PlaceOrderState>();
        services.AddCatSagaAnswer<PaymentProcessed>();

        var busOn = !string.IsNullOrWhiteSpace(configuration.GetConnectionString("messaging"));
        if (!busOn)
        {
            // Without the bus the order waits for an answer that never comes. The listener and the outbox need the bus.
            return false;
        }

        // The request goes into the outbox table and the instance is saved in the same transaction.
        services.AddCatSagasOutbox();

        // With an authority in the configuration (the AppHost sets it) a message needs a valid token of a logged in caller,
        // and a message of Orders carries the token of the user, or the client credentials token of Orders when there is no user request.
        var authenticationOn = !string.IsNullOrWhiteSpace(configuration["Authentication:Authority"]);

        services.AddCatEventProcessor(configuration, processor => processor
            .Receive<PaymentProcessed>(receive =>
            {
                receive.UseInbox = true;
                if (authenticationOn)
                {
                    receive.Require(policy => policy.RequireAuthenticatedUser());
                }
            })
            .Receive<CatSagaTimeout>(receive =>
            {
                if (authenticationOn)
                {
                    receive.Require(policy => policy.RequireAuthenticatedUser());
                }
            }));
        services.AddCatEventProcessorAzureServiceBus(options => options.SubscriptionName = SubscriptionName);
        services.AddCatEventProcessorInbox<OrderDbContext>();

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
    /// Creates the subscription of Orders on the topic of every message it receives. It skips what exists.
    /// The topic of <see cref="PaymentProcessed"/> comes from Payment, which creates it at its own startup. Call this in development only.
    /// </summary>
    public static async Task InitializeOrderEventProcessorAsync(this IServiceProvider services, CancellationToken cancellationToken = default)
    {
        var topology = services.GetService<ICatEventProcessorTopology>();
        if (topology is null)
        {
            return;
        }

        await topology.EnsureSubscriptionsAsync(cancellationToken);
    }
}

using System;
using System.Threading;
using System.Threading.Tasks;
using Cat.Demo.OrderService.CoreService.Workflows;
using Cat.Demo.OrderService.Infrastructure.DataAccess;
using Cat.Demo.OrderService.CoreService.Messages;
using Cat.Demo.ServiceDefaults;
using Cat.EventProcessor.Authorization.Extensions;
using Cat.EventProcessor.AzureServiceBus;
using Cat.EventProcessor.AzureServiceBus.Extensions;
using Cat.EventProcessor.Extensions;
using Cat.EventProcessor.Inbox.Extensions;
using Cat.Inbox.EFCore.Extensions;
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
    public static void AddCatDemoOrderSagas(this IServiceCollection services, IConfiguration configuration)
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

        // The request goes into the outbox table and the instance is saved in the same transaction.
        services.AddCatSagasOutbox();

        // A message needs a valid token of a logged in caller, and a message of Orders carries the token of the user,
        // or the client credentials token of Orders when there is no user request.
        services.AddCatEventProcessor(configuration, processor => processor
            .Receive<TakePayment>(receive =>
            {
                // The handler calls the payment provider and publishes the answer in the scope of the receiver,
                // so the answer and the inbox row are saved together.
                receive.UseInbox = true;
                receive.Require(policy => policy.RequireAuthenticatedUser());
            })
            .Receive<RefundPayment>(receive =>
            {
                receive.UseInbox = true;
                receive.Require(policy => policy.RequireAuthenticatedUser());
            })
            .Receive<PaymentProcessed>(receive =>
            {
                receive.UseInbox = true;
                receive.Require(policy => policy.RequireAuthenticatedUser());
            })
            .Receive<PaymentRefunded>(receive =>
            {
                // The handler runs its command in the scope of the receiver, so the inbox row is saved with the work.
                receive.UseInbox = true;
                receive.Require(policy => policy.RequireAuthenticatedUser());
            })
            .Receive<CatSagaTimeout>(receive => receive.Require(policy => policy.RequireAuthenticatedUser()))
            // The messages of a saga keep the language of the user who placed the order, so OrderConfirmed reaches Notifications in it.
            .ApplySenderCulture());
        services.AddCatEventProcessorAzureServiceBus(options => options.SubscriptionName = SubscriptionName);
        services.AddCatInboxEfCore<OrderDbContext>();
        services.AddCatEventProcessorInbox();

        services.AddDemoClientCredentials(configuration);
        services.AddDemoMessageTokens();
        services.AddCatEventProcessorAuthorization();

        services.AddHealthChecks().AddCatEventProcessorHealthCheck();
    }

    /// <summary>
    /// Creates the subscription of Orders on the topic of every message it receives. It skips what exists.
    /// Orders creates the topics of <see cref="PaymentProcessed"/> and <see cref="PaymentRefunded"/> itself, because the payment provider is outside.
    /// Call this in development only.
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

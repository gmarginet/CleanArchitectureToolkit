using Cat.Demo.PaymentService.Contracts.Messages;
using Cat.Demo.ServiceDefaults;
using Cat.EventProcessor.Authorization.Extensions;
using Cat.EventProcessor.AzureServiceBus;
using Cat.EventProcessor.AzureServiceBus.Extensions;
using Cat.EventProcessor.Extensions;
using Cat.Messaging.AzureServiceBus;
using Cat.Messaging.AzureServiceBus.Extensions;
using Cat.Messaging.Extensions;

namespace Cat.Demo.PaymentService.Api.Extensions;

public static class PaymentMessagingExtensions
{
    /// <summary>
    /// The name Payment uses on the topics it receives from. It receives a command only, which goes to a queue,
    /// so the name has no use yet. The event processor wants one anyway.
    /// </summary>
    public const string SubscriptionName = "payment";

    /// <summary>
    /// Declares the messages Payment receives and starts the listener for them, and registers the sender for its answer.
    /// It only works when the host gives Payment the connection string <c>messaging</c> (Aspire does).
    /// Without it nothing is registered, so <c>dotnet run</c> keeps working on its own, with the HTTP endpoint only.
    /// </summary>
    /// <returns><c>true</c> when the listener is registered.</returns>
    public static bool AddCatDemoPaymentMessaging(this IServiceCollection services, IConfiguration configuration)
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
        // and the answer carries the client credentials token of Payment. Without one, the messages run as before, with no token.
        var authenticationOn = !string.IsNullOrWhiteSpace(configuration["Authentication:Authority"]);

        services.AddCatEventProcessor(configuration, processor => processor.Receive<TakePayment>(options =>
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
    /// Creates the queue of <see cref="TakePayment"/> and the topic of <see cref="PaymentProcessed"/>. It skips what exists.
    /// Call it in development only. The emulator forgets its entities at every restart, so Payment creates them again at startup.
    /// Orders sends to the queue and subscribes to the topic, so Orders waits for Payment in the AppHost.
    /// </summary>
    public static async Task InitializePaymentMessagingAsync(this IServiceProvider services, CancellationToken cancellationToken = default)
    {
        var topology = services.GetService<ICatServiceBusTopology>();
        if (topology is null)
        {
            return;
        }

        await topology.EnsureTopologyAsync([typeof(TakePayment).Assembly], cancellationToken);
    }
}

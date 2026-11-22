using Cat.EventProcessor.AzureServiceBus;
using Cat.EventProcessor.AzureServiceBus.Extensions;
using Cat.EventProcessor.Extensions;
using Cat.EventProcessor.Inbox.Extensions;
using Cat.Inbox.EFCore.Extensions;
using Cat.Messaging.AzureServiceBus.Extensions;
using Cat.Messaging.Extensions;
using ServiceName.CoreService.Messages;
using ServiceName.Infrastructure.DataAccess;

namespace ServiceName.Api.Extensions;

public static class MessageHandlerExtensions
{
    /// <summary>The name the service uses on the topic of every message it receives.</summary>
    public const string SubscriptionName = "servicelower";

    /// <summary>
    /// Registers the connection to Azure Service Bus and the listener for the messages of the service.
    /// Every message type has the inbox on, so a message that arrives twice is handled once. The inbox table is in the database of the service.
    /// The connection string <c>messaging</c> comes from the configuration. The service does not start without it.
    /// </summary>
    public static IServiceCollection AddServiceShortMessageHandlers(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCatMessagingModule();

        var connectionString = configuration.GetConnectionString("messaging");
        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new InvalidOperationException("The connection string messaging is missing. Fill it in, see the readme.");
        }

        services.AddCatMessagingAzureServiceBus(options =>
        {
            options.ConnectionString = connectionString;
            options.AdministrationConnectionString = configuration["Messaging:AdministrationConnectionString"] ?? string.Empty;
        });

        services.AddCatEventProcessor(configuration, processor => processor
            .Receive<ExampleReceived>(receive => receive.UseInbox = true));
        services.AddCatEventProcessorAzureServiceBus(options => options.SubscriptionName = SubscriptionName);
        services.AddCatInboxEfCore<ServiceShortDbContext>();
        services.AddCatEventProcessorInbox();

        services.AddHealthChecks().AddCatEventProcessorHealthCheck();

        return services;
    }

    /// <summary>
    /// Creates the subscription of the service on the topic of every message it receives. It skips what exists.
    /// The topic itself belongs to the sender. Call this in development only.
    /// </summary>
    public static async Task InitializeServiceShortMessageHandlersAsync(this IServiceProvider services, CancellationToken cancellationToken = default)
    {
        var topology = services.GetService<ICatEventProcessorTopology>();
        if (topology is null)
        {
            return;
        }

        await topology.EnsureSubscriptionsAsync(cancellationToken);
    }
}

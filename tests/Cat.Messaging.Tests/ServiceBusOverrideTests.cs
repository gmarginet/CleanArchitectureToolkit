using Azure.Messaging.ServiceBus;
using Azure.Messaging.ServiceBus.Administration;
using Cat.Messaging.AzureServiceBus;
using Cat.Messaging.AzureServiceBus.Extensions;

namespace Cat.Messaging.Tests;

[TestFixture]
public class ServiceBusOverrideTests
{
    private const string FakeConnection = "Endpoint=sb://example.servicebus.windows.net/;SharedAccessKeyName=key;SharedAccessKey=c2VjcmV0";

    [Test]
    public async Task Client_WithoutCallback_KeepsTheDefaultsOfTheSdk()
    {
        await using var client = ServiceCollectionExtensions.CreateClient(new CatServiceBusOptions { ConnectionString = FakeConnection });

        Assert.That(client.FullyQualifiedNamespace, Is.EqualTo("example.servicebus.windows.net"));
    }

    [Test]
    public async Task Client_Callback_GetsTheDefaultsAndCanChangeThem()
    {
        ServiceBusClientOptions? seen = null;
        int? retriesBefore = null;
        var options = new CatServiceBusOptions
        {
            ConnectionString = FakeConnection,
            ConfigureClient = clientOptions =>
            {
                seen = clientOptions;
                retriesBefore = clientOptions.RetryOptions.MaxRetries;
                clientOptions.RetryOptions.MaxRetries = 7;
            }
        };

        await using var client = ServiceCollectionExtensions.CreateClient(options);

        Assert.That(seen, Is.Not.Null);
        Assert.That(retriesBefore, Is.EqualTo(new ServiceBusRetryOptions().MaxRetries));
        Assert.That(seen!.RetryOptions.MaxRetries, Is.EqualTo(7));
    }

    [Test]
    public void AdministrationClient_Callback_GetsTheDefaultsAndCanChangeThem()
    {
        ServiceBusAdministrationClientOptions? seen = null;
        int? retriesBefore = null;
        var options = new CatServiceBusOptions
        {
            ConnectionString = FakeConnection,
            ConfigureAdministrationClient = clientOptions =>
            {
                seen = clientOptions;
                retriesBefore = clientOptions.Retry.MaxRetries;
                clientOptions.Retry.MaxRetries = 7;
            }
        };

        var admin = ServiceCollectionExtensions.CreateAdministrationClient(options);

        Assert.That(admin, Is.Not.Null);
        Assert.That(seen, Is.Not.Null);
        Assert.That(retriesBefore, Is.EqualTo(new ServiceBusAdministrationClientOptions().Retry.MaxRetries));
        Assert.That(seen!.Retry.MaxRetries, Is.EqualTo(7));
    }

    [Test]
    public void Queue_WithoutCallback_KeepsTheDefaultsOfTheSdk()
    {
        var defaults = new CreateQueueOptions("x");

        var options = ServiceBusTopology.BuildQueueOptions("ReserveStock", requiresSession: false);

        Assert.That(options.MaxDeliveryCount, Is.EqualTo(defaults.MaxDeliveryCount));
        Assert.That(options.LockDuration, Is.EqualTo(defaults.LockDuration));
        Assert.That(options.DefaultMessageTimeToLive, Is.EqualTo(defaults.DefaultMessageTimeToLive));
    }

    [Test]
    public void Queue_Callback_CanChangeAnOption()
    {
        var options = ServiceBusTopology.BuildQueueOptions("ReserveStock", requiresSession: false,
            queue => queue.MaxDeliveryCount = 3);

        Assert.That(options.MaxDeliveryCount, Is.EqualTo(3));
    }

    [Test]
    public void Queue_Callback_CanTurnDuplicateDetectionOff()
    {
        var options = ServiceBusTopology.BuildQueueOptions("ReserveStock", requiresSession: false,
            queue => queue.RequiresDuplicateDetection = false);

        Assert.That(options.RequiresDuplicateDetection, Is.False);
    }

    [Test]
    public void Queue_Callback_CannotChangeTheSessionSetting()
    {
        var withSessions = ServiceBusTopology.BuildQueueOptions("emu-session", requiresSession: true,
            queue => queue.RequiresSession = false);
        var withoutSessions = ServiceBusTopology.BuildQueueOptions("ReserveStock", requiresSession: false,
            queue => queue.RequiresSession = true);

        Assert.That(withSessions.RequiresSession, Is.True);
        Assert.That(withoutSessions.RequiresSession, Is.False);
    }

    [Test]
    public void Topic_Callback_CanChangeAnOptionAndTurnDuplicateDetectionOff()
    {
        var options = ServiceBusTopology.BuildTopicOptions("OrderPlaced", topic =>
        {
            topic.DefaultMessageTimeToLive = TimeSpan.FromHours(1);
            topic.RequiresDuplicateDetection = false;
        });

        Assert.That(options.DefaultMessageTimeToLive, Is.EqualTo(TimeSpan.FromHours(1)));
        Assert.That(options.RequiresDuplicateDetection, Is.False);
    }
}

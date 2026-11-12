using System.Diagnostics.Metrics;
using Azure.Messaging.ServiceBus;
using Azure.Messaging.ServiceBus.Administration;
using Cat.Messaging.Abstractions;
using Cat.Messaging.AzureServiceBus;
using Cat.Messaging.AzureServiceBus.Extensions;
using Cat.Messaging.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;

namespace Cat.Messaging.Tests;

[CatMessage(Name = "emu-command")]
public class EmulatorCommand : CatCommandMessage
{
    public string Text { get; set; } = string.Empty;
}

[CatMessage(Name = "emu-event")]
public class EmulatorEvent : CatEventMessage
{
    public string Text { get; set; } = string.Empty;
}

[CatMessage(Name = "emu-session", RequiresSession = true)]
public class EmulatorSessionCommand : CatCommandMessage, ICatSessionMessage
{
    public string SessionId { get; set; } = string.Empty;
}

/// <summary>
/// Tests of the Azure Service Bus project against the Service Bus emulator of the demo AppHost.
/// They are explicit, so the normal test run and the build workflow skip them. Start the AppHost, then run:
/// <c>dotnet test tests/Cat.Messaging.Tests --filter "TestCategory=Emulator"</c>
/// </summary>
[TestFixture]
[Explicit("Needs the Service Bus emulator of the demo AppHost")]
[Category("Emulator")]
public class EmulatorTests
{
    private const string Connection = "Endpoint=sb://localhost:5672;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=SAS_KEY_VALUE;UseDevelopmentEmulator=true;";
    private const string AdministrationConnection = "Endpoint=sb://localhost:5300;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=SAS_KEY_VALUE;UseDevelopmentEmulator=true;";
    private const string Command = "emu-command";
    private const string Event = "emu-event";
    private const string Session = "emu-session";
    private const string Subscription = "emu-sub";

    private ServiceProvider _provider = null!;
    private ServiceBusClient _client = null!;
    private ServiceBusAdministrationClient _admin = null!;

    [OneTimeSetUp]
    public async Task OneTimeSetUp()
    {
        var services = new ServiceCollection();
        services.AddCatMessagingModule();
        services.AddCatMessagingAzureServiceBus(options =>
        {
            options.ConnectionString = Connection;
            options.AdministrationConnectionString = AdministrationConnection;
        });
        _provider = services.BuildServiceProvider();
        _client = _provider.GetRequiredService<ServiceBusClient>();
        _admin = _provider.GetRequiredService<ServiceBusAdministrationClient>();

        try
        {
            using var probe = new CancellationTokenSource(TimeSpan.FromSeconds(10));
            await _admin.QueueExistsAsync(Command, probe.Token);
        }
        catch (Exception exception)
        {
            Assert.Ignore($"The Service Bus emulator is not reachable on localhost:5300. Start the AppHost first. {exception.Message}");
        }
    }

    [OneTimeTearDown]
    public async Task OneTimeTearDown()
    {
        if (_client is not null)
        {
            await _client.DisposeAsync();
        }

        if (_provider is not null)
        {
            await _provider.DisposeAsync();
        }
    }

    /// <summary>
    /// Starts every test with fresh entities that the topology helper creates, so the options are the real ones.
    /// </summary>
    [SetUp]
    public async Task SetUp()
    {
        foreach (var queue in new[] { Command, Session })
        {
            if (await _admin.QueueExistsAsync(queue))
            {
                await _admin.DeleteQueueAsync(queue);
            }
        }

        if (await _admin.TopicExistsAsync(Event))
        {
            await _admin.DeleteTopicAsync(Event);
        }

        var topology = _provider.GetRequiredService<ICatServiceBusTopology>();
        await topology.EnsureTopologyAsync([typeof(EmulatorTests).Assembly]);
        await _admin.CreateSubscriptionAsync(new CreateSubscriptionOptions(Event, Subscription));
    }

    [Test, CancelAfter(120_000)]
    public async Task DeadLetter_AMessageThatKeepsFailing_ReachesTheDeadLetterQueue()
    {
        await SendCommandAsync("fails");

        await using var receiver = _client.CreateReceiver(Command);
        var deliveries = 0;
        while (deliveries < 12)
        {
            var message = await receiver.ReceiveMessageAsync(TimeSpan.FromSeconds(5));
            if (message is null)
            {
                break;
            }

            deliveries++;
            await receiver.AbandonMessageAsync(message);
        }

        await using var deadLetters = _client.CreateReceiver(Command, new ServiceBusReceiverOptions { SubQueue = SubQueue.DeadLetter });
        var dead = await deadLetters.ReceiveMessageAsync(TimeSpan.FromSeconds(10));

        Assert.That(deliveries, Is.EqualTo(10), "The bus delivers a message MaxDeliveryCount times and then dead letters it.");
        Assert.That(dead, Is.Not.Null);
        Assert.That(dead!.DeadLetterReason, Is.EqualTo("MaxDeliveryCountExceeded"));
    }

    [Test, CancelAfter(120_000)]
    public async Task Session_AQueueThatRequiresSessions_DeliversTheMessageToTheSession()
    {
        var properties = await _admin.GetQueueAsync(Session);
        var sender = _provider.CreateScope().ServiceProvider.GetRequiredService<ICatMessageSender>();

        await sender.SendAsync(new EmulatorSessionCommand { SessionId = "order-7" });

        await using var session = await _client.AcceptSessionAsync(Session, "order-7", cancellationToken: new CancellationTokenSource(TimeSpan.FromSeconds(30)).Token);
        var message = await session.ReceiveMessageAsync(TimeSpan.FromSeconds(10));

        Assert.That(properties.Value.RequiresSession, Is.True);
        Assert.That(message, Is.Not.Null);
        Assert.That(message!.SessionId, Is.EqualTo("order-7"));
        Assert.That(session.SessionId, Is.EqualTo("order-7"));
    }

    [Test, CancelAfter(120_000)]
    public async Task Scheduled_AMessageWithAScheduledTime_IsDeliveredAtThatMoment()
    {
        var at = DateTimeOffset.UtcNow.AddSeconds(10);
        await SendCommandAsync("later", at);

        await using var receiver = _client.CreateReceiver(Command);
        var early = await receiver.ReceiveMessageAsync(TimeSpan.FromSeconds(3));
        var onTime = await receiver.ReceiveMessageAsync(TimeSpan.FromSeconds(20));
        var receivedAt = DateTimeOffset.UtcNow;

        Assert.That(early, Is.Null, "The message must not arrive before its time.");
        Assert.That(onTime, Is.Not.Null);
        Assert.That(receivedAt, Is.GreaterThanOrEqualTo(at.AddSeconds(-1)));
        Assert.That(onTime!.ScheduledEnqueueTime, Is.EqualTo(at).Within(TimeSpan.FromSeconds(1)));
    }

    [Test, CancelAfter(120_000)]
    public async Task Metric_ReadsTheDeadLetterCountsOfAQueueAndOfASubscription()
    {
        await SendCommandAsync("dead");
        await using (var receiver = _client.CreateReceiver(Command))
        {
            var message = await receiver.ReceiveMessageAsync(TimeSpan.FromSeconds(10));
            await receiver.DeadLetterMessageAsync(message!, "test", "dead lettered by the test");
        }

        var sender = _provider.CreateScope().ServiceProvider.GetRequiredService<ICatMessageSender>();
        await sender.PublishAsync(new EmulatorEvent { Text = "dead" });
        await using (var receiver = _client.CreateReceiver(Event, Subscription))
        {
            var message = await receiver.ReceiveMessageAsync(TimeSpan.FromSeconds(10));
            await receiver.DeadLetterMessageAsync(message!, "test", "dead lettered by the test");
        }

        var options = new CatDeadLetterMetricsOptions { PollInterval = TimeSpan.FromSeconds(1) };
        options.Queues.Add(Command);
        options.Subscriptions.Add(new CatDeadLetterSubscription(Event, Subscription));
        using var service = new DeadLetterMetricsService(_admin, Options.Create(options), NullLogger<DeadLetterMetricsService>.Instance);

        var counts = new Dictionary<string, long>();
        using var listener = new MeterListener();
        listener.InstrumentPublished = (instrument, meterListener) =>
        {
            if (instrument.Meter.Name == DeadLetterMetricsService.MeterName)
            {
                meterListener.EnableMeasurementEvents(instrument);
            }
        };
        listener.SetMeasurementEventCallback<long>((_, value, tags, _) =>
        {
            foreach (var tag in tags)
            {
                if (tag.Key == "entity")
                {
                    counts[tag.Value!.ToString()!] = value;
                }
            }
        });
        listener.Start();

        await service.StartAsync(CancellationToken.None);
        for (var attempt = 0; attempt < 20 && counts.Count < 2; attempt++)
        {
            await Task.Delay(TimeSpan.FromSeconds(1));
            listener.RecordObservableInstruments();
        }

        await service.StopAsync(CancellationToken.None);

        Assert.That(counts.Keys, Is.EquivalentTo(new[] { $"queue:{Command}", $"subscription:{Event}/{Subscription}" }),
            "The metric must read the queue and the subscription.");

        // The emulator reports 0 for every message count, also when the dead letter queue holds a message.
        // The values can only be checked against a real namespace.
        Assume.That(counts[$"queue:{Command}"], Is.Not.Zero, "The emulator reports no message counts.");
        Assert.That(counts[$"queue:{Command}"], Is.EqualTo(1));
        Assert.That(counts[$"subscription:{Event}/{Subscription}"], Is.EqualTo(1));
    }

    [Test, CancelAfter(120_000)]
    public async Task DuplicateDetection_TheSameMessageIdSentTwice_ReachesAQueueOnce()
    {
        var properties = await _admin.GetQueueAsync(Command);
        var sender = _provider.CreateScope().ServiceProvider.GetRequiredService<ICatMessageSender>();
        var message = new EmulatorCommand { Text = "twice" };

        await sender.SendAsync(message);
        await sender.SendAsync(message);

        await using var receiver = _client.CreateReceiver(Command);
        var first = await receiver.ReceiveMessageAsync(TimeSpan.FromSeconds(10));
        var second = await receiver.ReceiveMessageAsync(TimeSpan.FromSeconds(5));

        Assert.That(properties.Value.RequiresDuplicateDetection, Is.True);
        Assert.That(first, Is.Not.Null);
        Assert.That(second, Is.Null, "The bus must drop the second message with the same MessageId.");
    }

    [Test, CancelAfter(120_000)]
    public async Task DuplicateDetection_TheSameMessageIdSentTwice_ReachesATopicSubscriptionOnce()
    {
        var properties = await _admin.GetTopicAsync(Event);
        var sender = _provider.CreateScope().ServiceProvider.GetRequiredService<ICatMessageSender>();
        var message = new EmulatorEvent { Text = "twice" };

        await sender.PublishAsync(message);
        await sender.PublishAsync(message);

        await using var receiver = _client.CreateReceiver(Event, Subscription);
        var first = await receiver.ReceiveMessageAsync(TimeSpan.FromSeconds(10));
        var second = await receiver.ReceiveMessageAsync(TimeSpan.FromSeconds(5));

        Assert.That(properties.Value.RequiresDuplicateDetection, Is.True);
        Assert.That(first, Is.Not.Null);
        Assert.That(second, Is.Null, "The bus must drop the second message with the same MessageId.");
    }

    private async Task SendCommandAsync(string text, DateTimeOffset? scheduledAt = null)
    {
        var sender = _provider.CreateScope().ServiceProvider.GetRequiredService<ICatMessageSender>();
        await sender.SendAsync(new EmulatorCommand { Text = text }, scheduledAt);
    }
}

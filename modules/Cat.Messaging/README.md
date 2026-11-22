<!-- region start: Header-->
<!-- Header template: @.claude\skills\cat-internal-create-header\header.template.md, RootPath: ../.. -->
<link href="../../resources/styles/style.css" rel="stylesheet" />
<table>
    <tr>
        <td colspan='6' style='text-align: center; font-weight: bold; border: none; border-top: 1px dashed #494949; border-bottom: 1px dashed #494949;'>
             Clean Architecture Toolkit for .NET
        </td>
    </tr>
    <tr>
        <td colspan='5' style='padding: 0; vertical-align: middle; border: none;'>
            Clean Architecture Toolkit is a clean, modular architecture foundation for .NET applications.<br>
            It embraces SOLID principles and focuses on maintainability, testability, and scalability through clear boundaries and pluggable design.</td>
        <td style='padding: 0; border: none;' width='220'>
            <img src='../../resources/logo/CatLogo.svg' alt='' width='200' style='padding: 15px; float: right; background: #121314; border-radius: 10px'/>
        </td>
    </tr>
    <tr>
        <td colspan='6' markdown='1' style='padding-left: 0; padding-right: 0; padding-top: 15px; padding-bottom: 0; border: none; border-top: 1px dashed #494949; border-bottom: 1px dashed #494949;'>

&#124;&nbsp;&nbsp;&nbsp;[HOME](../../README.md)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[REPO OVERVIEW](../../README.md#repo-overview)&nbsp;&nbsp;&nbsp;&#124;&nbsp;&nbsp;&nbsp;[DEMO](../../demo/README.md)&nbsp;&nbsp;&nbsp;&#124;

</td>
</tr>
</table>
<!-- region end: Header-->

<!-- region start: TemplateSkill-->
<!-- Use the cat-internal-create-module-readme skill to update this readme.-->
<!-- region end: TemplateSkill-->

# Cat.Messaging <!-- omit in toc -->  

<!-- region start: Intro-->
Cat.Messaging sends messages to other services over a message bus. You declare a message as a plain type, hand it to the sender, and the module picks the queue or topic, serializes the message and sends it. Azure Service Bus is the first broker. Every broker gets its own project, so another one can be added later.

There are two kinds of messages. An event says something happened, such as `OrderPlaced`. It goes to a topic, and every service that subscribes gets a copy. A command message says do this, such as `ReserveStock`. It goes to a queue and one receiver handles it.

The outbox is optional. With it, a message is saved in the same `SaveChanges` as your data, and a background service sends it afterwards, so a crash cannot lose it. The receiving side is not part of this module.  
<!-- region end: Intro-->

## Table of contents <!-- omit in toc -->  
- [NuGet packages](#nuget-packages)
- [Namespaces](#namespaces)
- [Dependencies](#dependencies)
- [Usage](#usage)
  - [Declare a message](#declare-a-message)
  - [Register the module](#register-the-module)
  - [Send a message](#send-a-message)
  - [Send the token of the caller](#send-the-token-of-the-caller)
  - [Send the culture of the caller](#send-the-culture-of-the-caller)
  - [Send work that has no user](#send-work-that-has-no-user)
  - [Names and sessions](#names-and-sessions)
  - [Create the queues and topics](#create-the-queues-and-topics)
  - [Change the options of Azure Service Bus](#change-the-options-of-azure-service-bus)
  - [Use the outbox](#use-the-outbox)
  - [Watch the dead letters](#watch-the-dead-letters)
  - [Where to publish from](#where-to-publish-from)
  - [The emulator](#the-emulator)

## NuGet packages  
<!-- region start: NuGet-->
[![NuGet Version](https://img.shields.io/nuget/vpre/gmarginet.Cat.Messaging)](#nuget-packages)

| Package | Role | Targets | Install | Downloads |
|---------|------|---------|---------|-----------|
| [Cat.Messaging.Abstractions](https://www.nuget.org/packages/gmarginet.Cat.Messaging.Abstractions/) | Contracts | netstandard2.0 | `dotnet add package gmarginet.Cat.Messaging.Abstractions` | [![NuGet Downloads](https://img.shields.io/nuget/dt/gmarginet.Cat.Messaging.Abstractions)](https://www.nuget.org/packages/gmarginet.Cat.Messaging.Abstractions/) |
| [Cat.Messaging](https://www.nuget.org/packages/gmarginet.Cat.Messaging/) | Implementation | netstandard2.0 | `dotnet add package gmarginet.Cat.Messaging` | [![NuGet Downloads](https://img.shields.io/nuget/dt/gmarginet.Cat.Messaging)](https://www.nuget.org/packages/gmarginet.Cat.Messaging/) |
| [Cat.Messaging.AzureServiceBus](https://www.nuget.org/packages/gmarginet.Cat.Messaging.AzureServiceBus/) | Azure Service Bus transport | netstandard2.0 | `dotnet add package gmarginet.Cat.Messaging.AzureServiceBus` | [![NuGet Downloads](https://img.shields.io/nuget/dt/gmarginet.Cat.Messaging.AzureServiceBus)](https://www.nuget.org/packages/gmarginet.Cat.Messaging.AzureServiceBus/) |

<!-- region end: NuGet-->

## Namespaces
<!-- region start: Namespaces-->

| Namespace | What it holds |
|-----------|---------------|
| [Cat.Messaging.Abstractions](namespaces/Cat.Messaging.Abstractions/index.md) | The message base types, the sender, the token provider, the name convention and the transport seam. |
| [Cat.Messaging](namespaces/Cat.Messaging/index.md) | The sender, the name convention, the JSON serializer and the module registration. |
| [Cat.Messaging.AzureServiceBus](namespaces/Cat.Messaging.AzureServiceBus/index.md) | The Azure Service Bus transport, the topology helper and the dead letter metric. |

<!-- region end: Namespaces-->

## Dependencies
<!-- region start: Dependencies-->
Cat.Messaging has no dependencies on other CAT modules.  
<!-- region end: Dependencies-->

## Usage
<!-- region start: Usage-->
### Declare a message

A message lives in the `Contracts` project of the service that sends it. A service that receives the message references that `Contracts` project. The `Contracts` project references only `Cat.Messaging.Abstractions`.

Inherit `CatEventMessage` for an event and `CatCommandMessage` for a command message:

```csharp
using Cat.Messaging.Abstractions;

public class OrderPlaced : CatEventMessage
{
    public Guid OrderId { get; set; }
    public string OrderNumber { get; set; } = string.Empty;
}

public class ReserveStock : CatCommandMessage
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}
```

A new message gets a `MessageId`, a `CorrelationId` and `OccurredAt` for you. The `MessageId` is copied to the message ID of the bus, which duplicate detection uses. The `CorrelationId` follows a business flow through the logs of several services. When a message is sent because of another message, copy the `CorrelationId` of that message to it.

A type that already inherits from something else implements `ICatEventMessage` or `ICatCommandMessage` instead.

### Register the module

Register the module, a transport, and nothing else:

```csharp
using Cat.Messaging.AzureServiceBus.Extensions;
using Cat.Messaging.Extensions;

builder.Services.AddCatMessagingModule();
builder.Services.AddCatMessagingAzureServiceBus(options =>
    options.ConnectionString = builder.Configuration.GetConnectionString("servicebus")!);
```

The module serializes with System.Text.Json and sets the content type to `application/json`. It does not support another serializer.

### Send a message

Inject `ICatMessageSender`. Use `PublishAsync` for an event and `SendAsync` for a command message:

```csharp
public class OrderPlaceCommandHandler : ICatCommandHandler<OrderPlaceCommand>
{
    private readonly ICatMessageSender _sender;

    public OrderPlaceCommandHandler(ICatMessageSender sender)
    {
        _sender = sender;
    }

    public async Task<ICatResponse> HandleAsync(OrderPlaceCommand command, CancellationToken cancellationToken = default)
    {
        // Save the order, then tell the other services.
        await _sender.PublishAsync(new OrderPlaced { OrderId = command.OrderId }, cancellationToken: cancellationToken);

        return CatResponse.Ok();
    }
}
```

Both methods take an optional `scheduledAt`. The bus then holds the message until that moment, which is how you do a timeout such as "the payment expires after 24 hours":

```csharp
await _sender.SendAsync(new PaymentExpired { OrderId = orderId }, DateTimeOffset.UtcNow.AddHours(24), cancellationToken);
```

### Send the token of the caller

A message can carry the token of its sender, so the receiver knows who sent the work. Implement `ICatTokenProvider` in the host and register it. The sender calls it for every message and puts the result in the message property `Authorization`, as `Bearer <token>`. Without a provider a message carries no token.

```csharp
public class RequestTokenProvider(IHttpContextAccessor accessor, ISystemTokenSource system) : ICatTokenProvider
{
    public async Task<string?> GetTokenAsync(CatTokenSubject subject, CancellationToken cancellationToken = default)
    {
        if (subject == CatTokenSubject.System)
        {
            return await system.GetTokenAsync(cancellationToken);
        }

        var header = accessor.HttpContext?.Request.Headers.Authorization.ToString();
        return header?.StartsWith("Bearer ") == true ? header["Bearer ".Length..] : null;
    }
}
```

A message with a scheduled time asks for `CatTokenSubject.System`, because a token of a user is expired when the bus delivers the message. The system token must be one that the receiving service accepts. The receiver skips the lifetime check for a scheduled message, see `Cat.EventProcessor`. The sender passes what the handler needs in the message, because the user is not known there. The token stays in the message, so it is in the queue and in the outbox table. Use short lived tokens.

### Send the culture of the caller

Every message carries the culture of its sender in the message property `Culture`, such as `nl-BE`. The sender takes it from `CultureInfo.CurrentUICulture` at the moment of the send, and writes nothing for the invariant culture. There is no setting. A message sent from a request gets the culture of the request, a message sent from a handler gets the culture the listener set, and a message sent from a job gets the default culture of the service. The outbox keeps the property with the message. The receiver decides what to do with it, see the module readme of `Cat.EventProcessor`.

### Send work that has no user

A webhook arrives without a user. The endpoint checks the signature and wants to hand the work off as a message, so it can answer the provider at once. Inject `ICatSystemMessageSender` there. It has `SendAsync` and `PublishAsync` like `ICatMessageSender`, and it always asks `ICatTokenProvider` for `CatTokenSubject.System`, also when the message is not scheduled.

```csharp
app.MapPost("/webhooks/payment", async (PaymentWebhook webhook, ICatSystemMessageSender sender, CancellationToken cancellationToken) =>
{
    await sender.SendAsync(new SettlePayment { Reference = webhook.Reference }, cancellationToken: cancellationToken);
    return Results.Accepted();
});
```

What to know:
- **On purpose.** Running as the system is never a default. `ICatMessageSender` keeps asking for the current user. Only the code that injects `ICatSystemMessageSender` sends as the system, so a handler that runs for a user cannot do it by accident, and a search for the type finds every place that does.
- **A provider is needed.** Without a registered `ICatTokenProvider` the sender throws, because the message would go out as the anonymous user.
- **The receiver decides.** The receiver checks the policy of the message type against the system token, as for a scheduled message. A system token on a message that is not scheduled gets the normal lifetime check, so the system token must be fresh when the bus delivers the message.
### Names and sessions

By convention the queue, the topic and the subject use the name of the message type. Override that with `CatMessageAttribute`:

```csharp
[CatMessage(Name = "payment-expired")]
public class PaymentExpired : CatCommandMessage
{
    public Guid OrderId { get; set; }
}
```

Sessions are off by default. A queue with sessions handles the messages of one session in order, one receiver at a time. Turn them on with `RequiresSession` and implement `ICatSessionMessage` to say which session a message belongs to:

```csharp
[CatMessage(RequiresSession = true)]
public class ShipmentStep : CatCommandMessage, ICatSessionMessage
{
    public string SessionId { get; set; } = string.Empty;
}
```

### Create the queues and topics

Nothing is created when a service starts. A queue or topic that does not exist makes the send fail. You create them yourself, and the module has an easy way:

```csharp
var topology = app.Services.GetRequiredService<ICatServiceBusTopology>();
var created = await topology.EnsureTopologyAsync([typeof(OrderPlaced).Assembly]);
```

It makes a queue for every command message and a topic for every event in the assemblies, and it skips what exists. Duplicate detection is on for every queue and topic it creates, so the bus drops a repeated message with the same `MessageId` inside the time window. That helps when the outbox sends a row twice. The window keeps the default of Azure Service Bus, 10 minutes. It is a setting of the entity, made when it is created, so an entity that exists already keeps its own setting. The administration client uses `AdministrationConnectionString` when you set it, and `ConnectionString` otherwise. The emulator needs the first one, because it answers management calls on port 5300 and messages on another port. Call it from a deployment step, a small tool or a test. It needs the manage right on the namespace, so most production services should not run it. A subscription belongs to the service that receives the message, so this method does not create subscriptions.

You can also create the entities with a script. A sample with the Azure CLI:

```powershell
az servicebus queue create --resource-group <group> --namespace-name <namespace> --name ReserveStock --enable-duplicate-detection true
az servicebus topic create --resource-group <group> --namespace-name <namespace> --name OrderPlaced --enable-duplicate-detection true
az servicebus topic subscription create --resource-group <group> --namespace-name <namespace> --topic-name OrderPlaced --name Inventory
```

Add `--enable-session true` to the queue command for a queue with sessions.

### Change the options of Azure Service Bus

The module starts from the defaults of Azure Service Bus and sets only what it needs. You can change any other option with a callback on `CatServiceBusOptions`. The module builds the SDK options with its own values first, and then calls your callback, so your callback wins.

| Callback | Changes | When it runs |
|---|---|---|
| `ConfigureClient` | `ServiceBusClientOptions` | When the client is created. |
| `ConfigureAdministrationClient` | `ServiceBusAdministrationClientOptions` | When the administration client is created. |
| `ConfigureQueue` | `CreateQueueOptions` | For every queue that `EnsureTopologyAsync` creates. |
| `ConfigureTopic` | `CreateTopicOptions` | For every topic that `EnsureTopologyAsync` creates. |

```csharp
builder.Services.AddCatMessagingAzureServiceBus(options =>
{
    options.ConnectionString = builder.Configuration.GetConnectionString("servicebus")!;
    options.ConfigureClient = client => client.RetryOptions.MaxRetries = 5;
    options.ConfigureQueue = queue => queue.MaxDeliveryCount = 5;
});
```

Things to know:
- **The module sets little.** On a queue it sets duplicate detection and `RequiresSession`, on a topic it sets duplicate detection, and on the clients it sets nothing. Your callback can turn duplicate detection off.
- **The message type decides sessions.** The module sets `RequiresSession` on a queue after your callback runs, so a callback cannot break how sessions work.
- **The retry options of the client are not a redelivery delay.** They cover failed calls to the bus, such as a timeout or a busy namespace. The SDK defaults are 3 retries, exponential back-off, a base delay of 0.8 seconds and a maximum delay of 60 seconds. A message that fails in a receiver still comes back at once, see [Watch the dead letters](#watch-the-dead-letters).
- **The event processor has its own callbacks.** The subscriptions and the processors belong to the service that receives the message, so their callbacks are in the module readme of `Cat.EventProcessor`.

### Use the outbox

Without the outbox, a message is sent at once, and a crash between saving the data and sending the message loses it. The outbox of the module `Cat.Outbox` closes that gap. It plugs into the sender through `ICatOutgoingMessageSink`, so your code does not change. `Cat.Messaging` never references it. See the [module readme of Cat.Outbox](../Cat.Outbox/README.md#turn-the-outbox-on).

### Watch the dead letters

A message that keeps failing goes to the dead letter queue. The defaults of Azure Service Bus apply. The bus has no setting for a delay between two deliveries. A message that fails comes back at once, until it has been delivered `MaxDeliveryCount` times (10 by default) and then goes to the dead letter queue. A receiver that needs a pause must add it itself. Looking at the dead letter queue is the job of whoever runs the service. The module can publish a metric that helps. It is off by default, because reading the counts needs the manage right on the namespace.

```csharp
using Cat.Messaging.AzureServiceBus.Extensions;

builder.Services.AddCatDeadLetterMetric(options =>
{
    options.Queues.Add("ReserveStock");
    options.Subscriptions.Add(new CatDeadLetterSubscription("OrderPlaced", "Inventory"));
});
```

The metric is the gauge `cat.messaging.dead_letters` on the meter `Cat.Messaging`, with the tag `entity`. Any dashboard that listens to the meter shows it, such as the Aspire dashboard, without Aspire code in the module.

### Where to publish from

Publish from the command handler. It saves the data and sends the message in one place, and with the outbox the two are one unit.

A service request handler may publish too. It is not recommended.

An event subscriber of `Cat.EventAggregators` can also bridge an in-process event to the bus. Use it when you do not need the guarantee of the outbox. The outbox row is only safe when the subscriber runs inside the same unit of work as the command handler.

### The emulator

The Azure Service Bus emulator works for local development, with limits. It does not support partitioned entities, and it supports AMQP over TCP only. Entities and data are gone after a restart of the container. The settings in its `config.json` override entities that were created with the administration client at startup. The limits are 50 queues and topics per namespace and 50 subscriptions per topic.

The Azure project has tests that run against the emulator, in `tests/Cat.Messaging.Tests/EmulatorTests.cs`. They are explicit, so the normal test run and the build workflow skip them. Start the demo AppHost, then run:

```powershell
dotnet test tests/Cat.Messaging.Tests --filter "TestCategory=Emulator"
```

What they show:
- A message that keeps failing is dead lettered with the reason `MaxDeliveryCountExceeded`, after 10 deliveries by default.
- A queue that requires sessions delivers a message to its session.
- A message with a scheduled time arrives at that moment, and not before.
- A message with the same `MessageId` that is sent twice reaches a queue once, and a topic subscription once.

The emulator reports 0 for every message count, also when the dead letter queue holds a message. So the dead letter metric shows 0 against the emulator, and the test that checks the values is skipped there. Check the metric against a real namespace.
<!-- region end: Usage-->

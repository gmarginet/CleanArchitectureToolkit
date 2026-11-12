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

# Cat.EventProcessor <!-- omit in toc -->  

<!-- region start: Intro-->
Cat.EventProcessor is the receiving side of the messaging modules. Not all work comes in over HTTP. A message on the bus is work that starts on its own. The module listens to the bus and turns every incoming message into a service request that your core handles. The worker holds no business logic.

The message is the service request. There is no mapping step. You write one `ICatServiceRequestHandler` for the message type, like for any other service request, and the decorators of `Cat.ServiceRequests` (logging, validation, tracing) work for it too.

The module settles every message for you. A handler that succeeds completes the message. A failure that will not change dead letters it, and a failure that may go away abandons it, so the bus delivers it again. Azure Service Bus is the first broker. Every broker gets its own project.  
<!-- region end: Intro-->

## Table of contents <!-- omit in toc -->  
- [NuGet packages](#nuget-packages)
- [Namespaces](#namespaces)
- [Dependencies](#dependencies)
- [Usage](#usage)
  - [Declare the message types](#declare-the-message-types)
  - [Write the handler](#write-the-handler)
  - [Register the module](#register-the-module)
  - [Settings per message type](#settings-per-message-type)
  - [What happens to a message](#what-happens-to-a-message)
  - [Create the subscriptions](#create-the-subscriptions)
  - [Change the options of Azure Service Bus](#change-the-options-of-azure-service-bus)
  - [Try a message in development](#try-a-message-in-development)
  - [Add the health check](#add-the-health-check)
  - [The inbox](#the-inbox)
  - [Competing consumers and shutdown](#competing-consumers-and-shutdown)
  - [Traces](#traces)
  - [What is not built yet](#what-is-not-built-yet)

## NuGet packages  
<!-- region start: NuGet-->
[![NuGet Version](https://img.shields.io/nuget/vpre/gmarginet.Cat.EventProcessor)](#nuget-packages)

| Package | Role | Install | Downloads |
|---------|------|---------|-----------|
| [Cat.EventProcessor.Abstractions](https://www.nuget.org/packages/gmarginet.Cat.EventProcessor.Abstractions/) | Contracts | `dotnet add package gmarginet.Cat.EventProcessor.Abstractions` | [![NuGet Downloads](https://img.shields.io/nuget/dt/gmarginet.Cat.EventProcessor.Abstractions)](#nuget-packages) |
| [Cat.EventProcessor](https://www.nuget.org/packages/gmarginet.Cat.EventProcessor/) | Implementation | `dotnet add package gmarginet.Cat.EventProcessor` | [![NuGet Downloads](https://img.shields.io/nuget/dt/gmarginet.Cat.EventProcessor)](#nuget-packages) |
| [Cat.EventProcessor.AzureServiceBus](https://www.nuget.org/packages/gmarginet.Cat.EventProcessor.AzureServiceBus/) | Azure Service Bus listener | `dotnet add package gmarginet.Cat.EventProcessor.AzureServiceBus` | [![NuGet Downloads](https://img.shields.io/nuget/dt/gmarginet.Cat.EventProcessor.AzureServiceBus)](#nuget-packages) |
| [Cat.EventProcessor.Minimal.Api](https://www.nuget.org/packages/gmarginet.Cat.EventProcessor.Minimal.Api/) | Optional development endpoint | `dotnet add package gmarginet.Cat.EventProcessor.Minimal.Api` | [![NuGet Downloads](https://img.shields.io/nuget/dt/gmarginet.Cat.EventProcessor.Minimal.Api)](#nuget-packages) |
| [Cat.EventProcessor.Inbox.EFCore](https://www.nuget.org/packages/gmarginet.Cat.EventProcessor.Inbox.EFCore/) | Optional inbox for EF Core | `dotnet add package gmarginet.Cat.EventProcessor.Inbox.EFCore` | [![NuGet Downloads](https://img.shields.io/nuget/dt/gmarginet.Cat.EventProcessor.Inbox.EFCore)](#nuget-packages) |

<!-- region end: NuGet-->

## Namespaces
<!-- region start: Namespaces-->

| Namespace | What it holds |
|-----------|---------------|
| [Cat.EventProcessor.Abstractions](namespaces/Cat.EventProcessor.Abstractions/index.md) | The incoming message, the settlement, the receiver, the contract of the inbox store and the settings per message type. |
| [Cat.EventProcessor](namespaces/Cat.EventProcessor/index.md) | The receiver, the failure table, the builder for the message types and the module registration. |
| [Cat.EventProcessor.AzureServiceBus](namespaces/Cat.EventProcessor.AzureServiceBus/index.md) | The Azure Service Bus listener, the health check and the creation of the subscriptions. |
| [Cat.EventProcessor.Minimal.Api](namespaces/Cat.EventProcessor.Minimal.Api/index.md) | The development endpoint that simulates an incoming message. |
| [Cat.EventProcessor.Inbox.EFCore](namespaces/Cat.EventProcessor.Inbox.EFCore/index.md) | The inbox table and its store. |

<!-- region end: Namespaces-->

## Dependencies
<!-- region start: Dependencies-->

| Module | Why Cat.EventProcessor needs it |
|--------|---------------------------------|
| [Cat.Messaging](../Cat.Messaging/README.md) | The message types, the name convention and the Azure Service Bus connection. |
| [Cat.ServiceRequests](../Cat.ServiceRequests/README.md) | The message is the service request, and its handler runs through the service request processor. |
| [Cat.Responses](../Cat.Responses/README.md) | The response of the handler decides what happens to the message. |

<!-- region end: Dependencies-->

## Usage
<!-- region start: Usage-->
### Declare the message types

A message type that the service receives is a message and a service request at the same time. The `Contracts` project of the sender references `Cat.Messaging.Abstractions` and `Cat.ServiceRequests.Abstractions`:

```csharp
using Cat.Messaging.Abstractions;
using Cat.ServiceRequests.Abstractions;

public class OrderPlaced : CatEventMessage, ICatServiceRequest
{
    public Guid OrderId { get; set; }
    public string OrderNumber { get; set; } = string.Empty;
}
```

### Write the handler

Every service that receives the message writes its own handler. An event with several receivers works, because every service has its own handlers:

```csharp
public class OrderPlacedHandler : ICatServiceRequestHandler<OrderPlaced>
{
    public async Task<ICatResponse> HandleAsync(OrderPlaced message, CancellationToken cancellationToken = default)
    {
        await ReserveStockAsync(message.OrderId, cancellationToken);

        return CatResponse.Ok();
    }
}
```

Write the handler so that it can run twice for the same message. The bus delivers a message at least once. See [The inbox](#the-inbox) for a handler that cannot do that.

### Register the module

The module works like the API gateway. The `EventProcessor` project of the service holds the declaration in one extension method, and the API calls it:

```csharp
using Cat.EventProcessor.Extensions;

public static class EventProcessorExtensions
{
    public static IServiceCollection AddOrdersEventProcessor(this IServiceCollection services, IConfiguration configuration)
    {
        return services.AddCatEventProcessor(configuration, processor => processor
            .Receive<OrderPlaced>()
            .Receive<ReserveStock>(options => options.MaxConcurrentCalls = 4));
    }
}
```

In the API project, register the service request module, the connection to the bus and the listener. The subscription name is the name this service uses on the topic of every event:

```csharp
using Cat.EventProcessor.AzureServiceBus.Extensions;
using Cat.Messaging.AzureServiceBus.Extensions;
using Cat.Messaging.Extensions;
using Cat.ServiceRequests.Extensions;

builder.Services.AddCatServiceRequestsModule(typeof(OrderPlacedHandler));
builder.Services.AddCatMessagingModule();
builder.Services.AddCatMessagingAzureServiceBus(options =>
    options.ConnectionString = builder.Configuration.GetConnectionString("servicebus")!);
builder.Services.AddOrdersEventProcessor(builder.Configuration);
builder.Services.AddCatEventProcessorAzureServiceBus(options => options.SubscriptionName = "inventory");
```

An event is read from the subscription of the service on its topic. A command message is read from its queue. The names follow the convention of `Cat.Messaging`, so `[CatMessage(Name = "...")]` works on the receiving side too. The listener starts one Azure Service Bus processor for every declared message type, and stops them together.

### Settings per message type

Set them in code, as in the example above. Whoever runs the service can also set them in the configuration, and the configuration wins, so no build is needed:

```json
{
  "CatEventProcessor": {
    "Messages": {
      "OrderPlaced": {
        "MaxConcurrentCalls": 8,
        "FailureOverrides": { "NotFound": "Complete" }
      }
    }
  }
}
```

- **`MaxConcurrentCalls`:** how many messages of this type run at the same time. The default of the bus applies when it is empty. For a message type that needs sessions it is the number of sessions at the same time.
- **`FailureOverrides`:** what to do with a failed response of a given type. See the table below.

### What happens to a message

The listener turns the response of the handler into an action on the message:

| The handler returns | What the listener does | Why |
|---|---|---|
| Succeeded | Completes the message. | Done. |
| `BadRequest`, `NotFound`, `Conflict`, `Forbidden` or `Unauthorized` | Dead letters it at once, with the error codes as the reason and the error messages as the description. | Trying again gives the same answer. |
| `InternalServerError`, or an exception | Abandons it, so the bus delivers it again. After the maximum number of deliveries the bus dead letters it. | The cause may go away, such as a database that is down for a moment. |

A body that is not JSON, or does not fit the message type, is dead lettered with the reason `InvalidMessage`. A content type other than `application/json` is dead lettered with the reason `UnsupportedContentType`.

The bus alone retries. The module adds no retry loop of its own, because two retry layers multiply. The bus uses its own settings, with a default of 10 deliveries. It redelivers at once, so a dependency that is down gets hit up to ten times in a second.

Override the table per message type with `FailureOverrides`. The key is the name of the response type, and the value is `Complete`, `Abandon` or `DeadLetter`.

### Create the subscriptions

Nothing is created when the service starts. A subscription belongs to the service that receives the message, so the service creates its own. The topic comes from the sender, see `Cat.Messaging`. The topic must exist already:

```csharp
var topology = app.Services.GetRequiredService<ICatEventProcessorTopology>();
var created = await topology.EnsureSubscriptionsAsync();
```

It creates the subscription of this service on the topic of every declared event, and skips what exists. It needs the manage right on the namespace, so call it from a deployment step or a test, and not from the service itself. A sample with the Azure CLI:

```powershell
az servicebus topic subscription create --resource-group <group> --namespace-name <namespace> --topic-name OrderPlaced --name inventory
```

### Change the options of Azure Service Bus

The listener starts from the defaults of Azure Service Bus and sets only what it needs. You can change any other option with a callback on `CatEventProcessorServiceBusOptions`. The listener builds the SDK options with its own values first, and then calls your callback, so your callback wins. The callbacks for the client, the administration client, the queues and the topics are on the options of `Cat.Messaging`, see its module readme.

| Callback | Changes | When it runs |
|---|---|---|
| `ConfigureProcessor` | `ServiceBusProcessorOptions` | For every message type that does not need sessions, when the listener starts. |
| `ConfigureSessionProcessor` | `ServiceBusSessionProcessorOptions` | For every message type that needs sessions, when the listener starts. |
| `ConfigureSubscription` | `CreateSubscriptionOptions` | For every subscription that `EnsureSubscriptionsAsync` creates. |

The two processor callbacks get the message type as the first argument, so you can tune one message type:

```csharp
builder.Services.AddCatEventProcessorAzureServiceBus(options =>
{
    options.SubscriptionName = "inventory";
    options.ConfigureProcessor = (messageType, processor) =>
    {
        if (messageType == typeof(OrderPlaced))
        {
            processor.PrefetchCount = 20;
        }
    };
    options.ConfigureSubscription = subscription => subscription.MaxDeliveryCount = 5;
});
```

Things to know:
- **The callback wins over the settings per message type.** The listener sets `MaxConcurrentCalls`, or the number of sessions, from the declaration and the configuration first. A callback that sets it again replaces that value.
- **The listener settles every message itself.** It sets `AutoCompleteMessages` to false after your callback runs, so a callback cannot turn it on. The table in [What happens to a message](#what-happens-to-a-message) depends on it.
- **A subscription gets the defaults.** The listener sets only the names of the topic and the subscription.

### Try a message in development

The API can map a development endpoint. It exists only in the Development environment. In any other environment nothing is mapped:

```csharp
using Cat.EventProcessor.Minimal.Api.Extensions;

app.MapCatEventProcessor();
```

- `GET /dev/event-processor` lists the declared message types with their queue or topic.
- `POST /dev/event-processor/{messageType}` takes the JSON of a message and runs it through the same pipeline as a real message. The answer says what the listener would do with the message: `Complete`, `Abandon` or `DeadLetter`, with the reason.

Nothing is settled on the bus, because there is no real message.

### Add the health check

A listener can stop because of a fatal error, such as a deleted queue or a missing permission, while the API still answers. The health check tells the platform:

```csharp
builder.Services.AddHealthChecks().AddCatEventProcessorHealthCheck();
```

It is unhealthy when a listener has stopped, and degraded for a minute after a listener reported an error while it keeps processing.

### The inbox

Use the inbox only when a handler cannot run twice for the same message. It stores the ID of a handled message in the service database, in the same `SaveChanges` as the work of the handler. A repeated message hits the key of the table and is skipped.

Add the `Cat.EventProcessor.Inbox.EFCore` package. Map the table in the context that the handlers use and register the store:

```csharp
using Cat.EventProcessor.Inbox.EFCore;
using Cat.EventProcessor.Inbox.EFCore.Extensions;

public class InventoryDbContext : DbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.AddCatInbox();
    }
}

builder.Services.AddCatEventProcessorInbox<InventoryDbContext>();
```

Add a migration afterwards, so the `CatInbox` table exists. Then switch the inbox on for the message types that need it:

```csharp
builder.Services.AddCatEventProcessor(builder.Configuration, events => events
    .Receive<OrderPlaced>(options => options.UseInbox = true)
    .Receive<StockCounted>());
```

What to know:
- **Per message type.** `UseInbox` is false by default. Only a message type with it on gets the inbox, so you pick the types and not every handler.
- **Configuration.** The configuration of the service wins over the code, like the other settings: `CatEventProcessor:Messages:OrderPlaced:UseInbox`.
- **Where it runs.** The receiver does the work, not a decorator. Before the handler runs it asks the store for the message ID. A repeated message completes without running the handler. A new message gets its row in the context of the handler, so the `SaveChanges` of the handler saves the row with the work, or neither is saved.
- **Two copies at once.** The key of the table fails the second save, the message is abandoned, and the next delivery finds the row and skips it.
- **No message ID.** A message without an ID is handled without the inbox.
- **Missing store.** The listener fails at startup when a message type has `UseInbox` on and no `ICatInboxStore` is registered.
- **Other stores.** `ICatInboxStore` lives in `Cat.EventProcessor.Abstractions`, so you can register a store of your own.
- **The sender helps.** It sets the message ID, and duplicate detection of the queue or topic can drop a repeated message.

### Competing consumers and shutdown

Several instances of the same service can listen to the same subscription, and the bus gives a message to one of them. The module never assumes one instance. The order of messages is not guaranteed, unless the message type needs sessions, see `Cat.Messaging`.

When the service stops, the listener stops taking new messages and finishes the messages that are running.

### Traces

The trace of the sender continues in the service. The Azure Service Bus SDK reads the `Diagnostic-Id` of the message and starts the activity of the handling from it, so the second half of a flow joins the same trace. The module adds nothing for this. Register the `Azure.Messaging.ServiceBus` source in the OpenTelemetry setup of the service.

### What is not built yet

The identity of the sender is not carried by the message yet. It waits for `Cat.Users`, which does not exist yet. A handler that runs for a message has no current user. The plan holds the decisions about the token.
<!-- region end: Usage-->

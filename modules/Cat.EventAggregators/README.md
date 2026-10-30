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

|&nbsp;&nbsp;&nbsp;[HOME](../../README.md)&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;[MODULE OVERVIEW](../../README.md#module-overview)&nbsp;&nbsp;&nbsp;|

</td>
</tr>
</table>

# Cat.EventAggregators <!-- omit in toc -->  

<!-- Intro start-->
Cat.EventAggregators is a lightweight in-process event aggregator. It lets different parts of your app talk to each other through events, without taking a direct dependency on one another.

A publisher raises an event, and any subscriber that handles that event type gets notified. Subscribers are tracked through weak references, so you don't have to remember to unsubscribe just to avoid a memory leak.  
<!-- Intro end-->

## Table of contents <!-- omit in toc -->  
- [NuGet packages](#nuget-packages)
- [Namespaces](#namespaces)
- [Dependencies](#dependencies)
- [Usage](#usage)
  - [Register the module](#register-the-module)
  - [Define an event and a subscriber](#define-an-event-and-a-subscriber)
  - [Subscribe and publish](#subscribe-and-publish)
  - [Handle more than one event type](#handle-more-than-one-event-type)
  - [Handle a base type](#handle-a-base-type)
  - [Check for subscribers](#check-for-subscribers)
  - [Weak references](#weak-references)
  - [Errors and exceptions](#errors-and-exceptions)

## NuGet packages
<!-- NuGet start -->
![NuGet Version](https://img.shields.io/nuget/vpre/gmarginet.Cat.EventAggregators)

| Package | Role | Install | Downloads |
|---------|------|---------|-----------|
| [Cat.EventAggregators.Abstractions](https://www.nuget.org/packages/gmarginet.Cat.EventAggregators.Abstractions/) | Contracts | `dotnet add package gmarginet.Cat.EventAggregators.Abstractions` | ![NuGet Downloads](https://img.shields.io/nuget/dt/gmarginet.Cat.EventAggregators.Abstractions) |
| [Cat.EventAggregators](https://www.nuget.org/packages/gmarginet.Cat.EventAggregators/) | Implementation | `dotnet add package gmarginet.Cat.EventAggregators` | ![NuGet Downloads](https://img.shields.io/nuget/dt/gmarginet.Cat.EventAggregators) |
<!-- NuGet end -->

## Namespaces
<!-- Namespaces start-->
| Namespace | What it holds |
|-----------|---------------|
| [Cat.EventAggregators.Abstractions](namespaces/Cat.EventAggregators.Abstractions/index.md) | Interfaces for publishers and subscribers. |
| [Cat.EventAggregators](namespaces/Cat.EventAggregators/index.md) | The event aggregator and the module registration. |
<!-- Namespaces end-->

## Dependencies
<!-- Dependencies start-->
| Module | Why Cat.EventAggregators needs it |
|--------|----------------------------------|
| [Cat.Extensions](../Cat.Extensions/README.md) | Small helpers for service registration. |
<!-- Dependencies end-->

## Usage
<!-- Usage start-->
### Register the module

Call `AddCatEventAggregatorsModule` to register `ICatEventAggregator` as a singleton. Every part of your app that injects it shares the same list of subscribers.

```csharp
using Cat.EventAggregators.Extensions;

services.AddCatEventAggregatorsModule();
```

### Define an event and a subscriber

An event is any type. A record works well. A subscriber is any class that implements `ICatHandleEvent<TEvent>`.

```csharp
using Cat.EventAggregators.Abstractions;

public record OrderCreatedEvent(int OrderId);

public class OrderCreatedSubscriber : ICatHandleEvent<OrderCreatedEvent>
{
    public Task HandleEventAsync(OrderCreatedEvent @event, CancellationToken cancellationToken = default)
    {
        Console.WriteLine($"Order {@event.OrderId} was created.");
        return Task.CompletedTask;
    }
}
```

### Subscribe and publish

Subscribe an instance, publish an event, and unsubscribe when the subscriber no longer cares. `PublishAsync` waits until every handler has finished.

```csharp
using Cat.EventAggregators.Abstractions;

var eventAggregator = serviceProvider.GetRequiredService<ICatEventAggregator>();

var subscriber = new OrderCreatedSubscriber();
eventAggregator.Subscribe(subscriber);

await eventAggregator.PublishAsync(new OrderCreatedEvent(OrderId: 42));

eventAggregator.Unsubscribe(subscriber);
```

A subscriber that gets its aggregator through dependency injection can subscribe itself:

```csharp
public class OrderStatistics : ICatHandleEvent<OrderCreatedEvent>
{
    public OrderStatistics(ICatEventAggregator eventAggregator)
    {
        eventAggregator.Subscribe(this);
    }

    public int OrderCount { get; private set; }

    public Task HandleEventAsync(OrderCreatedEvent @event, CancellationToken cancellationToken = default)
    {
        OrderCount++;
        return Task.CompletedTask;
    }
}
```

Pass a cancellation token to `PublishAsync`. Every handler receives it.

```csharp
await eventAggregator.PublishAsync(new OrderCreatedEvent(42), cancellationToken);
```

### Handle more than one event type

A subscriber can implement `ICatHandleEvent<TEvent>` for as many event types as it needs. One call to `Subscribe` picks up all of them.

```csharp
public class AuditSubscriber :
    ICatHandleEvent<OrderCreatedEvent>,
    ICatHandleEvent<OrderCancelledEvent>
{
    public Task HandleEventAsync(OrderCreatedEvent @event, CancellationToken cancellationToken = default)
    {
        // write an audit line
        return Task.CompletedTask;
    }

    public Task HandleEventAsync(OrderCancelledEvent @event, CancellationToken cancellationToken = default)
    {
        // write an audit line
        return Task.CompletedTask;
    }
}
```

Several subscribers can handle the same event. Each of them gets it.

### Handle a base type

A handler for a base type or an interface also receives every event that derives from it. Use it for cross-cutting subscribers like logging or auditing.

```csharp
public interface IOrderEvent
{
    int OrderId { get; }
}

public record OrderShippedEvent(int OrderId) : IOrderEvent;

public class OrderEventLogger : ICatHandleEvent<IOrderEvent>
{
    public Task HandleEventAsync(IOrderEvent @event, CancellationToken cancellationToken = default)
    {
        Console.WriteLine($"Order event for order {@event.OrderId}");
        return Task.CompletedTask;
    }
}
```

Publishing an `OrderShippedEvent` reaches `OrderEventLogger`.

### Check for subscribers

`HasSubscribersForEvent` tells you whether anyone is listening. Use it to skip expensive work when nobody would receive the event.

```csharp
if (eventAggregator.HasSubscribersForEvent(typeof(OrderCreatedEvent)))
{
    await eventAggregator.PublishAsync(CreateExpensiveEvent());
}
```

### Weak references

The aggregator holds each subscriber through a weak reference. A subscriber that nothing else references can be garbage collected, and the aggregator drops it the next time a publish completes.

That has one consequence. Keep a reference to the subscriber for as long as it should receive events. A subscriber created and subscribed in one expression stops receiving events as soon as the garbage collector runs.

```csharp
// Risky: nothing keeps this instance alive
eventAggregator.Subscribe(new OrderCreatedSubscriber());

// Safe: a field, or a service that lives as long as you need it
_subscriber = new OrderCreatedSubscriber();
eventAggregator.Subscribe(_subscriber);
```

### Errors and exceptions

The aggregator has no response types. It reports problems as exceptions, and it is forgiving about calls that do nothing.

| Situation | What you get |
|-----------|--------------|
| `Subscribe`, `Unsubscribe` or `PublishAsync` gets `null` | An `ArgumentNullException` with the parameter name. |
| The same instance subscribes twice | Nothing. The second call is ignored. |
| The subscriber implements no `ICatHandleEvent<TEvent>` | Nothing. The subscriber is ignored. |
| `Unsubscribe` gets an instance that isn't subscribed | Nothing. |
| `PublishAsync` finds no subscriber for the event | Nothing. The task completes right away. |
| A handler throws | The other handlers still run. `PublishAsync` rethrows the exception of the handler that failed. The exception is the original one, not a `TargetInvocationException`. |

When a handler throws, `PublishAsync` skips the cleanup of garbage collected subscribers for that call. They are removed after the next publish that succeeds.

Handle exceptions inside your handlers when one failing subscriber must not stop the publisher.
<!-- Usage end-->

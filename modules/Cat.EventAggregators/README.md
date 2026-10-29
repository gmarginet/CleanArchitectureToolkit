<link href="../../resources/styles/style.css" rel="stylesheet"></link>

# `Clean Architecture Toolkit for .NET` <!-- omit in toc -->  

[CAT](../../README.md 'Readme of the CAT project\.')  
[Module overview](../../README.md#module-overview 'List of all the CAT modules\.')  

# `Cat.EventAggregators` <!-- omit in toc -->  

<!-- Intro start-->
Cat.EventAggregators is a lightweight in-process event aggregator. It lets different parts of your app talk to each other through events, without taking a direct dependency on one another.

A publisher raises an event, and any subscriber that handles that event type gets notified. Subscribers are tracked through weak references, so you don't have to remember to unsubscribe just to avoid a memory leak.  
<!-- Intro end-->

## `Table of contents` <!-- omit in toc -->  
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

## Namespaces
<!-- Namespaces start-->
- [Cat.EventAggregators.Abstractions](namespaces/Cat.EventAggregators.Abstractions/index.md)  
- [Cat.EventAggregators](namespaces/Cat.EventAggregators/index.md)  
<!-- Namespaces end-->

## Dependencies
<!-- Dependencies start-->
- [Cat.Extensions](../Cat.Extensions/README.md)  
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

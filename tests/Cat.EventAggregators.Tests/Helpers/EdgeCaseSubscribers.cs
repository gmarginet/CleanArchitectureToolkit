using Cat.EventAggregators.Abstractions;

namespace Cat.EventAggregators.Tests.Helpers;

public record OrderPlacedEvent(string Id);

public record OrderShippedEvent(string Id);

/// <summary>
/// Handles two kinds of events through two interfaces.
/// </summary>
public class MultiEventSubscriber : ICatHandleEvent<OrderPlacedEvent>, ICatHandleEvent<OrderShippedEvent>
{
    public List<string> Seen { get; } = [];

    public Task HandleEventAsync(OrderPlacedEvent @event, CancellationToken cancellationToken = default)
    {
        Seen.Add("placed:" + @event.Id);
        return Task.CompletedTask;
    }

    public Task HandleEventAsync(OrderShippedEvent @event, CancellationToken cancellationToken = default)
    {
        Seen.Add("shipped:" + @event.Id);
        return Task.CompletedTask;
    }
}

/// <summary>
/// Counts the placed events it receives and remembers the cancellation token.
/// </summary>
public class CountingSubscriber : ICatHandleEvent<OrderPlacedEvent>
{
    public int Count { get; private set; }

    public CancellationToken LastToken { get; private set; }

    public Task HandleEventAsync(OrderPlacedEvent @event, CancellationToken cancellationToken = default)
    {
        Count++;
        LastToken = cancellationToken;
        return Task.CompletedTask;
    }
}

/// <summary>
/// Takes a moment to handle the event.
/// </summary>
public class SlowSubscriber : ICatHandleEvent<OrderPlacedEvent>
{
    public bool Done { get; private set; }

    public async Task HandleEventAsync(OrderPlacedEvent @event, CancellationToken cancellationToken = default)
    {
        await Task.Delay(50, CancellationToken.None);
        Done = true;
    }
}

/// <summary>
/// Always fails.
/// </summary>
public class ThrowingSubscriber : ICatHandleEvent<OrderPlacedEvent>
{
    public Task HandleEventAsync(OrderPlacedEvent @event, CancellationToken cancellationToken = default)
    {
        throw new InvalidOperationException("handler failed");
    }
}

/// <summary>
/// Has no event handlers at all.
/// </summary>
public class NoHandlersSubscriber;

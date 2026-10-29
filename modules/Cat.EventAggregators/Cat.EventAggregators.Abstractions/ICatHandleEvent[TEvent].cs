using System.Threading;
using System.Threading.Tasks;

namespace Cat.EventAggregators.Abstractions;

/// <summary>
/// Implemented by a subscriber to receive events of type <typeparamref name="TEvent"/> from an <see cref="ICatEventAggregator"/>.
/// </summary>
/// <typeparam name="TEvent">The type of event this subscriber handles.</typeparam>
public interface ICatHandleEvent<TEvent>
{
    /// <summary>
    /// Handles a published event.
    /// </summary>
    /// <param name="event">The event instance to handle.</param>
    /// <param name="cancellationToken">A token to cancel the handling operation.</param>
    Task HandleEventAsync(TEvent @event, CancellationToken cancellationToken = default);
}
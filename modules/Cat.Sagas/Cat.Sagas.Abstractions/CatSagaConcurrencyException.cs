using System;

namespace Cat.Sagas.Abstractions;

/// <summary>
/// Thrown by a store when another message changed the instance since it was loaded.
/// Let it pass. The message is delivered again and the next try sees the new state.
/// </summary>
public class CatSagaConcurrencyException : Exception
{
    /// <summary>
    /// Creates the exception.
    /// </summary>
    /// <param name="instanceId">The id of the instance that changed.</param>
    public CatSagaConcurrencyException(Guid instanceId)
        : base($"The saga instance {instanceId} was changed by another message. Try again.")
    {
        InstanceId = instanceId;
    }

    /// <summary>
    /// The id of the instance that changed.
    /// </summary>
    public Guid InstanceId { get; }
}

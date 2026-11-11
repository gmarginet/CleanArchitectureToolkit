using System;
using System.Threading;

namespace Cat.EventProcessor.Abstractions;

/// <summary>
/// The message that is being handled right now. Code in the handler pipeline, such as the inbox decorator, reads it.
/// It is empty when a service request does not come from a message, for example from an HTTP call.
/// </summary>
public static class CatMessageContext
{
    private static readonly AsyncLocal<CatMessageContextData?> CurrentData = new AsyncLocal<CatMessageContextData?>();

    /// <summary>
    /// The message that is being handled, or null.
    /// </summary>
    public static CatMessageContextData? Current => CurrentData.Value;

    /// <summary>
    /// Sets the current message until the returned object is disposed. The receiver calls it.
    /// </summary>
    /// <param name="messageId">The ID of the message.</param>
    /// <param name="deliveryCount">How many times the bus delivered the message.</param>
    /// <returns>An object that puts the previous value back when it is disposed.</returns>
    public static IDisposable Begin(string messageId, int deliveryCount)
    {
        var previous = CurrentData.Value;
        CurrentData.Value = new CatMessageContextData(messageId, deliveryCount);
        return new Scope(previous);
    }

    private sealed class Scope : IDisposable
    {
        private readonly CatMessageContextData? _previous;

        public Scope(CatMessageContextData? previous)
        {
            _previous = previous;
        }

        public void Dispose()
        {
            CurrentData.Value = _previous;
        }
    }
}

/// <summary>
/// The data of the message that is being handled.
/// </summary>
public class CatMessageContextData
{
    /// <summary>
    /// Creates the data.
    /// </summary>
    /// <param name="messageId">The ID of the message.</param>
    /// <param name="deliveryCount">How many times the bus delivered the message.</param>
    public CatMessageContextData(string messageId, int deliveryCount)
    {
        MessageId = messageId;
        DeliveryCount = deliveryCount;
    }

    /// <summary>
    /// The ID of the message, as the sender set it.
    /// </summary>
    public string MessageId { get; }

    /// <summary>
    /// How many times the bus delivered the message, this one included.
    /// </summary>
    public int DeliveryCount { get; }
}

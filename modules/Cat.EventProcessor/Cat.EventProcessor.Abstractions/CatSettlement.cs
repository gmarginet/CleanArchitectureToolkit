namespace Cat.EventProcessor.Abstractions;

/// <summary>
/// What the broker does with a message after the service handled it.
/// </summary>
public enum CatSettlement
{
    /// <summary>
    /// The work is done. The message leaves the queue.
    /// </summary>
    Complete = 0,

    /// <summary>
    /// The work failed and may work later. The bus delivers the message again, and dead letters it after the maximum number of deliveries.
    /// </summary>
    Abandon = 1,

    /// <summary>
    /// Trying again gives the same answer. The message goes to the dead letter queue at once.
    /// </summary>
    DeadLetter = 2
}

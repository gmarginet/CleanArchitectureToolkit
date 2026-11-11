namespace Cat.EventProcessor.Abstractions;

/// <summary>
/// The outcome of handling one message: what to do with it, and why.
/// </summary>
public class CatSettlementResult
{
    /// <summary>
    /// Creates a result.
    /// </summary>
    /// <param name="settlement">What to do with the message.</param>
    /// <param name="reason">A short reason, such as an error code. Empty when the message is completed.</param>
    /// <param name="description">A longer explanation, such as the error messages. Empty when the message is completed.</param>
    public CatSettlementResult(CatSettlement settlement, string reason = "", string description = "")
    {
        Settlement = settlement;
        Reason = reason;
        Description = description;
    }

    /// <summary>
    /// What to do with the message.
    /// </summary>
    public CatSettlement Settlement { get; }

    /// <summary>
    /// A short reason. The broker copies it to the dead letter reason.
    /// </summary>
    public string Reason { get; }

    /// <summary>
    /// A longer explanation. The broker copies it to the dead letter description.
    /// </summary>
    public string Description { get; }
}

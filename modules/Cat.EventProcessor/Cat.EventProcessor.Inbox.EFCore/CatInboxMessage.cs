namespace Cat.EventProcessor.Inbox.EFCore;

/// <summary>
/// One row of the inbox table: a message that the service handled.
/// </summary>
public class CatInboxMessage
{
    /// <summary>
    /// The ID of the message, as the sender set it. It is the key of the table, so a second row for the same message fails.
    /// </summary>
    public string MessageId { get; set; } = string.Empty;

    /// <summary>
    /// The name of the message type.
    /// </summary>
    public string MessageType { get; set; } = string.Empty;

    /// <summary>
    /// When the message was handled.
    /// </summary>
    public DateTimeOffset HandledAt { get; set; }
}

using Cat.Messaging.Abstractions;

namespace ServiceName.Contracts.Messages;

/// <summary>
/// The message that change data capture sends for every change of the table ItemName.
/// Add the properties that a receiver needs, and change ItemNameChangeMapper to fill them.
/// </summary>
public class ItemNameChanged : CatEventMessage
{
    public Guid Id { get; set; }

    /// <summary>Insert, Update or Delete.</summary>
    public string Operation { get; set; } = string.Empty;

    /// <summary>The name before the change. Null for an insert.</summary>
    public string? OldName { get; set; }

    /// <summary>The name after the change. Null for a delete.</summary>
    public string? NewName { get; set; }
}

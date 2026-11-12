using System.Collections.Generic;

namespace Cat.EventProcessor.Abstractions;

/// <summary>
/// The settings of one declared message type. Set them in code, and the configuration of the service can change them.
/// </summary>
public class CatReceiveOptions
{
    /// <summary>
    /// How many messages of this type are handled at the same time. Null means the default of the bus.
    /// </summary>
    public int? MaxConcurrentCalls { get; set; }

    /// <summary>
    /// Switches the inbox on for this message type. The receiver then skips a message that was handled before.
    /// It needs an <see cref="ICatInboxStore"/> in the service, such as the one of <c>Cat.EventProcessor.Inbox.EFCore</c>.
    /// The default is false, so a message type has no inbox unless you ask for it.
    /// </summary>
    public bool UseInbox { get; set; }

    /// <summary>
    /// Overrides the failure table for this message type. The key is the name of the response type,
    /// such as <c>NotFound</c> or <c>InternalServerError</c>. The value is what to do with the message.
    /// </summary>
    public IDictionary<string, CatSettlement> FailureOverrides { get; set; } = new Dictionary<string, CatSettlement>();
}

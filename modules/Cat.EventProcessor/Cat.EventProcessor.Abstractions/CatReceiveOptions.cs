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
    /// Overrides the failure table for this message type. The key is the name of the response type,
    /// such as <c>NotFound</c> or <c>InternalServerError</c>. The value is what to do with the message.
    /// </summary>
    public IDictionary<string, CatSettlement> FailureOverrides { get; set; } = new Dictionary<string, CatSettlement>();
}

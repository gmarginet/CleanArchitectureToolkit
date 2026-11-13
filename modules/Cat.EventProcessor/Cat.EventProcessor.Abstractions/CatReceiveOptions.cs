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
    /// The name of the authorization policy that a message of this type must pass before the handler runs. Null means no named policy.
    /// The policy is one of ASP.NET Core, defined in the service. It needs an <see cref="ICatMessageAuthorizer"/> in the service,
    /// such as the one of <c>Cat.EventProcessor.Authorization</c>.
    /// </summary>
    public string? Policy { get; set; }

    /// <summary>
    /// Rules that a developer states in code next to the message type, instead of a named policy. The project that implements
    /// <see cref="ICatMessageAuthorizer"/> adds extension methods to fill this list, so this project stays free of ASP.NET Core.
    /// A message must pass the named policy and every rule.
    /// </summary>
    public IList<object> AuthorizationRules { get; } = new List<object>();

    /// <summary>
    /// True when the message type has a named policy or a rule.
    /// </summary>
    public bool HasAuthorizationRule => !string.IsNullOrWhiteSpace(Policy) || AuthorizationRules.Count > 0;

    /// <summary>
    /// Overrides the failure table for this message type. The key is the name of the response type,
    /// such as <c>NotFound</c> or <c>InternalServerError</c>. The value is what to do with the message.
    /// </summary>
    public IDictionary<string, CatSettlement> FailureOverrides { get; set; } = new Dictionary<string, CatSettlement>();
}

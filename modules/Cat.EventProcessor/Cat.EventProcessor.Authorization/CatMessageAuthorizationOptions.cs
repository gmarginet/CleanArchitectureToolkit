namespace Cat.EventProcessor.Authorization;

/// <summary>
/// The settings of the authorization of messages.
/// </summary>
public class CatMessageAuthorizationOptions
{
    /// <summary>
    /// The JWT bearer scheme whose options validate the token of a message. The default is <c>Bearer</c>.
    /// The service registers that scheme, also when it has no HTTP authentication.
    /// </summary>
    public string AuthenticationScheme { get; set; } = "Bearer";

    /// <summary>
    /// When true, the receiver denies a message type that has no policy and no rule. The default is false, so a service keeps working
    /// while its message types get their rules. The listener logs the message types without a rule at startup either way.
    /// A message type that is open on purpose states a rule that always passes, such as <c>options.Require(policy =&gt; policy.RequireAssertion(_ =&gt; true))</c>.
    /// </summary>
    public bool DenyMessagesWithoutPolicy { get; set; }
}

using Cat.EventProcessor.Abstractions;
using Microsoft.AspNetCore.Authorization;

namespace Cat.EventProcessor.Authorization.Extensions;

/// <summary>
/// States an authorization rule next to a message type.
/// </summary>
public static class ReceiveOptionsExtensions
{
    /// <summary>
    /// Adds a rule that a message of this type must pass before the handler runs. The rule is built with the policy builder of ASP.NET Core,
    /// so every rule of ASP.NET Core works, such as <c>options.Require(policy =&gt; policy.RequireRole("admin"))</c>.
    /// A message must pass the named policy of <see cref="CatReceiveOptions.Policy"/> and every rule.
    /// </summary>
    /// <param name="options">The settings of the message type.</param>
    /// <param name="rule">Builds the rule.</param>
    /// <returns>The same options, so calls can be chained.</returns>
    public static CatReceiveOptions Require(this CatReceiveOptions options, Action<AuthorizationPolicyBuilder> rule)
    {
        options.AuthorizationRules.Add(rule);
        return options;
    }
}

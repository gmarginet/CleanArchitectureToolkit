using Cat.EventProcessor.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Cat.EventProcessor.Authorization;

/// <summary>
/// Checks the policies of the message types when the service starts. A policy name that does not exist stops the start,
/// so the mistake shows at startup and not on the first message. The message types without a rule are logged.
/// </summary>
internal sealed class AuthorizationStartupCheck : IHostedService
{
    private readonly ICatReceiveRegistry _registry;
    private readonly IAuthorizationPolicyProvider _policies;
    private readonly ILogger<AuthorizationStartupCheck> _logger;

    public AuthorizationStartupCheck(ICatReceiveRegistry registry, IAuthorizationPolicyProvider policies, ILogger<AuthorizationStartupCheck> logger)
    {
        _registry = registry;
        _policies = policies;
        _logger = logger;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        var withoutRule = new List<string>();

        foreach (var registration in _registry.Registrations)
        {
            if (!registration.Options.HasAuthorizationRule)
            {
                withoutRule.Add(registration.MessageType.Name);
                continue;
            }

            var policy = registration.Options.Policy;
            if (!string.IsNullOrWhiteSpace(policy) && await _policies.GetPolicyAsync(policy!).ConfigureAwait(false) == null)
            {
                throw new InvalidOperationException(
                    $"The policy {policy} of {registration.MessageType.Name} does not exist. Define it with AddAuthorization, or fix the name.");
            }
        }

        if (withoutRule.Count > 0)
        {
            _logger.LogWarning("These message types have no authorization policy and no rule: {MessageTypes}", string.Join(", ", withoutRule));
        }
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}

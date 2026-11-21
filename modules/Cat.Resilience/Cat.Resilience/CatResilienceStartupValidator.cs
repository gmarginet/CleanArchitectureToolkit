using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace Cat.Resilience;

/// <summary>
/// Fails the startup of the host when a registration refers to a profile that does not exist.
/// </summary>
internal sealed class CatResilienceStartupValidator(IEnumerable<CatResilienceUse> uses, CatResilienceProfiles profiles) : IHostedService
{
    /// <inheritdoc />
    public Task StartAsync(CancellationToken cancellationToken)
    {
        foreach (var use in uses)
        {
            // Get throws with a message that names the missing profile.
            profiles.Get(use.ProfileName);
        }

        return Task.CompletedTask;
    }

    /// <inheritdoc />
    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}

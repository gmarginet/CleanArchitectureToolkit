using System;
using Cat.Scheduling.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Cat.Scheduling.Resilience.Extensions;

/// <summary>
/// Registration helpers for the resilience bridge of the scheduling module.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Retries a failed run of every job through a resilience profile.
    /// Register the resilience module too, with <c>AddCatResilienceModule</c> of <c>Cat.Resilience</c>,
    /// because the pipelines come from there. Call this before or after <c>AddCatScheduling</c>.
    /// </summary>
    /// <param name="services">The service collection to add to.</param>
    /// <param name="configure">Sets the profile of all jobs or of single jobs. Optional.</param>
    /// <returns>The same service collection, for chaining.</returns>
    public static IServiceCollection AddCatSchedulingResilience(this IServiceCollection services,
        Action<CatSchedulingResilienceOptions>? configure = null)
    {
        var options = new CatSchedulingResilienceOptions();
        configure?.Invoke(options);

        services.AddSingleton(options);
        services.TryAddSingleton<ICatJobAttemptExecutor, CatResilienceJobAttemptExecutor>();
        return services;
    }
}

using System;
using Cat.Resilience.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace Cat.Resilience.Extensions;

/// <summary>
/// Registration helpers for the resilience module.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registers the resilience profiles and <see cref="ICatResiliencePipelines"/>.
    /// The profiles <see cref="CatResilienceProfile.Internal"/> and <see cref="CatResilienceProfile.External"/> exist with their defaults.
    /// Configuration under <c>Cat:Resilience:Profiles:{name}</c> wins over the code.
    /// Calling <see cref="HttpClientBuilderExtensions.AddCatResilience"/> registers the module too, so calling this one is only needed
    /// to add profiles or to use <see cref="ICatResiliencePipelines"/>.
    /// </summary>
    /// <param name="services">The service collection to add to.</param>
    /// <param name="configure">Adds or changes profiles in code. Optional.</param>
    /// <returns>The same service collection, for chaining.</returns>
    public static IServiceCollection AddCatResilienceModule(this IServiceCollection services,
        Action<CatResilienceOptions>? configure = null)
    {
        services.AddOptions<CatResilienceOptions>();
        services.TryAddEnumerable(ServiceDescriptor.Singleton<IPostConfigureOptions<CatResilienceOptions>, CatResilienceConfigurationSetup>());
        services.TryAddSingleton<CatResilienceProfiles>();
        services.TryAddSingleton<ICatResiliencePipelines, CatResiliencePipelines>();
        services.TryAddEnumerable(ServiceDescriptor.Singleton<IHostedService, CatResilienceStartupValidator>());

        if (configure != null)
        {
            services.Configure(configure);
        }

        return services;
    }
}

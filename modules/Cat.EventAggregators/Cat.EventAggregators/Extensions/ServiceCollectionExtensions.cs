using Cat.EventAggregators.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Cat.EventAggregators.Extensions;

/// <summary>
/// Registers the Cat EventAggregators module in the dependency injection container.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registers <see cref="ICatEventAggregator"/> as a singleton, backed by the module's default implementation.
    /// </summary>
    /// <param name="services">The service collection to add the registration to.</param>
    public static void AddCatEventAggregatorsModule(this IServiceCollection services)
    {
        services.AddSingleton<ICatEventAggregator, CatEventAggregator>();
    }
}
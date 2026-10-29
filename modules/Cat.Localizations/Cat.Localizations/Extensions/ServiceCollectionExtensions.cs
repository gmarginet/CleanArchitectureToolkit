using Cat.Localizations.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Cat.Localizations.Extensions;

/// <summary>
/// Registers the Cat Localizations module in the dependency injection container.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registers <see cref="ICatLocalizer"/> as a singleton, backed by the no-op implementation that returns keys as-is.
    /// </summary>
    /// <param name="services">The service collection to add the registration to.</param>
    public static void AddCatNoLocalizationLocalizer(this IServiceCollection services)
    {
        services.AddSingleton<ICatLocalizer, NoLocalizationCatLocalizer>();
    }
}
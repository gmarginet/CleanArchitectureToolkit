using Cat.Localizations.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Cat.Localizations.EFCore.Extensions;

/// <summary>
/// Registration helpers for the translator.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registers <see cref="ICatTranslator"/> on the <c>DbContext</c> that maps the translation table with
    /// <see cref="ModelBuilderExtensions.AddCatTranslations"/>. The translator is scoped, like the <c>DbContext</c>.
    /// It writes its debug lines through <c>ILogger</c>, so the service needs logging registered, as a web host has.
    /// </summary>
    /// <typeparam name="TDbContext">The <c>DbContext</c> with the translation table.</typeparam>
    /// <param name="services">The service collection to add to.</param>
    /// <returns>The same service collection, so calls can be chained.</returns>
    public static IServiceCollection AddCatLocalizations<TDbContext>(this IServiceCollection services)
        where TDbContext : DbContext
    {
        services.TryAddScoped<ICatTranslator, CatTranslator<TDbContext>>();
        return services;
    }
}

using Cat.Decorators.Abstractions;
using Cat.ServiceCollection.Extensions;
using Microsoft.Extensions.DependencyInjection;

// ReSharper disable RedundantBoolCompare

namespace Cat.Decorators.Extensions;

/// <summary>
/// Registration helpers for the decorators module.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registers the decorator factory and its builder.
    /// Safe to call more than once. A service that is already registered is skipped.
    /// </summary>
    /// <param name="services">The service collection to add to.</param>
    public static void AddCatDecoratorsModule(this IServiceCollection services)
    {
        if (services.HasRegistrationFor<ICatDecoratorFactory>() == false)
        {
            services.AddSingleton<ICatDecoratorFactory, CatDecoratorFactory>();
        }

        if (services.HasRegistrationFor<ICatDecoratorFactoryBuilder>() == false)
        {
            services.AddSingleton<ICatDecoratorFactoryBuilder, CatDecoratorFactoryBuilder>();
        }
    }
}
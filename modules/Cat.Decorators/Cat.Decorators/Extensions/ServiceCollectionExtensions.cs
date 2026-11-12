using Cat.Decorators.Abstractions;
using System;
using Cat.ServiceCollection.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

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

    /// <summary>
    /// Checks the registered decorators at startup. It is off until you call it, so nobody pays for it by default.
    /// Call it on the built service provider, after every <c>AddCat...Decorator</c> call.
    /// It throws an <see cref="InvalidOperationException"/> for a decorator that can never be built,
    /// and it logs a warning for decorators of one service that have the same order number.
    /// The warnings need an <see cref="ILoggerFactory"/> in the service provider, and are skipped without one.
    /// </summary>
    /// <param name="serviceProvider">The built service provider. It must be able to resolve <see cref="ICatDecoratorFactory"/>.</param>
    /// <returns>The same service provider, so calls can be chained.</returns>
    /// <exception cref="InvalidOperationException">At least one decorator can never be built, or the factory is not a <see cref="CatDecoratorFactory"/>.</exception>
    public static IServiceProvider CheckCatDecorators(this IServiceProvider serviceProvider)
    {
        var factory = serviceProvider.GetRequiredService<ICatDecoratorFactory>() as CatDecoratorFactory
                      ?? throw new InvalidOperationException("The decorator factory must be a CatDecoratorFactory to be checked.");
        var logger = serviceProvider.GetService<ILoggerFactory>()?.CreateLogger("Cat.Decorators");

        factory.Check(logger);

        return serviceProvider;
    }
}
using System;
using Cat.Commands.Abstractions;
using Cat.Decorators.Abstractions;
using Microsoft.Extensions.DependencyInjection;

// ReSharper disable RedundantBoolCompare

namespace Cat.Commands.Decorators.Logging.Extensions;

/// <summary>
/// Registration helpers for the logging decorator.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds the logging decorator to all command handlers.
    /// </summary>
    /// <param name="serviceProvider">Must be able to resolve <see cref="ICatDecoratorFactoryBuilder"/>.</param>
    public static void AddCatCommandsModuleLoggingDecorator(this IServiceProvider serviceProvider)
    {
        var decoratorFactory = serviceProvider.GetRequiredService<ICatDecoratorFactoryBuilder>();
        decoratorFactory.AddDecorator(typeof(ICatCommandHandler<>), typeof(LoggingDecorator.CatCommandHandler<>));
    }
}
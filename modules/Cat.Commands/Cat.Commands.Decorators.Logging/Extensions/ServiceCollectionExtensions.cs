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
    /// Adds the logging decorator to all command handlers, with or without a result.
    /// </summary>
    /// <param name="serviceProvider">Must be able to resolve <see cref="ICatDecoratorFactoryBuilder"/>.</param>
    /// <param name="order">Where the decorator sits, from the outside in. The default is <see cref="CatDecoratorOrder.Logging"/>.</param>
    public static void AddCatCommandsModuleLoggingDecorator(this IServiceProvider serviceProvider, int? order = null)
    {
        var decoratorFactory = serviceProvider.GetRequiredService<ICatDecoratorFactoryBuilder>();
        var decoratorOrder = order ?? CatDecoratorOrder.Logging;
        decoratorFactory.AddDecorator(typeof(ICatCommandHandler<>), typeof(LoggingDecorator.CatCommandHandler<>), decoratorOrder);
        decoratorFactory.AddDecorator(typeof(ICatCommandHandler<,>), typeof(LoggingDecorator.CatCommandHandler<,>), decoratorOrder);
    }
}

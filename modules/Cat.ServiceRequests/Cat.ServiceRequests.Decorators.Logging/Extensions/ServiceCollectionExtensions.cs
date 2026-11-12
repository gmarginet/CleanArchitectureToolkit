using System;
using Cat.Decorators.Abstractions;
using Cat.ServiceRequests.Abstractions;
using Microsoft.Extensions.DependencyInjection;

// ReSharper disable RedundantBoolCompare

namespace Cat.ServiceRequests.Decorators.Logging.Extensions;

/// <summary>
/// Registration helpers for the logging decorator.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds the logging decorator to all service request handlers.
    /// </summary>
    /// <param name="serviceProvider">Must be able to resolve <see cref="ICatDecoratorFactoryBuilder"/>.</param>
    /// <param name="order">Where the decorator sits, from the outside in. The default is <see cref="CatDecoratorOrder.Logging"/>.</param>
    public static void AddCatServiceRequestsModuleLoggingDecorator(this IServiceProvider serviceProvider, int? order = null)
    {
        var decoratorFactory = serviceProvider.GetRequiredService<ICatDecoratorFactoryBuilder>();
        var decoratorOrder = order ?? CatDecoratorOrder.Logging;
        decoratorFactory.AddDecorator(typeof(ICatServiceRequestHandler<>), typeof(LoggingDecorator.CatServiceRequestHandler<>), decoratorOrder);
        decoratorFactory.AddDecorator(typeof(ICatServiceRequestHandler<,>), typeof(LoggingDecorator.CatServiceRequestHandler<,>), decoratorOrder);
    }
}

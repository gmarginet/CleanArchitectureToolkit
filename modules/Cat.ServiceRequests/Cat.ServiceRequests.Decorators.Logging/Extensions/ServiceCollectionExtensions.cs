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
    public static void AddCatServiceRequestsModuleLoggingDecorator(this IServiceProvider serviceProvider)
    {
        var decoratorFactory = serviceProvider.GetRequiredService<ICatDecoratorFactoryBuilder>();
        decoratorFactory.AddDecorator(typeof(ICatServiceRequestHandler<>), typeof(LoggingDecorator.CatServiceRequestHandler<>));
        decoratorFactory.AddDecorator(typeof(ICatServiceRequestHandler<,>), typeof(LoggingDecorator.CatServiceRequestHandler<,>));
    }
}
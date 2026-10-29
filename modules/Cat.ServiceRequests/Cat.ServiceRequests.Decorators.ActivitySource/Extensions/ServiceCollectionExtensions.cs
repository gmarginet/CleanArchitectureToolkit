using System;
using Cat.Decorators.Abstractions;
using Cat.ServiceRequests.Abstractions;
using Microsoft.Extensions.DependencyInjection;

// ReSharper disable RedundantBoolCompare

namespace Cat.ServiceRequests.Decorators.ActivitySource.Extensions;

/// <summary>
/// Registration helpers for the activity source decorator.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds the activity source decorator to all service request handlers.
    /// </summary>
    /// <param name="serviceProvider">Must be able to resolve <see cref="ICatDecoratorFactoryBuilder"/>.</param>
    public static void AddCatServiceRequestsModuleActivitySourceDecorator(this IServiceProvider serviceProvider)
    {
        var decoratorFactory = serviceProvider.GetRequiredService<ICatDecoratorFactoryBuilder>();
        decoratorFactory.AddDecorator(typeof(ICatServiceRequestHandler<>), typeof(ActivitySourceDecorator.CatServiceRequestHandler<>));
        decoratorFactory.AddDecorator(typeof(ICatServiceRequestHandler<,>), typeof(ActivitySourceDecorator.CatServiceRequestHandler<,>));
    }
}
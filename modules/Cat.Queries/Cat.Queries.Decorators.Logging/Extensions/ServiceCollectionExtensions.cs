using System;
using Cat.Decorators.Abstractions;
using Cat.Queries.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Cat.Queries.Decorators.Logging.Extensions;

/// <summary>
/// Registration helpers for the logging decorator.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds the logging decorator to all query handlers.
    /// </summary>
    /// <param name="serviceProvider">Must be able to resolve <see cref="ICatDecoratorFactoryBuilder"/>.</param>
    public static void AddCatQueriesModuleLoggingDecorator(this IServiceProvider serviceProvider)
    {
        var decoratorFactory = serviceProvider.GetRequiredService<ICatDecoratorFactoryBuilder>();
        decoratorFactory.AddDecorator(typeof(ICatQueryHandler<,>), typeof(LoggingDecorator.CatQueryHandler<,>));
    }
}
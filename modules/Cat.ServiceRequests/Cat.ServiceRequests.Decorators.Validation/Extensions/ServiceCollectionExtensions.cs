using System;
using Cat.Decorators;
using Cat.Decorators.Abstractions;
using Cat.ServiceRequests.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Cat.ServiceRequests.Decorators.Validation.Extensions;

// ReSharper disable RedundantBoolCompare
/// <summary>
/// Registration helpers for the validation decorator.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds the validation decorator to all service request handlers.
    /// </summary>
    /// <param name="serviceProvider">Must be able to resolve <see cref="ICatDecoratorFactoryBuilder"/>.</param>
    /// <param name="validationRequired">When <c>true</c>, a request without a validator counts as a failure.</param>
    /// <returns>The same service provider, so calls can be chained.</returns>
    public static IServiceProvider AddCatServiceRequestsModuleValidationDecorator(this IServiceProvider serviceProvider, bool validationRequired = false)
    {
        var decoratorFactory = serviceProvider.GetRequiredService<ICatDecoratorFactoryBuilder>();
        decoratorFactory.AddDecorator(typeof(ICatServiceRequestHandler<>), typeof(ValidationDecorator.CatServiceRequestHandler<>), new CatDecoratorParameter("validationRequired", validationRequired));
        decoratorFactory.AddDecorator(typeof(ICatServiceRequestHandler<,>), typeof(ValidationDecorator.CatServiceRequestHandler<,>), new CatDecoratorParameter("validationRequired", validationRequired));
        return serviceProvider;
    }
}
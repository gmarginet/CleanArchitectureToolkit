using System;
using System.Collections.Generic;
using System.Linq;
using Cat.Decorators.Abstractions;
using Microsoft.Extensions.DependencyInjection;
// ReSharper disable RedundantBoolCompare

namespace Cat.Decorators;

/// <summary>
/// Default <see cref="ICatDecoratorFactory"/>.
/// Gets the service from the service provider, then wraps it in each registered decorator in registration order.
/// </summary>
public class CatDecoratorFactory : ICatDecoratorFactory
{
    private readonly Dictionary<Type, List<CatDecoratorInfo>> _serviceTypes = [];

    /// <summary>
    /// Adds a decorator for a service. The first decorator you add is the innermost one.
    /// </summary>
    /// <param name="serviceType">The open generic service type.</param>
    /// <param name="decoratorType">The open generic decorator type. It needs exactly one public constructor.</param>
    /// <param name="decoratorParameterDictionary">Constructor values by parameter name, or <c>null</c> for none.</param>
    /// <exception cref="ArgumentException">The service type or the decorator type isn't an open generic type.</exception>
    public void AddDecorator(Type serviceType, Type decoratorType, Dictionary<string, object>? decoratorParameterDictionary)
    {
        if (serviceType.IsGenericTypeDefinition is false) throw new ArgumentException("Service type must be a generic type definition");
        if (decoratorType.IsGenericTypeDefinition is false) throw new ArgumentException("Decorator type must be a generic type definition");
        
        _serviceTypes.TryGetValue(serviceType, out var decoratorInfoList);

        if (decoratorInfoList is null)
        {
            decoratorInfoList = [];
            _serviceTypes.Add(serviceType, decoratorInfoList);
        }

        var decoratorInfo = new CatDecoratorInfo(decoratorType, decoratorParameterDictionary);
        
        decoratorInfoList.Add(decoratorInfo);
    }

    /// <inheritdoc />
    public TService? GetDecoratedService<TService>(IServiceProvider serviceProvider)
    {
        return (TService?)GetDecoratedService(serviceProvider, typeof(TService));
    }

    /// <inheritdoc />
    public TService GetRequiredDecoratedService<TService>(IServiceProvider serviceProvider)
    {
        return (TService)GetRequiredDecoratedService(serviceProvider, typeof(TService));
    }

    /// <inheritdoc />
    public object GetRequiredDecoratedService(IServiceProvider serviceProvider, Type serviceType)
    {
        var service = GetDecoratedService(serviceProvider, serviceType);
        return service ?? throw new InvalidOperationException($"No decorated service found for service type {serviceType}");
    }

    /// <inheritdoc />
    public object? GetDecoratedService(IServiceProvider serviceProvider, Type serviceType)
    {
        var key = serviceType.GetGenericTypeDefinition();
        _serviceTypes.TryGetValue(key, out var decoratorInfoList);

        var service = serviceProvider.GetService(serviceType);
        if (service is null || decoratorInfoList is null) return service;

        var genericArgs = serviceType.GetGenericArguments();
        foreach (var decoratorInfo in decoratorInfoList)
        {
            var decoratorType = decoratorInfo.DecoratorGenericTypeDefinition.MakeGenericType(genericArgs);
            var constructorParameters = GetConstructorParameterArray(serviceProvider, service, decoratorType, decoratorInfo.DecoratorParameterDictionary);
            service = Activator.CreateInstance(decoratorType, constructorParameters);
        }

        return service;
    }

    /// <summary>
    /// Fills the constructor of a decorator. For each parameter it picks, in this order:
    /// a value registered by name, the service being wrapped, or a service from the provider.
    /// </summary>
    private static object[] GetConstructorParameterArray(IServiceProvider serviceProvider, object service, Type decoratorType, IDictionary<string,object>? decoratorParameterDictionary)
    {
        List<object> result = [];

        var constructorParameterInfos = decoratorType
            .GetConstructors()
            .Single()
            .GetParameters();
        
        foreach (var constructorParameterInfo in constructorParameterInfos)
        {
            if (decoratorParameterDictionary is not null
                && decoratorParameterDictionary.Keys.Count > 0
                && decoratorParameterDictionary.TryGetValue(constructorParameterInfo.Name,
                    out var constructorParameterValue)
                && constructorParameterInfo.ParameterType.IsInstanceOfType(constructorParameterValue))
            {
                result.Add(constructorParameterValue);
                continue;
            }
            if (constructorParameterInfo.ParameterType.IsInstanceOfType(service))
            {
                result.Add(service);
                continue;
            }
            var foundService = serviceProvider.GetRequiredService(constructorParameterInfo.ParameterType);
            result.Add(foundService);
        }

        return result.ToArray();
    }
}
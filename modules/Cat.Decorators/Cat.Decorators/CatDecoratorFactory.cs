using System;
using System.Collections.Generic;
using System.Linq;
using Cat.Decorators.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
// ReSharper disable RedundantBoolCompare

namespace Cat.Decorators;

/// <summary>
/// Default <see cref="ICatDecoratorFactory"/>.
/// Gets the service from the service provider, then wraps it in each registered decorator, the highest order number first.
/// So the decorator with the lowest number ends up outermost. Decorators with the same number keep the sequence in which they were added.
/// </summary>
public class CatDecoratorFactory : ICatDecoratorFactory
{
    // Each list is kept sorted from the innermost decorator to the outermost one.
    private readonly Dictionary<Type, List<CatDecoratorInfo>> _serviceTypes = [];

    /// <summary>
    /// Adds a decorator for a service, with the order <see cref="CatDecoratorOrder.Default"/>.
    /// With equal order numbers, the first decorator you add is the innermost one.
    /// </summary>
    /// <param name="serviceType">The open generic service type.</param>
    /// <param name="decoratorType">The open generic decorator type. It needs exactly one public constructor.</param>
    /// <param name="decoratorParameterDictionary">Constructor values by parameter name, or <c>null</c> for none.</param>
    /// <exception cref="ArgumentException">The service type or the decorator type isn't an open generic type.</exception>
    public void AddDecorator(Type serviceType, Type decoratorType, Dictionary<string, object>? decoratorParameterDictionary)
    {
        AddDecorator(serviceType, decoratorType, CatDecoratorOrder.Default, decoratorParameterDictionary);
    }

    /// <summary>
    /// Adds a decorator for a service, with an order. A lower number is the outer decorator.
    /// With equal order numbers, the first decorator you add is the innermost one.
    /// </summary>
    /// <param name="serviceType">The open generic service type.</param>
    /// <param name="decoratorType">The open generic decorator type. It needs exactly one public constructor.</param>
    /// <param name="order">The order of the decorator, from the outside in.</param>
    /// <param name="decoratorParameterDictionary">Constructor values by parameter name, or <c>null</c> for none.</param>
    /// <exception cref="ArgumentException">The service type or the decorator type isn't an open generic type.</exception>
    public void AddDecorator(Type serviceType, Type decoratorType, int order, Dictionary<string, object>? decoratorParameterDictionary)
    {
        if (serviceType.IsGenericTypeDefinition is false) throw new ArgumentException("Service type must be a generic type definition");
        if (decoratorType.IsGenericTypeDefinition is false) throw new ArgumentException("Decorator type must be a generic type definition");

        _serviceTypes.TryGetValue(serviceType, out var decoratorInfoList);

        if (decoratorInfoList is null)
        {
            decoratorInfoList = [];
            _serviceTypes.Add(serviceType, decoratorInfoList);
        }

        var decoratorInfo = new CatDecoratorInfo(decoratorType, decoratorParameterDictionary, order);

        // The list runs from the innermost decorator (the highest number) to the outermost one (the lowest number).
        // A new decorator goes behind the ones with the same number, so the call sequence decides between equal numbers.
        var index = decoratorInfoList.FindIndex(existing => existing.Order < order);
        if (index < 0)
        {
            decoratorInfoList.Add(decoratorInfo);
        }
        else
        {
            decoratorInfoList.Insert(index, decoratorInfo);
        }
    }

    /// <summary>
    /// Checks the registered decorators, so a mistake shows up at startup and not at the first request.
    /// It throws for a decorator that can never be built: a decorator type without exactly one public constructor,
    /// one with another number of type arguments than its service, and one whose constructor does not take the service it wraps.
    /// It writes a warning for decorators of one service that have the same order number,
    /// because then the sequence of the calls decides, which is easy to forget.
    /// </summary>
    /// <param name="logger">Gets the warnings. Pass <c>null</c> to skip them.</param>
    /// <exception cref="InvalidOperationException">At least one decorator can never be built. The message lists every problem.</exception>
    public void Check(ILogger? logger = null)
    {
        var problems = new List<string>();

        foreach (var pair in _serviceTypes)
        {
            var serviceType = pair.Key;

            foreach (var info in pair.Value)
            {
                var problem = CheckDecorator(serviceType, info.DecoratorGenericTypeDefinition);
                if (problem is not null)
                {
                    problems.Add(problem);
                }
            }

            if (logger is null) continue;

            foreach (var group in pair.Value.GroupBy(info => info.Order).Where(group => group.Count() > 1))
            {
                var names = string.Join(", ", group.Select(info => info.DecoratorGenericTypeDefinition.Name));
                logger.LogWarning(
                    "The decorators {Decorators} of {ServiceType} have the same order {Order}. The sequence in which they were added decides.",
                    names, serviceType.Name, group.Key);
            }
        }

        if (problems.Count > 0)
        {
            throw new InvalidOperationException("The decorators are not valid: " + string.Join(" ", problems));
        }
    }

    private static string? CheckDecorator(Type serviceType, Type decoratorType)
    {
        var name = decoratorType.Name;

        if (decoratorType.GetGenericArguments().Length != serviceType.GetGenericArguments().Length)
        {
            return $"{name} has a different number of type arguments than {serviceType.Name}.";
        }

        var constructors = decoratorType.GetConstructors();
        if (constructors.Length != 1)
        {
            return $"{name} needs exactly one public constructor, and it has {constructors.Length}.";
        }

        // Close both types with the same placeholder types, so the constructor can be compared with the service.
        // A type with generic constraints can't be closed this way, so that check is skipped for it.
        try
        {
            var placeholders = serviceType.GetGenericArguments().Select(_ => typeof(object)).ToArray();
            var closedService = serviceType.MakeGenericType(placeholders);
            var closedDecorator = decoratorType.MakeGenericType(placeholders);
            var takesService = closedDecorator.GetConstructors().Single().GetParameters()
                .Any(parameter => parameter.ParameterType.IsAssignableFrom(closedService));

            if (takesService is false)
            {
                return $"{name} has no constructor parameter for the service it wraps, {serviceType.Name}.";
            }
        }
        catch (ArgumentException)
        {
            // A generic constraint stops the placeholder, so this decorator can't be checked further.
        }

        return null;
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
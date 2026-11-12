using System;
using System.Collections.Generic;

namespace Cat.Decorators.Abstractions;

/// <summary>
/// Registers decorators for open generic services.
/// </summary>
public interface ICatDecoratorFactoryBuilder
{
    /// <summary>
    /// Adds a decorator for a service, with the order <see cref="CatDecoratorOrder.Default"/>.
    /// A lower number is the outer decorator. When two decorators have the same number, the first one you add is the innermost one,
    /// and each later one wraps the one before it.
    /// </summary>
    /// <param name="serviceType">The open generic service type, like <c>typeof(IHandler&lt;&gt;)</c>.</param>
    /// <param name="decoratorType">The open generic decorator type. It needs exactly one public constructor.</param>
    /// <param name="decoratorParameters">Values for constructor parameters, matched by parameter name.</param>
    /// <exception cref="ArgumentException">The service type or the decorator type isn't an open generic type.</exception>
    void AddDecorator(Type serviceType, Type decoratorType, params ICatDecoratorParameter[] decoratorParameters);

    /// <summary>
    /// Adds a decorator for a service, with an order. A lower number is the outer decorator.
    /// Use the numbers of <see cref="CatDecoratorOrder"/>, or a number in between to slot a decorator of your own.
    /// When two decorators have the same number, the first one you add is the innermost one.
    /// </summary>
    /// <param name="serviceType">The open generic service type, like <c>typeof(IHandler&lt;&gt;)</c>.</param>
    /// <param name="decoratorType">The open generic decorator type. It needs exactly one public constructor.</param>
    /// <param name="order">The order of the decorator, from the outside in.</param>
    /// <param name="decoratorParameters">Values for constructor parameters, matched by parameter name.</param>
    /// <exception cref="ArgumentException">The service type or the decorator type isn't an open generic type.</exception>
    void AddDecorator(Type serviceType, Type decoratorType, int order, params ICatDecoratorParameter[] decoratorParameters);
}

using System;
using System.Collections.Generic;

namespace Cat.Decorators.Abstractions;

/// <summary>
/// Registers decorators for open generic services.
/// </summary>
public interface ICatDecoratorFactoryBuilder
{
    /// <summary>
    /// Adds a decorator for a service. The first decorator you add is the innermost one.
    /// Each later decorator wraps the one before it.
    /// </summary>
    /// <param name="serviceType">The open generic service type, like <c>typeof(IHandler&lt;&gt;)</c>.</param>
    /// <param name="decoratorType">The open generic decorator type. It needs exactly one public constructor.</param>
    /// <param name="decoratorParameters">Values for constructor parameters, matched by parameter name.</param>
    /// <exception cref="ArgumentException">The service type or the decorator type isn't an open generic type.</exception>
    void AddDecorator(Type serviceType, Type decoratorType, params ICatDecoratorParameter[] decoratorParameters);
}
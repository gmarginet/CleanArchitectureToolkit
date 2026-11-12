using System;
using System.Collections.Generic;
using Cat.Decorators.Abstractions;

namespace Cat.Decorators;

/// <summary>
/// Describes one registered decorator: its open generic type, its order and the constructor values to pass to it.
/// </summary>
public record CatDecoratorInfo
{
    /// <summary>
    /// Creates the description with the order <see cref="CatDecoratorOrder.Default"/>.
    /// </summary>
    /// <param name="decoratorGenericTypeDefinition">The open generic decorator type.</param>
    /// <param name="decoratorParameterDictionary">Constructor values by parameter name, or <c>null</c> for none.</param>
    public CatDecoratorInfo(Type decoratorGenericTypeDefinition, IDictionary<string,object>? decoratorParameterDictionary)
        : this(decoratorGenericTypeDefinition, decoratorParameterDictionary, CatDecoratorOrder.Default)
    {
    }

    /// <summary>
    /// Creates the description.
    /// </summary>
    /// <param name="decoratorGenericTypeDefinition">The open generic decorator type.</param>
    /// <param name="decoratorParameterDictionary">Constructor values by parameter name, or <c>null</c> for none.</param>
    /// <param name="order">The order of the decorator, from the outside in.</param>
    public CatDecoratorInfo(Type decoratorGenericTypeDefinition, IDictionary<string,object>? decoratorParameterDictionary, int order)
    {
        DecoratorGenericTypeDefinition = decoratorGenericTypeDefinition;
        DecoratorParameterDictionary = decoratorParameterDictionary;
        Order = order;
    }

    /// <summary>
    /// The open generic decorator type.
    /// </summary>
    public Type DecoratorGenericTypeDefinition { get; }

    /// <summary>
    /// Constructor values by parameter name, or <c>null</c> for none.
    /// </summary>
    public IDictionary<string,object>? DecoratorParameterDictionary { get; }

    /// <summary>
    /// The order of the decorator, from the outside in. A lower number is the outer decorator.
    /// </summary>
    public int Order { get; }
}

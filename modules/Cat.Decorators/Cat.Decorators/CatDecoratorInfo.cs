using System;
using System.Collections.Generic;

namespace Cat.Decorators;

/// <summary>
/// Describes one registered decorator: its open generic type and the constructor values to pass to it.
/// </summary>
public record CatDecoratorInfo
{
    /// <summary>
    /// Creates the description.
    /// </summary>
    /// <param name="decoratorGenericTypeDefinition">The open generic decorator type.</param>
    /// <param name="decoratorParameterDictionary">Constructor values by parameter name, or <c>null</c> for none.</param>
    public CatDecoratorInfo(Type decoratorGenericTypeDefinition, IDictionary<string,object>? decoratorParameterDictionary)
    {
        DecoratorGenericTypeDefinition = decoratorGenericTypeDefinition;
        DecoratorParameterDictionary = decoratorParameterDictionary;
    }

    /// <summary>
    /// The open generic decorator type.
    /// </summary>
    public Type DecoratorGenericTypeDefinition { get; }

    /// <summary>
    /// Constructor values by parameter name, or <c>null</c> for none.
    /// </summary>
    public IDictionary<string,object>? DecoratorParameterDictionary { get; }
}
using System;
using System.Linq;
using Cat.Decorators.Abstractions;

namespace Cat.Decorators;

/// <summary>
/// Default <see cref="ICatDecoratorFactoryBuilder"/>.
/// Hands the decorators over to the <see cref="CatDecoratorFactory"/>.
/// </summary>
public class CatDecoratorFactoryBuilder : ICatDecoratorFactoryBuilder
{
    private readonly CatDecoratorFactory _catDecoratorFactory;

    /// <summary>
    /// Creates the builder.
    /// </summary>
    /// <param name="decoratorFactory">Must be a <see cref="CatDecoratorFactory"/>.</param>
    public CatDecoratorFactoryBuilder(ICatDecoratorFactory decoratorFactory)
    {
        _catDecoratorFactory = (CatDecoratorFactory)decoratorFactory;
    }

    /// <inheritdoc />
    public void AddDecorator(Type serviceType, Type decoratorType, params ICatDecoratorParameter[] decoratorParameters)
    {
        _catDecoratorFactory.AddDecorator(serviceType, decoratorType, decoratorParameters.ToDictionary(x => x.Name, x => x.Value));
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using Cat.Decorators.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Cat.UnitTesting.NUnit;

/// <summary>
/// An <see cref="ICatDecoratorFactoryBuilder"/> that only records the calls, so a test can check
/// which decorator a module adds and with which order.
/// </summary>
public sealed class RecordingDecoratorBuilder : ICatDecoratorFactoryBuilder
{
    /// <summary>
    /// The decorators that were added, in the sequence of the calls.
    /// </summary>
    public List<RecordedDecorator> Added { get; } = [];

    /// <summary>
    /// Creates a service provider that hands out this builder, to pass to an <c>AddCat...Decorator</c> method.
    /// </summary>
    public IServiceProvider CreateServiceProvider()
    {
        var services = new ServiceCollection();
        services.AddSingleton<ICatDecoratorFactoryBuilder>(this);
        return services.BuildServiceProvider();
    }

    /// <inheritdoc />
    public void AddDecorator(Type serviceType, Type decoratorType, params ICatDecoratorParameter[] decoratorParameters)
    {
        AddDecorator(serviceType, decoratorType, CatDecoratorOrder.Default, decoratorParameters);
    }

    /// <inheritdoc />
    public void AddDecorator(Type serviceType, Type decoratorType, int order, params ICatDecoratorParameter[] decoratorParameters)
    {
        Added.Add(new RecordedDecorator(serviceType, decoratorType, order, decoratorParameters.ToDictionary(x => x.Name, x => x.Value)));
    }
}

/// <summary>
/// One recorded call of <see cref="RecordingDecoratorBuilder.AddDecorator(System.Type,System.Type,int,Cat.Decorators.Abstractions.ICatDecoratorParameter[])"/>.
/// </summary>
public sealed record RecordedDecorator(Type ServiceType, Type DecoratorType, int Order, IDictionary<string, object> Parameters);

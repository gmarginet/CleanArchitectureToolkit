namespace Cat.Decorators.Abstractions;

/// <summary>
/// A fixed value for one constructor parameter of a decorator.
/// </summary>
public interface ICatDecoratorParameter
{
    /// <summary>
    /// The name of the constructor parameter.
    /// </summary>
    string Name { get;  }

    /// <summary>
    /// The value to pass. Its type must fit the parameter type.
    /// </summary>
    object Value { get;  }
}
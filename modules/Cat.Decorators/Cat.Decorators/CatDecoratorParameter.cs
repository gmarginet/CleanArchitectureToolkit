using Cat.Decorators.Abstractions;

namespace Cat.Decorators;

/// <summary>
/// Default <see cref="ICatDecoratorParameter"/>.
/// </summary>
public record CatDecoratorParameter : ICatDecoratorParameter
{
    /// <summary>
    /// Creates the parameter.
    /// </summary>
    /// <param name="name">The name of the constructor parameter.</param>
    /// <param name="value">The value to pass.</param>
    public CatDecoratorParameter(string name, object value)
    {
        Name = name;
        Value = value;
    }

    /// <inheritdoc />
    public string Name { get; }

    /// <inheritdoc />
    public object Value { get; }
}
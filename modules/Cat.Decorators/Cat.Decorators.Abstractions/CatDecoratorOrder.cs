namespace Cat.Decorators.Abstractions;

/// <summary>
/// The default order of the decorators, from the outside in. A lower number runs first on the way in and last on the way out.
/// Every module that ships a decorator uses one of these numbers as its default, so the order is the same
/// whatever the sequence in which you add the decorators.
/// The numbers are spaced out in steps of 100, so you can slot a decorator of your own in between, for example 250.
/// </summary>
public static class CatDecoratorOrder
{
    /// <summary>
    /// Tracing, the outermost decorator. It sees every request, so the trace covers all the other work.
    /// </summary>
    public const int Tracing = 100;

    /// <summary>
    /// Logging. It logs every request, also the ones that validation turns down.
    /// </summary>
    public const int Logging = 200;

    /// <summary>
    /// Validation. It lets only valid requests through to the decorators and the handler that follow.
    /// </summary>
    public const int Validation = 400;

    /// <summary>
    /// The number of a decorator that is added without an order, after validation. It sees valid input.
    /// </summary>
    public const int Default = 450;
}

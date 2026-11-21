namespace Cat.Resilience.Abstractions;

/// <summary>
/// How the delay between two tries grows.
/// </summary>
public enum CatBackoffType
{
    /// <summary>
    /// Every try waits the same delay.
    /// </summary>
    Constant,

    /// <summary>
    /// The delay grows with every try, by the same step.
    /// </summary>
    Linear,

    /// <summary>
    /// The delay doubles with every try.
    /// </summary>
    Exponential
}

namespace Cat.Validators.Abstractions;

/// <summary>
/// Describes the rules for one model type.
/// Implement it once per model. The module finds and registers it for you.
/// </summary>
/// <typeparam name="TModel">The type being validated.</typeparam>
public interface ICatValidator<TModel>
    where TModel : class
{
    /// <summary>
    /// Adds the rules for the model.
    /// </summary>
    /// <param name="b">Collects the rules.</param>
    void Build(ICatValidatorBuilder<TModel> b);
}
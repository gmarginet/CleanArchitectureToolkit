namespace Cat.Validators.Abstractions;

/// <summary>
/// Sets options on the rule you just added, like a condition, a field name or a message.
/// </summary>
/// <typeparam name="TModel">The type being validated.</typeparam>
/// <typeparam name="TProperty">The type of the property.</typeparam>
public interface ICatValidatorPropertyRuleOptionsBuilder<TModel, TProperty>
    where TModel : class
{
    /// <summary>
    /// The rule the options apply to.
    /// </summary>
    ICatValidatorPropertyRule<TModel, TProperty> Rule { get; }
}
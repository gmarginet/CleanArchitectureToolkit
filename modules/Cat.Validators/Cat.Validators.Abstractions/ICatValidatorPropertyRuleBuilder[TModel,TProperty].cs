namespace Cat.Validators.Abstractions;

/// <summary>
/// Adds rules for one property. The built-in rules are extension methods on this interface.
/// </summary>
/// <typeparam name="TModel">The type being validated.</typeparam>
/// <typeparam name="TProperty">The type of the property.</typeparam>
public interface ICatValidatorPropertyRuleBuilder<TModel, TProperty>
    where TModel : class
{
    /// <summary>
    /// Adds a rule for the property.
    /// </summary>
    /// <typeparam name="TRule">The type of the rule.</typeparam>
    /// <param name="rule">The rule to add.</param>
    /// <returns>A builder for the rule options, like a condition or a custom message.</returns>
    ICatValidatorPropertyRuleOptionsBuilder<TModel, TProperty> AddPropertyRule<TRule>(TRule rule)
        where TRule : class, ICatValidatorPropertyRule<TModel, TProperty>;
}
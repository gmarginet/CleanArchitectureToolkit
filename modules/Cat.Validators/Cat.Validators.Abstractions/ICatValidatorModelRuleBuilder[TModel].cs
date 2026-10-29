namespace Cat.Validators.Abstractions;

/// <summary>
/// Adds rules that look at the whole model.
/// </summary>
/// <typeparam name="TModel">The type being validated.</typeparam>
public interface ICatValidatorModelRuleBuilder<TModel>
    where TModel : class
{
    /// <summary>
    /// Adds a rule to the validator.
    /// </summary>
    /// <typeparam name="TRule">The type of the rule.</typeparam>
    /// <param name="rule">The rule to add.</param>
    void AddRule<TRule>(TRule rule)
        where TRule : class, ICatValidatorModelRule<TModel>;
}
using Cat.Validators.Abstractions;

namespace Cat.Validators;

/// <summary>
/// Default <see cref="ICatValidatorPropertyRuleOptionsBuilder{TModel,TProperty}"/>.
/// </summary>
/// <typeparam name="TModel">The type being validated.</typeparam>
/// <typeparam name="TProperty">The type of the property.</typeparam>
public class CatValidatorPropertyRuleOptionsBuilder<TModel, TProperty>(
    ICatValidatorPropertyRule<TModel, TProperty> rule
) : ICatValidatorPropertyRuleOptionsBuilder<TModel, TProperty>
    where TModel : class
{
    /// <inheritdoc />
    public ICatValidatorPropertyRule<TModel, TProperty> Rule => rule;
}
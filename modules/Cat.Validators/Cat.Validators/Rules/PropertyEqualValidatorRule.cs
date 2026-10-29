using System;
using System.Collections.Generic;
using Cat.Validators.Abstractions;

namespace Cat.Validators.Rules;

/// <summary>
/// Passes when the value equals the given value.
/// Fails with <see cref="CatValidatorErrorDefinitions.Equal"/> otherwise.
/// </summary>
/// <typeparam name="TModel">The type being validated.</typeparam>
/// <typeparam name="TProperty">The type of the property.</typeparam>
internal class PropertyEqualValidatorRule<TModel, TProperty>(
    TProperty valueToCompare,
    IEqualityComparer<TProperty?>? comparer = null
) : CatValidatorPropertyRuleBase<TModel, TProperty>
    where TModel : class
{
    private IEqualityComparer<TProperty?>? _comparer = comparer;

    protected override List<ICatValidatorError> Validate(TProperty value, string fieldName, TModel model)
    {
        _comparer ??= value switch
        {
            string => (IEqualityComparer<TProperty?>)StringComparer.Ordinal,
            _ => EqualityComparer<TProperty?>.Default
        };
            
        if (_comparer.Equals(valueToCompare, value)) return CatValidatorResult.Valid();

        return CatValidatorResult.Invalid(
            CatValidatorError.Create(
                code: ErrorCode ?? CatValidatorErrorDefinitions.Equal.Code,
                fieldName: FieldName ?? fieldName,
                message: ErrorMessage ?? CatValidatorErrorDefinitions.Equal.Message,
                valueToCompare
            )
        );
    }
}
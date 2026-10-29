using System.Collections;
using System.Collections.Generic;
using Cat.Enumerable.Extensions;
using Cat.Validators.Abstractions;

namespace Cat.Validators.Rules;

/// <summary>
/// Passes when the value is <c>null</c>, a blank string, an empty collection or the default value of its type.
/// Fails with <see cref="CatValidatorErrorDefinitions.Empty"/> otherwise.
/// </summary>
/// <typeparam name="TModel">The type being validated.</typeparam>
/// <typeparam name="TProperty">The type of the property.</typeparam>
internal class PropertyEmptyValidatorRule<TModel, TProperty>
    : CatValidatorPropertyRuleBase<TModel, TProperty>
    where TModel : class
{
    protected override List<ICatValidatorError> Validate(TProperty value, string fieldName, TModel model)
    {
        if (value == null) return CatValidatorResult.Valid();

        var isValid = value switch
        {
            string s => string.IsNullOrWhiteSpace(s),
            ICollection c => c.Count == 0,
            IEnumerable e => e.IsEmpty(),
            _ => EqualityComparer<TProperty?>.Default.Equals(value, default)
        };

        
        return isValid
            ? CatValidatorResult.Valid()
            : CatValidatorResult.Invalid(
                CatValidatorError.Create(
                    code: ErrorCode ?? CatValidatorErrorDefinitions.Empty.Code,
                    fieldName: FieldName ?? fieldName,
                    message: ErrorMessage ?? CatValidatorErrorDefinitions.Empty.Message
                )
            );
    }
}
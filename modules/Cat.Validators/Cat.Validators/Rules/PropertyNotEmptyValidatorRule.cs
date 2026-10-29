using System.Collections;
using System.Collections.Generic;
using Cat.Enumerable.Extensions;
using Cat.Validators.Abstractions;

// ReSharper disable RedundantBoolCompare

namespace Cat.Validators.Rules;

/// <summary>
/// Passes when the value is not <c>null</c>, not a blank string, not an empty collection and not the default value of its type.
/// Fails with <see cref="CatValidatorErrorDefinitions.NotEmpty"/> otherwise.
/// </summary>
/// <typeparam name="TModel">The type being validated.</typeparam>
/// <typeparam name="TProperty">The type of the property.</typeparam>
internal class PropertyNotEmptyValidatorRule<TModel, TProperty>
    : CatValidatorPropertyRuleBase<TModel, TProperty>
    where TModel : class
{
    protected override List<ICatValidatorError> Validate(TProperty value, string fieldName, TModel model)
    {
        if (value == null) return CatValidatorResult.Invalid(
            CatValidatorError.Create(
                code: ErrorCode ?? CatValidatorErrorDefinitions.NotEmpty.Code,
                fieldName: FieldName ?? fieldName,
                message: ErrorMessage ?? CatValidatorErrorDefinitions.NotEmpty.Message
            )
        );

        var isValid = value switch
        {
            string s => string.IsNullOrWhiteSpace(s) is false,
            ICollection c => c.Count > 0,
            IEnumerable e => e.IsEmpty() is false,
            _ => EqualityComparer<TProperty?>.Default.Equals(value, default) is false
        };

        
        return isValid
            ? CatValidatorResult.Valid()
            : CatValidatorResult.Invalid(
                CatValidatorError.Create(
                    code: ErrorCode ?? CatValidatorErrorDefinitions.NotEmpty.Code,
                    fieldName: FieldName ?? fieldName,
                    message: ErrorMessage ?? CatValidatorErrorDefinitions.NotEmpty.Message
                )
            );
    }
}
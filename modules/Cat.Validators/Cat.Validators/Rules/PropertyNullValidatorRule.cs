using System.Collections.Generic;
using Cat.Validators.Abstractions;

namespace Cat.Validators.Rules;

/// <summary>
/// Passes when the value is <c>null</c>.
/// Fails with <see cref="CatValidatorErrorDefinitions.Null"/> otherwise.
/// </summary>
/// <typeparam name="TModel">The type being validated.</typeparam>
/// <typeparam name="TProperty">The type of the property.</typeparam>
internal class PropertyNullValidatorRule<TModel, TProperty>
    : CatValidatorPropertyRuleBase<TModel, TProperty>
    where TModel : class
{
    protected override List<ICatValidatorError> Validate(TProperty value, string fieldName, TModel model)
    {
        return value is null
            ? CatValidatorResult.Valid()
            : CatValidatorResult.Invalid(
                CatValidatorError.Create(
                    code: ErrorCode ?? CatValidatorErrorDefinitions.Null.Code,
                    fieldName: FieldName ?? fieldName,
                    message: ErrorMessage ?? CatValidatorErrorDefinitions.Null.Message
                )
            );
    }
}
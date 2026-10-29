using System.Collections.Generic;
using Cat.Validators.Abstractions;

namespace Cat.Validators.Rules;

/// <summary>
/// Passes when the value is not <c>null</c>.
/// Fails with <see cref="CatValidatorErrorDefinitions.NotNull"/> otherwise.
/// </summary>
/// <typeparam name="TModel">The type being validated.</typeparam>
/// <typeparam name="TProperty">The type of the property.</typeparam>
internal class PropertyNotNullValidatorRule<TModel, TProperty>
    : CatValidatorPropertyRuleBase<TModel, TProperty>
    where TModel : class
{
    protected override List<ICatValidatorError> Validate(TProperty value, string fieldName, TModel model)
    {
        return value is not null
            ? CatValidatorResult.Valid()
            : CatValidatorResult.Invalid(
                CatValidatorError.Create(
                    code: ErrorCode ?? CatValidatorErrorDefinitions.NotNull.Code,
                    fieldName: FieldName ?? fieldName,
                    message: ErrorMessage ?? CatValidatorErrorDefinitions.NotNull.Message
                )
            );
    }
}
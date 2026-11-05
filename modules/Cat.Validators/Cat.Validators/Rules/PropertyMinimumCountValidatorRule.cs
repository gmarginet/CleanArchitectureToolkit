using System;
using System.Collections;
using System.Collections.Generic;
using Cat.Validators.Abstractions;

namespace Cat.Validators.Rules;

/// <summary>
/// Passes when the collection has at least the minimum number of items. A <c>null</c> collection passes.
/// Fails with <see cref="CatValidatorErrorDefinitions.MinimumCount"/> otherwise.
/// </summary>
/// <typeparam name="TModel">The type being validated.</typeparam>
/// <typeparam name="TProperty">The type of the collection.</typeparam>
internal class PropertyMinimumCountValidatorRule<TModel, TProperty>(
    Func<TModel, int> minimumCountFunc
) : CatValidatorPropertyRuleBase<TModel, TProperty>
    where TModel : class
    where TProperty : IEnumerable?
{
    protected override List<ICatValidatorError> Validate(TProperty value, string fieldName, TModel model)
    {
        if (value is null) return CatValidatorResult.Valid();

        var minimumCount = minimumCountFunc(model);
        var count = CollectionCount.Of(value);

        if (count >= minimumCount) return CatValidatorResult.Valid();

        return CatValidatorResult.Invalid(
            CatValidatorError.Create(
                code: ErrorCode ?? CatValidatorErrorDefinitions.MinimumCount.Code,
                fieldName: FieldName ?? fieldName,
                message: ErrorMessage ?? CatValidatorErrorDefinitions.MinimumCount.Message,
                minimumCount,
                count
            )
        );
    }
}

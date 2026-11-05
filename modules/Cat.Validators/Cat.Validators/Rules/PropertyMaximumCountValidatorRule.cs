using System;
using System.Collections;
using System.Collections.Generic;
using Cat.Validators.Abstractions;

namespace Cat.Validators.Rules;

/// <summary>
/// Passes when the collection has no more than the maximum number of items. A <c>null</c> collection passes.
/// Fails with <see cref="CatValidatorErrorDefinitions.MaximumCount"/> otherwise.
/// </summary>
/// <typeparam name="TModel">The type being validated.</typeparam>
/// <typeparam name="TProperty">The type of the collection.</typeparam>
internal class PropertyMaximumCountValidatorRule<TModel, TProperty>(
    Func<TModel, int> maximumCountFunc
) : CatValidatorPropertyRuleBase<TModel, TProperty>
    where TModel : class
    where TProperty : IEnumerable?
{
    protected override List<ICatValidatorError> Validate(TProperty value, string fieldName, TModel model)
    {
        if (value is null) return CatValidatorResult.Valid();

        var maximumCount = maximumCountFunc(model);
        var count = CollectionCount.Of(value);

        if (count <= maximumCount) return CatValidatorResult.Valid();

        return CatValidatorResult.Invalid(
            CatValidatorError.Create(
                code: ErrorCode ?? CatValidatorErrorDefinitions.MaximumCount.Code,
                fieldName: FieldName ?? fieldName,
                message: ErrorMessage ?? CatValidatorErrorDefinitions.MaximumCount.Message,
                maximumCount,
                count
            )
        );
    }
}

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Cat.Object.Extensions;
using Cat.Objects.Extensions;
using Cat.Validators.Abstractions;

namespace Cat.Validators.Rules;

/// <summary>
/// Passes when the value is less than another property of the model.
/// Fails with <see cref="CatValidatorErrorDefinitions.LessThan"/> otherwise.
/// </summary>
/// <typeparam name="TModel">The type being validated.</typeparam>
/// <typeparam name="TProperty">The type of the property.</typeparam>
internal class PropertyLessThanWithFuncValidatorRule<TModel, TProperty>(
    Expression<Func<TModel, TProperty>> expression
) : CatValidatorPropertyRuleBase<TModel, TProperty>
    where TModel : class
    where TProperty : IComparable<TProperty>, IComparable
{
    protected override List<ICatValidatorError> Validate(TProperty value, string fieldName, TModel model)
    {
        CompiledMemberExpressionCache.ThrowIfNull(nameof(CompiledMemberExpressionCache));
        expression.ThrowIfNull(nameof(expression));

        var valueToCompareFunc = CompiledMemberExpressionCache.GetOrAdd(expression);
        var valueToCompare = valueToCompareFunc(model);

        if (value.CompareTo(valueToCompare) < 0) return CatValidatorResult.Valid();

        return CatValidatorResult.Invalid(
            CatValidatorError.Create(
                code: ErrorCode ?? CatValidatorErrorDefinitions.LessThan.Code,
                fieldName: FieldName ?? fieldName,
                message: ErrorMessage ?? CatValidatorErrorDefinitions.LessThan.Message,
                valueToCompare
            )
        );
    }
}

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Cat.Object.Extensions;
using Cat.Objects.Extensions;
using Cat.Validators.Abstractions;

namespace Cat.Validators.Rules;

/// <summary>
/// Passes when the value doesn't equal another property of the model.
/// Fails with <see cref="CatValidatorErrorDefinitions.NotEqual"/> otherwise.
/// </summary>
/// <typeparam name="TModel">The type being validated.</typeparam>
/// <typeparam name="TProperty">The type of the property.</typeparam>
internal class PropertyNotEqualWithFuncValidatorRule<TModel, TProperty>(
    Expression<Func<TModel, TProperty>> expression,
    IEqualityComparer<TProperty?>? comparer = null
) : CatValidatorPropertyRuleBase<TModel, TProperty>
    where TModel : class
{
    private IEqualityComparer<TProperty?>? _comparer = comparer;

    protected override List<ICatValidatorError> Validate(TProperty value, string fieldName, TModel model)
    {
        CompiledMemberExpressionCache.ThrowIfNull(nameof(CompiledMemberExpressionCache));
        expression.ThrowIfNull(nameof(expression));

        var valueToCompareFunc = CompiledMemberExpressionCache.GetOrAdd(expression);
        
        _comparer ??= value switch
        {
            string => (IEqualityComparer<TProperty?>)StringComparer.Ordinal,
            _ => EqualityComparer<TProperty?>.Default
        };
            
        var valueToCompare = valueToCompareFunc(model);
            
        if (_comparer.Equals(valueToCompare, value) is false) return CatValidatorResult.Valid();

        return CatValidatorResult.Invalid(
            CatValidatorError.Create(
                code: ErrorCode ?? CatValidatorErrorDefinitions.NotEqual.Code,
                fieldName: FieldName ?? fieldName,
                message: ErrorMessage ?? CatValidatorErrorDefinitions.NotEqual.Message,
                valueToCompare
            )
        );
    }
}
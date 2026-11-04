using System;
using System.Collections.Generic;
using Cat.Expressions.Abstractions;
using Cat.Object.Extensions;
using Cat.Objects.Extensions;
using Cat.Validators.Abstractions;

namespace Cat.Validators.Rules;

/// <summary>
/// Runs a check on a nullable value type, like <c>decimal?</c>.
/// A <c>null</c> value passes. Otherwise the check decides.
/// </summary>
/// <typeparam name="TModel">The type being validated.</typeparam>
/// <typeparam name="TProperty">The value type behind the nullable property.</typeparam>
/// <param name="code">The error code when the check fails.</param>
/// <param name="message">The error message when the check fails.</param>
/// <param name="check">Gets the value, the model and the expression cache. Returns <c>null</c> when the value is valid, or the error arguments when it is not.</param>
internal class PropertyNullableValidatorRule<TModel, TProperty>(
    string code,
    string message,
    Func<TProperty, TModel, ICatCompiledMemberExpressionCache<TModel>, object?[]?> check
) : CatValidatorPropertyRuleBase<TModel, TProperty?>
    where TModel : class
    where TProperty : struct
{
    protected override List<ICatValidatorError> Validate(TProperty? value, string fieldName, TModel model)
    {
        if (value is null) return CatValidatorResult.Valid();

        var arguments = check(
            value.Value,
            model,
            CompiledMemberExpressionCache.ThrowIfNull(nameof(CompiledMemberExpressionCache)));

        if (arguments is null) return CatValidatorResult.Valid();

        return CatValidatorResult.Invalid(
            CatValidatorError.Create(
                code: ErrorCode ?? code,
                fieldName: FieldName ?? fieldName,
                message: ErrorMessage ?? message,
                arguments
            )
        );
    }
}

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Cat.Object.Extensions;
using Cat.Objects.Extensions;
using Cat.Validators.Abstractions;

namespace Cat.Validators.Rules;

/// <summary>
/// Validates a property with its own validator.
/// Prefixes the field name of every error with the property name.
/// A <c>null</c> property passes. A property without a validator is skipped only when the top level call
/// has <c>validatorRequired</c> set to <c>false</c>. Otherwise it throws.
/// </summary>
/// <typeparam name="TModel">The type being validated.</typeparam>
/// <typeparam name="TProperty">The type of the property.</typeparam>
internal class PropertyValidateValidatorRule<TModel, TProperty>
    : CatValidatorPropertyRuleAsyncBase<TModel, TProperty>
    where TModel : class
    where TProperty : class?
{
    protected override async Task<List<ICatValidatorError>> ValidateAsync(TProperty value, string fieldName, TModel model, CancellationToken ct)
    {
        // ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
        if (value is null) return CatValidatorResult.Valid();

        ValidatorProcessor.ThrowIfNull(nameof(ValidatorProcessor));

        // TProperty may be nullable, but value is known to be non-null here.
#pragma warning disable CS8634
        var validationErrorDetailsList = await ValidatorProcessor.InternalValidateAsync(value, ValidatorRequired, ct);
#pragma warning restore CS8634

        var parentFieldName = FieldName ?? fieldName;
        foreach (var validationErrorDetails in validationErrorDetailsList)
        {
            validationErrorDetails.FieldName = $"{parentFieldName}.{validationErrorDetails.FieldName}";
        }
            
        return validationErrorDetailsList.Count <= 0
            ? CatValidatorResult.Valid()
            : CatValidatorResult.Invalid([.. validationErrorDetailsList]);
    }
}
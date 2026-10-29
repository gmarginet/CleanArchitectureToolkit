using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Cat.Object.Extensions;
using Cat.Objects.Extensions;
using Cat.Responses.Abstractions;
using Cat.Validators.Abstractions;

namespace Cat.Validators.Rules;

/// <summary>
/// Validates each item of a collection with its own validator.
/// Prefixes the field name of every error with the property name and the item index.
/// A <c>null</c> item is skipped but still counts for the index. An item without a validator is skipped only when the top level call
/// has <c>validatorRequired</c> set to <c>false</c>. Otherwise it throws.
/// </summary>
/// <typeparam name="TModel">The type being validated.</typeparam>
/// <typeparam name="TProperty">The type of the collection.</typeparam>
internal class EnumerablePropertyValidateValidatorRule<TModel, TProperty>
    : CatValidatorPropertyRuleAsyncBase<TModel, TProperty>
    where TModel : class
    where TProperty : IEnumerable?
{
    private readonly MethodInfo _internalValidateAsyncMethod;
    public EnumerablePropertyValidateValidatorRule()
    {
        var validatorProcessorType = typeof(CatValidatorProcessor);
        var internalValidateAsyncMethod = validatorProcessorType.GetMethod("InternalValidateAsync", BindingFlags.NonPublic | BindingFlags.Instance);
        internalValidateAsyncMethod.ThrowIfNull(nameof(internalValidateAsyncMethod));
        _internalValidateAsyncMethod = internalValidateAsyncMethod!;
    }
    
    protected override async Task<List<ICatValidatorError>> ValidateAsync(TProperty enumerableValue, string fieldName, TModel model, CancellationToken ct)
    {
        if (enumerableValue is null) return CatValidatorResult.Valid();

        ValidatorProcessor.ThrowIfNull(nameof(ValidatorProcessor));

        var result = new List<ICatValidatorError>();

        var index = 0;
        var enumerator = enumerableValue.GetEnumerator();
        using (enumerator as IDisposable)
        {
            while (enumerator.MoveNext())
            {
                if (enumerator.Current is null)
                {
                    index++;
                    continue;
                }

                var method = _internalValidateAsyncMethod.MakeGenericMethod(enumerator.Current.GetType());
                var validationErrorListTask = method.Invoke(ValidatorProcessor, [enumerator.Current, ValidatorRequired, ct]) as Task<List<ICatValidatorError>>;
                if (validationErrorListTask is null) throw new InvalidOperationException("InternalValidateAsync method returned null");
                var validationErrorList = await validationErrorListTask;

                var parentFieldName = FieldName ?? fieldName;
                foreach (var validationError in validationErrorList)
                {
                    validationError.FieldName = $"{parentFieldName}[{index}].{validationError.FieldName}";
                }

                result.AddRange(validationErrorList);
                index++;
            }
        }
            
        return result.Count <= 0
            ? CatValidatorResult.Valid()
            : CatValidatorResult.Invalid([.. result]);
    }
}
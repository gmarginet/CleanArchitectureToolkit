using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Cat.Expressions.Abstractions;
using Cat.Responses;
using Cat.Responses.Abstractions;
using Cat.Validators.Abstractions;
using Cat.Validators.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Nito.AsyncEx;

namespace Cat.Validators;

/// <summary>
/// Default <see cref="ICatValidatorProcessor"/>.
/// Gets the validator for a model, builds its rules and runs each one whose conditions allow it.
/// Every rule runs, so one call reports all the failures.
/// </summary>
/// <param name="serviceProvider">Resolves validators and the expression cache.</param>
public class CatValidatorProcessor(
    IServiceProvider serviceProvider
) : ICatValidatorProcessor
{
    /// <summary>
    /// Runs the rules and returns the raw failures. Nested validation uses this to get at the field names.
    /// The <paramref name="validatorRequired"/> flag also goes to the nested rules, so they follow the top level.
    /// </summary>
    internal async Task<List<ICatValidatorError>> InternalValidateAsync<T>(T model, bool validatorRequired = true, CancellationToken ct = default)
        where T : class
    {
        ICatValidator<T>? validator;
        if (validatorRequired)
        {
            validator = serviceProvider.GetRequiredService<ICatValidator<T>>();
        }
        else
        {
            validator = serviceProvider.GetService<ICatValidator<T>>();
            if (validator is null) return [];
        }

        var compiledMemberExpressionCache = serviceProvider.GetRequiredService<ICatCompiledMemberExpressionCache<T>>();
        var validatorBuilder = new CatValidatorBuilder<T>(compiledMemberExpressionCache, this, validatorRequired);
        validator.Build(validatorBuilder);

        var errorList = new List<ICatValidatorError>();
        // ReSharper disable once ForeachCanBePartlyConvertedToQueryUsingAnotherGetEnumerator
        foreach (var rule in validatorBuilder.Rules)
        {
            var conditionTasks = rule.RulesConditionFuncAsyncList.Select(f => f.Invoke(model, ct)).ToList();
            await Task.WhenAll(conditionTasks);
            var conditionResults = conditionTasks.Select(t => t.Result).ToList();
            // ReSharper disable once RedundantBoolCompare
            if (conditionResults.Any(x => x is false)) continue;
            
            var validationResult = await rule.ValidateAsync(model, ct);

            if (validationResult.Count <= 0) continue;
            
            errorList.AddRange(validationResult);
        }

        return errorList;
    }

    /// <inheritdoc />
    public async Task<ICatResponse> ValidateAsync<T>(T model, bool validatorRequired = true,
        CancellationToken ct = default)
        where T : class
    {
        var errorList = await InternalValidateAsync(model, validatorRequired, ct);
        return errorList.Count <= 0
            ? CatResponse.Ok()
            : CatResponse.BadRequest([.. errorList.Select(x => x.ToCatError())]);
    }

    /// <inheritdoc />
    public ICatResponse Validate<T>(T model, bool validatorRequired = true) where T : class
    {
        return AsyncContext.Run(() => ValidateAsync(model, validatorRequired));
    }
}
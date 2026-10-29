using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Cat.Validators.Abstractions;

/// <summary>
/// A rule that checks a model and returns the failures it finds.
/// </summary>
/// <typeparam name="TModel">The type being validated.</typeparam>
public interface ICatValidatorModelRule<TModel>
    where TModel : class
{
    /// <summary>
    /// Conditions that decide whether the rule runs. The rule is skipped when any of them returns <c>false</c>.
    /// </summary>
    ConcurrentBag<Func<TModel, CancellationToken, Task<bool>>> RulesConditionFuncAsyncList { get; }

    /// <summary>
    /// Runs the rule.
    /// </summary>
    /// <param name="model">The model to check.</param>
    /// <param name="ct">Token to cancel the work.</param>
    /// <returns>The failures found. The list is empty when the model is valid.</returns>
    Task<List<ICatValidatorError>> ValidateAsync(TModel model, CancellationToken ct);
}
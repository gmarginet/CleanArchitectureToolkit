using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Cat.Validators.Abstractions;

namespace Cat.Validators;

/// <summary>
/// Base class for a model rule that needs async work.
/// Derive from it when you write your own rule. Use <see cref="CatValidatorModelRuleBase{TModel}"/> for sync work.
/// </summary>
/// <typeparam name="TModel">The type being validated.</typeparam>
public abstract class CatValidatorModelRuleAsyncBase<TModel>
    : ICatValidatorModelRule<TModel>
    where TModel : class
{
    /// <inheritdoc />
    public ConcurrentBag<Func<TModel, CancellationToken, Task<bool>>> RulesConditionFuncAsyncList { get; } = [];

    /// <inheritdoc />
    public abstract Task<List<ICatValidatorError>> ValidateAsync(TModel model, CancellationToken ct);
}
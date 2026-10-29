using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Cat.Validators.Abstractions;
using Cat.Validators.Rules;

namespace Cat.Validators.Extensions;

/// <summary>
/// Rules that look at the whole model. Use them inside <see cref="ICatValidatorBuilder{TModel}.AddRules"/>.
/// </summary>
public static class CatValidatorModelRuleBuilderExtensions
{
    /// <summary>
    /// Adds an async rule that checks the whole model with your own code.
    /// </summary>
    /// <typeparam name="TModel">The type being validated.</typeparam>
    /// <param name="builder">The builder to add the rule to.</param>
    /// <param name="predicate">Returns the failures it finds, or an empty list when the model is valid.</param>
    public static void MustAsync<TModel>(
        this ICatValidatorModelRuleBuilder<TModel> builder,
        Func<TModel, CancellationToken, Task<List<ICatValidatorError>>> predicate)
        where TModel : class
    {
        var newRule = new ModelMustAsyncValidatorRule<TModel>(predicate);
        builder.AddRule(newRule);
    }
    
    /// <summary>
    /// Adds a rule that checks the whole model with your own code.
    /// </summary>
    /// <typeparam name="TModel">The type being validated.</typeparam>
    /// <param name="builder">The builder to add the rule to.</param>
    /// <param name="predicate">Returns the failures it finds, or an empty list when the model is valid.</param>
    public static void Must<TModel>(
        this ICatValidatorModelRuleBuilder<TModel> builder,
        Func<TModel, List<ICatValidatorError>> predicate)
        where TModel : class
    {
        var newRule = new ModelMustValidatorRule<TModel>(predicate);
        builder.AddRule(newRule);
    }
}
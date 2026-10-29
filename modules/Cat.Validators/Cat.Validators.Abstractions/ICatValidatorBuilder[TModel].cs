using System;
using System.Linq.Expressions;

namespace Cat.Validators.Abstractions;

/// <summary>
/// Collects the rules of a validator. You get one in <see cref="ICatValidator{TModel}.Build"/>.
/// </summary>
/// <typeparam name="TModel">The type being validated.</typeparam>
public interface ICatValidatorBuilder<TModel>
    where TModel : class
{
    /// <summary>
    /// Adds rules that look at the whole model.
    /// </summary>
    /// <param name="b">Adds the rules to the given builder.</param>
    /// <returns>The same builder, so calls can be chained.</returns>
    ICatValidatorBuilder<TModel> AddRules(Action<ICatValidatorModelRuleBuilder<TModel>> b);

    /// <summary>
    /// Adds rules for one property of the model.
    /// </summary>
    /// <typeparam name="TProperty">The type of the property.</typeparam>
    /// <param name="expression">Picks the property, like <c>m =&gt; m.Name</c>.</param>
    /// <param name="b">Adds the rules to the given builder.</param>
    /// <returns>The same builder, so calls can be chained.</returns>
    ICatValidatorBuilder<TModel> AddPropertyRules<TProperty>(Expression<Func<TModel, TProperty>> expression, Action<ICatValidatorPropertyRuleBuilder<TModel, TProperty>> b);
}
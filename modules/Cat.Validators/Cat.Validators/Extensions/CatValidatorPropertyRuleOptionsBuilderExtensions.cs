using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Cat.Object.Extensions;
using Cat.Objects.Extensions;
using Cat.Validators.Abstractions;

namespace Cat.Validators.Extensions;

/// <summary>
/// Options you can chain after a property rule: conditions, a field name, a message and a code.
/// Each option applies only to the rule right before it.
/// </summary>
public static class CatValidatorPropertyRuleOptionsBuilderExtensions
{
    /// <summary>
    /// Runs the rule only when the async condition returns <c>true</c>.
    /// Add several conditions and all of them must be <c>true</c>.
    /// </summary>
    /// <typeparam name="TModel">The type being validated.</typeparam>
    /// <typeparam name="TProperty">The type of the property.</typeparam>
    /// <param name="builder">The options of the rule.</param>
    /// <param name="condition">Decides whether the rule runs.</param>
    /// <returns>The same builder, so calls can be chained.</returns>
    public static ICatValidatorPropertyRuleOptionsBuilder<TModel, TProperty> WhenAsync<TModel, TProperty>(
        this ICatValidatorPropertyRuleOptionsBuilder<TModel, TProperty> builder,
        Expression<Func<TModel, CancellationToken, Task<bool>>> condition)
        where TModel : class
    {
        condition.ThrowIfNull(nameof(condition));

        var compiledCondition = condition.Compile();

        builder.Rule.RulesConditionFuncAsyncList.Add(compiledCondition);
        return builder;
    }
    
    /// <summary>
    /// Runs the rule only when the condition returns <c>true</c>.
    /// Add several conditions and all of them must be <c>true</c>.
    /// </summary>
    /// <typeparam name="TModel">The type being validated.</typeparam>
    /// <typeparam name="TProperty">The type of the property.</typeparam>
    /// <param name="builder">The options of the rule.</param>
    /// <param name="condition">Decides whether the rule runs.</param>
    /// <returns>The same builder, so calls can be chained.</returns>
    public static ICatValidatorPropertyRuleOptionsBuilder<TModel, TProperty> When<TModel, TProperty>(
        this ICatValidatorPropertyRuleOptionsBuilder<TModel, TProperty> builder,
        Expression<Func<TModel, bool>> condition)
        where TModel : class
    {
        condition.ThrowIfNull(nameof(condition));

        var compiledCondition = condition.Compile();

        builder.Rule.RulesConditionFuncAsyncList.Add((m,_) => Task.FromResult(compiledCondition(m)));
        return builder;
    }
    
    /// <summary>
    /// Replaces the field name in the errors of the rule.
    /// </summary>
    /// <typeparam name="TModel">The type being validated.</typeparam>
    /// <typeparam name="TProperty">The type of the property.</typeparam>
    /// <param name="builder">The options of the rule.</param>
    /// <param name="fieldName">The field name to report instead of the property name.</param>
    /// <returns>The same builder, so calls can be chained.</returns>
    public static ICatValidatorPropertyRuleOptionsBuilder<TModel, TProperty> WithFieldName<TModel, TProperty>(
        this ICatValidatorPropertyRuleOptionsBuilder<TModel, TProperty> builder,
        string fieldName)
        where TModel : class
    {
        builder.Rule.FieldName = fieldName;
        return builder;
    }
    
    /// <summary>
    /// Replaces the message in the errors of the rule.
    /// The arguments of the rule still fill the placeholders, so you can reuse them.
    /// </summary>
    /// <typeparam name="TModel">The type being validated.</typeparam>
    /// <typeparam name="TProperty">The type of the property.</typeparam>
    /// <param name="builder">The options of the rule.</param>
    /// <param name="errorMessage">The message template to report.</param>
    /// <returns>The same builder, so calls can be chained.</returns>
    public static ICatValidatorPropertyRuleOptionsBuilder<TModel, TProperty> WithMessage<TModel, TProperty>(
        this ICatValidatorPropertyRuleOptionsBuilder<TModel, TProperty> builder,
        string errorMessage)
        where TModel : class
    {
        builder.Rule.ErrorMessage = errorMessage;
        return builder;
    }
    
    /// <summary>
    /// Replaces the code in the errors of the rule.
    /// </summary>
    /// <typeparam name="TModel">The type being validated.</typeparam>
    /// <typeparam name="TProperty">The type of the property.</typeparam>
    /// <param name="builder">The options of the rule.</param>
    /// <param name="code">The error code to report.</param>
    /// <returns>The same builder, so calls can be chained.</returns>
    public static ICatValidatorPropertyRuleOptionsBuilder<TModel, TProperty> WithCode<TModel, TProperty>(
        this ICatValidatorPropertyRuleOptionsBuilder<TModel, TProperty> builder,
        string code)
        where TModel : class
    {
        builder.Rule.ErrorCode = code;
        return builder;
    }
}
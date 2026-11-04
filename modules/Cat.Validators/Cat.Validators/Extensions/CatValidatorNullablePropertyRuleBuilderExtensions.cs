using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Cat.Expressions.Abstractions;
using Cat.Object.Extensions;
using Cat.Objects.Extensions;
using Cat.Responses;
using Cat.Validators.Abstractions;
using Cat.Validators.Rules;

namespace Cat.Validators.Extensions;

/// <summary>
/// The comparison and range rules for nullable value types, like <c>decimal?</c>, <c>int?</c> and <c>DateTime?</c>.
/// They work like the rules in <see cref="CatValidatorPropertyRuleBuilderExtensions"/>, with one difference:
/// a <c>null</c> property passes. Add <c>NotNull</c> to the property when a value is required.
/// When you compare with another property or take a bound from the model, a <c>null</c> there passes too.
/// </summary>
public static class CatValidatorNullablePropertyRuleBuilderExtensions
{
    private static ICatValidatorPropertyRuleOptionsBuilder<TModel, TProperty?> AddRule<TModel, TProperty>(
        ICatValidatorPropertyRuleBuilder<TModel, TProperty?> builder,
        CatErrorDefinition definition,
        Func<TProperty, TModel, ICatCompiledMemberExpressionCache<TModel>, object?[]?> check)
        where TModel : class
        where TProperty : struct
    {
        var newRule = new PropertyNullableValidatorRule<TModel, TProperty>(definition.Code, definition.Message, check);
        return builder.AddPropertyRule(newRule);
    }

    #region Comparison

    /// <summary>
    /// The value must be less than the given value. Code <c>CAT-VAL-1012</c>.
    /// A <c>null</c> property passes.
    /// </summary>
    /// <typeparam name="TModel">The type being validated.</typeparam>
    /// <typeparam name="TProperty">The value type behind the nullable property.</typeparam>
    /// <param name="builder">The builder to add the rule to.</param>
    /// <param name="valueToCompare">The value to compare with.</param>
    /// <returns>The options of the rule.</returns>
    public static ICatValidatorPropertyRuleOptionsBuilder<TModel, TProperty?> LessThan<TModel, TProperty>(
        this ICatValidatorPropertyRuleBuilder<TModel, TProperty?> builder,
        TProperty valueToCompare)
        where TModel : class
        where TProperty : struct, IComparable<TProperty>, IComparable
    {
        return AddRule<TModel, TProperty>(builder, CatValidatorErrorDefinitions.LessThan,
            (value, _, _) => value.CompareTo(valueToCompare) < 0 ? null : new object?[] { valueToCompare });
    }

    /// <summary>
    /// The value must be less than another property of the model. Code <c>CAT-VAL-1012</c>.
    /// A <c>null</c> property passes. So does a <c>null</c> value in the other property.
    /// </summary>
    /// <typeparam name="TModel">The type being validated.</typeparam>
    /// <typeparam name="TProperty">The value type behind the nullable property.</typeparam>
    /// <param name="builder">The builder to add the rule to.</param>
    /// <param name="expression">Picks the value to compare with, like <c>m =&gt; m.MaxPrice</c>.</param>
    /// <returns>The options of the rule.</returns>
    public static ICatValidatorPropertyRuleOptionsBuilder<TModel, TProperty?> LessThan<TModel, TProperty>(
        this ICatValidatorPropertyRuleBuilder<TModel, TProperty?> builder,
        Expression<Func<TModel, TProperty?>> expression)
        where TModel : class
        where TProperty : struct, IComparable<TProperty>, IComparable
    {
        expression.ThrowIfNull(nameof(expression));
        return AddRule<TModel, TProperty>(builder, CatValidatorErrorDefinitions.LessThan, (value, model, cache) =>
        {
            var valueToCompare = cache.GetOrAdd(expression)(model);
            if (valueToCompare is null) return null;
            return value.CompareTo(valueToCompare.Value) < 0 ? null : new object?[] { valueToCompare.Value };
        });
    }

    /// <summary>
    /// The value must be less than or equal to the given value. Code <c>CAT-VAL-1013</c>.
    /// A <c>null</c> property passes.
    /// </summary>
    /// <typeparam name="TModel">The type being validated.</typeparam>
    /// <typeparam name="TProperty">The value type behind the nullable property.</typeparam>
    /// <param name="builder">The builder to add the rule to.</param>
    /// <param name="valueToCompare">The value to compare with.</param>
    /// <returns>The options of the rule.</returns>
    public static ICatValidatorPropertyRuleOptionsBuilder<TModel, TProperty?> LessThanOrEqualTo<TModel, TProperty>(
        this ICatValidatorPropertyRuleBuilder<TModel, TProperty?> builder,
        TProperty valueToCompare)
        where TModel : class
        where TProperty : struct, IComparable<TProperty>, IComparable
    {
        return AddRule<TModel, TProperty>(builder, CatValidatorErrorDefinitions.LessThanOrEqualTo,
            (value, _, _) => value.CompareTo(valueToCompare) <= 0 ? null : new object?[] { valueToCompare });
    }

    /// <summary>
    /// The value must be less than or equal to another property of the model. Code <c>CAT-VAL-1013</c>.
    /// A <c>null</c> property passes. So does a <c>null</c> value in the other property.
    /// </summary>
    /// <typeparam name="TModel">The type being validated.</typeparam>
    /// <typeparam name="TProperty">The value type behind the nullable property.</typeparam>
    /// <param name="builder">The builder to add the rule to.</param>
    /// <param name="expression">Picks the value to compare with, like <c>m =&gt; m.MaxPrice</c>.</param>
    /// <returns>The options of the rule.</returns>
    public static ICatValidatorPropertyRuleOptionsBuilder<TModel, TProperty?> LessThanOrEqualTo<TModel, TProperty>(
        this ICatValidatorPropertyRuleBuilder<TModel, TProperty?> builder,
        Expression<Func<TModel, TProperty?>> expression)
        where TModel : class
        where TProperty : struct, IComparable<TProperty>, IComparable
    {
        expression.ThrowIfNull(nameof(expression));
        return AddRule<TModel, TProperty>(builder, CatValidatorErrorDefinitions.LessThanOrEqualTo, (value, model, cache) =>
        {
            var valueToCompare = cache.GetOrAdd(expression)(model);
            if (valueToCompare is null) return null;
            return value.CompareTo(valueToCompare.Value) <= 0 ? null : new object?[] { valueToCompare.Value };
        });
    }

    /// <summary>
    /// The value must be greater than the given value. Code <c>CAT-VAL-1014</c>.
    /// A <c>null</c> property passes.
    /// </summary>
    /// <typeparam name="TModel">The type being validated.</typeparam>
    /// <typeparam name="TProperty">The value type behind the nullable property.</typeparam>
    /// <param name="builder">The builder to add the rule to.</param>
    /// <param name="valueToCompare">The value to compare with.</param>
    /// <returns>The options of the rule.</returns>
    public static ICatValidatorPropertyRuleOptionsBuilder<TModel, TProperty?> GreaterThan<TModel, TProperty>(
        this ICatValidatorPropertyRuleBuilder<TModel, TProperty?> builder,
        TProperty valueToCompare)
        where TModel : class
        where TProperty : struct, IComparable<TProperty>, IComparable
    {
        return AddRule<TModel, TProperty>(builder, CatValidatorErrorDefinitions.GreaterThan,
            (value, _, _) => value.CompareTo(valueToCompare) > 0 ? null : new object?[] { valueToCompare });
    }

    /// <summary>
    /// The value must be greater than another property of the model. Code <c>CAT-VAL-1014</c>.
    /// A <c>null</c> property passes. So does a <c>null</c> value in the other property.
    /// </summary>
    /// <typeparam name="TModel">The type being validated.</typeparam>
    /// <typeparam name="TProperty">The value type behind the nullable property.</typeparam>
    /// <param name="builder">The builder to add the rule to.</param>
    /// <param name="expression">Picks the value to compare with, like <c>m =&gt; m.MinPrice</c>.</param>
    /// <returns>The options of the rule.</returns>
    public static ICatValidatorPropertyRuleOptionsBuilder<TModel, TProperty?> GreaterThan<TModel, TProperty>(
        this ICatValidatorPropertyRuleBuilder<TModel, TProperty?> builder,
        Expression<Func<TModel, TProperty?>> expression)
        where TModel : class
        where TProperty : struct, IComparable<TProperty>, IComparable
    {
        expression.ThrowIfNull(nameof(expression));
        return AddRule<TModel, TProperty>(builder, CatValidatorErrorDefinitions.GreaterThan, (value, model, cache) =>
        {
            var valueToCompare = cache.GetOrAdd(expression)(model);
            if (valueToCompare is null) return null;
            return value.CompareTo(valueToCompare.Value) > 0 ? null : new object?[] { valueToCompare.Value };
        });
    }

    /// <summary>
    /// The value must be greater than or equal to the given value. Code <c>CAT-VAL-1015</c>.
    /// A <c>null</c> property passes.
    /// </summary>
    /// <typeparam name="TModel">The type being validated.</typeparam>
    /// <typeparam name="TProperty">The value type behind the nullable property.</typeparam>
    /// <param name="builder">The builder to add the rule to.</param>
    /// <param name="valueToCompare">The value to compare with.</param>
    /// <returns>The options of the rule.</returns>
    public static ICatValidatorPropertyRuleOptionsBuilder<TModel, TProperty?> GreaterThanOrEqualTo<TModel, TProperty>(
        this ICatValidatorPropertyRuleBuilder<TModel, TProperty?> builder,
        TProperty valueToCompare)
        where TModel : class
        where TProperty : struct, IComparable<TProperty>, IComparable
    {
        return AddRule<TModel, TProperty>(builder, CatValidatorErrorDefinitions.GreaterThanOrEqualTo,
            (value, _, _) => value.CompareTo(valueToCompare) >= 0 ? null : new object?[] { valueToCompare });
    }

    /// <summary>
    /// The value must be greater than or equal to another property of the model. Code <c>CAT-VAL-1015</c>.
    /// A <c>null</c> property passes. So does a <c>null</c> value in the other property.
    /// </summary>
    /// <typeparam name="TModel">The type being validated.</typeparam>
    /// <typeparam name="TProperty">The value type behind the nullable property.</typeparam>
    /// <param name="builder">The builder to add the rule to.</param>
    /// <param name="expression">Picks the value to compare with, like <c>m =&gt; m.MinPrice</c>.</param>
    /// <returns>The options of the rule.</returns>
    public static ICatValidatorPropertyRuleOptionsBuilder<TModel, TProperty?> GreaterThanOrEqualTo<TModel, TProperty>(
        this ICatValidatorPropertyRuleBuilder<TModel, TProperty?> builder,
        Expression<Func<TModel, TProperty?>> expression)
        where TModel : class
        where TProperty : struct, IComparable<TProperty>, IComparable
    {
        expression.ThrowIfNull(nameof(expression));
        return AddRule<TModel, TProperty>(builder, CatValidatorErrorDefinitions.GreaterThanOrEqualTo, (value, model, cache) =>
        {
            var valueToCompare = cache.GetOrAdd(expression)(model);
            if (valueToCompare is null) return null;
            return value.CompareTo(valueToCompare.Value) >= 0 ? null : new object?[] { valueToCompare.Value };
        });
    }

    #endregion Comparison

    #region Inclusive between

    /// <summary>
    /// The value must be between the bounds, bounds included. Code <c>CAT-VAL-1016</c>.
    /// The lower bound must be less than the upper bound. A <c>null</c> property passes.
    /// </summary>
    /// <typeparam name="TModel">The type being validated.</typeparam>
    /// <typeparam name="TProperty">The value type behind the nullable property.</typeparam>
    /// <param name="builder">The builder to add the rule to.</param>
    /// <param name="lowerBound">The lowest allowed value.</param>
    /// <param name="upperBound">The highest allowed value.</param>
    /// <returns>The options of the rule.</returns>
    public static ICatValidatorPropertyRuleOptionsBuilder<TModel, TProperty?> InclusiveBetween<TModel, TProperty>(
        this ICatValidatorPropertyRuleBuilder<TModel, TProperty?> builder,
        TProperty lowerBound,
        TProperty upperBound)
        where TModel : class
        where TProperty : struct, IComparable<TProperty>, IComparable
    {
        return AddRule<TModel, TProperty>(builder, CatValidatorErrorDefinitions.InclusiveBetween, (value, _, _) =>
        {
            lowerBound.ThrowIfGreaterThanOrEqualTo(upperBound, nameof(lowerBound), nameof(upperBound));
            return value.CompareTo(lowerBound) >= 0 && value.CompareTo(upperBound) <= 0
                ? null
                : new object?[] { lowerBound, upperBound, value };
        });
    }

    /// <summary>
    /// The value must be between two bounds taken from the model, bounds included. Code <c>CAT-VAL-1016</c>.
    /// The lower bound must be less than the upper bound.
    /// A <c>null</c> property passes. So does a <c>null</c> bound.
    /// </summary>
    /// <typeparam name="TModel">The type being validated.</typeparam>
    /// <typeparam name="TProperty">The value type behind the nullable property.</typeparam>
    /// <param name="builder">The builder to add the rule to.</param>
    /// <param name="lowerBoundFunc">Gets the lowest allowed value from the model.</param>
    /// <param name="upperBoundFunc">Gets the highest allowed value from the model.</param>
    /// <returns>The options of the rule.</returns>
    public static ICatValidatorPropertyRuleOptionsBuilder<TModel, TProperty?> InclusiveBetween<TModel, TProperty>(
        this ICatValidatorPropertyRuleBuilder<TModel, TProperty?> builder,
        Func<TModel, TProperty?> lowerBoundFunc,
        Func<TModel, TProperty?> upperBoundFunc)
        where TModel : class
        where TProperty : struct, IComparable<TProperty>, IComparable
    {
        lowerBoundFunc.ThrowIfNull(nameof(lowerBoundFunc));
        upperBoundFunc.ThrowIfNull(nameof(upperBoundFunc));
        return AddRule<TModel, TProperty>(builder, CatValidatorErrorDefinitions.InclusiveBetween, (value, model, _) =>
        {
            var lowerBound = lowerBoundFunc(model);
            var upperBound = upperBoundFunc(model);
            if (lowerBound is null || upperBound is null) return null;

            lowerBound.Value.ThrowIfGreaterThanOrEqualTo(upperBound.Value, nameof(lowerBound), nameof(upperBound));
            return value.CompareTo(lowerBound.Value) >= 0 && value.CompareTo(upperBound.Value) <= 0
                ? null
                : new object?[] { lowerBound.Value, upperBound.Value, value };
        });
    }

    /// <summary>
    /// The value must be between the bounds, bounds included, using your own comparer. Code <c>CAT-VAL-1016</c>.
    /// The lower bound must be less than the upper bound. A <c>null</c> property passes.
    /// </summary>
    /// <typeparam name="TModel">The type being validated.</typeparam>
    /// <typeparam name="TProperty">The value type behind the nullable property.</typeparam>
    /// <param name="builder">The builder to add the rule to.</param>
    /// <param name="lowerBound">The lowest allowed value.</param>
    /// <param name="upperBound">The highest allowed value.</param>
    /// <param name="comparer">Decides how values are ordered.</param>
    /// <returns>The options of the rule.</returns>
    public static ICatValidatorPropertyRuleOptionsBuilder<TModel, TProperty?> InclusiveBetween<TModel, TProperty>(
        this ICatValidatorPropertyRuleBuilder<TModel, TProperty?> builder,
        TProperty lowerBound,
        TProperty upperBound,
        IComparer<TProperty> comparer)
        where TModel : class
        where TProperty : struct, IComparable<TProperty>, IComparable
    {
        comparer.ThrowIfNull(nameof(comparer));
        return AddRule<TModel, TProperty>(builder, CatValidatorErrorDefinitions.InclusiveBetween, (value, _, _) =>
        {
            lowerBound.ThrowIfGreaterThanOrEqualTo(upperBound, comparer, nameof(lowerBound), nameof(upperBound));
            return comparer.Compare(value, lowerBound) >= 0 && comparer.Compare(value, upperBound) <= 0
                ? null
                : new object?[] { lowerBound, upperBound, value };
        });
    }

    /// <summary>
    /// The value must be between two bounds taken from the model, bounds included, using your own comparer.
    /// Code <c>CAT-VAL-1016</c>. The lower bound must be less than the upper bound.
    /// A <c>null</c> property passes. So does a <c>null</c> bound.
    /// </summary>
    /// <typeparam name="TModel">The type being validated.</typeparam>
    /// <typeparam name="TProperty">The value type behind the nullable property.</typeparam>
    /// <param name="builder">The builder to add the rule to.</param>
    /// <param name="lowerBoundFunc">Gets the lowest allowed value from the model.</param>
    /// <param name="upperBoundFunc">Gets the highest allowed value from the model.</param>
    /// <param name="comparer">Decides how values are ordered.</param>
    /// <returns>The options of the rule.</returns>
    public static ICatValidatorPropertyRuleOptionsBuilder<TModel, TProperty?> InclusiveBetween<TModel, TProperty>(
        this ICatValidatorPropertyRuleBuilder<TModel, TProperty?> builder,
        Func<TModel, TProperty?> lowerBoundFunc,
        Func<TModel, TProperty?> upperBoundFunc,
        IComparer<TProperty> comparer)
        where TModel : class
        where TProperty : struct, IComparable<TProperty>, IComparable
    {
        lowerBoundFunc.ThrowIfNull(nameof(lowerBoundFunc));
        upperBoundFunc.ThrowIfNull(nameof(upperBoundFunc));
        comparer.ThrowIfNull(nameof(comparer));
        return AddRule<TModel, TProperty>(builder, CatValidatorErrorDefinitions.InclusiveBetween, (value, model, _) =>
        {
            var lowerBound = lowerBoundFunc(model);
            var upperBound = upperBoundFunc(model);
            if (lowerBound is null || upperBound is null) return null;

            lowerBound.Value.ThrowIfGreaterThanOrEqualTo(upperBound.Value, comparer, nameof(lowerBound), nameof(upperBound));
            return comparer.Compare(value, lowerBound.Value) >= 0 && comparer.Compare(value, upperBound.Value) <= 0
                ? null
                : new object?[] { lowerBound.Value, upperBound.Value, value };
        });
    }

    #endregion Inclusive between

    #region Exclusive between

    /// <summary>
    /// The value must be between the bounds, bounds excluded. Code <c>CAT-VAL-1017</c>.
    /// The lower bound must be less than the upper bound. A <c>null</c> property passes.
    /// </summary>
    /// <typeparam name="TModel">The type being validated.</typeparam>
    /// <typeparam name="TProperty">The value type behind the nullable property.</typeparam>
    /// <param name="builder">The builder to add the rule to.</param>
    /// <param name="lowerBound">The value the property must be greater than.</param>
    /// <param name="upperBound">The value the property must be less than.</param>
    /// <returns>The options of the rule.</returns>
    public static ICatValidatorPropertyRuleOptionsBuilder<TModel, TProperty?> ExclusiveBetween<TModel, TProperty>(
        this ICatValidatorPropertyRuleBuilder<TModel, TProperty?> builder,
        TProperty lowerBound,
        TProperty upperBound)
        where TModel : class
        where TProperty : struct, IComparable<TProperty>, IComparable
    {
        return AddRule<TModel, TProperty>(builder, CatValidatorErrorDefinitions.ExclusiveBetween, (value, _, _) =>
        {
            lowerBound.ThrowIfGreaterThanOrEqualTo(upperBound, nameof(lowerBound), nameof(upperBound));
            return value.CompareTo(lowerBound) > 0 && value.CompareTo(upperBound) < 0
                ? null
                : new object?[] { lowerBound, upperBound, value };
        });
    }

    /// <summary>
    /// The value must be between two bounds taken from the model, bounds excluded. Code <c>CAT-VAL-1017</c>.
    /// The lower bound must be less than the upper bound.
    /// A <c>null</c> property passes. So does a <c>null</c> bound.
    /// </summary>
    /// <typeparam name="TModel">The type being validated.</typeparam>
    /// <typeparam name="TProperty">The value type behind the nullable property.</typeparam>
    /// <param name="builder">The builder to add the rule to.</param>
    /// <param name="lowerBoundFunc">Gets the value the property must be greater than.</param>
    /// <param name="upperBoundFunc">Gets the value the property must be less than.</param>
    /// <returns>The options of the rule.</returns>
    public static ICatValidatorPropertyRuleOptionsBuilder<TModel, TProperty?> ExclusiveBetween<TModel, TProperty>(
        this ICatValidatorPropertyRuleBuilder<TModel, TProperty?> builder,
        Func<TModel, TProperty?> lowerBoundFunc,
        Func<TModel, TProperty?> upperBoundFunc)
        where TModel : class
        where TProperty : struct, IComparable<TProperty>, IComparable
    {
        lowerBoundFunc.ThrowIfNull(nameof(lowerBoundFunc));
        upperBoundFunc.ThrowIfNull(nameof(upperBoundFunc));
        return AddRule<TModel, TProperty>(builder, CatValidatorErrorDefinitions.ExclusiveBetween, (value, model, _) =>
        {
            var lowerBound = lowerBoundFunc(model);
            var upperBound = upperBoundFunc(model);
            if (lowerBound is null || upperBound is null) return null;

            lowerBound.Value.ThrowIfGreaterThanOrEqualTo(upperBound.Value, nameof(lowerBound), nameof(upperBound));
            return value.CompareTo(lowerBound.Value) > 0 && value.CompareTo(upperBound.Value) < 0
                ? null
                : new object?[] { lowerBound.Value, upperBound.Value, value };
        });
    }

    /// <summary>
    /// The value must be between the bounds, bounds excluded, using your own comparer. Code <c>CAT-VAL-1017</c>.
    /// The lower bound must be less than the upper bound. A <c>null</c> property passes.
    /// </summary>
    /// <typeparam name="TModel">The type being validated.</typeparam>
    /// <typeparam name="TProperty">The value type behind the nullable property.</typeparam>
    /// <param name="builder">The builder to add the rule to.</param>
    /// <param name="lowerBound">The value the property must be greater than.</param>
    /// <param name="upperBound">The value the property must be less than.</param>
    /// <param name="comparer">Decides how values are ordered.</param>
    /// <returns>The options of the rule.</returns>
    public static ICatValidatorPropertyRuleOptionsBuilder<TModel, TProperty?> ExclusiveBetween<TModel, TProperty>(
        this ICatValidatorPropertyRuleBuilder<TModel, TProperty?> builder,
        TProperty lowerBound,
        TProperty upperBound,
        IComparer<TProperty> comparer)
        where TModel : class
        where TProperty : struct, IComparable<TProperty>, IComparable
    {
        comparer.ThrowIfNull(nameof(comparer));
        return AddRule<TModel, TProperty>(builder, CatValidatorErrorDefinitions.ExclusiveBetween, (value, _, _) =>
        {
            lowerBound.ThrowIfGreaterThanOrEqualTo(upperBound, comparer, nameof(lowerBound), nameof(upperBound));
            return comparer.Compare(value, lowerBound) > 0 && comparer.Compare(value, upperBound) < 0
                ? null
                : new object?[] { lowerBound, upperBound, value };
        });
    }

    /// <summary>
    /// The value must be between two bounds taken from the model, bounds excluded, using your own comparer.
    /// Code <c>CAT-VAL-1017</c>. The lower bound must be less than the upper bound.
    /// A <c>null</c> property passes. So does a <c>null</c> bound.
    /// </summary>
    /// <typeparam name="TModel">The type being validated.</typeparam>
    /// <typeparam name="TProperty">The value type behind the nullable property.</typeparam>
    /// <param name="builder">The builder to add the rule to.</param>
    /// <param name="lowerBoundFunc">Gets the value the property must be greater than.</param>
    /// <param name="upperBoundFunc">Gets the value the property must be less than.</param>
    /// <param name="comparer">Decides how values are ordered.</param>
    /// <returns>The options of the rule.</returns>
    public static ICatValidatorPropertyRuleOptionsBuilder<TModel, TProperty?> ExclusiveBetween<TModel, TProperty>(
        this ICatValidatorPropertyRuleBuilder<TModel, TProperty?> builder,
        Func<TModel, TProperty?> lowerBoundFunc,
        Func<TModel, TProperty?> upperBoundFunc,
        IComparer<TProperty> comparer)
        where TModel : class
        where TProperty : struct, IComparable<TProperty>, IComparable
    {
        lowerBoundFunc.ThrowIfNull(nameof(lowerBoundFunc));
        upperBoundFunc.ThrowIfNull(nameof(upperBoundFunc));
        comparer.ThrowIfNull(nameof(comparer));
        return AddRule<TModel, TProperty>(builder, CatValidatorErrorDefinitions.ExclusiveBetween, (value, model, _) =>
        {
            var lowerBound = lowerBoundFunc(model);
            var upperBound = upperBoundFunc(model);
            if (lowerBound is null || upperBound is null) return null;

            lowerBound.Value.ThrowIfGreaterThanOrEqualTo(upperBound.Value, comparer, nameof(lowerBound), nameof(upperBound));
            return comparer.Compare(value, lowerBound.Value) > 0 && comparer.Compare(value, upperBound.Value) < 0
                ? null
                : new object?[] { lowerBound.Value, upperBound.Value, value };
        });
    }

    #endregion Exclusive between
}

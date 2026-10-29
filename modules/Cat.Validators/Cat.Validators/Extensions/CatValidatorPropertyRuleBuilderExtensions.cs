using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Cat.Validators.Abstractions;
using Cat.Validators.Rules;

namespace Cat.Validators.Extensions;

/// <summary>
/// The built-in property rules. Use them inside <see cref="ICatValidatorBuilder{TModel}.AddPropertyRules{TProperty}"/>.
/// Each rule returns an options builder, so you can chain <c>When</c>, <c>WithFieldName</c>, <c>WithMessage</c> and <c>WithCode</c>.
/// </summary>
public static class CatValidatorPropertyRuleBuilderExtensions
{
    /// <summary>
    /// The value must not be <c>null</c>. Code <c>CAT-VAL-1001</c>.
    /// </summary>
    /// <typeparam name="TModel">The type being validated.</typeparam>
    /// <typeparam name="TProperty">The type of the property.</typeparam>
    /// <param name="builder">The builder to add the rule to.</param>
    /// <returns>The options of the rule.</returns>
    public static ICatValidatorPropertyRuleOptionsBuilder<TModel, TProperty> NotNull<TModel, TProperty>(
        this ICatValidatorPropertyRuleBuilder<TModel, TProperty> builder)
        where TModel : class
    {
        var newRule = new PropertyNotNullValidatorRule<TModel, TProperty>();
        return builder.AddPropertyRule(newRule);
    }

    /// <summary>
    /// The value must be <c>null</c>. Code <c>CAT-VAL-1002</c>.
    /// </summary>
    /// <typeparam name="TModel">The type being validated.</typeparam>
    /// <typeparam name="TProperty">The type of the property.</typeparam>
    /// <param name="builder">The builder to add the rule to.</param>
    /// <returns>The options of the rule.</returns>
    public static ICatValidatorPropertyRuleOptionsBuilder<TModel, TProperty> Null<TModel, TProperty>(
        this ICatValidatorPropertyRuleBuilder<TModel, TProperty> builder)
        where TModel : class
    {
        var newRule = new PropertyNullValidatorRule<TModel, TProperty>();
        return builder.AddPropertyRule(newRule);
    }

    /// <summary>
    /// The value must not be empty. Code <c>CAT-VAL-1003</c>.
    /// <c>null</c>, a blank string, an empty collection and the default value of a type all count as empty.
    /// </summary>
    /// <typeparam name="TModel">The type being validated.</typeparam>
    /// <typeparam name="TProperty">The type of the property.</typeparam>
    /// <param name="builder">The builder to add the rule to.</param>
    /// <returns>The options of the rule.</returns>
    public static ICatValidatorPropertyRuleOptionsBuilder<TModel, TProperty> NotEmpty<TModel, TProperty>(
        this ICatValidatorPropertyRuleBuilder<TModel, TProperty> builder)
        where TModel : class
    {
        var newRule = new PropertyNotEmptyValidatorRule<TModel, TProperty>();
        return builder.AddPropertyRule(newRule);
    }

    /// <summary>
    /// The value must be empty. Code <c>CAT-VAL-1004</c>.
    /// <c>null</c> passes. So does a blank string, an empty collection and the default value of a type.
    /// </summary>
    /// <typeparam name="TModel">The type being validated.</typeparam>
    /// <typeparam name="TProperty">The type of the property.</typeparam>
    /// <param name="builder">The builder to add the rule to.</param>
    /// <returns>The options of the rule.</returns>
    public static ICatValidatorPropertyRuleOptionsBuilder<TModel, TProperty> Empty<TModel, TProperty>(
        this ICatValidatorPropertyRuleBuilder<TModel, TProperty> builder)
        where TModel : class
    {
        var newRule = new PropertyEmptyValidatorRule<TModel, TProperty>();
        return builder.AddPropertyRule(newRule);
    }

    /// <summary>
    /// The value must not equal the given value. Code <c>CAT-VAL-1010</c>.
    /// </summary>
    /// <typeparam name="TModel">The type being validated.</typeparam>
    /// <typeparam name="TProperty">The type of the property.</typeparam>
    /// <param name="builder">The builder to add the rule to.</param>
    /// <param name="valueToCompare">The value to compare with.</param>
    /// <param name="comparer">Decides when two values are equal. Strings compare ordinal by default.</param>
    /// <returns>The options of the rule.</returns>
    public static ICatValidatorPropertyRuleOptionsBuilder<TModel, TProperty> NotEqual<TModel, TProperty>(
        this ICatValidatorPropertyRuleBuilder<TModel, TProperty> builder,
        TProperty valueToCompare,
        IEqualityComparer<TProperty?>? comparer = null)
        where TModel : class
    {
        var newRule = new PropertyNotEqualValidatorRule<TModel, TProperty>(valueToCompare, comparer);
        return builder.AddPropertyRule(newRule);
    }

    /// <summary>
    /// The value must not equal another property of the model. Code <c>CAT-VAL-1010</c>.
    /// </summary>
    /// <typeparam name="TModel">The type being validated.</typeparam>
    /// <typeparam name="TProperty">The type of the property.</typeparam>
    /// <param name="builder">The builder to add the rule to.</param>
    /// <param name="expression">Picks the value to compare with, like <c>m =&gt; m.OtherName</c>.</param>
    /// <param name="comparer">Decides when two values are equal. Strings compare ordinal by default.</param>
    /// <returns>The options of the rule.</returns>
    public static ICatValidatorPropertyRuleOptionsBuilder<TModel, TProperty> NotEqual<TModel, TProperty>(
        this ICatValidatorPropertyRuleBuilder<TModel, TProperty> builder,
        Expression<Func<TModel, TProperty>> expression,
        IEqualityComparer<TProperty?>? comparer = null)
        where TModel : class
    {
        var newRule = new PropertyNotEqualWithFuncValidatorRule<TModel, TProperty>(expression, comparer);
        return builder.AddPropertyRule(newRule);
    }

    /// <summary>
    /// The value must equal the given value. Code <c>CAT-VAL-1011</c>.
    /// </summary>
    /// <typeparam name="TModel">The type being validated.</typeparam>
    /// <typeparam name="TProperty">The type of the property.</typeparam>
    /// <param name="builder">The builder to add the rule to.</param>
    /// <param name="valueToCompare">The value to compare with.</param>
    /// <param name="comparer">Decides when two values are equal. Strings compare ordinal by default.</param>
    /// <returns>The options of the rule.</returns>
    public static ICatValidatorPropertyRuleOptionsBuilder<TModel, TProperty> Equal<TModel, TProperty>(
        this ICatValidatorPropertyRuleBuilder<TModel, TProperty> builder,
        TProperty valueToCompare,
        IEqualityComparer<TProperty?>? comparer = null)
        where TModel : class
    {
        var newRule = new PropertyEqualValidatorRule<TModel, TProperty>(valueToCompare, comparer);
        return builder.AddPropertyRule(newRule);
    }

    /// <summary>
    /// The value must equal another property of the model. Code <c>CAT-VAL-1011</c>.
    /// </summary>
    /// <typeparam name="TModel">The type being validated.</typeparam>
    /// <typeparam name="TProperty">The type of the property.</typeparam>
    /// <param name="builder">The builder to add the rule to.</param>
    /// <param name="expression">Picks the value to compare with, like <c>m =&gt; m.OtherName</c>.</param>
    /// <param name="comparer">Decides when two values are equal. Strings compare ordinal by default.</param>
    /// <returns>The options of the rule.</returns>
    public static ICatValidatorPropertyRuleOptionsBuilder<TModel, TProperty> Equal<TModel, TProperty>(
        this ICatValidatorPropertyRuleBuilder<TModel, TProperty> builder,
        Expression<Func<TModel, TProperty>> expression,
        IEqualityComparer<TProperty?>? comparer = null)
        where TModel : class
    {
        var newRule = new PropertyEqualWithFuncValidatorRule<TModel, TProperty>(expression, comparer);
        return builder.AddPropertyRule(newRule);
    }

    /// <summary>
    /// The value must be less than the given value. Code <c>CAT-VAL-1012</c>.
    /// </summary>
    /// <typeparam name="TModel">The type being validated.</typeparam>
    /// <typeparam name="TProperty">The type of the property.</typeparam>
    /// <param name="builder">The builder to add the rule to.</param>
    /// <param name="valueToCompare">The value to compare with.</param>
    /// <returns>The options of the rule.</returns>
    public static ICatValidatorPropertyRuleOptionsBuilder<TModel, TProperty> LessThan<TModel, TProperty>(
        this ICatValidatorPropertyRuleBuilder<TModel, TProperty> builder,
        TProperty valueToCompare)
        where TModel : class
        where TProperty : IComparable<TProperty>, IComparable
    {
        var newRule = new PropertyLessThanValidatorRule<TModel, TProperty>(valueToCompare);
        return builder.AddPropertyRule(newRule);
    }

    /// <summary>
    /// The value must be less than another property of the model. Code <c>CAT-VAL-1012</c>.
    /// </summary>
    /// <typeparam name="TModel">The type being validated.</typeparam>
    /// <typeparam name="TProperty">The type of the property.</typeparam>
    /// <param name="builder">The builder to add the rule to.</param>
    /// <param name="expression">Picks the value to compare with, like <c>m =&gt; m.MaxAge</c>.</param>
    /// <returns>The options of the rule.</returns>
    public static ICatValidatorPropertyRuleOptionsBuilder<TModel, TProperty> LessThan<TModel, TProperty>(
        this ICatValidatorPropertyRuleBuilder<TModel, TProperty> builder,
        Expression<Func<TModel, TProperty>> expression)
        where TModel : class
        where TProperty : IComparable<TProperty>, IComparable
    {
        var newRule = new PropertyLessThanWithFuncValidatorRule<TModel, TProperty>(expression);
        return builder.AddPropertyRule(newRule);
    }

    /// <summary>
    /// The value must be less than or equal to the given value. Code <c>CAT-VAL-1013</c>.
    /// </summary>
    /// <typeparam name="TModel">The type being validated.</typeparam>
    /// <typeparam name="TProperty">The type of the property.</typeparam>
    /// <param name="builder">The builder to add the rule to.</param>
    /// <param name="valueToCompare">The value to compare with.</param>
    /// <returns>The options of the rule.</returns>
    public static ICatValidatorPropertyRuleOptionsBuilder<TModel, TProperty> LessThanOrEqualTo<TModel, TProperty>(
        this ICatValidatorPropertyRuleBuilder<TModel, TProperty> builder,
        TProperty valueToCompare)
        where TModel : class
        where TProperty : IComparable<TProperty>, IComparable
    {
        var newRule = new PropertyLessThanOrEqualToValidatorRule<TModel, TProperty>(valueToCompare);
        return builder.AddPropertyRule(newRule);
    }

    /// <summary>
    /// The value must be less than or equal to another property of the model. Code <c>CAT-VAL-1013</c>.
    /// </summary>
    /// <typeparam name="TModel">The type being validated.</typeparam>
    /// <typeparam name="TProperty">The type of the property.</typeparam>
    /// <param name="builder">The builder to add the rule to.</param>
    /// <param name="expression">Picks the value to compare with, like <c>m =&gt; m.MaxAge</c>.</param>
    /// <returns>The options of the rule.</returns>
    public static ICatValidatorPropertyRuleOptionsBuilder<TModel, TProperty> LessThanOrEqualTo<TModel, TProperty>(
        this ICatValidatorPropertyRuleBuilder<TModel, TProperty> builder,
        Expression<Func<TModel, TProperty>> expression)
        where TModel : class
        where TProperty : IComparable<TProperty>, IComparable
    {
        var newRule = new PropertyLessThanOrEqualToWithFuncValidatorRule<TModel, TProperty>(expression);
        return builder.AddPropertyRule(newRule);
    }

    /// <summary>
    /// The value must be greater than the given value. Code <c>CAT-VAL-1014</c>.
    /// </summary>
    /// <typeparam name="TModel">The type being validated.</typeparam>
    /// <typeparam name="TProperty">The type of the property.</typeparam>
    /// <param name="builder">The builder to add the rule to.</param>
    /// <param name="valueToCompare">The value to compare with.</param>
    /// <returns>The options of the rule.</returns>
    public static ICatValidatorPropertyRuleOptionsBuilder<TModel, TProperty> GreaterThan<TModel, TProperty>(
        this ICatValidatorPropertyRuleBuilder<TModel, TProperty> builder,
        TProperty valueToCompare)
        where TModel : class
        where TProperty : IComparable<TProperty>, IComparable
    {
        var newRule = new PropertyGreaterThanValidatorRule<TModel, TProperty>(valueToCompare);
        return builder.AddPropertyRule(newRule);
    }

    /// <summary>
    /// The value must be greater than another property of the model. Code <c>CAT-VAL-1014</c>.
    /// </summary>
    /// <typeparam name="TModel">The type being validated.</typeparam>
    /// <typeparam name="TProperty">The type of the property.</typeparam>
    /// <param name="builder">The builder to add the rule to.</param>
    /// <param name="expression">Picks the value to compare with, like <c>m =&gt; m.MinAge</c>.</param>
    /// <returns>The options of the rule.</returns>
    public static ICatValidatorPropertyRuleOptionsBuilder<TModel, TProperty> GreaterThan<TModel, TProperty>(
        this ICatValidatorPropertyRuleBuilder<TModel, TProperty> builder,
        Expression<Func<TModel, TProperty>> expression)
        where TModel : class
        where TProperty : IComparable<TProperty>, IComparable
    {
        var newRule = new PropertyGreaterThanWithFuncValidatorRule<TModel, TProperty>(expression);
        return builder.AddPropertyRule(newRule);
    }

    /// <summary>
    /// The value must be greater than or equal to the given value. Code <c>CAT-VAL-1015</c>.
    /// </summary>
    /// <typeparam name="TModel">The type being validated.</typeparam>
    /// <typeparam name="TProperty">The type of the property.</typeparam>
    /// <param name="builder">The builder to add the rule to.</param>
    /// <param name="valueToCompare">The value to compare with.</param>
    /// <returns>The options of the rule.</returns>
    public static ICatValidatorPropertyRuleOptionsBuilder<TModel, TProperty> GreaterThanOrEqualTo<TModel, TProperty>(
        this ICatValidatorPropertyRuleBuilder<TModel, TProperty> builder,
        TProperty valueToCompare)
        where TModel : class
        where TProperty : IComparable<TProperty>, IComparable
    {
        var newRule = new PropertyGreaterThanOrEqualToValidatorRule<TModel, TProperty>(valueToCompare);
        return builder.AddPropertyRule(newRule);
    }

    /// <summary>
    /// The value must be greater than or equal to another property of the model. Code <c>CAT-VAL-1015</c>.
    /// </summary>
    /// <typeparam name="TModel">The type being validated.</typeparam>
    /// <typeparam name="TProperty">The type of the property.</typeparam>
    /// <param name="builder">The builder to add the rule to.</param>
    /// <param name="expression">Picks the value to compare with, like <c>m =&gt; m.MinAge</c>.</param>
    /// <returns>The options of the rule.</returns>
    public static ICatValidatorPropertyRuleOptionsBuilder<TModel, TProperty> GreaterThanOrEqualTo<TModel, TProperty>(
        this ICatValidatorPropertyRuleBuilder<TModel, TProperty> builder,
        Expression<Func<TModel, TProperty>> expression)
        where TModel : class
        where TProperty : IComparable<TProperty>, IComparable
    {
        var newRule = new PropertyGreaterThanOrEqualToWithFuncValidatorRule<TModel, TProperty>(expression);
        return builder.AddPropertyRule(newRule);
    }

    /// <summary>
    /// The value must be between the bounds, bounds included. Code <c>CAT-VAL-1016</c>.
    /// The lower bound must be less than the upper bound.
    /// </summary>
    /// <typeparam name="TModel">The type being validated.</typeparam>
    /// <typeparam name="TProperty">The type of the property.</typeparam>
    /// <param name="builder">The builder to add the rule to.</param>
    /// <param name="lowerBound">The lowest allowed value.</param>
    /// <param name="upperBound">The highest allowed value.</param>
    /// <returns>The options of the rule.</returns>
    public static ICatValidatorPropertyRuleOptionsBuilder<TModel, TProperty>  InclusiveBetween<TModel, TProperty>(
        this ICatValidatorPropertyRuleBuilder<TModel, TProperty> builder,
        TProperty lowerBound,
        TProperty upperBound)
        where TModel : class
        where TProperty : IComparable<TProperty>, IComparable
    {
        var newRule = new PropertyInclusiveBetweenValidatorRule<TModel, TProperty>(lowerBound, upperBound);
        return builder.AddPropertyRule(newRule);
    }

    /// <summary>
    /// The value must be between two bounds taken from the model, bounds included. Code <c>CAT-VAL-1016</c>.
    /// The lower bound must be less than the upper bound.
    /// </summary>
    /// <typeparam name="TModel">The type being validated.</typeparam>
    /// <typeparam name="TProperty">The type of the property.</typeparam>
    /// <param name="builder">The builder to add the rule to.</param>
    /// <param name="lowerBoundFunc">Gets the lowest allowed value from the model.</param>
    /// <param name="upperBoundFunc">Gets the highest allowed value from the model.</param>
    /// <returns>The options of the rule.</returns>
    public static ICatValidatorPropertyRuleOptionsBuilder<TModel, TProperty>  InclusiveBetween<TModel, TProperty>(
        this ICatValidatorPropertyRuleBuilder<TModel, TProperty> builder,
        Func<TModel, TProperty> lowerBoundFunc,
        Func<TModel, TProperty> upperBoundFunc)
        where TModel : class
        where TProperty : IComparable<TProperty>, IComparable
    {
        var newRule = new PropertyInclusiveBetweenWithFuncValidatorRule<TModel, TProperty>(lowerBoundFunc, upperBoundFunc);
        return builder.AddPropertyRule(newRule);
    }

    /// <summary>
    /// The value must be between the bounds, bounds included, using your own comparer. Code <c>CAT-VAL-1016</c>.
    /// The lower bound must be less than the upper bound.
    /// </summary>
    /// <typeparam name="TModel">The type being validated.</typeparam>
    /// <typeparam name="TProperty">The type of the property.</typeparam>
    /// <param name="builder">The builder to add the rule to.</param>
    /// <param name="lowerBound">The lowest allowed value.</param>
    /// <param name="upperBound">The highest allowed value.</param>
    /// <param name="comparer">Decides how values are ordered.</param>
    /// <returns>The options of the rule.</returns>
    public static ICatValidatorPropertyRuleOptionsBuilder<TModel, TProperty>  InclusiveBetween<TModel, TProperty>(
        this ICatValidatorPropertyRuleBuilder<TModel, TProperty> builder,
        TProperty lowerBound,
        TProperty upperBound,
        IComparer<TProperty> comparer)
        where TModel : class
        where TProperty : IComparable<TProperty>, IComparable
    {
        var newRule = new PropertyInclusiveBetweenWithComparerValidatorRule<TModel, TProperty>(lowerBound, upperBound, comparer);
        return builder.AddPropertyRule(newRule);
    }

    /// <summary>
    /// The value must be between two bounds taken from the model, bounds included, using your own comparer.
    /// Code <c>CAT-VAL-1016</c>. The lower bound must be less than the upper bound.
    /// </summary>
    /// <typeparam name="TModel">The type being validated.</typeparam>
    /// <typeparam name="TProperty">The type of the property.</typeparam>
    /// <param name="builder">The builder to add the rule to.</param>
    /// <param name="lowerBoundFunc">Gets the lowest allowed value from the model.</param>
    /// <param name="upperBoundFunc">Gets the highest allowed value from the model.</param>
    /// <param name="comparer">Decides how values are ordered.</param>
    /// <returns>The options of the rule.</returns>
    public static ICatValidatorPropertyRuleOptionsBuilder<TModel, TProperty>  InclusiveBetween<TModel, TProperty>(
        this ICatValidatorPropertyRuleBuilder<TModel, TProperty> builder,
        Func<TModel, TProperty> lowerBoundFunc,
        Func<TModel, TProperty> upperBoundFunc,
        IComparer<TProperty> comparer)
        where TModel : class
        where TProperty : IComparable<TProperty>, IComparable
    {
        var newRule = new PropertyInclusiveBetweenWithFuncAndComparerValidatorRule<TModel, TProperty>(lowerBoundFunc, upperBoundFunc, comparer);
        return builder.AddPropertyRule(newRule);
    }

    /// <summary>
    /// The value must be between the bounds, bounds excluded. Code <c>CAT-VAL-1017</c>.
    /// The lower bound must be less than the upper bound.
    /// </summary>
    /// <typeparam name="TModel">The type being validated.</typeparam>
    /// <typeparam name="TProperty">The type of the property.</typeparam>
    /// <param name="builder">The builder to add the rule to.</param>
    /// <param name="lowerBound">The value the property must be greater than.</param>
    /// <param name="upperBound">The value the property must be less than.</param>
    /// <returns>The options of the rule.</returns>
    public static ICatValidatorPropertyRuleOptionsBuilder<TModel, TProperty>  ExclusiveBetween<TModel, TProperty>(
        this ICatValidatorPropertyRuleBuilder<TModel, TProperty> builder,
        TProperty lowerBound,
        TProperty upperBound)
        where TModel : class
        where TProperty : IComparable<TProperty>, IComparable
    {
        var newRule = new PropertyExclusiveBetweenValidatorRule<TModel, TProperty>(lowerBound, upperBound);
        return builder.AddPropertyRule(newRule);
    }

    /// <summary>
    /// The value must be between two bounds taken from the model, bounds excluded. Code <c>CAT-VAL-1017</c>.
    /// The lower bound must be less than the upper bound.
    /// </summary>
    /// <typeparam name="TModel">The type being validated.</typeparam>
    /// <typeparam name="TProperty">The type of the property.</typeparam>
    /// <param name="builder">The builder to add the rule to.</param>
    /// <param name="lowerBoundFunc">Gets the value the property must be greater than.</param>
    /// <param name="upperBoundFunc">Gets the value the property must be less than.</param>
    /// <returns>The options of the rule.</returns>
    public static ICatValidatorPropertyRuleOptionsBuilder<TModel, TProperty>  ExclusiveBetween<TModel, TProperty>(
        this ICatValidatorPropertyRuleBuilder<TModel, TProperty> builder,
        Func<TModel, TProperty> lowerBoundFunc,
        Func<TModel, TProperty> upperBoundFunc)
        where TModel : class
        where TProperty : IComparable<TProperty>, IComparable
    {
        var newRule = new PropertyExclusiveBetweenWithFuncValidatorRule<TModel, TProperty>(lowerBoundFunc, upperBoundFunc);
        return builder.AddPropertyRule(newRule);
    }

    /// <summary>
    /// The value must be between the bounds, bounds excluded, using your own comparer. Code <c>CAT-VAL-1017</c>.
    /// The lower bound must be less than the upper bound.
    /// </summary>
    /// <typeparam name="TModel">The type being validated.</typeparam>
    /// <typeparam name="TProperty">The type of the property.</typeparam>
    /// <param name="builder">The builder to add the rule to.</param>
    /// <param name="lowerBound">The value the property must be greater than.</param>
    /// <param name="upperBound">The value the property must be less than.</param>
    /// <param name="comparer">Decides how values are ordered.</param>
    /// <returns>The options of the rule.</returns>
    public static ICatValidatorPropertyRuleOptionsBuilder<TModel, TProperty>  ExclusiveBetween<TModel, TProperty>(
        this ICatValidatorPropertyRuleBuilder<TModel, TProperty> builder,
        TProperty lowerBound,
        TProperty upperBound,
        IComparer<TProperty> comparer)
        where TModel : class
        where TProperty : IComparable<TProperty>, IComparable
    {
        var newRule = new PropertyExclusiveBetweenWithComparerValidatorRule<TModel, TProperty>(lowerBound, upperBound, comparer);
        return builder.AddPropertyRule(newRule);
    }

    /// <summary>
    /// The value must be between two bounds taken from the model, bounds excluded, using your own comparer.
    /// Code <c>CAT-VAL-1017</c>. The lower bound must be less than the upper bound.
    /// </summary>
    /// <typeparam name="TModel">The type being validated.</typeparam>
    /// <typeparam name="TProperty">The type of the property.</typeparam>
    /// <param name="builder">The builder to add the rule to.</param>
    /// <param name="lowerBoundFunc">Gets the value the property must be greater than.</param>
    /// <param name="upperBoundFunc">Gets the value the property must be less than.</param>
    /// <param name="comparer">Decides how values are ordered.</param>
    /// <returns>The options of the rule.</returns>
    public static ICatValidatorPropertyRuleOptionsBuilder<TModel, TProperty>  ExclusiveBetween<TModel, TProperty>(
        this ICatValidatorPropertyRuleBuilder<TModel, TProperty> builder,
        Func<TModel, TProperty> lowerBoundFunc,
        Func<TModel, TProperty> upperBoundFunc,
        IComparer<TProperty> comparer)
        where TModel : class
        where TProperty : IComparable<TProperty>, IComparable
    {
        var newRule = new PropertyExclusiveBetweenWithFuncAndComparerValidatorRule<TModel, TProperty>(lowerBoundFunc, upperBoundFunc, comparer);
        return builder.AddPropertyRule(newRule);
    }

    #region String Specific Validators

    /// <summary>
    /// The text length must be between the minimum and the maximum. Code <c>CAT-VAL-1005</c>.
    /// A <c>null</c> string passes. The minimum must be less than the maximum.
    /// </summary>
    /// <typeparam name="TModel">The type being validated.</typeparam>
    /// <param name="builder">The builder to add the rule to.</param>
    /// <param name="min">The shortest allowed length.</param>
    /// <param name="max">The longest allowed length.</param>
    /// <returns>The options of the rule.</returns>
    public static ICatValidatorPropertyRuleOptionsBuilder<TModel, string> Length<TModel>(
        this ICatValidatorPropertyRuleBuilder<TModel, string> builder,
        int min,
        int max)
        where TModel : class
    {
        var newRule = new PropertyStringLengthValidatorRule<TModel>(min, max);
        return builder.AddPropertyRule(newRule);
    }

    /// <summary>
    /// The text length must be between a minimum and a maximum taken from the model. Code <c>CAT-VAL-1005</c>.
    /// A <c>null</c> string passes. The minimum must be less than the maximum.
    /// </summary>
    /// <typeparam name="TModel">The type being validated.</typeparam>
    /// <param name="builder">The builder to add the rule to.</param>
    /// <param name="minFunc">Gets the shortest allowed length from the model.</param>
    /// <param name="maxFunc">Gets the longest allowed length from the model.</param>
    /// <returns>The options of the rule.</returns>
    public static ICatValidatorPropertyRuleOptionsBuilder<TModel, string> Length<TModel>(
        this ICatValidatorPropertyRuleBuilder<TModel, string> builder,
        Func<TModel, int> minFunc,
        Func<TModel, int> maxFunc)
        where TModel : class
    {
        var newRule = new PropertyStringLengthWithFuncValidatorRule<TModel>(minFunc, maxFunc);
        return builder.AddPropertyRule(newRule);
    }

    /// <summary>
    /// The text must have exactly the given length. Code <c>CAT-VAL-1006</c>.
    /// A <c>null</c> string passes.
    /// </summary>
    /// <typeparam name="TModel">The type being validated.</typeparam>
    /// <param name="builder">The builder to add the rule to.</param>
    /// <param name="exactLength">The required length.</param>
    /// <returns>The options of the rule.</returns>
    public static ICatValidatorPropertyRuleOptionsBuilder<TModel, string> ExactLength<TModel>(
        this ICatValidatorPropertyRuleBuilder<TModel, string> builder,
        int exactLength)
        where TModel : class
    {
        var newRule = new PropertyStringExactLengthValidatorRule<TModel>(exactLength);
        return builder.AddPropertyRule(newRule);
    }

    /// <summary>
    /// The text must have exactly the length taken from the model. Code <c>CAT-VAL-1006</c>.
    /// A <c>null</c> string passes.
    /// </summary>
    /// <typeparam name="TModel">The type being validated.</typeparam>
    /// <param name="builder">The builder to add the rule to.</param>
    /// <param name="exactLengthFunc">Gets the required length from the model.</param>
    /// <returns>The options of the rule.</returns>
    public static ICatValidatorPropertyRuleOptionsBuilder<TModel, string> ExactLength<TModel>(
        this ICatValidatorPropertyRuleBuilder<TModel, string> builder,
        Func<TModel, int> exactLengthFunc)
        where TModel : class
    {
        var newRule = new PropertyStringExactLengthWithFuncValidatorRule<TModel>(exactLengthFunc);
        return builder.AddPropertyRule(newRule);
    }

    /// <summary>
    /// The text must not be longer than the maximum. Code <c>CAT-VAL-1007</c>.
    /// A <c>null</c> string passes.
    /// </summary>
    /// <typeparam name="TModel">The type being validated.</typeparam>
    /// <param name="builder">The builder to add the rule to.</param>
    /// <param name="maximumLength">The longest allowed length.</param>
    /// <returns>The options of the rule.</returns>
    public static ICatValidatorPropertyRuleOptionsBuilder<TModel, string> MaximumLength<TModel>(
        this ICatValidatorPropertyRuleBuilder<TModel, string> builder,
        int maximumLength)
        where TModel : class
    {
        var newRule = new PropertyStringMaximumLengthValidatorRule<TModel>(maximumLength);
        return builder.AddPropertyRule(newRule);
    }

    /// <summary>
    /// The text must not be longer than the maximum taken from the model. Code <c>CAT-VAL-1007</c>.
    /// A <c>null</c> string passes.
    /// </summary>
    /// <typeparam name="TModel">The type being validated.</typeparam>
    /// <param name="builder">The builder to add the rule to.</param>
    /// <param name="maximumLengthFunc">Gets the longest allowed length from the model.</param>
    /// <returns>The options of the rule.</returns>
    public static ICatValidatorPropertyRuleOptionsBuilder<TModel, string> MaximumLength<TModel>(
        this ICatValidatorPropertyRuleBuilder<TModel, string> builder,
        Func<TModel, int> maximumLengthFunc)
        where TModel : class
    {
        var newRule = new PropertyStringMaximumLengthWithFuncValidatorRule<TModel>(maximumLengthFunc);
        return builder.AddPropertyRule(newRule);
    }

    /// <summary>
    /// The text must not be shorter than the minimum. Code <c>CAT-VAL-1008</c>.
    /// A <c>null</c> string passes.
    /// </summary>
    /// <typeparam name="TModel">The type being validated.</typeparam>
    /// <param name="builder">The builder to add the rule to.</param>
    /// <param name="minimumLength">The shortest allowed length.</param>
    /// <returns>The options of the rule.</returns>
    public static ICatValidatorPropertyRuleOptionsBuilder<TModel, string> MinimumLength<TModel>(
        this ICatValidatorPropertyRuleBuilder<TModel, string> builder,
        int minimumLength)
        where TModel : class
    {
        var newRule = new PropertyStringMinimumLengthValidatorRule<TModel>(minimumLength);
        return builder.AddPropertyRule(newRule);
    }

    /// <summary>
    /// The text must not be shorter than the minimum taken from the model. Code <c>CAT-VAL-1008</c>.
    /// A <c>null</c> string passes.
    /// </summary>
    /// <typeparam name="TModel">The type being validated.</typeparam>
    /// <param name="builder">The builder to add the rule to.</param>
    /// <param name="minimumLengthFunc">Gets the shortest allowed length from the model.</param>
    /// <returns>The options of the rule.</returns>
    public static ICatValidatorPropertyRuleOptionsBuilder<TModel, string> MinimumLength<TModel>(
        this ICatValidatorPropertyRuleBuilder<TModel, string> builder,
        Func<TModel, int> minimumLengthFunc)
        where TModel : class
    {
        var newRule = new PropertyStringMinimumLengthWithFuncValidatorRule<TModel>(minimumLengthFunc);
        return builder.AddPropertyRule(newRule);
    }

    /// <summary>
    /// The text must match the regular expression pattern. Code <c>CAT-VAL-1009</c>.
    /// A <c>null</c> string passes.
    /// </summary>
    /// <typeparam name="TModel">The type being validated.</typeparam>
    /// <param name="builder">The builder to add the rule to.</param>
    /// <param name="regexPattern">The regular expression pattern.</param>
    /// <param name="options">The options for the regular expression.</param>
    /// <returns>The options of the rule.</returns>
    public static ICatValidatorPropertyRuleOptionsBuilder<TModel, string> MatchesRegex<TModel>(
        this ICatValidatorPropertyRuleBuilder<TModel, string> builder,
        string regexPattern,
        RegexOptions options = RegexOptions.None)
        where TModel : class
    {
        var newRule = new PropertyStringMatchesRegexWithPatternValidatorRule<TModel>(regexPattern, options);
        return builder.AddPropertyRule(newRule);
    }

    /// <summary>
    /// The text must match a regular expression pattern taken from the model. Code <c>CAT-VAL-1009</c>.
    /// A <c>null</c> string passes.
    /// </summary>
    /// <typeparam name="TModel">The type being validated.</typeparam>
    /// <param name="builder">The builder to add the rule to.</param>
    /// <param name="regexPatternFunc">Gets the regular expression pattern from the model.</param>
    /// <param name="options">The options for the regular expression.</param>
    /// <returns>The options of the rule.</returns>
    public static ICatValidatorPropertyRuleOptionsBuilder<TModel, string> MatchesRegex<TModel>(
        this ICatValidatorPropertyRuleBuilder<TModel, string> builder,
        Func<TModel, string> regexPatternFunc,
        RegexOptions options = RegexOptions.None)
        where TModel : class
    {
        var newRule = new PropertyStringMatchesRegexWithPatternFuncValidatorRule<TModel>(regexPatternFunc, options);
        return builder.AddPropertyRule(newRule);
    }

    /// <summary>
    /// The text must match the regular expression. Code <c>CAT-VAL-1009</c>.
    /// A <c>null</c> string passes.
    /// </summary>
    /// <typeparam name="TModel">The type being validated.</typeparam>
    /// <param name="builder">The builder to add the rule to.</param>
    /// <param name="regex">The regular expression.</param>
    /// <returns>The options of the rule.</returns>
    public static ICatValidatorPropertyRuleOptionsBuilder<TModel, string> MatchesRegex<TModel>(
        this ICatValidatorPropertyRuleBuilder<TModel, string> builder,
        Regex regex)
        where TModel : class
    {
        var newRule = new PropertyStringMatchesRegexValidatorRule<TModel>(regex);
        return builder.AddPropertyRule(newRule);
    }

    /// <summary>
    /// The text must match a regular expression taken from the model. Code <c>CAT-VAL-1009</c>.
    /// A <c>null</c> string passes.
    /// </summary>
    /// <typeparam name="TModel">The type being validated.</typeparam>
    /// <param name="builder">The builder to add the rule to.</param>
    /// <param name="regexFunc">Gets the regular expression from the model.</param>
    /// <returns>The options of the rule.</returns>
    public static ICatValidatorPropertyRuleOptionsBuilder<TModel, string> MatchesRegex<TModel>(
        this ICatValidatorPropertyRuleBuilder<TModel, string> builder,
        Func<TModel, Regex> regexFunc)
        where TModel : class
    {
        var newRule = new PropertyStringMatchesRegexWithFuncValidatorRule<TModel>(regexFunc);
        return builder.AddPropertyRule(newRule);
    }

    #endregion String Specific Validators

    /// <summary>
    /// Validates the property with its own validator.
    /// Errors get the property name as a prefix, like <c>Todo.Title</c>.
    /// A <c>null</c> property passes. A property without a registered validator is skipped only when the top level call
    /// has <c>validatorRequired</c> set to <c>false</c>. Otherwise it throws.
    /// </summary>
    /// <typeparam name="TModel">The type being validated.</typeparam>
    /// <typeparam name="TProperty">The type of the property.</typeparam>
    /// <param name="builder">The builder to add the rule to.</param>
    /// <returns>The options of the rule.</returns>
    public static ICatValidatorPropertyRuleOptionsBuilder<TModel, TProperty> Validate<TModel, TProperty>(
        this ICatValidatorPropertyRuleBuilder<TModel, TProperty> builder)
        where TModel : class
        where TProperty : class?
    {
        var newRule = new PropertyValidateValidatorRule<TModel, TProperty>();
        return builder.AddPropertyRule(newRule);
    }

    /// <summary>
    /// Validates each item of the collection with its own validator.
    /// Errors get the property name and the item index as a prefix, like <c>Items[0].Title</c>.
    /// A <c>null</c> collection passes. A <c>null</c> item is skipped but still counts for the index.
    /// An item without a registered validator is skipped only when the top level call
    /// has <c>validatorRequired</c> set to <c>false</c>. Otherwise it throws.
    /// </summary>
    /// <typeparam name="TModel">The type being validated.</typeparam>
    /// <typeparam name="TProperty">The type of the collection.</typeparam>
    /// <param name="builder">The builder to add the rule to.</param>
    /// <returns>The options of the rule.</returns>
    public static ICatValidatorPropertyRuleOptionsBuilder<TModel, TProperty> ValidateEnumerable<TModel, TProperty>(
        this ICatValidatorPropertyRuleBuilder<TModel, TProperty> builder)
        where TModel : class
        where TProperty : IEnumerable?
    {
        var newRule = new EnumerablePropertyValidateValidatorRule<TModel, TProperty>();
        return builder.AddPropertyRule(newRule);
    }

    /// <summary>
    /// Adds an async rule that checks the property with your own code.
    /// You build the errors yourself, so the other options don't apply.
    /// </summary>
    /// <typeparam name="TModel">The type being validated.</typeparam>
    /// <typeparam name="TProperty">The type of the property.</typeparam>
    /// <param name="builder">The builder to add the rule to.</param>
    /// <param name="predicate">Gets the value, the field name and a cancellation token. Returns the failures, or an empty list.</param>
    public static void MustAsync<TModel, TProperty>(
        this ICatValidatorPropertyRuleBuilder<TModel, TProperty> builder,
        Func<TProperty, string, CancellationToken, Task<List<ICatValidatorError>>> predicate)
        where TModel : class
    {
        var newRule = new PropertyMustAsyncValidatorRule<TModel, TProperty>(predicate);
        builder.AddPropertyRule(newRule);
    }

    /// <summary>
    /// Adds a rule that checks the property with your own code.
    /// You build the errors yourself, so the other options don't apply.
    /// </summary>
    /// <typeparam name="TModel">The type being validated.</typeparam>
    /// <typeparam name="TProperty">The type of the property.</typeparam>
    /// <param name="builder">The builder to add the rule to.</param>
    /// <param name="predicate">Gets the value and the field name. Returns the failures, or an empty list.</param>
    public static void Must<TModel, TProperty>(
        this ICatValidatorPropertyRuleBuilder<TModel, TProperty> builder,
        Func<TProperty, string, List<ICatValidatorError>> predicate)
        where TModel : class
    {
        var newRule = new PropertyMustValidatorRule<TModel, TProperty>(predicate);
        builder.AddPropertyRule(newRule);
    }

    /// <summary>
    /// Adds an async rule that checks the property with your own code and can look at the whole model.
    /// You build the errors yourself, so the other options don't apply.
    /// </summary>
    /// <typeparam name="TModel">The type being validated.</typeparam>
    /// <typeparam name="TProperty">The type of the property.</typeparam>
    /// <param name="builder">The builder to add the rule to.</param>
    /// <param name="predicate">Gets the value, the field name, the model and a cancellation token. Returns the failures, or an empty list.</param>
    public static void MustAsync<TModel, TProperty>(
        this ICatValidatorPropertyRuleBuilder<TModel, TProperty> builder,
        Func<TProperty, string, TModel, CancellationToken, Task<List<ICatValidatorError>>> predicate)
        where TModel : class
    {
        var newRule = new PropertyModelMustAsyncValidatorRule<TModel, TProperty>(predicate);
        builder.AddPropertyRule(newRule);
    }

    /// <summary>
    /// Adds a rule that checks the property with your own code and can look at the whole model.
    /// You build the errors yourself, so the other options don't apply.
    /// </summary>
    /// <typeparam name="TModel">The type being validated.</typeparam>
    /// <typeparam name="TProperty">The type of the property.</typeparam>
    /// <param name="builder">The builder to add the rule to.</param>
    /// <param name="predicate">Gets the value, the field name and the model. Returns the failures, or an empty list.</param>
    public static void Must<TModel, TProperty>(
        this ICatValidatorPropertyRuleBuilder<TModel, TProperty> builder,
        Func<TProperty, string, TModel, List<ICatValidatorError>> predicate)
        where TModel : class
    {
        var newRule = new PropertyModelMustValidatorRule<TModel, TProperty>(predicate);
        builder.AddPropertyRule(newRule);
    }
}

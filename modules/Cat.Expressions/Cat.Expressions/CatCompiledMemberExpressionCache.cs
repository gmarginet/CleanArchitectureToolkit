using System;
using System.Collections.Concurrent;
using System.Linq.Expressions;
using System.Reflection;
using Cat.Expression.Extensions;
using Cat.Expressions.Abstractions;
using Cat.Expressions.Extensions;
using Cat.Object.Extensions;
using Cat.Objects.Extensions;

namespace Cat.Expressions;

/// <summary>
/// Caches compiled member expressions in a concurrent dictionary, keyed by member and expression text, so the
/// same expression is compiled only once.
/// </summary>
/// <typeparam name="T">The type the member expression is evaluated against.</typeparam>
internal class CatCompiledMemberExpressionCache<T> : ICatCompiledMemberExpressionCache<T>
    where T : class
{
    private readonly ConcurrentDictionary<CatCompiledMemberExpressionKey, Delegate> _cache = new();

    /// <inheritdoc />
    public Func<T, TProperty> GetOrAdd<TProperty>(Expression<Func<T, TProperty>> expression,
        MemberInfo? memberInfo = null)
    {
        expression.ThrowIfNull(nameof(expression));
        memberInfo ??= expression.GetMemberInfo();
        // if the expression is not a member expression, compile it and return it
        if (memberInfo == null) return expression.Compile();

        var key = new CatCompiledMemberExpressionKey(memberInfo, expression);
        return (Func<T, TProperty>)_cache.GetOrAdd(key, _ => expression.Compile());
    }
}
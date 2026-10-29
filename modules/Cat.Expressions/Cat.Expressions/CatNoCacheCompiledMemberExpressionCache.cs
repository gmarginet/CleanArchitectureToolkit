using System;
using System.Linq.Expressions;
using System.Reflection;
using Cat.Expressions.Abstractions;
using Cat.Object.Extensions;
using Cat.Objects.Extensions;

namespace Cat.Expressions;

/// <summary>
/// Compiles a member expression into a delegate on every call, without caching the result.
/// Use this when caching isn't worth it, for example when expressions are built fresh each time anyway.
/// </summary>
/// <typeparam name="T">The type the member expression is evaluated against.</typeparam>
public class CatNoCacheCompiledMemberExpressionCache<T> : ICatCompiledMemberExpressionCache<T>
    where T : class
{
    /// <inheritdoc />
    public Func<T, TProperty> GetOrAdd<TProperty>(Expression<Func<T, TProperty>> expression, MemberInfo? memberInfo = null)
    {
        expression.ThrowIfNull(nameof(expression));
        return expression.Compile();
    }
}
using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Cat.Expressions.Abstractions;

/// <summary>
/// Caches compiled member access delegates for <typeparamref name="T"/>, so the same expression doesn't get recompiled on every call.
/// </summary>
/// <typeparam name="T">The type the member expression is evaluated against.</typeparam>
public interface ICatCompiledMemberExpressionCache<T>
    where T : class
{
    /// <summary>
    /// Compiles the given member expression into a delegate, or returns the delegate compiled for it on a previous call.
    /// </summary>
    /// <typeparam name="TProperty">The type of value the compiled delegate returns.</typeparam>
    /// <param name="expression">The member access expression to compile.</param>
    /// <param name="memberInfo">The member the expression resolves to, if already known. Pass <c>null</c> to let the cache resolve it from the expression.</param>
    /// <returns>A compiled delegate that evaluates the expression against an instance of <typeparamref name="T"/>.</returns>
    Func<T, TProperty> GetOrAdd<TProperty>(Expression<Func<T, TProperty>> expression, MemberInfo? memberInfo = null);
}
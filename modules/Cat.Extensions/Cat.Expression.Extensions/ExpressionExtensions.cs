using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Cat.Expression.Extensions;

/// <summary>
/// Extension methods for inspecting <see cref="System.Linq.Expressions.Expression"/> trees.
/// </summary>
public static class ExpressionExtensions
{
    /// <summary>
    /// Resolves the member a simple member access expression points to, for example the <c>Id</c> property in <c>x => x.Id</c>.
    /// </summary>
    /// <typeparam name="T">The type the expression's parameter is evaluated against.</typeparam>
    /// <typeparam name="TProperty">The type of value the expression returns.</typeparam>
    /// <param name="expression">The expression to inspect.</param>
    /// <returns>The resolved member, or <c>null</c> if the expression isn't a direct member access on its parameter.</returns>
    public static MemberInfo? GetMemberInfo<T, TProperty>(this Expression<Func<T, TProperty>> expression) {
        if (RemoveUnary(expression.Body) is not MemberExpression memberExp) {
            return null;
        }

        var currentExpr = memberExp.Expression;
        if (currentExpr is null) return null;

        while (true) {
            currentExpr = RemoveUnary(currentExpr);

            if (currentExpr.NodeType is ExpressionType.MemberAccess) {
                currentExpr = ((MemberExpression)currentExpr).Expression;

                // a static member has no instance expression, so the chain does not start at the parameter
                if (currentExpr is null) return null;
            }
            else
            {
                break;
            }
        }

        return currentExpr.NodeType is not ExpressionType.Parameter ? null : memberExp.Member;
    }

    /// <summary>
    /// Unwraps a unary expression, such as a boxing conversion, to get at its underlying operand.
    /// </summary>
    /// <param name="expression">The expression to unwrap.</param>
    /// <returns>The operand of a unary expression, or the expression itself if it isn't unary.</returns>
    private static System.Linq.Expressions.Expression RemoveUnary(System.Linq.Expressions.Expression expression) {
        if (expression is UnaryExpression unaryExpression) {
            return unaryExpression.Operand;
        }

        return expression;
    }
}
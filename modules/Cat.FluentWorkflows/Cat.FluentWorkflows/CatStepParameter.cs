using System;
using System.Linq;
using System.Linq.Expressions;
using Cat.FluentWorkflows.Abstractions;

namespace Cat.FluentWorkflows;

/// <summary>
/// Default <see cref="ICatStepParameter"/>.
/// Reads a value with one expression and writes it with another. A <c>null</c> value writes the default of the target type.
/// </summary>
public class CatStepParameter : ICatStepParameter
{
    private readonly LambdaExpression _sourceExp;
    private readonly LambdaExpression _targetExp;

    /// <summary>
    /// Creates the parameter.
    /// </summary>
    /// <param name="source">Reads the value.</param>
    /// <param name="target">Picks the member to write. Its body must be a member access.</param>
    /// <exception cref="NotSupportedException">The target is not a member access.</exception>
    public CatStepParameter(LambdaExpression source, LambdaExpression target)
    {
        if (target.Body.NodeType != ExpressionType.MemberAccess)
        {
            throw new NotSupportedException();
        }

        _sourceExp = source;
        _targetExp = target;
    }

    /// <inheritdoc />
    public void Assign(object source, object target)
    {
        var resolvedValue = _sourceExp.Compile().DynamicInvoke(source);

        if (resolvedValue == null)
        {
            var defaultAssign = Expression.Lambda(Expression.Assign(_targetExp.Body, Expression.Default(_targetExp.ReturnType)), _targetExp.Parameters.Single());
            defaultAssign.Compile().DynamicInvoke(target);
            return;
        }

        var valueExpr = Expression.Convert(Expression.Constant(resolvedValue), _targetExp.ReturnType);
        var assign = Expression.Lambda(Expression.Assign(_targetExp.Body, valueExpr), _targetExp.Parameters.Single());
        assign.Compile().DynamicInvoke(target);
    }
    
}
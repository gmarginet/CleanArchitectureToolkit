using System;
using System.Linq;
using System.Linq.Expressions;
using Cat.FluentWorkflows.Abstractions;
using Microsoft.Extensions.Logging;

namespace Cat.FluentWorkflows.Steps;

/// <summary>
/// Built-in step behind <c>Set</c>. It calculates a value and writes it to a property of the workflow state.
/// </summary>
/// <typeparam name="TWorkflowState">The state of the workflow.</typeparam>
/// <typeparam name="TProperty">The type of the property.</typeparam>
public class CatSetStatePropertyStep<TWorkflowState, TProperty> : CatStepBody<TWorkflowState>
    where TWorkflowState : class, ICatWorkflowState<TWorkflowState>
{
    /// <summary>
    /// Creates the step.
    /// </summary>
    /// <param name="logger">The logger the step passes to your code.</param>
    public CatSetStatePropertyStep(
        ILogger<CatSetStatePropertyStep<TWorkflowState, TProperty>> logger)
        : base(logger)
    {
    }

    /// <summary>
    /// Picks the property to write.
    /// </summary>
    public Expression<Func<TWorkflowState, TProperty>> StateProperty { get; set; } = null!;

    /// <summary>
    /// Calculates the new value from the logger and the workflow state.
    /// </summary>
    public Expression<Func<ILogger, TWorkflowState, TProperty>> GetPropertyValue { get; set; } = null!;

    /// <inheritdoc />
    protected override ICatWorkflowResponse Run()
    {
        var workflowState = ((ICatStepBodyWithState<TWorkflowState>)this).WorkflowState;

        var resolvedValue = GetPropertyValue.Compile().DynamicInvoke(Logger, workflowState);
            
        var valueExpr = Expression.Convert(Expression.Constant(resolvedValue), typeof(TProperty));
        var assignExpr = Expression.Assign(StateProperty.Body, valueExpr);
        var assign = Expression.Lambda(assignExpr, StateProperty.Parameters.Single());

        assign.Compile().DynamicInvoke(workflowState);
            
        return CatWorkflowResponse.Succeeded(CatStepExecutionResult.Continue);
    }
}
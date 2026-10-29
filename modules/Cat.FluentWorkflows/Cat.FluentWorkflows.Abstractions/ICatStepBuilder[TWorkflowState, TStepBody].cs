using System;
using System.Linq.Expressions;

namespace Cat.FluentWorkflows.Abstractions;

/// <summary>
/// Connects a step to the workflow state. Inputs go from the state into the step before it runs.
/// Outputs go from the step back into the state after it ran.
/// </summary>
/// <typeparam name="TWorkflowState">The state of the workflow.</typeparam>
/// <typeparam name="TStepBody">The step body being configured.</typeparam>
public interface ICatStepBuilder<TWorkflowState, TStepBody>
    where TWorkflowState : class, ICatWorkflowState<TWorkflowState>
    where TStepBody : class, ICatStepBodyAsync
{
    /// <summary>
    /// Copies a value from the workflow state into a member of the step, right before the step runs.
    /// </summary>
    /// <typeparam name="TInput">The type of the value.</typeparam>
    /// <param name="source">Reads the value from the state, like <c>s =&gt; s.Total</c>.</param>
    /// <param name="target">Picks the member of the step to fill, like <c>step =&gt; step.Amount</c>. It must be a member access.</param>
    /// <returns>The same builder, so calls can be chained.</returns>
    ICatStepBuilder<TWorkflowState, TStepBody> Input<TInput>(Expression<Func<TWorkflowState, TInput>> source,
        Expression<Func<TStepBody, TInput>> target);

    /// <summary>
    /// Copies a value from a member of the step into the workflow state, right after the step ran.
    /// </summary>
    /// <typeparam name="TOutput">The type of the value.</typeparam>
    /// <param name="source">Reads the value from the step, like <c>step =&gt; step.Result</c>.</param>
    /// <param name="target">Picks the property of the state to fill, like <c>s =&gt; s.Total</c>. It must be a member access.</param>
    /// <returns>The same builder, so calls can be chained.</returns>
    ICatStepBuilder<TWorkflowState, TStepBody> Output<TOutput>(Expression<Func<TStepBody, TOutput>> source,
        Expression<Func<TWorkflowState, TOutput>> target);
}
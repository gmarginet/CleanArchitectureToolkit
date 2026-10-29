using System;
using System.Linq.Expressions;
using Cat.FluentWorkflows.Abstractions;

namespace Cat.FluentWorkflows;

/// <summary>
/// Default <see cref="ICatStepBuilder{TWorkflowState, TStepBody}"/>.
/// Stores the inputs and outputs on the workflow step.
/// </summary>
/// <typeparam name="TWorkflowState">The state of the workflow.</typeparam>
/// <typeparam name="TStepBody">The step body being configured.</typeparam>
public class CatStepBuilder<TWorkflowState, TStepBody> : ICatStepBuilder<TWorkflowState, TStepBody>
    where TWorkflowState : class , ICatWorkflowState<TWorkflowState>
    where TStepBody : class, ICatStepBodyAsync
{
    private readonly CatWorkflowStep<TStepBody> _workflowStep;

    /// <summary>
    /// Creates the builder.
    /// </summary>
    /// <param name="workflowStep">The step to add the inputs and outputs to.</param>
    public CatStepBuilder(CatWorkflowStep<TStepBody> workflowStep)
    {
        _workflowStep = workflowStep;
    }

    /// <inheritdoc />
    public ICatStepBuilder<TWorkflowState, TStepBody> Input<TInput>(Expression<Func<TWorkflowState, TInput>> source, Expression<Func<TStepBody, TInput>> target)
    {
        _workflowStep.Inputs.Add(new CatStepParameter(source, target));
        return this;
    }

    /// <inheritdoc />
    public ICatStepBuilder<TWorkflowState, TStepBody> Output<TOutput>(Expression<Func<TStepBody, TOutput>> source, Expression<Func<TWorkflowState, TOutput>> target)
    {
        _workflowStep.Outputs.Add(new CatStepParameter(source, target));
        return this;
    }
}
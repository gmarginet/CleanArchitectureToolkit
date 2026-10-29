using System;
using Cat.FluentWorkflows.Abstractions;
using Microsoft.Extensions.Logging;

namespace Cat.FluentWorkflows.Steps;

/// <summary>
/// Built-in step behind <c>Run(Action)</c>. It runs your code and always continues.
/// </summary>
/// <typeparam name="TWorkflowState">The state of the workflow.</typeparam>
public class CatInlineActionStep<TWorkflowState> : CatStepBody<TWorkflowState>
    where TWorkflowState : class, ICatWorkflowState<TWorkflowState>
{
    /// <summary>
    /// Creates the step.
    /// </summary>
    /// <param name="logger">The logger the step passes to your code.</param>
    public CatInlineActionStep(
        ILogger<CatInlineActionStep<TWorkflowState>> logger)
        : base(logger)
    {
    }

    /// <summary>
    /// Your code. It gets the logger and the workflow state.
    /// </summary>
    public Action<ILogger, TWorkflowState> Body { get; set; } = null!;

    /// <inheritdoc />
    protected override ICatWorkflowResponse Run()
    {
        Body(Logger, WorkflowState);

        return CatWorkflowResponse.Succeeded(CatStepExecutionResult.Continue);
    }
}
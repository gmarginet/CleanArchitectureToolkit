using System;
using Cat.FluentWorkflows.Abstractions;
using Microsoft.Extensions.Logging;

namespace Cat.FluentWorkflows.Steps;

/// <summary>
/// Built-in step behind <c>BreakCascadeIf</c>, <c>BreakFromCurrentFlowOnlyIf</c> and <c>BreakFromLoopIf</c>.
/// It runs the check. When the check returns <c>true</c> it breaks the way <see cref="BreakType"/> says, otherwise it continues.
/// </summary>
/// <typeparam name="TWorkflowState">The state of the workflow.</typeparam>
public class CatBreakIfStep<TWorkflowState> : CatStepBody<TWorkflowState>
    where TWorkflowState : class, ICatWorkflowState<TWorkflowState>
{
    /// <summary>
    /// Creates the step.
    /// </summary>
    /// <param name="logger">The logger the step can use.</param>
    public CatBreakIfStep(
        ILogger<CatBreakIfStep<TWorkflowState>> logger)
        : base(logger)
    {
    }

    /// <summary>
    /// The kind of break to make when the check returns <c>true</c>.
    /// </summary>
    public CatBreakType BreakType { get; set; }

    /// <summary>
    /// The check. It gets the logger and the workflow state.
    /// </summary>
    public Func<ILogger, TWorkflowState, bool> Check { get; set; } = null!;

    /// <inheritdoc />
    protected override ICatWorkflowResponse Run()
    {
        var result = Check(Logger, WorkflowState);
        return result switch
        {
            false => CatWorkflowResponse.Succeeded(CatStepExecutionResult.Continue),
            true when BreakType is CatBreakType.BreakFromCurrentFlowOnly => CatWorkflowResponse.Succeeded(CatStepExecutionResult.BreakFromCurrentFlowOnly),
            true when BreakType is CatBreakType.BreakFromLoop => CatWorkflowResponse.Succeeded(CatStepExecutionResult.BreakFromLoop),
            true when BreakType is CatBreakType.BreakCascade => CatWorkflowResponse.Succeeded(CatStepExecutionResult.BreakCascade),
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}
using System;
using Cat.FluentWorkflows.Abstractions;
using Cat.FluentWorkflows.Extensions;
using Cat.Object.Extensions;
using Cat.Responses.Abstractions;
using Microsoft.Extensions.Logging;

namespace Cat.FluentWorkflows.Steps;

/// <summary>
/// Built-in step behind <c>Run(Func)</c>. It runs your code. A succeeded response carries the result to use.
/// A failed response ends the workflow with BreakCascade and passes the errors on.
/// </summary>
/// <typeparam name="TWorkflowState">The state of the workflow.</typeparam>
public class CatInlineFuncStep<TWorkflowState> : CatStepBody<TWorkflowState>
    where TWorkflowState : class, ICatWorkflowState<TWorkflowState>
{
    /// <summary>
    /// Creates the step.
    /// </summary>
    /// <param name="logger">The logger the step passes to your code.</param>
    public CatInlineFuncStep(
        ILogger<CatInlineFuncStep<TWorkflowState>> logger)
        : base(logger)
    {
    }

    /// <summary>
    /// Your code. It gets the logger and the workflow state.
    /// </summary>
    public Func<ILogger, TWorkflowState, ICatResponse<CatStepExecutionResult>>? Body { get; set; } = null!;

    /// <inheritdoc />
    protected override ICatWorkflowResponse Run()
    {
        Body.ThrowIfNull(nameof(Body));

        var response = Body(Logger, WorkflowState);

        return response.IsSucceeded
            ? CatWorkflowResponse.Succeeded(response.Value)
            : CatResponseExtensions.Cast(response, CatStepExecutionResult.BreakCascade);
    }
}
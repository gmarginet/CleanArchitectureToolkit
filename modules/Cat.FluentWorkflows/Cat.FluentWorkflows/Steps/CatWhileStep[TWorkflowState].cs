using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Cat.FluentWorkflows.Abstractions;
using Cat.Responses;
using Cat.Responses.Abstractions;
using Microsoft.Extensions.Logging;

namespace Cat.FluentWorkflows.Steps;

/// <summary>
/// Built-in step behind <c>While</c>. It repeats its inner steps while the condition is <c>true</c>.
/// A BreakFromLoop leaves the loop and continues. A BreakCascade leaves the loop and ends the workflow.
/// The errors of every pass are kept.
/// </summary>
/// <typeparam name="TWorkflowState">The state of the workflow.</typeparam>
public class CatWhileStep<TWorkflowState> : CatContainerStepBody<TWorkflowState>
    where TWorkflowState : class, ICatWorkflowState<TWorkflowState>
{
    private readonly ICatStepProcessor _catStepProcessor;

    /// <summary>
    /// Creates the step.
    /// </summary>
    /// <param name="catStepProcessor">Runs the inner steps.</param>
    /// <param name="logger">The logger the step can use.</param>
    public CatWhileStep(
        ICatStepProcessor catStepProcessor,
        ILogger<CatWhileStep<TWorkflowState>> logger)
        : base(logger)
    {
        _catStepProcessor = catStepProcessor;
    }

    /// <summary>
    /// The condition. It gets the workflow state and is checked before every pass.
    /// </summary>
    public Func<TWorkflowState, bool> Condition { get; set; } = null!;

    /// <summary>
    /// Holds the inner steps.
    /// </summary>
    public CatWorkflowBuilder<TWorkflowState> Builder { get; set; } = null!;

    /// <inheritdoc />
    public override async Task<ICatWorkflowResponse> RunAsync(CancellationToken cancellationToken = default)
    {
        var result = CatWorkflowResponse.Succeeded(CatStepExecutionResult.Continue);
        var errors = new List<ICatError>();

        var resuming = SavedFrame != null;
        var pass = SavedFrame?.Iteration ?? 0;

        while (resuming || Condition(WorkflowState))
        {
            if (!resuming)
            {
                pass++;
            }

            result = await RunChildStepsAsync(_catStepProcessor, Builder, WorkflowState, resuming, cancellationToken);
            resuming = false;
            errors.AddRange(result.ErrorList);

            if (result.WorkflowResult == CatStepExecutionResult.Suspend)
            {
                var currentPass = pass;
                return Suspended(result, errors, frame =>
                {
                    frame.Branch = CatCheckpointBranches.Body;
                    frame.Iteration = currentPass;
                });
            }

            if (result.WorkflowResult == CatStepExecutionResult.BreakFromLoop)
            {
                result = result.ChangeWorkflowResult(CatStepExecutionResult.Continue);
                break;
            }

            if (result.WorkflowResult == CatStepExecutionResult.BreakCascade)
            {
                break;
            }
        }

        return CatWorkflowResponse.WithErrors(result, errors);
    }
}
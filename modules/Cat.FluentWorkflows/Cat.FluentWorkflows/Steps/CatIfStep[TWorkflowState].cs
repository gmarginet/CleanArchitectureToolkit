using System;
using System.Threading;
using System.Threading.Tasks;
using Cat.FluentWorkflows.Abstractions;
using Cat.Responses;
using Cat.Responses.Abstractions;
using Microsoft.Extensions.Logging;

namespace Cat.FluentWorkflows.Steps;

/// <summary>
/// Built-in step behind <c>If</c>. It runs the then steps when the condition is <c>true</c>, otherwise the else steps, if there are any.
/// A break result from the inner steps goes on to the steps around the if.
/// </summary>
/// <typeparam name="TWorkflowState">The state of the workflow.</typeparam>
public class CatIfStep<TWorkflowState> : CatContainerStepBody<TWorkflowState>
    where TWorkflowState : class, ICatWorkflowState<TWorkflowState>
{
    private readonly ICatStepProcessor _catStepProcessor;

    /// <summary>
    /// Creates the step.
    /// </summary>
    /// <param name="catStepProcessor">Runs the inner steps.</param>
    /// <param name="logger">The logger the step can use.</param>
    public CatIfStep(
        ICatStepProcessor catStepProcessor,
        ILogger<CatIfStep<TWorkflowState>> logger)
        : base(logger)
    {
        _catStepProcessor = catStepProcessor;
    }

    /// <summary>
    /// The condition. It gets the workflow state.
    /// </summary>
    public Func<TWorkflowState, bool> Condition { get; set; } = null!;

    /// <summary>
    /// Holds the steps to run when the condition is <c>true</c>.
    /// </summary>
    public CatWorkflowBuilder<TWorkflowState> ThenBuilder { get; set; } = null!;

    /// <summary>
    /// Holds the steps to run when the condition is <c>false</c>, or <c>null</c> for none.
    /// </summary>
    public CatWorkflowBuilder<TWorkflowState>? ElseBuilder { get; set; } = null;

    /// <inheritdoc />
    public override async Task<ICatWorkflowResponse> RunAsync(CancellationToken cancellationToken = default)
    {
        var resuming = SavedFrame != null;
        string? branch = null;

        if (resuming)
        {
            branch = SavedFrame!.Branch;
        }
        else if (Condition(WorkflowState))
        {
            branch = CatCheckpointBranches.Then;
        }
        else if (ElseBuilder?.WorkflowSteps != null)
        {
            branch = CatCheckpointBranches.Else;
        }

        var builder = branch switch
        {
            CatCheckpointBranches.Then => ThenBuilder,
            CatCheckpointBranches.Else => ElseBuilder,
            _ => null
        };

        if (builder == null)
        {
            return resuming
                ? throw new CatWorkflowResumeException($"The checkpoint holds the branch '{branch}' of an if, but the workflow has no such branch.")
                : CatWorkflowResponse.Succeeded(CatStepExecutionResult.Continue);
        }

        var result = await RunChildStepsAsync(_catStepProcessor, builder, WorkflowState, resuming, cancellationToken);

        return result.WorkflowResult == CatStepExecutionResult.Suspend
            ? Suspended(result, frame => frame.Branch = branch)
            : result;
    }
}
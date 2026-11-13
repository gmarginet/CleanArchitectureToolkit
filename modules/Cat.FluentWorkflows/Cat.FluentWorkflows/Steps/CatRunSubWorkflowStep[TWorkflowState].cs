using System.Threading;
using System.Threading.Tasks;
using Cat.FluentWorkflows.Abstractions;
using Microsoft.Extensions.Logging;

namespace Cat.FluentWorkflows.Steps;

/// <summary>
/// Built-in step behind <c>Run&lt;TSubWorkflow, TSubWorkflowState, TWorkflowState&gt;</c>.
/// It runs another workflow on the sub-workflow state that the main state carries.
/// A BreakFromCurrentFlowOnly inside the sub-workflow ends only the sub-workflow.
/// When the sub-workflow suspends, this step suspends too, and a resume goes on inside the sub-workflow.
/// </summary>
/// <typeparam name="TWorkflowState">The state of the main workflow.</typeparam>
/// <typeparam name="TSubWorkflow">The workflow to run.</typeparam>
/// <typeparam name="TSubWorkflowState">The state of the sub-workflow.</typeparam>
public class CatRunSubWorkflowStep<TWorkflowState, TSubWorkflow, TSubWorkflowState> : CatContainerStepBody<TWorkflowState>
    where TWorkflowState : class, ICatWorkflowState<TWorkflowState>, ICatHasSubWorkflowState<TSubWorkflowState>
    where TSubWorkflow : ICatWorkflow<TSubWorkflowState>
    where TSubWorkflowState : class, ICatWorkflowState<TSubWorkflowState>
{
    private readonly ICatWorkflowProcessor _workflowProcessor;

    /// <summary>
    /// Creates the step.
    /// </summary>
    /// <param name="workflowProcessor">Runs the sub-workflow.</param>
    /// <param name="logger">The logger the step can use.</param>
    public CatRunSubWorkflowStep(
        ICatWorkflowProcessor workflowProcessor,
        ILogger<CatRunSubWorkflowStep<TWorkflowState, TSubWorkflow, TSubWorkflowState>> logger)
        : base(logger)
    {
        _workflowProcessor = workflowProcessor;
    }

    /// <inheritdoc />
    public override async Task<ICatWorkflowResponse> RunAsync(CancellationToken cancellationToken = default)
    {
        var subWorkflowState = WorkflowState.WorkflowState;
        ICatWorkflowResponse result;

        if (Resume is { Frame.Child: { } child } resume)
        {
            var checkpoint = new CatWorkflowCheckpoint { Version = resume.Frame.WorkflowVersion, Frame = child };
            result = await _workflowProcessor.ResumeAsync<TSubWorkflow, TSubWorkflowState>(
                subWorkflowState, checkpoint, resume.Request.Answer, resume.Request.Target, cancellationToken);
        }
        else
        {
            result = await _workflowProcessor.RunAsync<TSubWorkflow, TSubWorkflowState>(subWorkflowState, cancellationToken);
        }

        if (result.WorkflowResult == CatStepExecutionResult.Suspend)
        {
            var version = result.Checkpoint?.Version ?? 0;
            return Suspended(result, frame =>
            {
                frame.Branch = CatCheckpointBranches.Sub;
                frame.WorkflowVersion = version;
            });
        }

        return result.WorkflowResult == CatStepExecutionResult.BreakFromCurrentFlowOnly
            ? result.ChangeWorkflowResult(CatStepExecutionResult.Continue)
            : result;
    }
}

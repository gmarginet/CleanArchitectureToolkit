using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Cat.FluentWorkflows.Abstractions;
using Cat.FluentWorkflows.Telemetry;
using Microsoft.Extensions.DependencyInjection;

namespace Cat.FluentWorkflows;

/// <summary>
/// Default <see cref="ICatWorkflowProcessor"/>.
/// Gets the workflow from the service provider, builds its steps, and runs them inside a tracing activity.
/// A resume builds the steps again and goes on at the step that suspended.
/// </summary>
public class CatWorkflowProcessor : ICatWorkflowProcessor
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ICatStepProcessor _stepProcessor;

    /// <summary>
    /// Creates the processor.
    /// </summary>
    /// <param name="serviceProvider">Gives the workflow.</param>
    /// <param name="stepProcessor">Runs the steps.</param>
    public CatWorkflowProcessor(IServiceProvider serviceProvider, ICatStepProcessor stepProcessor)
    {
        _serviceProvider = serviceProvider;
        _stepProcessor = stepProcessor;
    }

    /// <inheritdoc />
    public async Task<ICatWorkflowResponse> RunAsync<TWorkflow, TWorkflowState>(TWorkflowState workflowState, CancellationToken cancellationToken)
        where TWorkflow : ICatWorkflow<TWorkflowState>
        where TWorkflowState : class, ICatWorkflowState<TWorkflowState>
    {
        var workflow = _serviceProvider.GetRequiredService<TWorkflow>();
        var workflowName = workflow.GetType().Name;
        var workflowBuilder = new CatWorkflowBuilder<TWorkflowState>();

        workflow.Build(workflowBuilder);

        using var activity = CatWorkFlowActivitySource.CreateActivity($"Processing Workflow {workflowName}");

        var result = await _stepProcessor.RunStepsAsync(workflowBuilder, workflowState, cancellationToken);

        return Finish(result, workflow);
    }

    /// <inheritdoc />
    public Task<ICatWorkflowResponse> ResumeAsync<TWorkflow, TWorkflowState>(TWorkflowState workflowState, CatWorkflowCheckpoint checkpoint, object? answer,
        CancellationToken cancellationToken)
        where TWorkflow : ICatWorkflow<TWorkflowState>
        where TWorkflowState : class, ICatWorkflowState<TWorkflowState>
    {
        return ResumeAsync<TWorkflow, TWorkflowState>(workflowState, checkpoint, answer, null, cancellationToken);
    }

    /// <inheritdoc />
    /// <exception cref="CatWorkflowResumeException">The version differs, the steps do not fit the checkpoint, or the target is not one waiting step.</exception>
    public async Task<ICatWorkflowResponse> ResumeAsync<TWorkflow, TWorkflowState>(TWorkflowState workflowState, CatWorkflowCheckpoint checkpoint, object? answer,
        string? target, CancellationToken cancellationToken)
        where TWorkflow : ICatWorkflow<TWorkflowState>
        where TWorkflowState : class, ICatWorkflowState<TWorkflowState>
    {
        if (checkpoint == null)
        {
            throw new ArgumentNullException(nameof(checkpoint));
        }

        var workflow = _serviceProvider.GetRequiredService<TWorkflow>();
        var workflowName = workflow.GetType().Name;

        CheckVersion(workflow, workflowName, checkpoint);
        CheckTarget(checkpoint, target);

        var workflowBuilder = new CatWorkflowBuilder<TWorkflowState>();

        workflow.Build(workflowBuilder);

        using var activity = CatWorkFlowActivitySource.CreateActivity($"Resuming Workflow {workflowName}");

        var resume = new CatResumeInfo(checkpoint.Frame, new CatResumeRequest(answer, target));
        var result = await _stepProcessor.RunStepsAsync(workflowBuilder, workflowState, resume, cancellationToken);

        return Finish(result, workflow);
    }

    private static ICatWorkflowResponse Finish(ICatWorkflowResponse result, object workflow)
    {
        if (result.WorkflowResult == CatStepExecutionResult.Suspend && result.Checkpoint != null)
        {
            result.Checkpoint.Version = GetVersion(workflow);
        }

        return result.WorkflowResult == CatStepExecutionResult.BreakFromCurrentFlowOnly
            ? result.ChangeWorkflowResult(CatStepExecutionResult.Continue)
            : result;
    }

    private static int GetVersion(object workflow)
    {
        return workflow is ICatVersionedWorkflow versioned ? versioned.Version : 0;
    }

    private static void CheckVersion(object workflow, string workflowName, CatWorkflowCheckpoint checkpoint)
    {
        var version = GetVersion(workflow);

        if (version != checkpoint.Version)
        {
            throw new CatWorkflowResumeException(
                $"The checkpoint was saved by version {checkpoint.Version} of {workflowName}, but the workflow is now version {version}.");
        }
    }

    private static void CheckTarget(CatWorkflowCheckpoint checkpoint, string? target)
    {
        var leaves = checkpoint.Frame.Leaves().ToList();

        if (target == null)
        {
            if (leaves.Count != 1)
            {
                throw new CatWorkflowResumeException(
                    $"The checkpoint has {leaves.Count} waiting steps. Name the step that gets the answer with the target argument.");
            }

            return;
        }

        var matches = leaves.Count(l => l.StepName == target);

        if (matches != 1)
        {
            throw new CatWorkflowResumeException($"The checkpoint has {matches} waiting steps named '{target}', and it needs exactly one.");
        }
    }
}

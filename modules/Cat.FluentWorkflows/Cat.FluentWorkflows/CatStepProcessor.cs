using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Cat.FluentWorkflows.Abstractions;
using Cat.Responses.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Cat.FluentWorkflows;

/// <summary>
/// Default <see cref="ICatStepProcessor"/>.
/// For each step it gets the step body from the service provider, fills the inputs, runs the step and copies the outputs.
/// It stops after a step that returns BreakCascade, BreakFromCurrentFlowOnly, BreakFromLoop or Suspend.
/// The result is the one of the last step that ran. The errors of every step that ran are kept.
/// A step that suspends is written as a frame in the checkpoint of the response. A resume starts again at that step.
/// </summary>
public class CatStepProcessor : ICatStepProcessor
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<CatStepProcessor> _logger;

    /// <summary>
    /// Creates the processor.
    /// </summary>
    /// <param name="serviceProvider">Gives the step bodies. Every step body must be registered.</param>
    /// <param name="logger">Logs problems with inputs and outputs.</param>
    public CatStepProcessor(IServiceProvider serviceProvider, ILogger<CatStepProcessor> logger)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
    }

    /// <inheritdoc />
    /// <exception cref="ArgumentNullException">The workflow state is <c>null</c>.</exception>
    public Task<ICatWorkflowResponse> RunStepsAsync<TWorkflowState>(ICatWorkflowBuilder<TWorkflowState> workflowBuilder, TWorkflowState workflowState,
        CancellationToken cancellationToken)
        where TWorkflowState : class, ICatWorkflowState<TWorkflowState>
    {
        return RunStepsAsync(workflowBuilder, workflowState, null, cancellationToken);
    }

    /// <inheritdoc />
    /// <exception cref="ArgumentNullException">The workflow state is <c>null</c>.</exception>
    /// <exception cref="CatWorkflowResumeException">The saved frame does not fit the steps.</exception>
    public async Task<ICatWorkflowResponse> RunStepsAsync<TWorkflowState>(ICatWorkflowBuilder<TWorkflowState> workflowBuilder, TWorkflowState workflowState,
        CatResumeInfo? resume, CancellationToken cancellationToken)
        where TWorkflowState : class, ICatWorkflowState<TWorkflowState>
    {
        if (workflowState == null)
        {
            throw new ArgumentNullException(nameof(workflowState));
        }

        var steps = workflowBuilder.WorkflowSteps;
        CheckNamesAreUnique(steps);

        var startIndex = resume == null ? 0 : FindResumeIndex(steps, resume.Frame);
        var result = CatWorkflowResponse.Succeeded(CatStepExecutionResult.Continue);
        var errors = new List<ICatError>();

        for (var index = startIndex; index < steps.Count; index++)
        {
            var workflowStep = steps[index];
            var body = (ICatStepBodyAsync)_serviceProvider.GetRequiredService(workflowStep.BodyType);
            var stepBodyName = body.GetType().Name;
            var stepResume = index == startIndex ? resume : null;

            try
            {
                if (body is ICatStepBodyWithState<TWorkflowState> bodyWithState)
                {
                    bodyWithState.WorkflowState = workflowState;
                }

                foreach (var input in workflowStep.Inputs)
                {
                    input.Assign(workflowState, body);
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Could not assign inputs of WorkflowStep {workflowStep}", stepBodyName);
                throw;
            }

            if (body is ICatContainerStepBody container)
            {
                container.Resume = stepResume;
                result = await body.RunAsync(cancellationToken);
            }
            else if (stepResume != null)
            {
                result = await ResumeStepAsync(body, stepResume, cancellationToken);
            }
            else
            {
                result = await body.RunAsync(cancellationToken);
            }

            errors.AddRange(result.ErrorList);

            try
            {
                foreach (var output in workflowStep.Outputs)
                {
                    output.Assign(body, workflowState);
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Could not assign outputs of WorkflowStep {workflowStep}", stepBodyName);
                throw;
            }

            if (result.WorkflowResult == CatStepExecutionResult.Suspend)
            {
                var frame = result.Checkpoint?.Frame ?? new CatCheckpointFrame();
                frame.StepIndex = index;
                frame.StepName = workflowStep.Name;
                frame.BodyType = workflowStep.BodyType.FullName;
                return CatWorkflowResponse.Suspended(frame, errors);
            }

            if (result.WorkflowResult is CatStepExecutionResult.BreakCascade or CatStepExecutionResult.BreakFromCurrentFlowOnly or CatStepExecutionResult.BreakFromLoop)
            {
                break;
            }
        }

        return CatWorkflowResponse.WithErrors(result, errors);
    }

    private static Task<ICatWorkflowResponse> ResumeStepAsync(ICatStepBodyAsync body, CatResumeInfo resume, CancellationToken cancellationToken)
    {
        if (!resume.Frame.IsLeaf)
        {
            throw new CatWorkflowResumeException(
                $"The checkpoint holds a container at step {resume.Frame.StepIndex}, but the step {body.GetType().Name} is not a container. Did the workflow change?");
        }

        if (body is not ICatResumableStepBody resumable)
        {
            throw new CatWorkflowResumeException(
                $"The step {body.GetType().Name} suspended, but it does not implement ICatResumableStepBody, so it cannot take the answer.");
        }

        return resumable.ResumeAsync(resume.Request.Answer, cancellationToken);
    }

    private static void CheckNamesAreUnique(List<ICatWorkflowStep> steps)
    {
        HashSet<string>? names = null;

        foreach (var step in steps)
        {
            if (step.Name == null)
            {
                continue;
            }

            names ??= [];

            if (!names.Add(step.Name))
            {
                throw new InvalidOperationException($"The step name '{step.Name}' is used more than once in the same list of steps.");
            }
        }
    }

    private static int FindResumeIndex(List<ICatWorkflowStep> steps, CatCheckpointFrame frame)
    {
        int index;

        if (frame.StepName != null)
        {
            index = steps.FindIndex(s => s.Name == frame.StepName);

            if (index < 0)
            {
                throw new CatWorkflowResumeException($"The checkpoint points at the step '{frame.StepName}', but the workflow has no step with that name.");
            }
        }
        else
        {
            index = frame.StepIndex;

            if (index < 0 || index >= steps.Count)
            {
                throw new CatWorkflowResumeException(
                    $"The checkpoint points at step {index}, but the list has {steps.Count} steps. Did the workflow change without a new version?");
            }
        }

        var bodyType = steps[index].BodyType.FullName;

        if (frame.BodyType != null && frame.BodyType != bodyType)
        {
            throw new CatWorkflowResumeException(
                $"The checkpoint expects the step {frame.BodyType} at position {index}, but the workflow has {bodyType}. Did the workflow change without a new version?");
        }

        return index;
    }
}

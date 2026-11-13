using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Cat.FluentWorkflows.Abstractions;
using Cat.Responses.Abstractions;
using Microsoft.Extensions.Logging;

namespace Cat.FluentWorkflows;

/// <summary>
/// Base class for a step that runs other steps, such as an if or a loop. It handles the frame of a suspend and a resume for you.
/// Run the inner steps with <see cref="RunChildStepsAsync{TChildState}"/>. When the result suspends, return <see cref="Suspended(ICatWorkflowResponse, Action{CatCheckpointFrame})"/>
/// and write in the frame what you need to find your place again. On a resume read it from <see cref="SavedFrame"/>.
/// </summary>
/// <typeparam name="TWorkflowState">The state of the workflow.</typeparam>
public abstract class CatContainerStepBody<TWorkflowState> : CatStepBodyAsync<TWorkflowState>, ICatContainerStepBody
    where TWorkflowState : class, ICatWorkflowState<TWorkflowState>
{
    /// <summary>
    /// Creates the step.
    /// </summary>
    /// <param name="logger">The logger the step can use.</param>
    protected CatContainerStepBody(ILogger logger) : base(logger)
    {
    }

    /// <inheritdoc />
    public CatResumeInfo? Resume { get; set; }

    /// <summary>
    /// The frame this step wrote when it suspended, or <c>null</c> when the step runs for the first time.
    /// When it is set, go on in the branch it names and do not decide again.
    /// </summary>
    protected CatCheckpointFrame? SavedFrame => Resume?.Frame;

    /// <summary>
    /// Runs the inner steps. With <paramref name="resuming"/> set, the run goes on at the step that suspended inside this container.
    /// Set it only for the first pass of a loop.
    /// </summary>
    /// <typeparam name="TChildState">The state of the inner steps.</typeparam>
    /// <param name="stepProcessor">Runs the inner steps.</param>
    /// <param name="builder">Holds the inner steps.</param>
    /// <param name="state">The state the inner steps work on.</param>
    /// <param name="resuming"><c>true</c> to go on at the saved step, <c>false</c> to run from the first step.</param>
    /// <param name="cancellationToken">Token to cancel the work.</param>
    /// <returns>The result of the inner steps.</returns>
    protected Task<ICatWorkflowResponse> RunChildStepsAsync<TChildState>(ICatStepProcessor stepProcessor,
        ICatWorkflowBuilder<TChildState> builder, TChildState state, bool resuming, CancellationToken cancellationToken)
        where TChildState : class, ICatWorkflowState<TChildState>
    {
        return stepProcessor.RunStepsAsync(builder, state, resuming ? Resume?.ForChild() : null, cancellationToken);
    }

    /// <summary>
    /// Creates the response of a container whose inner steps suspended. It keeps the errors of the inner steps.
    /// </summary>
    /// <param name="child">The response of the inner steps. Its checkpoint becomes the child frame.</param>
    /// <param name="describe">Writes what the container needs to find its place again, such as the branch.</param>
    /// <returns>A response with the result <see cref="CatStepExecutionResult.Suspend"/>.</returns>
    protected static ICatWorkflowResponse Suspended(ICatWorkflowResponse child, Action<CatCheckpointFrame>? describe = null)
    {
        return Suspended(child, child.ErrorList, describe);
    }

    /// <summary>
    /// Creates the response of a container whose inner steps suspended, with the errors collected over several passes.
    /// </summary>
    /// <param name="child">The response of the inner steps. Its checkpoint becomes the child frame.</param>
    /// <param name="errors">All the errors collected so far.</param>
    /// <param name="describe">Writes what the container needs to find its place again, such as the branch.</param>
    /// <returns>A response with the result <see cref="CatStepExecutionResult.Suspend"/>.</returns>
    protected static ICatWorkflowResponse Suspended(ICatWorkflowResponse child, IReadOnlyList<ICatError> errors,
        Action<CatCheckpointFrame>? describe = null)
    {
        var frame = new CatCheckpointFrame { Child = child.Checkpoint?.Frame };
        describe?.Invoke(frame);
        return CatWorkflowResponse.Suspended(frame, errors);
    }
}

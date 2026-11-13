using System;
using System.Threading;
using System.Threading.Tasks;

namespace Cat.FluentWorkflows.Abstractions;

/// <summary>
/// Single entry point for running a workflow.
/// </summary>
public interface ICatWorkflowProcessor
{
    /// <summary>
    /// Builds the workflow, runs its steps on the given state and returns the outcome.
    /// A <see cref="CatStepExecutionResult.BreakFromCurrentFlowOnly"/> result is reported as <see cref="CatStepExecutionResult.Continue"/>.
    /// </summary>
    /// <typeparam name="TWorkflow">The workflow to run. It must be registered.</typeparam>
    /// <typeparam name="TWorkflowState">The state of the workflow.</typeparam>
    /// <param name="workflowState">The state the steps work on. Read it afterwards to get the results.</param>
    /// <param name="cancellationToken">Token to cancel the work.</param>
    /// <returns>The result of the last step that ran, with the errors of every step that ran.</returns>
    Task<ICatWorkflowResponse> RunAsync<TWorkflow, TWorkflowState>(TWorkflowState workflowState, CancellationToken cancellationToken)
        where TWorkflow : ICatWorkflow<TWorkflowState>
        where TWorkflowState : class, ICatWorkflowState<TWorkflowState>;

    /// <summary>
    /// Builds the workflow again and goes on at the step that suspended, with the answer.
    /// The workflow must be the same as when it suspended, see <see cref="ICatVersionedWorkflow"/>.
    /// Use this when only one step waits. A result of <see cref="CatStepExecutionResult.Suspend"/> means the workflow waits again, and the response holds a new checkpoint.
    /// </summary>
    /// <typeparam name="TWorkflow">The workflow to resume. It must be registered.</typeparam>
    /// <typeparam name="TWorkflowState">The state of the workflow. Give the state as it was when the workflow suspended.</typeparam>
    /// <param name="workflowState">The state the steps work on.</param>
    /// <param name="checkpoint">The checkpoint from the response of the suspended run.</param>
    /// <param name="answer">The answer for the waiting step. It reaches the step as the argument of <see cref="ICatResumableStepBody.ResumeAsync"/>.</param>
    /// <param name="cancellationToken">Token to cancel the work.</param>
    /// <returns>The result of the last step that ran, with the errors of every step that ran.</returns>
    /// <exception cref="InvalidOperationException">The checkpoint does not fit the workflow, or more than one step waits. See the message.</exception>
    Task<ICatWorkflowResponse> ResumeAsync<TWorkflow, TWorkflowState>(TWorkflowState workflowState, CatWorkflowCheckpoint checkpoint, object? answer,
        CancellationToken cancellationToken)
        where TWorkflow : ICatWorkflow<TWorkflowState>
        where TWorkflowState : class, ICatWorkflowState<TWorkflowState>;

    /// <summary>
    /// Builds the workflow again and goes on at the step that suspended, with the answer, for the waiting step with the given name.
    /// Use this when a parallel step has several waiting branches.
    /// </summary>
    /// <typeparam name="TWorkflow">The workflow to resume. It must be registered.</typeparam>
    /// <typeparam name="TWorkflowState">The state of the workflow. Give the state as it was when the workflow suspended.</typeparam>
    /// <param name="workflowState">The state the steps work on.</param>
    /// <param name="checkpoint">The checkpoint from the response of the suspended run.</param>
    /// <param name="answer">The answer for the waiting step.</param>
    /// <param name="target">The name of the waiting step that gets the answer, or <c>null</c> when only one step waits.</param>
    /// <param name="cancellationToken">Token to cancel the work.</param>
    /// <returns>The result of the last step that ran, with the errors of every step that ran.</returns>
    /// <exception cref="InvalidOperationException">The checkpoint does not fit the workflow, or the target is not one waiting step. See the message.</exception>
    Task<ICatWorkflowResponse> ResumeAsync<TWorkflow, TWorkflowState>(TWorkflowState workflowState, CatWorkflowCheckpoint checkpoint, object? answer,
        string? target, CancellationToken cancellationToken)
        where TWorkflow : ICatWorkflow<TWorkflowState>
        where TWorkflowState : class, ICatWorkflowState<TWorkflowState>;
}
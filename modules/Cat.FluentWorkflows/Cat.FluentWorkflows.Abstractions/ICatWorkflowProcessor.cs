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
}
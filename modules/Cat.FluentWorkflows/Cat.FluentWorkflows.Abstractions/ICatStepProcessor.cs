using System.Threading;
using System.Threading.Tasks;

namespace Cat.FluentWorkflows.Abstractions;

/// <summary>
/// Runs a list of steps one by one. Steps like if and foreach use it to run their own inner steps.
/// </summary>
public interface ICatStepProcessor
{
    /// <summary>
    /// Runs the steps of a builder in order. It stops after a step that returns a break result.
    /// </summary>
    /// <typeparam name="TWorkflowState">The state of the workflow.</typeparam>
    /// <param name="workflowBuilder">Holds the steps.</param>
    /// <param name="workflowState">The state the steps work on.</param>
    /// <param name="cancellationToken">Token to cancel the work.</param>
    /// <returns>The result of the last step that ran, with the errors of every step that ran.</returns>
    Task<ICatWorkflowResponse> RunStepsAsync<TWorkflowState>(ICatWorkflowBuilder<TWorkflowState> workflowBuilder,
        TWorkflowState workflowState, CancellationToken cancellationToken)
        where TWorkflowState : class, ICatWorkflowState<TWorkflowState>;
}
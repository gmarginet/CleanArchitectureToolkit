using System;
using System.Threading;
using System.Threading.Tasks;
using Cat.FluentWorkflows.Abstractions;

namespace Cat.Sagas.Abstractions;

/// <summary>
/// Starts a saga. The workflow runs until it ends or reaches a wait step. At a wait step its state is saved and the request message is sent.
/// </summary>
public interface ICatSagaRunner
{
    /// <summary>
    /// Runs the workflow on the state. The workflow must be registered with <c>AddCatSaga</c>.
    /// </summary>
    /// <typeparam name="TWorkflow">The workflow to run.</typeparam>
    /// <typeparam name="TWorkflowState">The state of the workflow. It must be serializable.</typeparam>
    /// <param name="state">The state the steps work on.</param>
    /// <param name="correlationId">The id of the new instance. Leave it empty to get a new one.</param>
    /// <param name="cancellationToken">Token to cancel the work.</param>
    /// <returns>The result, with the instance id and the status. Only a waiting instance is saved.</returns>
    Task<CatSagaResult> StartAsync<TWorkflow, TWorkflowState>(TWorkflowState state, Guid? correlationId = null, CancellationToken cancellationToken = default)
        where TWorkflow : ICatWorkflow<TWorkflowState>
        where TWorkflowState : class, ICatWorkflowState<TWorkflowState>;
}

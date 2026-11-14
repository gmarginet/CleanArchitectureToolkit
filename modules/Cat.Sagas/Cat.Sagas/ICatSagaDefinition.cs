using System;
using System.Threading;
using System.Threading.Tasks;
using Cat.FluentWorkflows.Abstractions;

namespace Cat.Sagas;

/// <summary>
/// A registered saga: its name, and a way to resume it without knowing its types at the call site.
/// </summary>
internal interface ICatSagaDefinition
{
    string Name { get; }

    Type WorkflowType { get; }

    Type StateType { get; }

    Task<ICatWorkflowResponse> ResumeAsync(ICatWorkflowProcessor processor, object state, CatWorkflowCheckpoint checkpoint, object answer,
        string target, CancellationToken cancellationToken);
}

internal sealed class CatSagaDefinition<TWorkflow, TWorkflowState> : ICatSagaDefinition
    where TWorkflow : ICatWorkflow<TWorkflowState>
    where TWorkflowState : class, ICatWorkflowState<TWorkflowState>
{
    public string Name => typeof(TWorkflow).FullName ?? typeof(TWorkflow).Name;

    public Type WorkflowType => typeof(TWorkflow);

    public Type StateType => typeof(TWorkflowState);

    public Task<ICatWorkflowResponse> ResumeAsync(ICatWorkflowProcessor processor, object state, CatWorkflowCheckpoint checkpoint, object answer,
        string target, CancellationToken cancellationToken)
    {
        return processor.ResumeAsync<TWorkflow, TWorkflowState>((TWorkflowState)state, checkpoint, answer, target, cancellationToken);
    }
}

namespace Cat.FluentWorkflows.Abstractions;

/// <summary>
/// Marks a step body that wants the state of the workflow. The step processor sets it before the step runs.
/// </summary>
/// <typeparam name="TWorkflowState">The state of the workflow.</typeparam>
public interface ICatStepBodyWithState<TWorkflowState>
    where TWorkflowState : class, ICatWorkflowState<TWorkflowState>
{
    /// <summary>
    /// The state of the workflow the step runs in.
    /// </summary>
    TWorkflowState WorkflowState { get; set; }
}
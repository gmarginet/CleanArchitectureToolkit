namespace Cat.FluentWorkflows.Abstractions;

/// <summary>
/// Marks a workflow state that carries the state for a sub-workflow.
/// </summary>
/// <typeparam name="TSubWorkflowState">The state of the sub-workflow.</typeparam>
public interface ICatHasSubWorkflowState<TSubWorkflowState>
{
    /// <summary>
    /// The state the sub-workflow runs on.
    /// </summary>
    TSubWorkflowState WorkflowState { get; set; }
}
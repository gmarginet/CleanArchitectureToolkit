namespace Cat.FluentWorkflows.Abstractions;

/// <summary>
/// Describes one workflow: the steps to run, in order. Implement it once per workflow. The module finds and registers it for you.
/// </summary>
/// <typeparam name="TWorkflowState">The state of the workflow.</typeparam>
public interface ICatWorkflow<TWorkflowState>
    where TWorkflowState : class, ICatWorkflowState<TWorkflowState>
{
    /// <summary>
    /// Adds the steps of the workflow.
    /// </summary>
    /// <param name="builder">Collects the steps.</param>
    void Build(ICatWorkflowBuilder<TWorkflowState> builder);
}
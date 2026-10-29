namespace Cat.FluentWorkflows.Abstractions;

/// <summary>
/// Marks the class that holds the data of a workflow. Steps read from it and write to it.
/// Implement it with the class itself as the type argument, like <c>class OrderState : ICatWorkflowState&lt;OrderState&gt;</c>.
/// </summary>
/// <typeparam name="TWorkflowState">The state class itself.</typeparam>
public interface ICatWorkflowState<out TWorkflowState>
    where TWorkflowState : class, ICatWorkflowState<TWorkflowState>
{
}
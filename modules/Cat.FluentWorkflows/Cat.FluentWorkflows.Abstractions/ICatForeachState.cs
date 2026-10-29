namespace Cat.FluentWorkflows.Abstractions;

/// <summary>
/// The state of the steps inside a foreach. It holds the current item and the state of the workflow around the loop.
/// </summary>
/// <typeparam name="TCollection">The type of the items in the collection.</typeparam>
/// <typeparam name="TWorkflowState">The state of the workflow around the loop.</typeparam>
public interface ICatForeachState<TCollection, TWorkflowState> : ICatWorkflowState<ICatForeachState<TCollection, TWorkflowState>>
    where TWorkflowState : class, ICatWorkflowState<TWorkflowState>
{
    /// <summary>
    /// The item the loop is working on.
    /// </summary>
    TCollection CurrentItem { get; set; }

    /// <summary>
    /// The state of the workflow around the loop.
    /// </summary>
    TWorkflowState ParentWorkflowState { get; set; }
}

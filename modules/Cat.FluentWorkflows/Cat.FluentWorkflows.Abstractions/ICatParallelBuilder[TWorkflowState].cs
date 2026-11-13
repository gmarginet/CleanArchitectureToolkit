using System;

namespace Cat.FluentWorkflows.Abstractions;

/// <summary>
/// Collects the branches of a parallel step.
/// </summary>
/// <typeparam name="TWorkflowState">The state of the workflow. All branches work on the same state, so two branches must not write the same property.</typeparam>
public interface ICatParallelBuilder<TWorkflowState>
    where TWorkflowState : class, ICatWorkflowState<TWorkflowState>
{
    /// <summary>
    /// Adds a branch.
    /// </summary>
    /// <param name="build">Adds the steps of the branch.</param>
    /// <returns>The same builder, so calls can be chained.</returns>
    ICatParallelBuilder<TWorkflowState> Branch(Action<ICatWorkflowBuilder<TWorkflowState>> build);
}

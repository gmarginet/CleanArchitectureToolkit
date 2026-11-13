using System;
using System.Collections.Generic;
using Cat.FluentWorkflows.Abstractions;

namespace Cat.FluentWorkflows.Steps;

/// <summary>
/// Default <see cref="ICatParallelBuilder{TWorkflowState}"/>.
/// Collects the branches of a parallel step.
/// </summary>
/// <typeparam name="TWorkflowState">The state of the workflow.</typeparam>
public class CatParallelBuilder<TWorkflowState> : ICatParallelBuilder<TWorkflowState>
    where TWorkflowState : class, ICatWorkflowState<TWorkflowState>
{
    /// <summary>
    /// The branches added so far.
    /// </summary>
    public List<CatWorkflowBuilder<TWorkflowState>> Branches { get; } = [];

    /// <inheritdoc />
    public ICatParallelBuilder<TWorkflowState> Branch(Action<ICatWorkflowBuilder<TWorkflowState>> build)
    {
        var branchBuilder = new CatWorkflowBuilder<TWorkflowState>();
        build(branchBuilder);
        Branches.Add(branchBuilder);
        return this;
    }
}

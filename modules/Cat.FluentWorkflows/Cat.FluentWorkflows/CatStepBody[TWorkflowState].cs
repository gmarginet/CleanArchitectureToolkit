using System.Threading;
using System.Threading.Tasks;
using Cat.FluentWorkflows.Abstractions;
using Microsoft.Extensions.Logging;

namespace Cat.FluentWorkflows;

/// <summary>
/// Base class for a step that works synchronously and reads or writes the workflow state directly.
/// Implement <see cref="Run"/> and use <see cref="CatStepBodyAsync{TWorkflowState}.WorkflowState"/>.
/// </summary>
/// <typeparam name="TWorkflowState">The state of the workflow.</typeparam>
public abstract class CatStepBody<TWorkflowState> : CatStepBodyAsync<TWorkflowState>
    where TWorkflowState : class, ICatWorkflowState<TWorkflowState>
{
    /// <summary>
    /// Creates the step.
    /// </summary>
    /// <param name="logger">The logger the step can use. Pass the <c>ILogger&lt;YourStep&gt;</c> you got from the constructor.</param>
    protected CatStepBody(ILogger<CatStepBody<TWorkflowState>> logger) : base(logger)
    {
    }

    /// <inheritdoc />
    public override Task<ICatWorkflowResponse> RunAsync(CancellationToken cancellationToken = default)
    {
        return Task.FromResult(Run());
    }

    /// <summary>
    /// Does the work of the step.
    /// </summary>
    /// <returns>A response with the result for the step processor and the errors, if any.</returns>
    protected abstract ICatWorkflowResponse Run();
}
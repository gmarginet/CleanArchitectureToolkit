using System.Threading;
using System.Threading.Tasks;
using Cat.FluentWorkflows.Abstractions;
using Microsoft.Extensions.Logging;

namespace Cat.FluentWorkflows;

/// <summary>
/// Base class for a step that works synchronously and doesn't need the workflow state directly.
/// Get its data through <c>Input</c> and hand results back through <c>Output</c>. Implement <see cref="Run"/>.
/// </summary>
public abstract class CatStepBody : CatStepBodyAsync
{
    /// <summary>
    /// Creates the step.
    /// </summary>
    /// <param name="logger">The logger the step can use.</param>
    protected CatStepBody(ILogger logger)
        : base(logger)
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
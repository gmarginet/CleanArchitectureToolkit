using System.Threading;
using System.Threading.Tasks;
using Cat.FluentWorkflows.Abstractions;
using Microsoft.Extensions.Logging;

namespace Cat.FluentWorkflows;

/// <summary>
/// Base class for a step that works asynchronously and doesn't need the workflow state directly.
/// Get its data through <c>Input</c> and hand results back through <c>Output</c>. Implement <see cref="RunAsync"/>.
/// </summary>
public abstract class CatStepBodyAsync : ICatStepBodyAsync
{
    /// <summary>
    /// The logger of the step.
    /// </summary>
    protected readonly ILogger Logger;

    /// <summary>
    /// Creates the step.
    /// </summary>
    /// <param name="logger">The logger the step can use.</param>
    protected CatStepBodyAsync(ILogger logger)
    {
        Logger = logger;
    }

    /// <inheritdoc />
    public abstract Task<ICatWorkflowResponse> RunAsync(CancellationToken cancellationToken = default);
}
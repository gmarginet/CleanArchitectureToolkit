using System.Threading;
using System.Threading.Tasks;

namespace Cat.FluentWorkflows.Abstractions;

/// <summary>
/// The code of one step. Derive from <c>CatStepBody</c> or <c>CatStepBodyAsync</c> instead of implementing this yourself.
/// </summary>
public interface ICatStepBodyAsync
{
    /// <summary>
    /// Runs the step.
    /// </summary>
    /// <param name="cancellationToken">Token to cancel the work.</param>
    /// <returns>A response with the result for the step processor and the errors, if any.</returns>
    Task<ICatWorkflowResponse> RunAsync(CancellationToken cancellationToken = default);
}
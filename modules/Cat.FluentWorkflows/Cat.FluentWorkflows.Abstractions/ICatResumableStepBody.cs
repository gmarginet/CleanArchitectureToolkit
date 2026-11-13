using System.Threading;
using System.Threading.Tasks;

namespace Cat.FluentWorkflows.Abstractions;

/// <summary>
/// A step that can wait for an answer. Its <c>RunAsync</c> starts the work and returns <see cref="CatStepExecutionResult.Suspend"/>.
/// When the answer comes, the resume calls <see cref="ResumeAsync"/> on a new instance of the step.
/// Derive from <c>CatResumableStepBody</c> to get the answer typed.
/// </summary>
public interface ICatResumableStepBody : ICatStepBodyAsync
{
    /// <summary>
    /// Finishes the step with the answer. The inputs of the step are filled again before this runs, and the outputs are copied after it.
    /// </summary>
    /// <param name="answer">The answer that was given to <c>ResumeAsync</c> of the workflow processor.</param>
    /// <param name="cancellationToken">Token to cancel the work.</param>
    /// <returns>A response with the result for the step processor. It can suspend again.</returns>
    Task<ICatWorkflowResponse> ResumeAsync(object? answer, CancellationToken cancellationToken = default);
}

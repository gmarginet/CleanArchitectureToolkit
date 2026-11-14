using System;
using System.Threading;
using System.Threading.Tasks;
using Cat.Responses.Abstractions;

namespace Cat.Sagas.Abstractions;

/// <summary>
/// Gives an answer to a waiting saga. It finds the instance, resumes the workflow at the wait step and saves the result.
/// The handler that <c>AddCatSagaAnswer</c> registers calls it for you.
/// </summary>
public interface ICatSagaDispatcher
{
    /// <summary>
    /// Resumes the instance with the answer.
    /// </summary>
    /// <param name="correlationId">The id of the instance. An answer carries it as its correlation id.</param>
    /// <param name="answer">The answer for the wait step.</param>
    /// <param name="cancellationToken">Token to cancel the work.</param>
    /// <returns>
    /// A succeeded response when the answer was used, or when the instance is not waiting any more, which makes a repeated answer harmless.
    /// A NotFound response when there is no such instance, and a Conflict response when the answer does not fit the wait step or the workflow changed.
    /// </returns>
    /// <exception cref="CatSagaConcurrencyException">Another message changed the instance at the same time.</exception>
    Task<ICatResponse> ResumeAsync(Guid correlationId, object answer, CancellationToken cancellationToken = default);
}

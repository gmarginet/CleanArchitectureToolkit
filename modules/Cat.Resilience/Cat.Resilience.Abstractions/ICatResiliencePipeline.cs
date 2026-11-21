using System;
using System.Threading;
using System.Threading.Tasks;

namespace Cat.Resilience.Abstractions;

/// <summary>
/// Runs one call through a resilience profile. Use it for a call that is not HTTP, such as an upload to blob storage.
/// The call inside must be safe to repeat, because the pipeline can run it more than once.
/// Never put a database write of the handler inside it.
/// </summary>
public interface ICatResiliencePipeline
{
    /// <summary>
    /// Runs the callback and tries it again on an exception, as the profile says.
    /// </summary>
    /// <param name="callback">The call to run.</param>
    /// <param name="cancellationToken">Cancels the call and its retries.</param>
    /// <returns>A task that ends when the call succeeded or the pipeline gave up.</returns>
    Task ExecuteAsync(Func<CancellationToken, Task> callback, CancellationToken cancellationToken = default);

    /// <summary>
    /// Runs the callback and tries it again on an exception, as the profile says.
    /// </summary>
    /// <param name="callback">The call to run.</param>
    /// <param name="cancellationToken">Cancels the call and its retries.</param>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <returns>The result of the first call that succeeded.</returns>
    Task<TResult> ExecuteAsync<TResult>(Func<CancellationToken, Task<TResult>> callback, CancellationToken cancellationToken = default);
}

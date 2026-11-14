using System;
using System.Threading;
using System.Threading.Tasks;

namespace Cat.Sagas.Abstractions;

/// <summary>
/// Keeps the saga instances. A store must refuse an update when the instance changed since it was loaded.
/// </summary>
public interface ICatSagaStore
{
    /// <summary>
    /// Finds an instance.
    /// </summary>
    /// <param name="id">The id of the instance, which is the correlation id of its messages.</param>
    /// <param name="cancellationToken">Token to cancel the work.</param>
    /// <returns>The instance, or null when there is none.</returns>
    Task<CatSagaInstance?> FindAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Saves a new instance with <see cref="CatSagaInstance.Version"/> 1.
    /// </summary>
    /// <param name="instance">The instance to save.</param>
    /// <param name="cancellationToken">Token to cancel the work.</param>
    /// <returns>A task that completes when the instance is saved.</returns>
    Task AddAsync(CatSagaInstance instance, CancellationToken cancellationToken = default);

    /// <summary>
    /// Saves the changes of an instance and raises <see cref="CatSagaInstance.Version"/> by one.
    /// </summary>
    /// <param name="instance">The instance to save. Its version is the version it had when it was loaded.</param>
    /// <param name="cancellationToken">Token to cancel the work.</param>
    /// <returns>A task that completes when the instance is saved.</returns>
    /// <exception cref="CatSagaConcurrencyException">The saved version is not the version of <paramref name="instance"/>.</exception>
    Task UpdateAsync(CatSagaInstance instance, CancellationToken cancellationToken = default);
}

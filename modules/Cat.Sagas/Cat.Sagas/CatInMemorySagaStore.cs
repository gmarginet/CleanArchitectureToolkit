using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using Cat.Sagas.Abstractions;

namespace Cat.Sagas;

/// <summary>
/// An <see cref="ICatSagaStore"/> that keeps the instances in memory. Use it for tests and for trying a saga.
/// The instances are gone when the process stops, so it is no store for a real service. Register it as a singleton.
/// </summary>
public sealed class CatInMemorySagaStore : ICatSagaStore
{
    private readonly ConcurrentDictionary<Guid, CatSagaInstance> _instances = new ConcurrentDictionary<Guid, CatSagaInstance>();

    /// <inheritdoc />
    public Task<CatSagaInstance?> FindAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return Task.FromResult(_instances.TryGetValue(id, out var saved) ? Copy(saved) : null);
    }

    /// <inheritdoc />
    public Task AddAsync(CatSagaInstance instance, CancellationToken cancellationToken = default)
    {
        var copy = Copy(instance);
        copy.Version = 1;

        if (!_instances.TryAdd(copy.Id, copy))
        {
            throw new CatSagaConcurrencyException(instance.Id);
        }

        instance.Version = 1;
        return Task.CompletedTask;
    }

    /// <inheritdoc />
    public Task UpdateAsync(CatSagaInstance instance, CancellationToken cancellationToken = default)
    {
        while (true)
        {
            if (!_instances.TryGetValue(instance.Id, out var saved) || saved.Version != instance.Version)
            {
                throw new CatSagaConcurrencyException(instance.Id);
            }

            var copy = Copy(instance);
            copy.Version = saved.Version + 1;

            if (_instances.TryUpdate(instance.Id, copy, saved))
            {
                instance.Version = copy.Version;
                return Task.CompletedTask;
            }
        }
    }

    private static CatSagaInstance Copy(CatSagaInstance source)
    {
        return new CatSagaInstance
        {
            Id = source.Id,
            WorkflowType = source.WorkflowType,
            WorkflowVersion = source.WorkflowVersion,
            Status = source.Status,
            State = source.State,
            Checkpoint = source.Checkpoint,
            Waits = source.Waits,
            CreatedAt = source.CreatedAt,
            UpdatedAt = source.UpdatedAt,
            Version = source.Version
        };
    }
}

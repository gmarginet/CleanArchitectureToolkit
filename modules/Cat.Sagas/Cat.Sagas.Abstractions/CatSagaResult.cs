using System.Collections.Generic;
using Cat.Responses.Abstractions;
using System;

namespace Cat.Sagas.Abstractions;

/// <summary>
/// What a saga run came to: waiting for an answer, done, or failed.
/// </summary>
public class CatSagaResult
{
    /// <summary>
    /// Creates the result.
    /// </summary>
    /// <param name="instanceId">The id of the instance.</param>
    /// <param name="status">Where the instance is now.</param>
    /// <param name="errors">The errors of the run. Empty when nothing failed.</param>
    public CatSagaResult(Guid instanceId, CatSagaStatus status, IReadOnlyList<ICatError> errors)
    {
        InstanceId = instanceId;
        Status = status;
        Errors = errors;
    }

    /// <summary>
    /// The id of the instance. It is the correlation id of the messages of the saga.
    /// </summary>
    public Guid InstanceId { get; }

    /// <summary>
    /// Where the instance is now.
    /// </summary>
    public CatSagaStatus Status { get; }

    /// <summary>
    /// The errors of the run. Empty when nothing failed.
    /// </summary>
    public IReadOnlyList<ICatError> Errors { get; }
}

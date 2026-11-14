using System;

namespace Cat.Sagas.Abstractions;

/// <summary>
/// The saga that is running right now. A step reads it to know its instance. It is empty outside a saga run.
/// </summary>
public interface ICatSagaContext
{
    /// <summary>
    /// The id of the running instance. It is the correlation id for every message of the saga.
    /// </summary>
    Guid InstanceId { get; }
}

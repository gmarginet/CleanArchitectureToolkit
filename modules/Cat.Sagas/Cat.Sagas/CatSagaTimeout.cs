using System;
using Cat.Messaging.Abstractions;
using Cat.ServiceRequests.Abstractions;

namespace Cat.Sagas;

/// <summary>
/// The message that times out a wait. The wait step sends it to the own queue of the service with a scheduled time.
/// Declare it with <c>Receive</c> on the event processor of the service. The module registers its handler.
/// The bus cannot cancel a scheduled message, so it arrives even when the answer came first. The dispatcher then ignores it.
/// </summary>
public class CatSagaTimeout : CatCommandMessage, ICatServiceRequest
{
    /// <summary>
    /// The id of the wait that this message times out.
    /// </summary>
    public Guid WaitId { get; set; }

    /// <summary>
    /// The name of the wait step. It is only there to make logs readable.
    /// </summary>
    public string StepName { get; set; } = string.Empty;
}

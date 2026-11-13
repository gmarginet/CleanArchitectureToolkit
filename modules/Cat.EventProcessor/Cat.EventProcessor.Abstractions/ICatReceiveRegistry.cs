using System.Collections.Generic;

namespace Cat.EventProcessor.Abstractions;

/// <summary>
/// The message types the service receives, as declared when the event processor is registered in the API project.
/// </summary>
public interface ICatReceiveRegistry
{
    /// <summary>
    /// The declared message types with their settings.
    /// </summary>
    public IReadOnlyList<CatReceiveRegistration> Registrations { get; }
}

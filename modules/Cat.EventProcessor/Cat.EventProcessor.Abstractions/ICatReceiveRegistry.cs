using System.Collections.Generic;

namespace Cat.EventProcessor.Abstractions;

/// <summary>
/// The message types the service receives, as declared in the <c>EventProcessor</c> project.
/// </summary>
public interface ICatReceiveRegistry
{
    /// <summary>
    /// The declared message types with their settings.
    /// </summary>
    public IReadOnlyList<CatReceiveRegistration> Registrations { get; }
}

using System.Collections.Generic;
using Cat.EventProcessor.Abstractions;

namespace Cat.EventProcessor;

/// <summary>
/// Default <see cref="ICatReceiveRegistry"/>.
/// </summary>
internal sealed class ReceiveRegistry : ICatReceiveRegistry
{
    /// <summary>
    /// Creates the registry.
    /// </summary>
    /// <param name="registrations">The declared message types.</param>
    public ReceiveRegistry(IReadOnlyList<CatReceiveRegistration> registrations)
    {
        Registrations = registrations;
    }

    /// <inheritdoc />
    public IReadOnlyList<CatReceiveRegistration> Registrations { get; }
}

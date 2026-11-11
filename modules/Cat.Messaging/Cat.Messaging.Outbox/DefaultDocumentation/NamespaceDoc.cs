// Keep this class in the root namespace of the project !!!
// ReSharper disable CheckNamespace
namespace Cat.Messaging.Outbox;

// Ignore this class, it is only used by the DefaultDocumentation tool.
// The XML documentation of this class can be used for a general description of the namespace.

/// <summary>
/// The outbox pattern for messages. The sender stores a message in the same unit of work as the data,
/// and a background service sends the stored messages to the transport.
/// The storage itself is behind <see cref="Cat.Messaging.Outbox.ICatOutboxStore"/>.
/// </summary>
internal static class NamespaceDoc { }

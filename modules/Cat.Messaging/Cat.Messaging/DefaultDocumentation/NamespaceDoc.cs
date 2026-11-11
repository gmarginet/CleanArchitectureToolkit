// Keep this class in the root namespace of the project !!!
// ReSharper disable CheckNamespace
namespace Cat.Messaging;

// Ignore this class, it is only used by the DefaultDocumentation tool.
// The XML documentation of this class can be used for a general description of the namespace.

/// <summary>
/// Provides the default <see cref="Cat.Messaging.Abstractions.ICatMessageSender"/>.
/// It applies the name convention, serializes the message with System.Text.Json and hands it to the transport or the outbox.
/// </summary>
internal static class NamespaceDoc { }

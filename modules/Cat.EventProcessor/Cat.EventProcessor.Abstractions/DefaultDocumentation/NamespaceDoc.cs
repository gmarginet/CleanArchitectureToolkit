// Keep this class in the root namespace of the project !!!
// ReSharper disable CheckNamespace
namespace Cat.EventProcessor.Abstractions;

// Ignore this class, it is only used by the DefaultDocumentation tool.
// The XML documentation of this class can be used for a general description of the namespace.

/// <summary>
/// The contracts of the event processor: the incoming message, the settlement of a message, the receiver, the contract of the inbox store and the settings per message type.
/// A broker project, such as the one for Azure Service Bus, calls the receiver and settles the message with the result.
/// </summary>
internal static class NamespaceDoc { }

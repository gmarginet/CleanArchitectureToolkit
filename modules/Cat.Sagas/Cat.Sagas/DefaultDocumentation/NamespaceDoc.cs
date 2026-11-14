// Keep this class in the root namespace of the project !!!
// ReSharper disable CheckNamespace
namespace Cat.Sagas;

// Ignore this class, it is only used by the DefaultDocumentation tool.
// The XML documentation of this class can be used for a general description of the namespace.

/// <summary>
/// Runs a workflow over a long time. It saves the state at a wait step, sends the request message and goes on when the answer arrives.
/// It holds the runner, the dispatcher, the JSON serializer, an in-memory store and the registration of the module.
/// </summary>
internal static class NamespaceDoc { }

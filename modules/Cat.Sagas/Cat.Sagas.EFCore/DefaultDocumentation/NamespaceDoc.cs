// Keep this class in the root namespace of the project !!!
// ReSharper disable CheckNamespace
namespace Cat.Sagas.EFCore;

// Ignore this class, it is only used by the DefaultDocumentation tool.
// The XML documentation of this class can be used for a general description of the namespace.

/// <summary>
/// Keeps the saga instances in the database of the service. The table has a version column,
/// so two answers for the same instance at the same moment can never both win.
/// </summary>
internal static class NamespaceDoc { }
